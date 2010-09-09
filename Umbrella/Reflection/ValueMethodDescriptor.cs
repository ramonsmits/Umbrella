using System;
using System.Reflection;

namespace nVentive.Umbrella.Reflection
{
    public class ValueMethodDescriptor : MethodDescriptor, IValueMemberDescriptor
    {
        public ValueMethodDescriptor(MethodInfo methodInfo)
            : base(methodInfo)
        {
            if (!IsValid(methodInfo))
            {
                throw new ArgumentException("Not supported", "methodInfo");
            }
        }

        #region IValueMemberDescriptor Members

        public override Type Type
        {
            get
            {
                var parameters = MemberInfo.GetParameters();

                return parameters.Length == 0 ? MemberInfo.ReturnType : parameters[0].ParameterType;
            }
        }

        public object GetValue(object instance)
        {
            if (MemberInfo.GetParameters().Length != 0)
            {
                throw new InvalidOperationException("Cannot Get Value for Set Method");
            }
            return Invoke(instance, null);
        }

        public void SetValue(object instance, object value)
        {
            if (MemberInfo.GetParameters().Length == 0)
            {
                throw new InvalidOperationException("Cannot Set Value for Get Method");
            }
            Invoke(instance, value);
        }

        #endregion

        public static bool IsValid(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();

            switch (parameters.Length)
            {
                case 0:
                    if (methodInfo.ReturnType == typeof (void))
                    {
                        return false;
                    }
                    break;
                case 1:
                    if (methodInfo.ReturnType != typeof (void))
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }

        #region IValueMemberDescriptor Members


        public Action<object, object> ToCompiledSetValue()
        {
            return SetValue;
        }

        public Action<object, object> ToCompiledSetValue(bool strict)
        {
            return SetValue;
        }

        public Func<object, object> ToCompiledGetValue()
        {
            return GetValue;
        }

        public Func<object, object> ToCompiledGetValue(bool strict)
        {
            return GetValue;
        }

        #endregion
    }
}