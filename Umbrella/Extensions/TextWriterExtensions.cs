using System.IO;

namespace nVentive.Umbrella.Extensions
{
    public static class TextWriterExtensions
    {
        public static void Write(this TextWriter writer, string format, params object[] args)
        {
            writer.Write(string.Format(format, args));
        }

        public static void WriteLine(this TextWriter writer, string format, params object[] args)
        {
            writer.Write(string.Format(format, args));
        }
    }
}