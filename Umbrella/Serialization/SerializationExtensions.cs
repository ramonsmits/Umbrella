using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using nVentive.Umbrella.Serialization;

#if !SILVERLIGHT
using System.Runtime.Serialization.Formatters.Binary;
#endif

namespace nVentive.Umbrella.Extensions
{
    public static class SerializationExtensions
    {
        public static SerializationExtensionPoint<T> Serialization<T>(this T value)
        {
            return new SerializationExtensionPoint<T>(value);
        }

        public static SerializationExtensionPoint<T> Serialization<T>(this Type type)
        {
            return new SerializationExtensionPoint<T>(type);
        }

        public static T DataContract<T>(this SerializationExtensionPoint<T> extensionPoint)
        {
            var serializer = new DataContractSerializer(extensionPoint.ExtendedType);

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, extensionPoint.ExtendedValue);

                stream.Position = 0;

                var newInstance = (T) serializer.ReadObject(stream);

                return newInstance;
            }
        }

 #if !SILVERLIGHT
       public static T Binary<T>(this SerializationExtensionPoint<T> extensionPoint)
        {
            var serializer = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, extensionPoint.ExtendedValue);

                stream.Position = 0;

                var newInstance = (T) serializer.Deserialize(stream);

                return newInstance;
            }
        }

        public static void Binary<T>(this SerializationExtensionPoint<T> extensionPoint, Stream output)
        {
            if (extensionPoint.ExtendedValue != null)
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(output, extensionPoint.ExtendedValue);
                output.Flush();
            }
        }

        public static T Binary<T>(this SerializationExtensionPoint<T> extensionPoint, byte[] data)
        {
            var serializer = new BinaryFormatter();
            using (var stream = new MemoryStream(data))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public static T Xml<T>(this SerializationExtensionPoint<T> extensionPoint)
        {
            using (var stream = new MemoryStream())
            {
                Xml(extensionPoint, stream, extensionPoint.ExtendedValue);

                stream.Position = 0;

                return Xml(extensionPoint, stream);
            }
        }

        public static T Xml<T>(this SerializationExtensionPoint<T> extensionPoint, string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return Xml(extensionPoint, stream);
            }
        }

        public static void Xml<T>(this SerializationExtensionPoint<T> extensionPoint, string path, T value)
        {
            using (var stream = File.OpenWrite(path))
            {
                Xml(extensionPoint, stream, value);
            }
        }

        public static T Xml<T>(this SerializationExtensionPoint<T> extensionPoint, Stream stream)
        {
            var serializer = new XmlSerializer(extensionPoint.ExtendedType);

            return (T) serializer.Deserialize(stream);
        }

        public static void Xml<T>(this SerializationExtensionPoint<T> extensionPoint, Stream stream, T value)
        {
            var serializer = new XmlSerializer(extensionPoint.ExtendedType);

            serializer.Serialize(stream, value);
        }
#endif
    }
}