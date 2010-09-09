using System;

namespace nVentive.Umbrella.Reflection
{
    public class TypeDescriptor : MemberDescriptor<Type>
    {
        public TypeDescriptor(Type type)
            : base(type)
        {
        }

        public override Type Type
        {
            get { return MemberInfo; }
        }

        public override bool IsStatic
        {
            get { return MemberInfo.IsAbstract && MemberInfo.IsSealed; }
        }

        public override bool IsGeneric
        {
            get { return MemberInfo.IsGenericType; }
        }

        public override bool IsOpen
        {
            get { return MemberInfo.IsGenericTypeDefinition; }
        }

        public override IMemberDescriptor Open()
        {
            return IsClosed ? new TypeDescriptor(MemberInfo.GetGenericTypeDefinition()) : base.Open();
        }

        // TODO: params are ignored
        public override IMemberDescriptor Close(params Type[] types)
        {
            if (!IsOpen)
            {
                return base.Close(types);
            }
            
            var closedType = MemberInfo.MakeGenericType(types);

            return new TypeDescriptor(closedType);
        }
    }
}