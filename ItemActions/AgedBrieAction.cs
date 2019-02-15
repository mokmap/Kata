using csharp.Action;

namespace csharp.Actions
{
    public class AgedBrieAction : ActionBase
    {
        public AgedBrieAction()
        {
            properties = new ActionProperties { Rate = -1 };
        }

        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        public override int UpdateState(int sellIn)
        {
            properties.Rate = -1; //because the quality raises over time the rate is negative
            return properties.Rate;
        }
    }
}
