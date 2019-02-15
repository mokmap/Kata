using csharp._Shared;
using csharp.Action;
using csharp.Interfaces;

namespace csharp.Actions
{
    /// <summary>
    /// Derived of Action design pattern.
    /// </summary>
    public abstract class ActionBase: IItemAction
    {
        #region Fields

        public const int _RateBetweenZeroAndFive = -3;
        public static int _RateBetweenFiveAndTen = -2;
        public static int _RateAboveTen = -1;

        #endregion

        protected ActionProperties properties;

        /// <summary>
        /// Update Quality & SellIn values.
        /// </summary>
        /// <param name="item"></param>
        public void Update(Item item)
        {
            UpdateQuality(item);
            UpdateSellIn(item);
        }

        /// <summary>
        /// Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but 
        /// Quality drops to 0 after the concert
        /// </summary>
        public abstract int UpdateState(int sellIn);

        /// <summary>
        /// Calculates new quality considering current state and constraints
        /// </summary>
        public virtual void UpdateQuality(Item item)
        {
            UpdateState(item.SellIn);
            int newQuality = item.Quality - properties.unitChange;
            newQuality = Constraints.ApplyConstraints(newQuality, properties.MinQuality, properties.MaxQuality);
            item.Quality = newQuality;
        }

        /// <summary>
        /// Calulate the new SellInValue according to the SellinunitChange
        /// </summary>
        /// <returns></returns>
        public virtual void UpdateSellIn(Item item)
        {
            item.SellIn -= properties.SellInunitChange;
        }
    }
}
