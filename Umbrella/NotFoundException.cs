using System;
using System.Runtime.Serialization;

namespace nVentive.Umbrella
{
    /// <summary>
    /// A NotFoundException is thrown when demanding something that doesn't exist be found.
    /// </summary>
    [Serializable]
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// See Exception Pattern.
        /// </summary>
        public NotFoundException()
        {
        }

        /// <summary>
        /// See Exception Pattern.
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message)
            : base(message)
        {
        }

 #if !SILVERLIGHT
       /// <summary>
        /// See Exception Pattern.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        /// <summary>
        /// See Exception Pattern.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}