using csharp._Shared;
using csharp.Action;

namespace csharp.Actions
{
    public class NormalAction : ActionBase
    {
        public NormalAction()
        {
            properties = new ActionProperties { Rate = Constants.DefaultRate };
        }

        /// <summary>
        /// Once the sell by date has passed, Quality degrades twice as fast
        /// </summary>
        /// <param name="sellIn"></param>
        /// <returns>new SellIn value</returns>
        public override int UpdateState(int sellIn)
        {
            properties.Rate = Constants.DefaultRate;

            if (sellIn < 0)
                properties.Rate *= 2;

            return properties.Rate;
        }
    }
}
