using System.Collections.Generic;

namespace nVentive.Umbrella.Sources
{
    public class EnumerableSource<T> : SourceDecorator<IEnumerable<T>>
    {
        public EnumerableSource(ISource<IEnumerable<T>> target)
            : base(target)
        {
        }

        public override IEnumerable<T> Value
        {
            get
            {
                foreach (var item in Target.Value)
                {
                    yield return item;
                }
            }
            set { base.Value = value; }
        }
    }
}