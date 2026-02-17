using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public int x;         [FieldOffset( 0)] public int r;
    [FieldOffset( 4)] public int y;         [FieldOffset( 4)] public int g;
    [FieldOffset( 8)] public int z;         [FieldOffset( 8)] public int b;
    [FieldOffset(12)] public int w;         [FieldOffset(12)] public int a;

    //==========================================================================================================================================================
    [FieldOffset( 0)] public ivec3 xyz;     [FieldOffset( 0)] public ivec3 rgb;

    [FieldOffset( 0)] public ivec2 xy;
    [FieldOffset( 4)] public ivec2 yz;
    [FieldOffset( 8)] public ivec2 zw;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec2 xz {get => new ivec2(x,z);  set {x=value.x; z=value.y;}}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec4() {}
    public ivec4(int X, int Y, int Z, int W) {x=X;     y=Y;     z=Z;     w=W;   }
    public ivec4(int XYZ            , int W) {x=XYZ;   y=XYZ;   z=XYZ;   w=W;   }
    public ivec4(int XYZW                  ) {x=XYZW;  y=XYZW;  z=XYZW;  w=XYZW;}

    public ivec4(ivec3 XYZ          , int W) {x=XYZ.x; y=XYZ.y; z=XYZ.z; w=W;   }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining)] public static implicit operator ivec4((int X, int Y, int Z, int W) t) => new ivec4(t.X, t.Y, t.Z, t.W);
    [Impl(AggressiveInlining)] public static implicit operator ivec4((ivec3 XYZ,           int W) t) => new ivec4(t.XYZ.x, t.XYZ.y, t.XYZ.z, t.W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(ivec4 A) => (A != 0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static ivec4 operator +(ivec4 A, ivec4 B) => new ivec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator +(ivec4 A, int   B) => new ivec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [Impl(AggressiveInlining)] public static ivec4 operator +(int   A, ivec4 B) => new ivec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator -(ivec4 A, ivec4 B) => new ivec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator -(ivec4 A, int   B) => new ivec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [Impl(AggressiveInlining)] public static ivec4 operator -(int   A, ivec4 B) => new ivec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator -(ivec4 A)          => new ivec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [Impl(AggressiveInlining)] public static ivec4 operator *(ivec4 A, ivec4 B) => new ivec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator *(ivec4 A, int   B) => new ivec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [Impl(AggressiveInlining)] public static ivec4 operator *(int   A, ivec4 B) => new ivec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator /(ivec4 A, ivec4 B) => new ivec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator /(ivec4 A, int   B) => new ivec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [Impl(AggressiveInlining)] public static ivec4 operator /(int   A, ivec4 B) => new ivec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator %(ivec4 A, ivec4 B) => new ivec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator %(ivec4 A, int   B) => new ivec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [Impl(AggressiveInlining)] public static ivec4 operator %(int   A, ivec4 B) => new ivec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    [Impl(AggressiveInlining)] public static ivec4 operator   ~(ivec4 A)          => new ivec4(   ~A.x,    ~A.y,    ~A.z,    ~A.w);

    [Impl(AggressiveInlining)] public static ivec4 operator   &(ivec4 A, ivec4 B) => new ivec4(A.x&B.x, A.y&B.y, A.z&B.z, A.w&B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator   |(ivec4 A, ivec4 B) => new ivec4(A.x|B.x, A.y|B.y, A.z|B.z, A.w|B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator   ^(ivec4 A, ivec4 B) => new ivec4(A.x^B.x, A.y^B.y, A.z^B.z, A.w^B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator  <<(ivec4 A, int   n) => new ivec4(A.x <<n, A.y <<n, A.z <<n, A.w <<n);
    [Impl(AggressiveInlining)] public static ivec4 operator  >>(ivec4 A, int   n) => new ivec4(A.x >>n, A.y >>n, A.z >>n, A.w >>n);
    [Impl(AggressiveInlining)] public static ivec4 operator >>>(ivec4 A, int   n) => new ivec4(A.x>>>n, A.y>>>n, A.z>>>n, A.w>>>n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(ivec4 A, ivec4 B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [Impl(AggressiveInlining)] public static bool operator ==(ivec4 A, int   B) => (A.x==B   && A.y==B   && A.z==B   && A.w==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(ivec4 A, ivec4 B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);
    [Impl(AggressiveInlining)] public static bool operator !=(ivec4 A, int   B) => (A.x!=B   || A.y!=B   || A.z!=B   || A.w!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(ivec4 A, ivec4 B) => (A.x< B.x && A.y< B.y && A.z< B.z && A.w< B.w);
    [Impl(AggressiveInlining)] public static bool operator  <(ivec4 A, int   B) => (A.x< B   && A.y< B   && A.z< B   && A.w< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(ivec4 A, ivec4 B) => (A.x> B.x && A.y> B.y && A.z> B.z && A.w> B.w);
    [Impl(AggressiveInlining)] public static bool operator  >(ivec4 A, int   B) => (A.x> B   && A.y> B   && A.z> B   && A.w> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(ivec4 A, ivec4 B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z && A.w<=B.w);
    [Impl(AggressiveInlining)] public static bool operator <=(ivec4 A, int   B) => (A.x<=B   && A.y<=B   && A.z<=B   && A.w<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(ivec4 A, ivec4 B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z && A.w>=B.w);
    [Impl(AggressiveInlining)] public static bool operator >=(ivec4 A, int   B) => (A.x>=B   && A.y>=B   && A.z>=B   && A.w>=B  );

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

        return $"({X}, {Y}, {Z}, {W})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3}, {this.y,3}, {this.z,3}, {this.w,3})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
