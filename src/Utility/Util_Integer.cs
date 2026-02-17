
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
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    //  NOTE:  Does not check for overflow.    -(-2_147_483_648)
    //
    [Impl(AggressiveInlining)] internal static  s8 abs( s8 A) =>  s8((A >= 0) ? A : -A);
    [Impl(AggressiveInlining)] internal static s16 abs(s16 A) => s16((A >= 0) ? A : -A);
    [Impl(AggressiveInlining)] internal static s32 abs(s32 A) =>     (A >= 0) ? A : -A;
    [Impl(AggressiveInlining)] internal static s64 abs(s64 A) =>     (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //                *Inclusive*  *Inclusive*
    //      clamp( A, LowerBounds, UpperBounds )
    //
    [Impl(AggressiveInlining)] internal static  s8 clamp( s8 A,  s8 L,  s8 U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static  u8 clamp( u8 A,  u8 L,  u8 U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static s16 clamp(s16 A, s16 L, s16 U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static u16 clamp(u16 A, u16 L, u16 U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static s32 clamp(s32 A, s32 L, s32 U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static u32 clamp(u32 A, u32 L, u32 U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static s64 clamp(s64 A, s64 L, s64 U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static u64 clamp(u64 A, u64 L, u64 U) => (A < L) ? L : (A > U) ? U : A;

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //               *Inclusive*  *Exclusive*
    //      wrap( A, LowerBounds, UpperBounds )
    //      wrap( A,              UpperBounds )     LowerBounds == 0
    //
    [Impl(AggressiveInlining)] internal static int wrap(int A, int L, int U) {int Domain = U-L;  A = (A-L) % Domain;  return A+L + ((A < 0) ? Domain : 0);}

    [Impl(AggressiveInlining)] internal static int wrap(int A,        int U) {                   A = (A    %     U);  return A   + ((A < 0) ?      U : 0);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static int prev(int i, int U) => (--i <  0) ? U-1 : i;

    [Impl(AggressiveInlining)] internal static int next(int i, int U) => (++i >= U) ?   0 : i;

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

    [Impl(AggressiveInlining)] internal static iv2 min(iv2 A, int B)               => new iv2(min(A.x,B          ), min(A.y,B          ));
    [Impl(AggressiveInlining)] internal static iv2 min(iv2 A, iv2 B)               => new iv2(min(A.x,B.x        ), min(A.y,B.y        ));
    [Impl(AggressiveInlining)] internal static iv2 min(iv2 A, iv2 B, iv2 C)        => new iv2(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ));
    [Impl(AggressiveInlining)] internal static iv2 min(iv2 A, iv2 B, iv2 C, iv2 D) => new iv2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));

    [Impl(AggressiveInlining)] internal static iv3 min(iv3 A, int B)               => new iv3(min(A.x,B          ), min(A.y,B          ), min(A.z,B          ));
    [Impl(AggressiveInlining)] internal static iv3 min(iv3 A, iv3 B)               => new iv3(min(A.x,B.x        ), min(A.y,B.y        ), min(A.z,B.z        ));
    [Impl(AggressiveInlining)] internal static iv3 min(iv3 A, iv3 B, iv3 C)        => new iv3(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ), min(A.z,B.z,C.z    ));
    [Impl(AggressiveInlining)] internal static iv3 min(iv3 A, iv3 B, iv3 C, iv3 D) => new iv3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));

    [Impl(AggressiveInlining)] internal static iv4 min(iv4 A, int B)               => new iv4(min(A.x,B          ), min(A.y,B          ), min(A.z,B          ), min(A.w,B          ));
    [Impl(AggressiveInlining)] internal static iv4 min(iv4 A, iv4 B)               => new iv4(min(A.x,B.x        ), min(A.y,B.y        ), min(A.z,B.z        ), min(A.w,B.w        ));
    [Impl(AggressiveInlining)] internal static iv4 min(iv4 A, iv4 B, iv4 C)        => new iv4(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ), min(A.z,B.z,C.z    ), min(A.w,B.w,C.w    ));
    [Impl(AggressiveInlining)] internal static iv4 min(iv4 A, iv4 B, iv4 C, iv4 D) => new iv4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [Impl(AggressiveInlining)] internal static int max(int A, int B)               => (A > B) ? A : B;

    [Impl(AggressiveInlining)] internal static int max(int A, int B, int C)        => (A > B) ? ((A > C) ? A : C)
                                                                                              : ((B > C) ? B : C);

    [Impl(AggressiveInlining)] internal static int max(int A, int B, int C, int D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                                         : ((C > D) ? C : D))
                                                                                              : ((B > C) ? ((B > D) ? B : D)
                                                                                                         : ((C > D) ? C : D));

    [Impl(AggressiveInlining)] internal static iv2 max(iv2 A, int B)               => new iv2(max(A.x,B          ), max(A.y,B          ));
    [Impl(AggressiveInlining)] internal static iv2 max(iv2 A, iv2 B)               => new iv2(max(A.x,B.x        ), max(A.y,B.y        ));
    [Impl(AggressiveInlining)] internal static iv2 max(iv2 A, iv2 B, iv2 C)        => new iv2(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ));
    [Impl(AggressiveInlining)] internal static iv2 max(iv2 A, iv2 B, iv2 C, iv2 D) => new iv2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));

    [Impl(AggressiveInlining)] internal static iv3 max(iv3 A, int B)               => new iv3(max(A.x,B          ), max(A.y,B          ), max(A.z,B          ));
    [Impl(AggressiveInlining)] internal static iv3 max(iv3 A, iv3 B)               => new iv3(max(A.x,B.x        ), max(A.y,B.y        ), max(A.z,B.z        ));
    [Impl(AggressiveInlining)] internal static iv3 max(iv3 A, iv3 B, iv3 C)        => new iv3(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ), max(A.z,B.z,C.z    ));
    [Impl(AggressiveInlining)] internal static iv3 max(iv3 A, iv3 B, iv3 C, iv3 D) => new iv3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));

    [Impl(AggressiveInlining)] internal static iv4 max(iv4 A, int B)               => new iv4(max(A.x,B          ), max(A.y,B          ), max(A.z,B          ), max(A.w,B          ));
    [Impl(AggressiveInlining)] internal static iv4 max(iv4 A, iv4 B)               => new iv4(max(A.x,B.x        ), max(A.y,B.y        ), max(A.z,B.z        ), max(A.w,B.w        ));
    [Impl(AggressiveInlining)] internal static iv4 max(iv4 A, iv4 B, iv4 C)        => new iv4(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ), max(A.z,B.z,C.z    ), max(A.w,B.w,C.w    ));
    [Impl(AggressiveInlining)] internal static iv4 max(iv4 A, iv4 B, iv4 C, iv4 D) => new iv4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Modulo"
    //  Based on Euclidean-Division.
    //
    [Impl(AggressiveInlining)] internal static int mod(int A, int B) {int R = A % B; return R + (R < 0 ? (B < 0 ? -B : B) : 0);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static  s8 sign( s8 A) =>  s8((A < 0) ? -1 : 1);
    [Impl(AggressiveInlining)] internal static s16 sign(s16 A) => s16((A < 0) ? -1 : 1);
    [Impl(AggressiveInlining)] internal static s32 sign(s32 A) =>     (A < 0) ? -1 : 1;
    [Impl(AggressiveInlining)] internal static s64 sign(s64 A) =>     (A < 0) ? -1 : 1;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 "Trunkate" Digits
    //  NOTE:  Doesn't handle "-" symbol.
    //
    //      trunk(12345, -2) ==   345
    //      trunk(12345,  2) == 123
    //
    internal static int trunk(int A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(Astr.Length-Digits,  Digits))  // Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(                 0, -Digits)); // Truncate Left
    }

    internal static long trunk(long A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(Astr.Length-Digits,  Digits))  // Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(                 0, -Digits)); // Truncate Left
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
