using System;
using System.Collections.Generic;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Events
{
    public interface IObservable
    {
        ICollection<IMessage<EventMessage<object, EventArgs>, Null>> Observers { get; }
    }
}