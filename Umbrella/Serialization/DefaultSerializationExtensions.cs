using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace nVentive.Umbrella.Serialization
{
    public class DefaultSerializationExtensions : ISerializationExtensions
    {
        #region ISerializationExtensions Members

        public virtual SerializationExtensionPoint<T> Serialization<T>(T value)
        {
        }

        public virtual SerializationExtensionPoint<T> Serialization<T>(Type type)
        {
        }

        public virtual T DataContract<T>(SerializationExtensionPoint<T> extensionPoint)
        {
        }

        public virtual T Binary<T>(SerializationExtensionPoint<T> extensionPoint)
        {
        }

        public virtual T Xml<T>(SerializationExtensionPoint<T> extensionPoint)
        {
        }

        public virtual T Xml<T>(SerializationExtensionPoint<T> extensionPoint, string path)
        {
        }

        public virtual void Xml<T>(SerializationExtensionPoint<T> extensionPoint, string path, T value)
        {
        }

        public virtual T Xml<T>(SerializationExtensionPoint<T> extensionPoint, System.IO.Stream stream)
        {
        }

        public virtual void Xml<T>(SerializationExtensionPoint<T> extensionPoint, System.IO.Stream stream, T value)
        {
            XmlSerializer serializer = new XmlSerializer(extensionPoint.ExtendedType);

            return (T)serializer.Deserialize(stream);
        }

        #endregion
    }
}
