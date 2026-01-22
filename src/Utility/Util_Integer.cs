
namespace Utility;
internal static class INT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal const sbyte  MIN_I8  =                       -128;     internal const sbyte  MIN_SBYTE  = MIN_I8;
    internal const sbyte  MAX_I8  =                        127;     internal const sbyte  MAX_SBYTE  = MAX_I8;

    internal const short  MIN_I16 =                    -32_768;     internal const short  MIN_SHORT  = MIN_I16;
    internal const short  MAX_I16 =                     32_767;     internal const short  MAX_SHORT  = MAX_I16;

    internal const int    MIN_I32 =             -2_147_483_648;     internal const int    MIN_INT    = MIN_I32;
    internal const int    MAX_I32 =              2_147_483_647;     internal const int    MAX_INT    = MAX_I32;

    internal const long   MIN_I64 = -9_223_372_036_854_775_808;     internal const long   MIN_LONG   = MIN_I64;
    internal const long   MAX_I64 =  9_223_372_036_854_775_807;     internal const long   MAX_LONG   = MAX_I64;

    internal const byte   MIN_U8  =                          0;     internal const byte   MIN_BYTE   = MIN_U8;
    internal const byte   MAX_U8  =                        255;     internal const byte   MAX_BYTE   = MAX_U8;

    internal const ushort MIN_U16 =                          0;     internal const ushort MIN_USHORT = MIN_U16;
    internal const ushort MAX_U16 =                     65_535;     internal const ushort MAX_USHORT = MAX_U16;

    internal const uint   MIN_U32 =                          0;     internal const uint   MIN_UINT   = MIN_U32;
    internal const uint   MAX_U32 =              4_294_967_295;     internal const uint   MAX_UINT   = MAX_U32;

    internal const ulong  MIN_U64 =                          0;     internal const ulong  MIN_ULONG  = MIN_U64;
    internal const ulong  MAX_U64 = 18_446_744_073_709_551_615;     internal const ulong  MAX_ULONG  = MAX_U64;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    //  NOTE:  Does not check for overflow.    -(-2_147_483_648)
    //
    [Impl(AggressiveInlining)] internal static sbyte abs(sbyte A) =>  i8((A >= 0) ? A : -A);
    [Impl(AggressiveInlining)] internal static short abs(short A) => i16((A >= 0) ? A : -A);
    [Impl(AggressiveInlining)] internal static   int abs(  int A) =>     (A >= 0) ? A : -A;
    [Impl(AggressiveInlining)] internal static  long abs( long A) =>     (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //                *Inclusive*  *Inclusive*
    //      clamp( A, LowerBounds, UpperBounds )
    //
    [Impl(AggressiveInlining)] internal static  sbyte clamp( sbyte A,  sbyte L,  sbyte U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static   byte clamp(  byte A,   byte L,   byte U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static  short clamp( short A,  short L,  short U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static ushort clamp(ushort A, ushort L, ushort U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static    int clamp(   int A,    int L,    int U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static   uint clamp(  uint A,   uint L,   uint U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static   long clamp(  long A,   long L,   long U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static  ulong clamp( ulong A,  ulong L,  ulong U) => (A < L) ? L : (A > U) ? U : A;

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //               *Inclusive*  *Exclusive*
    //      wrap( A, LowerBounds, UpperBounds )
    //      wrap( A,              UpperBounds )     LowerBounds == 0
    //
    [Impl(AggressiveInlining)] internal static int wrap(int A, int L, int U) {int Range = U-L;  A = (A-L) % Range;  return A+L + ((A < 0) ? Range : 0);}

    [Impl(AggressiveInlining)] internal static int wrap(int A,        int U) {                  A = (A    %    U);  return A   + ((A < 0) ?     U : 0);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [Impl(AggressiveInlining)] internal static int min(int A, int B)               => (A < B) ? A : B;

    [Impl(AggressiveInlining)] internal static int min(int A, int B, int C)        => (A < B) ? ((A < C) ? A : C)
                                                                                              : ((B < C) ? B : C);

    [Impl(AggressiveInlining)] internal static int min(int A, int B, int C, int D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                                         : ((C < D) ? C : D))
                                                                                              : ((B < C) ? ((B < D) ? B : D)
                                                                                                         : ((C < D) ? C : D));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [Impl(AggressiveInlining)] internal static int max(int A, int B)               => (A > B) ? A : B;

    [Impl(AggressiveInlining)] internal static int max(int A, int B, int C)        => (A > B) ? ((A > C) ? A : C)
                                                                                              : ((B > C) ? B : C);

    [Impl(AggressiveInlining)] internal static int max(int A, int B, int C, int D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                                         : ((C > D) ? C : D))
                                                                                              : ((B > C) ? ((B > D) ? B : D)
                                                                                                         : ((C > D) ? C : D));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Power"
    internal static int pow(int x, int pow) {
        int EKS;
        switch ((uint)pow) {
            case  0:                          return 1;
            case  1:                          return x;
            case  2:                          return x*x;
            case  3:                          return x*x*x;
            case  4: EKS = x*x;               return EKS*EKS;
            case  5: EKS = x*x;               return EKS*EKS * x;
            case  6: EKS = x*x*x;             return EKS*EKS;
            case  7: EKS = x*x*x;             return EKS*EKS * x;
            case  8: EKS = x*x*x*x;           return EKS*EKS;
            case  9: EKS = x*x*x;             return EKS*EKS*EKS;
            case 10: EKS = x*x*x*x*x;         return EKS*EKS;
            case 11: EKS = x*x*x*x*x;         return EKS*EKS * x;
            case 12: EKS = x*x*x*x;           return EKS*EKS*EKS;
            case 13: EKS = x*x*x*x;           return EKS*EKS*EKS * x;
            case 14: EKS = x*x*x*x*x*x*x;     return EKS*EKS;
            case 15: EKS = x*x*x*x*x;         return EKS*EKS*EKS;
            case 16: EKS = x*x*x*x;           return EKS*EKS*EKS*EKS;
            case 17: EKS = x*x*x*x;           return EKS*EKS*EKS*EKS * x;
            case 18: EKS = x*x*x*x*x*x;       return EKS*EKS*EKS;
            case 19: EKS = x*x*x*x*x*x;       return EKS*EKS*EKS * x;
            case 20: EKS = x*x*x*x*x;         return EKS*EKS*EKS*EKS;
            case 21: EKS = x*x*x*x*x*x*x;     return EKS*EKS*EKS;
            case 22: EKS = x*x*x*x*x*x*x;     return EKS*EKS*EKS * x;
            case 23: EKS = x*x*x*x*x*x*x;     return EKS*EKS*EKS * x * x;
            case 24: EKS = x*x*x*x*x*x;       return EKS*EKS*EKS*EKS;
            case 25: EKS = x*x*x*x*x;         return EKS*EKS*EKS*EKS*EKS;
            case 26: EKS = x*x*x*x*x;         return EKS*EKS*EKS*EKS*EKS * x;
            case 27: EKS = x*x*x*x*x*x*x*x*x; return EKS*EKS*EKS;
            case 28: EKS = x*x*x*x*x*x*x;     return EKS*EKS*EKS*EKS;
            case 29: EKS = x*x*x*x*x*x*x;     return EKS*EKS*EKS*EKS * x;
            case 30: EKS = x*x*x*x*x;         return EKS*EKS*EKS*EKS*EKS*EKS;
            default:
                return (x   == 0) ? 0
                     : (x   == 1) ? 1
                     : (x%1 == 0) ? int.MaxValue
                                  : int.MinValue;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Note:  Doesn't handle "-" symbol.
    //
    //      trunk(12345, -2) ==   345
    //      trunk(12345,  2) == 123
    //
    [Impl(AggressiveOptimization)]
    internal static int trunk(int A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(Astr.Length-Digits,  Digits))  // Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(                 0, -Digits)); // Truncate Left
    }

    [Impl(AggressiveOptimization)]
    internal static long trunk(long A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(Astr.Length-Digits,  Digits))  // Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(                 0, -Digits)); // Truncate Left
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static uint ByteFlip(uint A) => (
        ((A & 0xFF000000) >> 24) |
        ((A & 0x00FF0000) >>  8) |
        ((A & 0x0000FF00) <<  8) |
        ((A & 0x000000FF) << 24)
    );

    internal static bvec4 ByteFlip(bvec4 A) => (
        ((uint)A.x      ) |
        ((uint)A.y <<  8) |
        ((uint)A.z << 16) |
        ((uint)A.w << 24)
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################

    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitCount.xhtml            BitCount()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldExtract.xhtml     BitfieldExtract()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldReverse.xhtml     BitfieldReverse()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldInsert.xhtml      BitfieldInsert()

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
