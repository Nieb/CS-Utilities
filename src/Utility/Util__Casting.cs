
namespace Utility;
internal static class Casting {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static f32 BitCast_f32(s32 I) => new Data32(){I=I}.F;
    [Impl(AggressiveInlining)] internal static f32 BitCast_f32(u32 U) => new Data32(){U=U}.F;

    [Impl(AggressiveInlining)] internal static s32 BitCast_s32(f32 F) => new Data32(){F=F}.I;
    [Impl(AggressiveInlining)] internal static s32 BitCast_s32(u32 U) => new Data32(){U=U}.I;

    [Impl(AggressiveInlining)] internal static u32 BitCast_u32(f32 F) => new Data32(){F=F}.U;
    [Impl(AggressiveInlining)] internal static u32 BitCast_u32(s32 I) => new Data32(){I=I}.U;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static f64 BitCast_f64(s64 I) => new Data64(){I=I}.F;
    [Impl(AggressiveInlining)] internal static f64 BitCast_f64(u64 U) => new Data64(){U=U}.F;

    [Impl(AggressiveInlining)] internal static s64 BitCast_s64(f64 F) => new Data64(){F=F}.I;
    [Impl(AggressiveInlining)] internal static s64 BitCast_s64(u64 U) => new Data64(){U=U}.I;

    [Impl(AggressiveInlining)] internal static u64 BitCast_u64(f64 F) => new Data64(){F=F}.U;
    [Impl(AggressiveInlining)] internal static u64 BitCast_u64(s64 I) => new Data64(){I=I}.U;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All BYTE,SHORT operations result in an INT.  :(
    //
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static  u8 ClampToByte  (s32 A) =>        (u8)clamp(A, (s32)MIN_u8,  (s32)MAX_u8);
    [Impl(AggressiveInlining)] internal static  u8 ClampToByte  (s64 A) =>        (u8)clamp(A, (s64)MIN_u8,  (s64)MAX_u8);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static s16 ClampToShort (f32 A) => (s16)round(clamp(A, (f32)MIN_s16, (f32)MAX_s16));
    [Impl(AggressiveInlining)] internal static s16 ClampToShort (s32 A) =>       (s16)clamp(A, (s32)MIN_s16, (s32)MAX_s16);
    [Impl(AggressiveInlining)] internal static s16 ClampToShort (s64 A) =>       (s16)clamp(A, (s64)MIN_s16, (s64)MAX_s16);

    [Impl(AggressiveInlining)] internal static u16 ClampToUshort(f32 A) => (u16)round(clamp(A, (f32)MIN_u16, (f32)MAX_u16));
    [Impl(AggressiveInlining)] internal static u16 ClampToUshort(s32 A) =>       (u16)clamp(A, (s32)MIN_u16, (s32)MAX_u16);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static s32 ClampToInt   (s64 A) =>       (s32)clamp(A, (s64)MIN_s32, (s64)MAX_s32);

    [Impl(AggressiveInlining)] internal static u32 ClampToUint  (s32 A) =>       (u32)clamp(A, (s32)MIN_u32,      MAX_s32);
    [Impl(AggressiveInlining)] internal static u32 ClampToUint  (s64 A) =>       (u32)clamp(A, (s64)MIN_u32, (s64)MAX_u32);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This syntax is dumb.  :P
    //      (type)value;
    //      (type)expres / sion;
    //      (type)(expres / sion);
    //
    //  With this syntax, "order of operations" or "what/when exactly is being cast" is unambiguous:
    //      type(value);
    //      type(expres / sion);
    //
    [Impl(AggressiveInlining)] internal static  s8  s8( u8 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8( s8 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(s16 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(s16 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(u16 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(u16 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(s32 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(s32 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(u32 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(u32 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(s64 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(s64 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(u64 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(u64 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(f32 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(f32 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  s8  s8(f64 A) =>  (s8)A;        [Impl(AggressiveInlining)] internal static  u8  u8(f64 A) =>  (u8)A;

    [Impl(AggressiveInlining)] internal static s16 s16( s8 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16( s8 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16( u8 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16( u8 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(u16 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(s16 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(s32 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(s32 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(u32 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(u32 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(s64 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(s64 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(u64 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(u64 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(f32 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(f32 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static s16 s16(f64 A) => (s16)A;        [Impl(AggressiveInlining)] internal static u16 u16(f64 A) => (u16)A;

    [Impl(AggressiveInlining)] internal static s32 s32( s8 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32( s8 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32( u8 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32( u8 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(s16 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(s16 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(u16 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(u16 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(u32 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(s32 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(s64 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(s64 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(u64 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(u64 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(f32 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(f32 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s32(f64 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u32(f64 A) => (u32)A;

    [Impl(AggressiveInlining)] internal static s64 s64( s8 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64( s8 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64( u8 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64( u8 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(s16 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(s16 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(u16 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(u16 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(s32 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(s32 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(u32 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(u32 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(u64 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(s64 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(f32 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(f32 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static s64 s64(f64 A) => (s64)A;        [Impl(AggressiveInlining)] internal static u64 u64(f64 A) => (u64)A;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static f32 f32( s8 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32( u8 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(s16 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(u16 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(s32 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(u32 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(s64 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(u64 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(f64 A) => (f32)A;

    [Impl(AggressiveInlining)] internal static f64 f64( s8 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64( u8 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(s16 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(u16 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(s32 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(u32 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(s64 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(u64 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(f32 A) => (f64)A;

    //==========================================================================================================================================================
/*
    [Impl(AggressiveInlining)] internal static s32 s( s8 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u( s8 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s( u8 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u( u8 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(s16 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(s16 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(u16 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(u16 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(u32 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(s32 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(s64 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(s64 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(u64 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(u64 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(f32 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(f32 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static s32 s(f64 A) => (s32)A;        [Impl(AggressiveInlining)] internal static u32 u(f64 A) => (u32)A;

    [Impl(AggressiveInlining)] internal static f32 f( s8 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f( u8 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(s16 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(u16 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(s32 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(u32 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(s64 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(u64 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f(f64 A) => (f32)A;
*/
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
