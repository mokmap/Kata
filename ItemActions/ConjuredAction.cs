using csharp.Action;

namespace csharp.Actions
{
    public class ConjuredAction : ActionBase
    {
        public ConjuredAction()
        {
            properties = new ActionProperties { Rate = 2 };
        }

        /// <summary>
        /// Conjured items degrade in Quality twice as fast as normal items
        /// </summary>
        public override int UpdateState(int sellIn)
        {
            //Chain Of Responsibility design pattern (if normal rate change, rate for Conjured, will be adapted)
            var rate = (new NormalAction()).UpdateState(sellIn);
            properties.Rate = rate * 2;
            return properties.Rate;
        }
    }
}
