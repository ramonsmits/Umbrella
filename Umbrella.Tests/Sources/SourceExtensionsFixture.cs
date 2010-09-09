using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Tests.Sources
{
    public class SourceExtensionsFixture
    {
        [Fact]
        public void Adapt()
        {
            Assert.NotNull(new Source<int>().Adapt<int, string>());
        }

        [Fact]
        public void ToNullable()
        {
            ISource<int> source = new Source<int>(1);

            ISource<int?> nullableSource = source.Adapt();

            Assert.True(nullableSource.Value.HasValue);

            nullableSource.Value = null;

            Assert.Equal(0, source.Value);

            //TODO Assert.Null(nullableSource.Value);
        }

        [Fact]
        public void FromNullable()
        {
            ISource<int?> nullableSource = new Source<int?>();

            ISource<int> source = nullableSource.Adapt();

            Assert.Equal(0, source.Value);

            source.Value = 1;

            Assert.True(nullableSource.Value.HasValue);
            Assert.Equal(1, nullableSource.Value.Value);
        }

        [Fact]
        public void ToGetMessage()
        {
            IMessage<Null, int> message = new Source<int>(1).ToGetMessage();

            Assert.Equal(1, message.Send());
        }

        [Fact]
        public void ToSetMessage()
        {
            ISource<int> source = new Source<int>();

            IMessage<int, Null> message = source.ToSetMessage();

            message.Send(1);

            Assert.Equal(1, source.Value);
        }

        [Fact]
        public void AsReadOnly()
        {
            ISource<int> source = new Source<int>(1);

            ISource<int> readOnlySource = source.AsReadOnly();

            Assert.Throws<ReadOnlyException>(() => readOnlySource.Value = 2);

            Assert.Equal(1, source.Value);
        }
    }
}
