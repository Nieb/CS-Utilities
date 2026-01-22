
namespace Utility;
internal static class Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Returns the line-number at the callsite.
    //
    //      LINE_NUMBER()
    //
    internal static int LINE_NUMBER([System.Runtime.CompilerServices.CallerLineNumber] int LineNumber_AtCallSite = 0) => LineNumber_AtCallSite;

  //internal static string EXPRESSION(float PrintMe, [System.Runtime.CompilerServices.CallerArgumentExpression("PrintMe")] string Expr = "") => Expr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
