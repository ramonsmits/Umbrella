using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.Linq.Expressions;

namespace nVentive.Umbrella.Tests.Expressions
{
    public class ExpressionExtensionsFixture
    {
        [Fact]
        public void And_Null()
        {
            Expression<Func<bool>> nullFunc = null;

            Expression<Func<bool>> func = () => true;

            Assert.Same(func, nullFunc.And(func));
            Assert.Same(func, func.And(nullFunc));
        }

        [Fact]
        public void Or_Null()
        {
            Expression<Func<bool>> nullFunc = null;

            Expression<Func<bool>> func = () => true;

            Assert.Same(func, nullFunc.Or(func));
            Assert.Same(func, func.Or(nullFunc));
        }

        [Fact]
        public void And_True()
        {
            Expression<Func<bool>> trueFunc = () => true;
            Expression<Func<bool>> otherTrueFunc = () => true;

            var result = trueFunc.And(otherTrueFunc);

            Assert.True(result.Compile().Invoke());
        }

        [Fact]
        public void And_False()
        {
            Expression<Func<bool>> trueFunc = () => true;
            Expression<Func<bool>> falseFunc = () => false;

            var result = trueFunc.And(falseFunc);

            Assert.False(result.Compile().Invoke());
        }

        [Fact]
        public void Or_True()
        {
            Expression<Func<bool>> trueFunc = () => true;
            Expression<Func<bool>> falseFunc = () => false;

            var result = trueFunc.Or(falseFunc);

            Assert.True(result.Compile().Invoke());
        }

        [Fact]
        public void Or_False()
        {
            Expression<Func<bool>> falseFunc = () => false;
            Expression<Func<bool>> otherFalseFunc = () => false;

            var result = falseFunc.Or(otherFalseFunc);

            Assert.False(result.Compile().Invoke());
        }

        [Fact]
        public void Not_True()
        {
            Expression<Func<bool>> trueFunc = () => true;

            var result = trueFunc.Not();

            Assert.False(result.Compile().Invoke());
        }

        [Fact]
        public void Not_False()
        {
            Expression<Func<bool>> falseFunc = () => false;

            var result = falseFunc.Not();

            Assert.True(result.Compile().Invoke());
        }

#if !SILVERLIGHT
        [Fact]
        public void And_True_Instance()
        {
            Expression<Func<Foo, bool>> trueFunc = foo => foo.True;
            Expression<Func<Foo, bool>> otherTrueFunc = foo => foo.True;

            var result = trueFunc.And(otherTrueFunc);

            Assert.True(result.Compile().Invoke(new Foo()));
        }

        [Fact]
        public void And_False_Instance()
        {
            Expression<Func<Foo, bool>> trueFunc = foo => foo.True;
            Expression<Func<Foo, bool>> falseFunc = foo => foo.False;

            var result = trueFunc.And(falseFunc);

            Assert.False(result.Compile().Invoke(new Foo()));
        }

        [Fact]
        public void Or_True_Instance()
        {
            Expression<Func<Foo, bool>> trueFunc = foo => foo.True;
            Expression<Func<Foo, bool>> falseFunc = foo => foo.False;

            var result = trueFunc.Or(falseFunc);

            Assert.True(result.Compile().Invoke(new Foo()));
        }

        [Fact]
        public void Or_False_Instance()
        {
            Expression<Func<Foo, bool>> falseFunc = foo => foo.False;
            Expression<Func<Foo, bool>> otherFalseFunc = foo => foo.False;

            var result = falseFunc.Or(otherFalseFunc);

            Assert.False(result.Compile().Invoke(new Foo()));
        }

        [Fact]
        public void Not_True_Instance()
        {
            Expression<Func<Foo, bool>> trueFunc = foo => foo.True;

            var result = trueFunc.Not();

            Assert.False(result.Compile().Invoke(new Foo()));
        }

        [Fact]
        public void Not_False_Instance()
        {
            Expression<Func<Foo, bool>> falseFunc = foo => foo.False;

            var result = falseFunc.Not();

            Assert.True(result.Compile().Invoke(new Foo()));
        }
#endif

        private class Foo
        {
            public bool True
            {
                get { return true; }
            }

            public bool False
            {
                get { return false; }
            }
        }
    }
}
