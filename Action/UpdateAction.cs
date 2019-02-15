using csharp._Shared;
using csharp.Interfaces;

namespace csharp.Actions
{
    /// <summary>
    /// Derived of Factory pattern, and command Design pattern.
    /// </summary>
    public static class UpdateAction
    {
        #region Fields
        private const string backstageName = "Backstage passes to a TAFKAL80ETC concert";
        private const string sulfurasName = "Sulfuras, Hand of Ragnaros";
        private const string agedBrieName = "Aged Brie";
        private const string conjuredName = "Conjured Mana Cake";
        #endregion
        
        public static void DailyUpdate(this Item item)
        {
            var _action = GetItemAction(item);
            _action.Update(item);
        }

        /// <summary>
        /// Define the time of the Item
        /// </summary>
        /// <param name="item"></param>
        private static CategoryEnum DefineCategory(Item item)
        {
            var categoryEnum = CategoryEnum.Normal;
            switch (item.Name)
            {
                case backstageName:
                    categoryEnum = CategoryEnum.Backstage;
                    break;
                case sulfurasName:
                    categoryEnum = CategoryEnum.Sulfuras;
                    break;
                case agedBrieName:
                    categoryEnum = CategoryEnum.AgedBrie;
                    break;
                case conjuredName:
                    categoryEnum = CategoryEnum.Conjured;
                    break;
            }
            return categoryEnum;
        }

        private static IItemAction GetItemAction(Item item)
        {
            switch (DefineCategory(item))
            {
                case CategoryEnum.Normal:
                    return new NormalAction();
                case CategoryEnum.Backstage:
                    return new BackStageAction();
                case CategoryEnum.Sulfuras:
                    return new SulfurasAction();
                case CategoryEnum.AgedBrie:
                    return new AgedBrieAction();
                case CategoryEnum.Conjured:
                    return new ConjuredAction();
                default:
                    return new NormalAction();
            }
        }

    }
}
