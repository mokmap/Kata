using csharp._Shared;
using csharp.Action;

namespace csharp.Actions
{
    public class SulfurasAction : ActionBase
    {
        public SulfurasAction()
        {
            properties = new ActionProperties { Rate = Constants.noChangeRate, MaxQuality = 80 };
        }

        /// <summary>
        /// items degrade in Quality twice as fast as normal items
        /// </summary>
        /// <param name="sellIn"></param>
        /// <returns></returns>
        public override int UpdateState(int sellIn)
        {
            properties.Rate = Constants.noChangeRate;

            return properties.Rate;
        }

        public override void UpdateSellIn(Item item)
        {
            // With Sulfuras SellIn never change
        }
    }
}
