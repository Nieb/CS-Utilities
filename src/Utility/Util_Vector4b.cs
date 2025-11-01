using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct bvec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "bvec4" is interoperable-ish with "uint" via implicit operators.
    //
    //      0xXxYyZzWw   (X, Y, Z, W)
    //      0xRrGgBbAa   (Red, Green, Blue, Alpha)
    //
    //    3  2  1  0 |  7  6  5  4 | 11 10  9  8 | 15 14 13 12         Which endianness does OpenGL want?
    //    0  1  2  3 |  4  5  6  7 |  8  9 10 11 | 12 13 14 15
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(3)] public byte x;  [FieldOffset(3)] public byte r;
    [FieldOffset(2)] public byte y;  [FieldOffset(2)] public byte g;
    [FieldOffset(1)] public byte z;  [FieldOffset(1)] public byte b;
    [FieldOffset(0)] public byte w;  [FieldOffset(0)] public byte a;    [FieldOffset(0)] private uint U;

    public uint ABGR => ByteFlip(this.U);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public bvec4() {}
    public bvec4(uint XYZW)                      {U = XYZW;}
    public bvec4(byte X, byte Y, byte Z, byte W) {x=X; y=Y; z=Z; w=W;}
  //public bvec4( int X,  int Y,  int Z,  int W) {x=ClampToByte(X); y=ClampToByte(Y); z=ClampToByte(Z); w=ClampToByte(W);}

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining)] public static implicit operator bvec4( (byte X, byte Y, byte Z, byte W) t ) => new bvec4(t.X, t.Y, t.Z, t.W);
  //[Impl(AggressiveInlining)] public static implicit operator bvec4( ( int X,  int Y,  int Z,  int W) t ) => new bvec4(t.X, t.Y, t.Z, t.W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(bvec4 A) => (A.U != 0u);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public static implicit operator bvec4(uint  A) => new bvec4(A);   //  Directly assign 'uint' to 'bvec'.
    [Impl(AggressiveInlining)] public static implicit operator  uint(bvec4 A) => A.U;            //  Directly assign 'bvec' to 'uint'.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static bvec4 operator +(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x+B.x),ClampToByte(A.y+B.y),ClampToByte(A.z+B.z),ClampToByte(A.w+B.w));

    [Impl(AggressiveInlining)] public static bvec4 operator -(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x-B.x),ClampToByte(A.y-B.y),ClampToByte(A.z-B.z),ClampToByte(A.w-B.w));

    [Impl(AggressiveInlining)] public static bvec4 operator *(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x*B.x),ClampToByte(A.y*B.y),ClampToByte(A.z*B.z),ClampToByte(A.w*B.w));

    [Impl(AggressiveInlining)] public static bvec4 operator /(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x/B.x),ClampToByte(A.y/B.y),ClampToByte(A.z/B.z),ClampToByte(A.w/B.w));

    [Impl(AggressiveInlining)] public static bvec4 operator %(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x%B.x),ClampToByte(A.y%B.y),ClampToByte(A.z%B.z),ClampToByte(A.w%B.w));

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    [Impl(AggressiveInlining)] public static bvec4 operator ~(bvec4 A)          => (~A.U);

    [Impl(AggressiveInlining)] public static bvec4 operator &(bvec4 A, bvec4 B) => (A.U & B.U);
    [Impl(AggressiveInlining)] public static bvec4 operator &(bvec4 A, uint  B) => (A.U & B  );
    [Impl(AggressiveInlining)] public static bvec4 operator &(uint  A, bvec4 B) => (A   & B.U);

    [Impl(AggressiveInlining)] public static bvec4 operator |(bvec4 A, bvec4 B) => (A.U | B.U);
    [Impl(AggressiveInlining)] public static bvec4 operator |(bvec4 A, uint  B) => (A.U | B  );
    [Impl(AggressiveInlining)] public static bvec4 operator |(uint  A, bvec4 B) => (A   | B.U);

    [Impl(AggressiveInlining)] public static bvec4 operator ^(bvec4 A, bvec4 B) => (A.U ^ B.U);
    [Impl(AggressiveInlining)] public static bvec4 operator ^(bvec4 A, uint  B) => (A.U ^ B  );
    [Impl(AggressiveInlining)] public static bvec4 operator ^(uint  A, bvec4 B) => (A   ^ B.U);

    [Impl(AggressiveInlining)] public static bvec4 operator <<(bvec4 A, int n) => (A.U << n);
    [Impl(AggressiveInlining)] public static bvec4 operator >>(bvec4 A, int n) => (A.U >> n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(bvec4 A, bvec4 B) => (A.U == B.U);
    [Impl(AggressiveInlining)] public static bool operator ==(bvec4 A, uint  B) => (A.U == B  );
    [Impl(AggressiveInlining)] public static bool operator ==(uint  A, bvec4 B) => (A   == B.U);

    [Impl(AggressiveInlining)] public static bool operator !=(bvec4 A, bvec4 B) => (A.U != B.U);
    [Impl(AggressiveInlining)] public static bool operator !=(bvec4 A, uint  B) => (A.U != B  );
    [Impl(AggressiveInlining)] public static bool operator !=(uint  A, bvec4 B) => (A   != B.U);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length;

        return "("+this.x.ToString(FormatStr).PadLeft(Padding)
             +", "+this.y.ToString(FormatStr).PadLeft(Padding)
             +", "+this.z.ToString(FormatStr).PadLeft(Padding)
             +", "+this.w.ToString(FormatStr).PadLeft(Padding)+")";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3}, {this.y,3}, {this.z,3}, {this.w,3})";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by "object" type:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
