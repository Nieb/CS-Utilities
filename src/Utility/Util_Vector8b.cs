
namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct bvec8 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(7)] public byte b0;
    [FieldOffset(6)] public byte b1;    [FieldOffset(6)] public ushort s0;
    [FieldOffset(5)] public byte b2;
    [FieldOffset(4)] public byte b3;    [FieldOffset(4)] public ushort s1;    [FieldOffset(4)] public uint i0;
    [FieldOffset(3)] public byte b4;
    [FieldOffset(2)] public byte b5;    [FieldOffset(2)] public ushort s2;
    [FieldOffset(1)] public byte b6;
    [FieldOffset(0)] public byte b7;    [FieldOffset(0)] public ushort s3;    [FieldOffset(0)] public uint i1;    [FieldOffset(0)] public ulong L;

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
}
