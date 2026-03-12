
namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct bvec8 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(7)] public u8 b0;
    [FieldOffset(6)] public u8 b1;    [FieldOffset(6)] public u16 s0;
    [FieldOffset(5)] public u8 b2;
    [FieldOffset(4)] public u8 b3;    [FieldOffset(4)] public u16 s1;    [FieldOffset(4)] public u32 i0;
    [FieldOffset(3)] public u8 b4;
    [FieldOffset(2)] public u8 b5;    [FieldOffset(2)] public u16 s2;
    [FieldOffset(1)] public u8 b6;
    [FieldOffset(0)] public u8 b7;    [FieldOffset(0)] public u16 s3;    [FieldOffset(0)] public u32 i1;    [FieldOffset(0)] private u64 L;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public bvec8() {}
    public bvec8(ulong V) {L = V;}

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
  //[Impl(AggressiveInlining)] public static implicit operator bvec4((byte X, byte Y, byte Z, byte W) t) => new bvec4(t.X, t.Y, t.Z, t.W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(bvec8 A) => (A.L != 0L);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public static implicit operator bvec8(ulong A) => new bvec8(A);      //  Directly assign 'ulong' to 'bvec8'.
    [Impl(AggressiveInlining)] public static implicit operator ulong(bvec8 A) => A.L;               //  Directly assign 'bvec8' to 'ulong'.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
