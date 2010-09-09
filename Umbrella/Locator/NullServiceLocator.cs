using System;

namespace nVentive.Umbrella.Locator
{
    public class NullServiceLocator : IServiceLocator
    {
        public static readonly IServiceLocator Instance = new NullServiceLocator();

        private NullServiceLocator()
        {
        }

        #region IServiceLocator Members

        public bool CanResolve(Type type, string name)
        {
            return false;
        }

        public object Resolve(Type type, string name)
        {
            throw new InvalidOperationException();
        }

        #endregion
    }
}