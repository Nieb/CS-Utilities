
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

    //==========================================================================================================================================================
    //
    //  Returns verbatim string of Expr expression.
    //
    //      EXPRESSION(1.0 + PI * x)  ==  "1.0 + PI * x"
    //
  //internal static string EXPRESSION(float Expr, [System.Runtime.CompilerServices.CallerArgumentExpression("Expr")] string ExprStr = "") => ExprStr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
