using System;
using System.Runtime.Serialization;

namespace nVentive.Umbrella
{
    /// <summary>
    /// A ReadOnlyException is thrown when accessing a logically readonly
    /// accessor when it is presents a readwrite interface.
    /// </summary>
    [Serializable]
    public class ReadOnlyException : ApplicationException
    {
        /// <summary>
        /// See Exception Pattern.
        /// </summary>
        public ReadOnlyException()
        {
        }

        /// <summary>
        /// See Exception Pattern.
        /// </summary>
        /// <param name="message"></param>
        public ReadOnlyException(string message)
            : base(message)
        {
        }

#if !SILVERLIGHT
       /// <summary>
        /// See Exception Pattern.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ReadOnlyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        /// <summary>
        /// See Exception Pattern.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ReadOnlyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}