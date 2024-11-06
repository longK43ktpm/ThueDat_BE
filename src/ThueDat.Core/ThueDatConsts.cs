using ThueDat.Debugging;

namespace ThueDat
{
    public class ThueDatConsts
    {
        public const string LocalizationSourceName = "ThueDat";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "a320ae78de744b7a9b1e4b05a0419210";
    }
}
