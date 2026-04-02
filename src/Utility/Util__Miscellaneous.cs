using CallerLineNumber         = System.Runtime.CompilerServices.CallerLineNumberAttribute;
using CallerArgumentExpression = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace Utility;
internal static class Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Returns the line-number at the callsite.
    //
    //      LINE_NUMBER()
    //
    internal static int LINE_NUMBER(int Offset=0, [CallerLineNumber] int LineNumber=0) => LineNumber + Offset;

    //==========================================================================================================================================================
    //
    //  Returns verbatim string of Expr expression.
    //
    //      EXPRESSION(1.0 + PI * x)  ==  "1.0 + PI * x"
    //
    internal static string EXPRESSION(float Expr, [CallerArgumentExpression("Expr")] string ExprStr="") => ExprStr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  'FilePath' can include a file name, it doesn't need to be stripped from string.
    //
    [Impl(AggressiveInlining)] public static void IfNotExist_CreateDirectory(string FilePath) =>
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FilePath));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
