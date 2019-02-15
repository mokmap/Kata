using csharp._Shared;
using csharp.Action;

namespace csharp.Actions
{
    public class BackStageAction: ActionBase
    {
        public BackStageAction()
        {
            properties = new ActionProperties { Rate = Constants.noChangeRate }; //Quality will not change after concert
        }
        
        /// <summary>
        /// like aged brie, increases in Quality as its SellIn value approaches 
        /// Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        /// </summary>
        public override int UpdateState(int sellIn)
        {
            properties.Rate = Constants.DefaultRate;

            properties.Rate = Constants.noChangeRate;
            if (sellIn <= 10 && sellIn > 5)
                properties.Rate = _RateBetweenFiveAndTen;
            else if (sellIn <= 5 && sellIn > 0)
                properties.Rate = _RateBetweenZeroAndFive;
            else if (sellIn <= 0)
            {
                properties.Rate = 0;
            }
            else  // When SellIn > 1
            {
                properties.Rate = _RateAboveTen;
            }

            return properties.Rate;
        }

        public override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
                item.Quality = 0;
            else
                base.UpdateQuality(item);
        }
    }
}
