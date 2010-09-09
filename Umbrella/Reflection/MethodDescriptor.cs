using System;
using System.Reflection;
using System.Linq;
using nVentive.Umbrella.Extensions;

#if !SILVERLIGHT
using System.Reflection.Emit;
#endif

namespace nVentive.Umbrella.Reflection
{
    public class MethodDescriptor : MemberDescriptor<MethodInfo>, IMethodDescriptor
    {
        public MethodDescriptor(MethodInfo mi)
            : base(mi)
        {
        }

        #region IMethodDescriptor Members

        public override Type Type
        {
            get { throw new NotSupportedException(); }
        }

        public override bool IsStatic
        {
            get { return MemberInfo.IsStatic; }
        }

        public override bool IsGeneric
        {
            get { return MemberInfo.IsGenericMethod; }
        }

        public override bool IsOpen
        {
            get { return MemberInfo.IsGenericMethodDefinition; }
        }

        public override IMemberDescriptor Open()
        {
            return IsClosed ? new MethodDescriptor(MemberInfo.GetGenericMethodDefinition()) : base.Open();
        }

        // TODO: params are ignored
        public override IMemberDescriptor Close(params Type[] types)
        {
            if (!IsOpen)
            {
                return base.Close(types);
            }
            var closedMethodInfo = MemberInfo.MakeGenericMethod(types);

            return new MethodDescriptor(closedMethodInfo);
        }

        public object Invoke(object instance, params object[] args)
        {
            return MemberInfo.Invoke(instance, args);
        }

        #endregion

#if !SILVERLIGHT
        /// <summary>
        /// Build a compiled method that will call the specified method.
        /// </summary>
        /// <param name="MethodInfo">The method to invoke</param>
        /// <returns>A delegate that will call the requested method</returns>
        public Func<object, object[], object> ToCompiledMethodInvoke()
        {
            return ToCompiledMethodInvoke(MemberInfo.DeclaringType.TypeHandle, MemberInfo.MethodHandle, true);
        }

        /// <summary>
        /// Build a compiled method that will call the specified method.
        /// </summary>
        /// <param name="MethodInfo">The method to invoke</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate that will call the requested method</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. An invalid parameter could result in unexpected behavior.
        /// </remarks>
        public Func<object, object[], object> ToCompiledMethodInvoke(bool strict)
        {
            return ToCompiledMethodInvoke(MemberInfo.DeclaringType.TypeHandle, MemberInfo.MethodHandle, true);
        }

        /// <summary>
        /// Build a compiled method that will call the specified method.
        /// </summary>
        /// <param name="typeHandle">The type handle containing the specified method handle</param>
        /// <param name="methodHandle">The method handle to be processed</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate that will call the requested method</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. An invalid parameter could result in unexpected behavior.
        /// </remarks>
        public static Func<object, object[], object> ToCompiledMethodInvoke(RuntimeTypeHandle typeHandle, RuntimeMethodHandle methodHandle, bool strict)
        {
            var methodBase = MethodInfo.GetMethodFromHandle(methodHandle, typeHandle) as MethodInfo;

            //
            // Return the standard invocation when Out or Ref parameters are present, and when the method is declared on a valuetype.
            //
            if (methodBase.GetParameters().Any(p => p.IsOut || p.ParameterType.IsByRef)
                || methodBase.DeclaringType.IsValueType)
            {
                return methodBase.Invoke;
            }

            var name = "Invoker_{0}.{1}-{2}".InvariantCultureFormat(methodBase.DeclaringType.Name, methodBase.Name, Guid.NewGuid());

            DynamicMethod outputMethod = new DynamicMethod(name, typeof(object), new[] { typeof(object), typeof(object[]) }, typeof(MethodDescriptor), true);

            var il = outputMethod.GetILGenerator();

            if (!methodBase.IsStatic)
            {
                il.Emit(OpCodes.Ldarg_0);

                if (strict)
                {
                    il.Emit(OpCodes.Isinst, methodBase.DeclaringType);
                }
            }

            methodBase.GetParameters().ForEach(
                (index, parameterInfo) =>
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldc_I4, index);
                    il.Emit(OpCodes.Ldelem_Ref);

                    if (parameterInfo.ParameterType.IsValueType)
                    {
                        il.Emit(OpCodes.Unbox_Any, parameterInfo.ParameterType);
                    }
                    else
                    {
                        if (strict)
                        {
                            il.Emit(OpCodes.Castclass, parameterInfo.ParameterType);
                        }
                    }
                }
            );

            var callType = methodBase.IsStatic || !methodBase.IsVirtual ? OpCodes.Call : OpCodes.Callvirt;
            il.EmitCall(callType, methodBase, null);

            if (methodBase.ReturnType == typeof(void))
            {
                il.Emit(OpCodes.Ldnull);
            }
            else
            {
                if (methodBase.ReturnType.IsValueType)
                {
                    il.Emit(OpCodes.Box, methodBase.ReturnType);
                }
            }

            il.Emit(OpCodes.Ret);

            return outputMethod.CreateDelegate(typeof(Func<object, object[], object>)) as Func<object, object[], object>;
        }
#endif
    }
}