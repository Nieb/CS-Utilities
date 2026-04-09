
namespace Utility;
internal static partial class VEC {
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
    //    3  2  1  0 |  7  6  5  4 | 11 10  9  8 | 15 14 13 12          Which endianness does OpenGL want?
    //    0  1  2  3 |  4  5  6  7 |  8  9 10 11 | 12 13 14 15          just use byte[] arrays...
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(3)] public u8 x;  [FieldOffset(3)] public u8 r;
    [FieldOffset(2)] public u8 y;  [FieldOffset(2)] public u8 g;
    [FieldOffset(1)] public u8 z;  [FieldOffset(1)] public u8 b;
    [FieldOffset(0)] public u8 w;  [FieldOffset(0)] public u8 a;    [FieldOffset(0)] private u32 U;

    public uint ABGR => ByteFlip(this.U);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public bvec4() {}
    [Impl(AggressiveInlining)] public bvec4(u8 X, u8 Y, u8 Z, u8 W) {x=X; y=Y; z=Z; w=W;}
    [Impl(AggressiveInlining)] public bvec4(u32 XYZW)               {U = XYZW;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator   u32(                   bvec4 A) => A.U;                        //                  bvec4  to  uint
    [Impl(AggressiveInlining)] public static implicit operator bvec4(                   u32   A) => new bvec4(A);               //                   uint  to  bvec4
    [Impl(AggressiveInlining)] public static implicit operator bvec4((u8 x, u8 y, u8 z, u8 w) T) => new bvec4(T.x,T.y,T.z,T.w); //  (byte,byte,byte,byte)  to  bvec4

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
  //[Impl(AggressiveInlining)] public static implicit operator bool(bvec4 A) => (A.U != 0u);

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

    [Impl(AggressiveInlining)] public static bvec4 operator <<(bvec4 A, int n)  => (A.U << n);
    [Impl(AggressiveInlining)] public static bvec4 operator >>(bvec4 A, int n)  => (A.U >> n);

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

        string X = this.x.ToString(FormatStr).PadLeft(Padding);
        string Y = this.y.ToString(FormatStr).PadLeft(Padding);
        string Z = this.z.ToString(FormatStr).PadLeft(Padding);
        string W = this.w.ToString(FormatStr).PadLeft(Padding);

        return $"({X},{Y},{Z},{W})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3},{this.y,3},{this.z,3},{this.w,3})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
