using System;

namespace nVentive.Umbrella.Messages
{
    public class MessageFunc<T>
    {
        public static Func<IMessage<Null, T>, T> Response = arg => arg.Send(null);
    }
}