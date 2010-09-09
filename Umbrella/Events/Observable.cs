using System;
using System.Collections.Generic;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Events
{
    public class Observable : IObservable
    {
        private readonly List<IMessage<EventMessage<object, EventArgs>, Null>> observers =
            new List<IMessage<EventMessage<object, EventArgs>, Null>>();

        #region IObservable Members

        public ICollection<IMessage<EventMessage<object, EventArgs>, Null>> Observers
        {
            get { return observers; }
        }

        #endregion
    }
}