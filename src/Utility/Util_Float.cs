
namespace Utility;
internal static class FLT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      "-0"  -->  "0"
    //
    [Impl(AggressiveInlining)] internal static v1 FNZ(v1 A) => (abs(A) < EPS6 ? 0f : A);
    [Impl(AggressiveInlining)] internal static v2 FNZ(v2 A) => new v2(FNZ(A.x), FNZ(A.y));
    [Impl(AggressiveInlining)] internal static v3 FNZ(v3 A) => new v3(FNZ(A.x), FNZ(A.y), FNZ(A.z));
    [Impl(AggressiveInlining)] internal static v4 FNZ(v4 A) => new v4(FNZ(A.x), FNZ(A.y), FNZ(A.z), FNZ(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static f64   abs(f64 A)        => System.Math.Abs(A);
    [Impl(AggressiveInlining)] internal static f64   min(f64 A, f64 B) => System.Math.Min(A,B);
    [Impl(AggressiveInlining)] internal static f64   max(f64 A, f64 B) => System.Math.Max(A,B);
    [Impl(AggressiveInlining)] internal static f64 round(f64 A)        => System.Math.Round(A);
    [Impl(AggressiveInlining)] internal static f64 floor(f64 A)        => System.Math.Floor(A);
    [Impl(AggressiveInlining)] internal static f64  ceil(f64 A)        => System.Math.Ceiling(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
