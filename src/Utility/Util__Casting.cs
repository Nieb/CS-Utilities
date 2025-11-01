using System.Runtime.InteropServices;

namespace Utility;
internal static class Casting {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All BYTE/SHORT operations result in an INT.  :(
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static   byte ClampToByte  (int   A) =>   (byte)clamp(A,         0, MAX_BYTE);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static  short ClampToShort (int   A) =>  (short)clamp(A, MIN_SHORT, MAX_SHORT);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static  short ClampToShort (float A) =>  (short)clamp(A, MIN_SHORT, MAX_SHORT);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static ushort ClampToUshort(int   A) => (ushort)clamp(A,         0, MAX_USHORT);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static   uint ClampToUint  (int   A) =>   (uint)clamp(A,         0, MAX_INT );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static   uint ClampToUint  (long  A) =>   (uint)clamp(A,         0, MAX_UINT);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static  short RoundClampToShort(float A) =>  (short)round(clamp(A, MIN_SHORT, MAX_SHORT));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static class BitCast {
        [StructLayout(LayoutKind.Explicit, Pack=4)]
        private struct Data32 {
            [FieldOffset(0)] public float F;    public Data32(float F) => this.F = F;
            [FieldOffset(0)] public   int I;    public Data32(  int I) => this.I = I;
            [FieldOffset(0)] public  uint U;    public Data32( uint U) => this.U = U;
        }

        [Impl(AggressiveInlining|AggressiveOptimization)] internal static float ToFloat( int A) => new Data32(A).F;
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static float ToFloat(uint A) => new Data32(A).F;

        [Impl(AggressiveInlining|AggressiveOptimization)] internal static   int ToInt( float A) => new Data32(A).I;
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static   int ToInt(  uint A) => new Data32(A).I;

        [Impl(AggressiveInlining|AggressiveOptimization)] internal static  uint ToUint(float A) => new Data32(A).U;
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static  uint ToUint(  int A) => new Data32(A).U;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
