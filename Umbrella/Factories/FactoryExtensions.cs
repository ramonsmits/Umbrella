using System;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Factories;

namespace nVentive.Umbrella.Extensions
{
    public static class FactoryExtensions
    {
        public static object Wrap(this IFactory factory, Type type, object existing)
        {
            return Create(factory, type, new WrapContract(existing));
        }

        public static object Create(this IFactory factory, Type type)
        {
            return Create(factory, type, (IContract) null);
        }

        public static object Create(this IFactory factory, Type type, object[] args)
        {
            return Create(factory, type, args, null);
        }

        public static object Create(this IFactory factory, Type type, object[] args, IContract contract)
        {
            contract = contract.Add(new TypeContract(type));

            if (args != null &&
                args.Length > 0)
            {
                contract = contract.Add(new ArgumentsContract(args));
            }

            return factory.Create(contract);
        }

        public static object Create(this IFactory factory, Type type, IContract contract)
        {
            return Create(factory, type, null, contract);
        }

        public static T Create<T>(this IFactory factory, Type type)
        {
            return Create<T>(factory, type, (IContract) null);
        }

        public static T Create<T>(this IFactory factory, Type type, object[] args)
        {
            return Create<T>(factory, type, args, null);
        }

        public static T Create<T>(this IFactory factory, Type type, object[] args, IContract contract)
        {
            return (T) Create(factory, type, args, contract);
        }

        public static T Create<T>(this IFactory factory, Type type, IContract contract)
        {
            return Create<T>(factory, type, null, contract);
        }

        public static T Wrap<T>(this IFactory factory, T existing)
        {
            return (T) Wrap(factory, typeof (T), existing);
        }

        public static T Create<T>(this IFactory factory)
        {
            return Create<T>(factory, (object[]) null, null);
        }

        public static T Create<T>(this IFactory factory, object[] args)
        {
            return Create<T>(factory, args, null);
        }

        public static T Create<T>(this IFactory factory, object[] args, IContract contract)
        {
            return (T) Create(factory, typeof (T), args, contract);
        }

        public static T Create<T>(this IFactory factory, IContract contract)
        {
            return Create<T>(factory, (object[]) null, contract);
        }
    }
}