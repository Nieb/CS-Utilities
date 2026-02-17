using System.Runtime.InteropServices;

namespace Utility;
internal static class Casting {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [StructLayout(LayoutKind.Explicit, Pack=4)]
    private struct Data32 {
        [FieldOffset(0)] public f32 F;
        [FieldOffset(0)] public s32 I;
        [FieldOffset(0)] public u32 U;
        public Data32(f32 F) => this.F = F;
        public Data32(s32 I) => this.I = I;
        public Data32(u32 U) => this.U = U;
      //[Impl(AggressiveInlining)] public static implicit operator Data32(f32 A) => new Data32(A); //  Directly assign 'f32' to 'Data32'.
      //[Impl(AggressiveInlining)] public static implicit operator Data32(s32 A) => new Data32(A); //  Directly assign 's32' to 'Data32'.
      //[Impl(AggressiveInlining)] public static implicit operator Data32(u32 A) => new Data32(A); //  Directly assign 'u32' to 'Data32'.
    }

    [Impl(AggressiveInlining)] internal static f32 BitCast_to_F32(s32 I) => new Data32(I).F;
    [Impl(AggressiveInlining)] internal static f32 BitCast_to_F32(u32 U) => new Data32(U).F;

    [Impl(AggressiveInlining)] internal static s32 BitCast_to_I32(f32 F) => new Data32(F).I;
    [Impl(AggressiveInlining)] internal static s32 BitCast_to_I32(u32 U) => new Data32(U).I;

    [Impl(AggressiveInlining)] internal static u32 BitCast_to_U32(f32 F) => new Data32(F).U;
    [Impl(AggressiveInlining)] internal static u32 BitCast_to_U32(s32 I) => new Data32(I).U;

    //==========================================================================================================================================================
    [StructLayout(LayoutKind.Explicit, Pack=4)]
    private struct Data64 {
        [FieldOffset(0)] public f64 F;
        [FieldOffset(0)] public s64 I;
        [FieldOffset(0)] public u64 U;
        public Data64(f64 F) => this.F = F;
        public Data64(s64 I) => this.I = I;
        public Data64(u64 U) => this.U = U;
      //[Impl(AggressiveInlining)] public static implicit operator Data64(f64 A) => new Data64(A); //  Directly assign 'f64' to 'Data64'.
      //[Impl(AggressiveInlining)] public static implicit operator Data64(s64 A) => new Data64(A); //  Directly assign 's64' to 'Data64'.
      //[Impl(AggressiveInlining)] public static implicit operator Data64(u64 A) => new Data64(A); //  Directly assign 'u64' to 'Data64'.
    }

    [Impl(AggressiveInlining)] internal static f64 BitCast_to_F64(s64 I) => new Data64(I).F;
    [Impl(AggressiveInlining)] internal static f64 BitCast_to_F64(u64 U) => new Data64(U).F;

    [Impl(AggressiveInlining)] internal static s64 BitCast_to_I64(f64 F) => new Data64(F).I;
    [Impl(AggressiveInlining)] internal static s64 BitCast_to_I64(u64 U) => new Data64(U).I;

    [Impl(AggressiveInlining)] internal static u64 BitCast_to_U64(f64 F) => new Data64(F).U;
    [Impl(AggressiveInlining)] internal static u64 BitCast_to_U64(s64 I) => new Data64(I).U;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All BYTE,SHORT operations result in an INT.  :(
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static s16 ClampToShort (s32 A) => (s16)clamp(A, (s32)MIN_I16, (s32)MAX_I16);

    [Impl(AggressiveInlining)] internal static s32 ClampToInt   (s64 A) => (s32)clamp(A, (s64)MIN_I32, (s64)MAX_I32);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static  u8 ClampToByte  (s32 A) =>  (u8)clamp(A,  0, (s32)MAX_BYTE);

    [Impl(AggressiveInlining)] internal static u16 ClampToUshort(s32 A) => (u16)clamp(A,  0, (s32)MAX_U16);

    [Impl(AggressiveInlining)] internal static u32 ClampToUint  (s32 A) => (u32)clamp(A,  0,      MAX_I32);
    [Impl(AggressiveInlining)] internal static u32 ClampToUint  (s64 A) => (u32)clamp(A, 0L, (s64)MAX_U32);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static s16      ClampToShort(f32 A) => (s16)      clamp(A, (f32)MIN_I16, (f32)MAX_I16);
    [Impl(AggressiveInlining)] internal static s16 RoundClampToShort(f32 A) => (s16)round(clamp(A, (f32)MIN_I16, (f32)MAX_I16));

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
    //==========================================================================================================================================================
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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
