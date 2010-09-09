using System;
using System.ComponentModel;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Reflection;
using nVentive.Umbrella.Sources;
using Container=nVentive.Umbrella.Containers.Container;

namespace nVentive.Umbrella.Values
{
    public class ReflectionValue<T> : Container, IValue<T>
    {
        private readonly IEventDescriptor memberChanged;
        private readonly ReflectionSource<T> source;

        public ReflectionValue(string memberName)
            : this((object) null, memberName)
        {
        }

        public ReflectionValue(string memberName, string eventMemberName)
            : this(null, memberName, eventMemberName)
        {
        }

        public ReflectionValue(object instance, string memberName)
            : this(instance, memberName, memberName + "Changed")
        {
        }

        public ReflectionValue(object instance, string memberName, string eventMemberName)
            : this(instance, memberName, memberName, eventMemberName)
        {
        }

        public ReflectionValue(object instance, string getMemberName, string setMemberName, string eventMemberName)
        {
            source = new ReflectionSource<T>(instance, getMemberName, setMemberName);

            memberChanged = (IEventDescriptor) instance.Reflection().FindDescriptor(eventMemberName);

            if (memberChanged == null)
            {
                var propertyChanged = instance as INotifyPropertyChanged;

                if (propertyChanged == null)
                {
                    throw new ArgumentException("Not Supported");
                }
                
                Disposable.Add(propertyChanged.Observe(OnPropertyChanged));
            }
            else
            {
                Disposable.Add(memberChanged.Observe(instance, this, "OnMemberChanged"));
            }
        }

        #region IValue<T> Members

        public IMessage<Null, T> Get
        {
            get { return Sources.Get<IMessage<Null, T>>("Get", CreateGet); }
        }

        public IMessage<T, Null> Set
        {
            get { return Sources.Get<IMessage<T, Null>>("Set", CreateSet); }
        }

        #endregion

        private IMessage<Null, T> CreateGet()
        {
            Func<T> func = () => source.Value;

            return func.ToMessage().ToObservable();
        }

        private IMessage<T, Null> CreateSet()
        {
            Action<T> action = value => source.Value = value;

            return action.ToMessage();
        }

        // This method is marked internal because of silverlight reflection restrictions.
        internal void OnMemberChanged(object sender, EventArgs args)
        {
            ((IObservable)Get).Raise(this, args);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (source.SetMemberName == e.PropertyName)
            {
                ((IObservable) Get).Raise(this, e);
            }
        }
    }
}