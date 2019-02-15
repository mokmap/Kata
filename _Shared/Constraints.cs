using System;

namespace csharp._Shared
{
    public static class Constraints
    {
        /// <summary>
        /// Applys all the constraints for this existing item
        /// </summary>
        /// <param name="value">the value that constraints should be applied on that</param>
        /// <returns>Returned the value after applying constraints like minimum and maximum</returns>
        public static int ApplyConstraints(int value, int minQuality, int maxQuality)
        {
            int minAppliedValue = Math.Max(minQuality, value);
            int maxAppliedValue = Math.Min(maxQuality, minAppliedValue);

            return maxAppliedValue;
        }
    }
}
