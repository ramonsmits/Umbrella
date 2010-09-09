using nVentive.Umbrella.Containers;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Values
{
    public class ValueBinding<T> : Container
    {
        public ValueBinding(IValue<T> first, IValue<T> second)
        {
            first.Validation().NotNull("first");
            second.Validation().NotNull("second");

            Disposable.Add(first.Get.Bind(second.Set));
            Disposable.Add(second.Get.Bind(first.Set));
        }
    }
}