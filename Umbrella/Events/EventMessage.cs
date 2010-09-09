using System;

namespace nVentive.Umbrella.Events
{
    public class EventMessage<TSender, TEventArgs>
        where TEventArgs : EventArgs
    {
        public EventMessage()
        {
        }

        public EventMessage(TSender sender, TEventArgs args)
        {
            Sender = sender;
            Args = args;
        }

        public TSender Sender { get; set; }

        public TEventArgs Args { get; set; }
    }
}