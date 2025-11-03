using System.Runtime.InteropServices;

namespace Utility;
internal static class Casting {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [StructLayout(LayoutKind.Explicit, Pack=4)]
    private struct Data32 {
        [FieldOffset(0)] public f32 F;
        [FieldOffset(0)] public i32 I;
        [FieldOffset(0)] public u32 U;
        public Data32(f32 F) => this.F = F;
        public Data32(i32 I) => this.I = I;
        public Data32(u32 U) => this.U = U;
    }

    [Impl(AggressiveInlining)] internal static f32 BitCast_to_F32(i32 A) => new Data32(A).F;
    [Impl(AggressiveInlining)] internal static f32 BitCast_to_F32(u32 A) => new Data32(A).F;

    [Impl(AggressiveInlining)] internal static i32 BitCast_to_I32(f32 A) => new Data32(A).I;
    [Impl(AggressiveInlining)] internal static i32 BitCast_to_I32(u32 A) => new Data32(A).I;

    [Impl(AggressiveInlining)] internal static u32 BitCast_to_U32(f32 A) => new Data32(A).U;
    [Impl(AggressiveInlining)] internal static u32 BitCast_to_U32(i32 A) => new Data32(A).U;

    //==========================================================================================================================================================
    [StructLayout(LayoutKind.Explicit, Pack=4)]
    private struct Data64 {
        [FieldOffset(0)] public f64 F;
        [FieldOffset(0)] public i64 I;
        [FieldOffset(0)] public u64 U;
        public Data64(f64 F) => this.F = F;
        public Data64(i64 I) => this.I = I;
        public Data64(u64 U) => this.U = U;
    }

    [Impl(AggressiveInlining)] internal static f64 BitCast_to_F64(i64 A) => new Data64(A).F;
    [Impl(AggressiveInlining)] internal static f64 BitCast_to_F64(u64 A) => new Data64(A).F;

    [Impl(AggressiveInlining)] internal static i64 BitCast_to_I64(f64 A) => new Data64(A).I;
    [Impl(AggressiveInlining)] internal static i64 BitCast_to_I64(u64 A) => new Data64(A).I;

    [Impl(AggressiveInlining)] internal static u64 BitCast_to_U64(f64 A) => new Data64(A).U;
    [Impl(AggressiveInlining)] internal static u64 BitCast_to_U64(i64 A) => new Data64(A).U;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All BYTE,SHORT operations result in an INT.  :(
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static i16 ClampToShort (i32 A) => (i16)clamp(A, (i32)MIN_SHORT, (i32)MAX_SHORT);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static i32 ClampToInt   (i64 A) => (i32)clamp(A, (i64)MIN_INT  , (i64)MAX_INT  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static  u8 ClampToByte  (i32 A) =>  (u8)clamp(A, 0 , (i32)MAX_BYTE);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static u16 ClampToUshort(i32 A) => (u16)clamp(A, 0 , (i32)MAX_USHORT);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static u32 ClampToUint  (i32 A) => (u32)clamp(A, 0 ,       MAX_INT);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static u32 ClampToUint  (i64 A) => (u32)clamp(A, 0L, (i64)MAX_UINT);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static i16      ClampToShort(float A) => (i16)      clamp(A, (float)MIN_SHORT, (float)MAX_SHORT);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static i16 RoundClampToShort(float A) => (i16)round(clamp(A, (float)MIN_SHORT, (float)MAX_SHORT));


    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This syntax is dumb.  :P
    //      (type)value;
    //
    //  Also, "order of operations" or "what/when exactly is being cast" is unambiguous with this syntax:
    //      type(value);
    //      type(expression);
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static  i8  i8( u8 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(i16 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(u16 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(i32 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(u32 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(i64 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(u64 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(f32 A) =>  (i8)A;
    [Impl(AggressiveInlining)] internal static  i8  i8(f64 A) =>  (i8)A;

    [Impl(AggressiveInlining)] internal static  u8  u8( i8 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(i16 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(u16 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(i32 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(u32 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(i64 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(u64 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(f32 A) =>  (u8)A;
    [Impl(AggressiveInlining)] internal static  u8  u8(f64 A) =>  (u8)A;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static i16 i16( i8 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16( u8 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(u16 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(i32 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(u32 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(i64 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(u64 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(f32 A) => (i16)A;
    [Impl(AggressiveInlining)] internal static i16 i16(f64 A) => (i16)A;

    [Impl(AggressiveInlining)] internal static u16 u16( i8 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16( u8 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(i16 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(i32 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(u32 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(i64 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(u64 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(f32 A) => (u16)A;
    [Impl(AggressiveInlining)] internal static u16 u16(f64 A) => (u16)A;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static i32 i32( i8 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32( u8 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(i16 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(u16 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(u32 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(i64 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(u64 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(f32 A) => (i32)A;
    [Impl(AggressiveInlining)] internal static i32 i32(f64 A) => (i32)A;

    [Impl(AggressiveInlining)] internal static u32 u32( i8 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32( u8 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(i16 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(u16 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(i32 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(i64 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(u64 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(f32 A) => (u32)A;
    [Impl(AggressiveInlining)] internal static u32 u32(f64 A) => (u32)A;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static i64 i64( i8 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64( u8 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(i16 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(u16 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(i32 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(u32 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(u64 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(f32 A) => (i64)A;
    [Impl(AggressiveInlining)] internal static i64 i64(f64 A) => (i64)A;

    [Impl(AggressiveInlining)] internal static u64 u64( i8 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64( u8 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(i16 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(u16 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(i32 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(u32 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(i64 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(f32 A) => (u64)A;
    [Impl(AggressiveInlining)] internal static u64 u64(f64 A) => (u64)A;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static f32 f32( i8 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32( u8 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(i16 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(u16 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(i32 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(u32 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(i64 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(u64 A) => (f32)A;
    [Impl(AggressiveInlining)] internal static f32 f32(f64 A) => (f32)A;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static f64 f64( i8 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64( u8 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(i16 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(u16 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(i32 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(u32 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(i64 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(u64 A) => (f64)A;
    [Impl(AggressiveInlining)] internal static f64 f64(f32 A) => (f64)A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
