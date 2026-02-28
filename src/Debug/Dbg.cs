global using static DEBUG.DEBUG;

using Conditional = System.Diagnostics.ConditionalAttribute;
using ConOut      = System.Console;

namespace DEBUG;
internal static partial class DEBUG {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if DEBUG && true
        private static System.IO.StreamWriter LogOut = new System.IO.StreamWriter("log.txt"){AutoFlush = true};
    #elif DEBUG
        private static System.IO.StreamWriter LogOut = new System.IO.StreamWriter("log.txt", append: true){AutoFlush = true}; //  Append existing file.
    #else
        private static System.IO.StreamWriter LogOut = null;
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Conditional("DEBUG")] internal static void CONOUT (string PrintMe) => ConOut.WriteLine(PrintMe);
    [Conditional("DEBUG")] internal static void CONOUTC(string PrintMe) => ConOut.Write    (PrintMe);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Conditional("DEBUG")] internal static void HERE() => CONOUT("*** HERE! ***");

    //==========================================================================================================================================================
    [Conditional("DEBUG")] internal static void LOGOUT (string PrintMe) => LogOut.WriteLine(PrintMe);
    [Conditional("DEBUG")] internal static void LOGOUTC(string PrintMe) => LogOut.Write    (PrintMe);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
