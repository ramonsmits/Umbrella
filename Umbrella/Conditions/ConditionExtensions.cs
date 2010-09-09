using nVentive.Umbrella.Conditions;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Extensions
{
    public static class ConditionExtensions
    {
        public static IMessage<Null, bool> Not(this IMessage<Null, bool> message)
        {
            return new NotCondition(message);
        }

        public static IMessage<Null, bool> And(this IMessage<Null, bool> x, IMessage<Null, bool> y)
        {
            return new AndCondition(x, y);
        }

        public static IMessage<Null, bool> Or(this IMessage<Null, bool> x, IMessage<Null, bool> y)
        {
            return new OrCondition(x, y);
        }
    }
}