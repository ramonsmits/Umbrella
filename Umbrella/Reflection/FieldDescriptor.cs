﻿using System;
using System.Reflection;
using System.Linq;
using nVentive.Umbrella.Extensions;

#if !SILVERLIGHT
using System.Reflection.Emit;
#endif

namespace nVentive.Umbrella.Reflection
{
    public class FieldDescriptor : ValueMemberDescriptor<FieldInfo>
    {
        public FieldDescriptor(FieldInfo fi)
            : base(fi)
        {
        }

        public override Type Type
        {
            get { return MemberInfo.FieldType; }
        }

        public override bool IsStatic
        {
            get { return MemberInfo.IsStatic; }
        }

        public override object GetValue(object instance)
        {
            return MemberInfo.GetValue(instance);
        }

        public override void SetValue(object instance, object value)
        {
            MemberInfo.SetValue(instance, value);
        }

#if !SILVERLIGHT
        /// <summary>
        /// Creates a compiled method that will allow a the assignation of the specified field.
        /// </summary>
        /// <param name="fieldInfo">The field to assign</param>
        /// <returns>A delegate taking an instance as the first parameter, and the value as the second parameter.</returns>
        public override Action<object, object> ToCompiledSetValue()
        {
            return ToCompiledSetValue(MemberInfo.DeclaringType.TypeHandle, MemberInfo.FieldHandle, true);
        }

        /// <summary>
        /// Creates a compiled method that will allow a the assignation of the specified field.
        /// </summary>
        /// <param name="fieldInfo">The field to assign</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate taking an instance as the first parameter, and the value as the second parameter.</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. Invalid parameters could result in unexpected behavior.
        /// </remarks>
        public override Action<object, object> ToCompiledSetValue(bool strict)
        {
            return ToCompiledSetValue(MemberInfo.DeclaringType.TypeHandle, MemberInfo.FieldHandle, strict);
        }

        /// <summary>
        /// Creates a compiled method that will allow a the assignation of the specified field.
        /// </summary>
        /// <param name="typeHandle">The declaring type for the specified RuntimeFieldHandle</param>
        /// <param name="fieldHandle">The field in the specified RuntimeTypeHandle</param>
        /// <param name="strict">Removes some type checking to enhance performance.</param>
        /// <returns>A delegate taking an instance as the first parameter, and the value as the second parameter.</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. Invalid parameters could result in unexpected behavior.
        /// </remarks>
        public static Action<object, object> ToCompiledSetValue(RuntimeTypeHandle typeHandle, RuntimeFieldHandle fieldHandle, bool strict)
        {
            var fieldInfo = FieldInfo.GetFieldFromHandle(fieldHandle, typeHandle);

            if (fieldInfo.IsStatic || fieldInfo.DeclaringType.IsValueType)
            {
                // Don't compile code for static fields
                return fieldInfo.SetValue;
            }

            var name = "Set_{0}.{1}-{2}".InvariantCultureFormat(fieldInfo.DeclaringType.Name, fieldInfo.Name, Guid.NewGuid());

            DynamicMethod method = new DynamicMethod(name, typeof(void), new[] { typeof(object), typeof(object) }, typeof(FieldDescriptor), true);

            var il = method.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);

            if (strict)
            {
                il.Emit(OpCodes.Castclass, fieldInfo.DeclaringType);
            }

            il.Emit(OpCodes.Ldarg_1);

            if (fieldInfo.FieldType.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, fieldInfo.FieldType);
            }
            else
            {
                if (strict)
                {
                    il.Emit(OpCodes.Castclass, fieldInfo.FieldType);
                }
            }

            il.Emit(OpCodes.Stfld, fieldInfo);
            il.Emit(OpCodes.Ret);

            return method.CreateDelegate(typeof(Action<object, object>)) as Action<object, object>;
        }

        /// <summary>
        /// Creates a compiled method that will get the value of a field 
        /// </summary>
        /// <param name="fieldInfo">The field to get the value from.</param>
        /// <returns></returns>
        public override Func<object, object> ToCompiledGetValue()
        {
            return ToCompiledGetValue(MemberInfo.DeclaringType.TypeHandle, MemberInfo.FieldHandle, true);
        }

        /// <summary>
        /// Creates a compiled method that will get the value of a field.
        /// </summary>
        /// <param name="fieldInfo">The field to get the value from.</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate taking an instance as the first parameter, and returns the value of the field.</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. An invalid parameter could result in unexpected behavior.
        /// </remarks>
        public override Func<object, object> ToCompiledGetValue(bool strict)
        {
            return ToCompiledGetValue(MemberInfo.DeclaringType.TypeHandle, MemberInfo.FieldHandle, strict);
        }

        /// <summary>
        /// Creates a compiled method that will get the value of a field.
        /// </summary>
        /// <param name="typeHandle">The declaring type for the specified RuntimeFieldHandle</param>
        /// <param name="fieldHandle">The field in the specified RuntimeTypeHandle</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns></returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. An invalid parameter could result in unexpected behavior.
        /// </remarks>
        public static Func<object, object> ToCompiledGetValue(RuntimeTypeHandle typeHandle, RuntimeFieldHandle fieldHandle, bool strict)
        {
            var fieldInfo = FieldInfo.GetFieldFromHandle(fieldHandle, typeHandle);

            if (fieldInfo.IsStatic || fieldInfo.DeclaringType.IsValueType)
            {
                // Don't compile code for static fields or fields from value types
                return fieldInfo.GetValue;
            }

            var name = "Get_{0}.{1}-{2}".InvariantCultureFormat(fieldInfo.DeclaringType.Name, fieldInfo.Name, Guid.NewGuid());

            var method = new DynamicMethod(name, typeof(object), new[] { typeof(object) }, typeof(FieldDescriptor), true);

            var il = method.GetILGenerator();

            il.DeclareLocal(typeof(object));

            il.Emit(OpCodes.Ldarg_0);

            if (strict)
            {
                il.Emit(OpCodes.Castclass, fieldInfo.DeclaringType);
            }

            il.Emit(OpCodes.Ldfld, fieldInfo);

            if (fieldInfo.FieldType.IsValueType)
            {
                il.Emit(OpCodes.Box, fieldInfo.FieldType);
            }

            il.Emit(OpCodes.Ret);

            return method.CreateDelegate(typeof(Func<object, object>)) as Func<object, object>;
        }
#endif
    }
}