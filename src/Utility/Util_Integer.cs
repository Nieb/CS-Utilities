
namespace Utility;
internal static class INT {
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
    [Impl(AggressiveInlining)] internal static s32 wrap(s32 A, s32 L, s32 U) {s32 Domain = U-L;  A = (A-L) % Domain;  return A+L + ((A < 0) ? Domain : 0);}
    [Impl(AggressiveInlining)] internal static s32 wrap(s32 A,        s32 U) {                   A = (A    %     U);  return A   + ((A < 0) ?      U : 0);}

    [Impl(AggressiveInlining)] internal static s64 wrap(s64 A, s64 L, s64 U) {s64 Domain = U-L;  A = (A-L) % Domain;  return A+L + ((A < 0) ? Domain : 0);}
    [Impl(AggressiveInlining)] internal static s64 wrap(s64 A,        s64 U) {                   A = (A    %     U);  return A   + ((A < 0) ?      U : 0);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Get previous/next Index, with Array.Length wrapping.
    //
    //      Blarg[ prev(i, Blarg.Length) ]      Equivalent to:  Blarg[ prev(i, 1, Blarg.Length) ]
    //      Blarg[ next(i, Blarg.Length) ]      Equivalent to:  Blarg[ next(i, 1, Blarg.Length) ]
    //
    //      Blarg[ prev(i, 2, Blarg.Length) ]
    //      Blarg[ next(i, 2, Blarg.Length) ]
    //
    [Impl(AggressiveInlining)] internal static int prev(int i,           int U) => (--i <  0) ? U-1 : i;
    [Impl(AggressiveInlining)] internal static int next(int i,           int U) => (++i >= U) ?   0 : i;

    [Impl(AggressiveInlining)] internal static int prev(int i, int Step, int U) => (i-Step <  0) ? i-Step + U : i-Step;
    [Impl(AggressiveInlining)] internal static int next(int i, int Step, int U) => (i+Step >= U) ? i+Step - U : i+Step;

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

    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i1 B)             => new i2(min(A.x,B          ), min(A.y,B          ));
    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i2 B)             => new i2(min(A.x,B.x        ), min(A.y,B.y        ));
    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i2 B, i2 C)       => new i2(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ));
    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i2 B, i2 C, i2 D) => new i2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));

    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i1 B)             => new i3(min(A.x,B          ), min(A.y,B          ), min(A.z,B          ));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i3 B)             => new i3(min(A.x,B.x        ), min(A.y,B.y        ), min(A.z,B.z        ));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i3 B, i3 C)       => new i3(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ), min(A.z,B.z,C.z    ));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i3 B, i3 C, i3 D) => new i3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));

    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i1 B)             => new i4(min(A.x,B          ), min(A.y,B          ), min(A.z,B          ), min(A.w,B          ));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i4 B)             => new i4(min(A.x,B.x        ), min(A.y,B.y        ), min(A.z,B.z        ), min(A.w,B.w        ));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i4 B, i4 C)       => new i4(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ), min(A.z,B.z,C.z    ), min(A.w,B.w,C.w    ));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i4 B, i4 C, i4 D) => new i4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [Impl(AggressiveInlining)] internal static int max(int A, int B)               => (A > B) ? A : B;

    [Impl(AggressiveInlining)] internal static int max(int A, int B, int C)        => (A > B) ? ((A > C) ? A : C)
                                                                                              : ((B > C) ? B : C);

    [Impl(AggressiveInlining)] internal static int max(int A, int B, int C, int D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                                         : ((C > D) ? C : D))
                                                                                              : ((B > C) ? ((B > D) ? B : D)
                                                                                                         : ((C > D) ? C : D));

    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i1 B)             => new i2(max(A.x,B          ), max(A.y,B          ));
    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i2 B)             => new i2(max(A.x,B.x        ), max(A.y,B.y        ));
    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i2 B, i2 C)       => new i2(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ));
    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i2 B, i2 C, i2 D) => new i2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));

    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i1 B)             => new i3(max(A.x,B          ), max(A.y,B          ), max(A.z,B          ));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i3 B)             => new i3(max(A.x,B.x        ), max(A.y,B.y        ), max(A.z,B.z        ));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i3 B, i3 C)       => new i3(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ), max(A.z,B.z,C.z    ));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i3 B, i3 C, i3 D) => new i3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));

    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i1 B)             => new i4(max(A.x,B          ), max(A.y,B          ), max(A.z,B          ), max(A.w,B          ));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i4 B)             => new i4(max(A.x,B.x        ), max(A.y,B.y        ), max(A.z,B.z        ), max(A.w,B.w        ));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i4 B, i4 C)       => new i4(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ), max(A.z,B.z,C.z    ), max(A.w,B.w,C.w    ));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i4 B, i4 C, i4 D) => new i4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

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
