using System;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Sources
{
    public class MessageSource<T> : ISource<T>
    {
        private readonly IMessage<Null, T> get;
        private readonly IMessage<T, Null> set;

        public MessageSource(Func<T> get, Action<T> set)
            : this(get.ToMessage(), set.ToMessage())
        {
        }

        public MessageSource(IMessage<Null, T> get, IMessage<T, Null> set)
        {
            this.get = get.Validation().NotNull("get");
            this.set = set.Validation().NotNull("set");
        }

        #region ISource<T> Members

        public T Value
        {
            get { return get.Send(); }
            set { set.Send(value); }
        }

        #endregion
    }
}