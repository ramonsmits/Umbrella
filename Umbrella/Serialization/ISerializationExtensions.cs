using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace nVentive.Umbrella.Serialization
{
    public interface ISerializationExtensions
    {
        SerializationExtensionPoint<T> Serialization<T>(T value);
        SerializationExtensionPoint<T> Serialization<T>(Type type);
        
        T DataContract<T>(SerializationExtensionPoint<T> extensionPoint);
        //TODo Complete DataContract, Binary
        T Binary<T>(SerializationExtensionPoint<T> extensionPoint);

        T Xml<T>(SerializationExtensionPoint<T> extensionPoint);
        T Xml<T>(SerializationExtensionPoint<T> extensionPoint, string path);
        void Xml<T>(SerializationExtensionPoint<T> extensionPoint, string path, T value);
        T Xml<T>(SerializationExtensionPoint<T> extensionPoint, Stream stream);
        void Xml<T>(SerializationExtensionPoint<T> extensionPoint, Stream stream, T value);
    }
}
