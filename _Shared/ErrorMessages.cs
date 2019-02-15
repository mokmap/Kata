namespace csharp._Shared
{
    /// <summary>
    /// this class contains error messages and in reality this error emssages should be read from a config file or database
    /// </summary>
    public class ErrorMessages
    {
        /// <summary>
        /// when quality is assigned a value over maximum threshold this error shows up
        /// </summary>
        public static string MaxQualityError { get { return "Maximum quality threshold is :{0} "; } }

        /// <summary>
        /// when quality is assigned a value under 0 this error shows up
        /// </summary>
        public static string MinQualityError { get { return "Minimum quality threshold is :{0} "; } }

        /// <summary>
        /// When a try happens for changing maximum threshold for sulfuras this error shows up.
        /// </summary>
        public static string MaxSulfurQualityError { get { return "Maximum threshold for sulfuras cannot be changed"; } }
    }
}
