using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public static class StringBuilderExtensions
    {
        public static void Append(this StringBuilder builder, string format, params object[] args)
        {
            builder.Append(string.Format(format, args));
        }

        public static void AppendLine(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendLine(string.Format(format, args));
        }
    }
}