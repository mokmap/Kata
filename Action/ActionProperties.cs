using csharp._Shared;

namespace csharp.Action
{
    public class ActionProperties
    {
        #region Properties
        /// <summary>
        /// Rate of change of quality
        /// </summary>
        public int Rate { get; set; } = Constants.DefaultRate;

        /// <summary>
        /// Unit of changing the amount of quality
        /// </summary>
        public int unitChange { get { return Constants.unitChange * Rate; } }        /// <summary>

        /// <summary>
        /// Unit of changing the amount of SellIn
        /// </summary>
        public int SellInunitChange { get { return 1; } }

        /// <summary>
        /// Minimum allowed quality
        /// </summary>
        public short MinQuality { get { return Constants.MinNormalQuality; } }

        /// <summary>
        /// Maximum allowed quality
        /// </summary>
        public short MaxQuality { get; set; } = Constants.MaxNormalQuality;
        #endregion
    }
}
