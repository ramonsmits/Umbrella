//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using Nventive.Framework.Containers;

//namespace Nventive.Framework.Threading
//{
//    public class ReaderWriter : Container, ISynchronizable
//    {
//        private readonly ReaderWriterLock readerWriterLock;

//        private IReaderWriterLockExtensions extensions;

//        public ReaderWriter()
//            : this(new ReaderWriterLock(), new DefaultReaderWriterLockExtensions())
//        {
//        }

//        public ReaderWriter(ReaderWriterLock readerWriterLock)
//            : this(readerWriterLock, new DefaultReaderWriterLockExtensions())
//        {
//        }

//        public ReaderWriter(IReaderWriterLockExtensions extensions)
//            : this(new ReaderWriterLock(), extensions)
//        {
//        }

//        public ReaderWriter(ReaderWriterLock readerWriterLock, IReaderWriterLockExtensions extensions)
//        {
//            this.readerWriterLock = readerWriterLock;
//            this.extensions = extensions;
//        }

//        public virtual T Read<T>(Func<T> func)
//        {
//            return extensions.Read<T>(readerWriterLock, func);
//        }

//        public virtual T Read<T>(int millisecondsTimeout, Func<T> func)
//        {
//            return extensions.Read<T>(readerWriterLock, millisecondsTimeout, func);
//        }

//        //TODO Move to Extensions Overload
//        public virtual bool Read(Func<bool> read)
//        {
//            if (read())
//            {
//                return true;
//            }
//            else
//            {
//                return Read(read);
//            }
//        }

//        public virtual bool Write(Func<bool> read, Action write)
//        {
//            return extensions.Write(readerWriterLock, read, write);
//        }

//        public virtual bool Write(int millisecondsTimeout, Func<bool> read, Action write)
//        {
//            return extensions.Write(readerWriterLock, millisecondsTimeout, read, write);
//        }

//        //TODO Move to Extensions
//        public virtual void Write(Action write)
//        {
//            extensions.Write(readerWriterLock, () => false, write);
//        }

//        public virtual T Write<T>(Func<T> write)
//        {
//            T value = default(T);

//            extensions.Write(readerWriterLock, () => false, () => value = write());

//            return value;
//        }

//        #region ISynchronizable Members

//        public virtual ReaderWriterLock Lock
//        {
//            get { return readerWriterLock; }
//        }

//        #endregion
//    }
//}
