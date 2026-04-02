using   F2 = (float x, float y);
using   F3 = (float x, float y, float z);
using   F4 = (float x, float y, float z, float w);
using   I2 = (int x, int y);
using   I3 = (int x, int y, int z);
using   I4 = (int x, int y, int z, int w);
using VEC2 = System.Numerics.Vector2;
using VEC3 = System.Numerics.Vector3;
using VEC4 = System.Numerics.Vector4;
using MAT4 = System.Numerics.Matrix4x4;

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec2 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;      [FieldOffset(0)] public int u;
    [FieldOffset(4)] public int y;      [FieldOffset(4)] public int v;

    //==========================================================================================================================================================
    public ivec2 yx {get => new ivec2(y,x);  set {x=value.y; y=value.x;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec3 xy_ => new ivec3(x,y,0);
    public ivec3 x_y => new ivec3(x,0,y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec2() {}
    public ivec2(i1 X, i1 Y) {x=X; y=Y;}
    public ivec2(i1 V      ) {x=V; y=V;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator ivec2((i1 x, i1 y) T) => new ivec2( T.x, T.y); //  (int,int)  to  ivec2
    [Impl(AggressiveInlining)] public static implicit operator ivec2(        i1[] V) => new ivec2(V[0],V[1]); //     int[2]  to  ivec2

    [Impl(AggressiveInlining)] public static implicit operator  VEC2(       ivec2 V) => new  VEC2( V.x, V.y); //      ivec2  to  ew-gross

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(ivec2 A) => (A != 0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static ivec2 operator +(ivec2 A, ivec2 B) => new ivec2(A.x+B.x, A.y+B.y);
    [Impl(AggressiveInlining)] public static ivec2 operator +(ivec2 A, int   B) => new ivec2(A.x+B  , A.y+B  );
    [Impl(AggressiveInlining)] public static ivec2 operator +(int   A, ivec2 B) => new ivec2(A  +B.x, A  +B.y);

    [Impl(AggressiveInlining)] public static ivec2 operator -(ivec2 A, ivec2 B) => new ivec2(A.x-B.x, A.y-B.y);
    [Impl(AggressiveInlining)] public static ivec2 operator -(ivec2 A, int   B) => new ivec2(A.x-B  , A.y-B  );
    [Impl(AggressiveInlining)] public static ivec2 operator -(int   A, ivec2 B) => new ivec2(A  -B.x, A  -B.y);

    [Impl(AggressiveInlining)] public static ivec2 operator -(ivec2 A)          => new ivec2(   -A.x,    -A.y);

    [Impl(AggressiveInlining)] public static ivec2 operator *(ivec2 A, ivec2 B) => new ivec2(A.x*B.x, A.y*B.y);
    [Impl(AggressiveInlining)] public static ivec2 operator *(ivec2 A, int   B) => new ivec2(A.x*B  , A.y*B  );
    [Impl(AggressiveInlining)] public static ivec2 operator *(int   A, ivec2 B) => new ivec2(A  *B.x, A  *B.y);

    [Impl(AggressiveInlining)] public static ivec2 operator /(ivec2 A, ivec2 B) => new ivec2(A.x/B.x, A.y/B.y);
    [Impl(AggressiveInlining)] public static ivec2 operator /(ivec2 A, int   B) => new ivec2(A.x/B  , A.y/B  );
    [Impl(AggressiveInlining)] public static ivec2 operator /(int   A, ivec2 B) => new ivec2(A  /B.x, A  /B.y);

    [Impl(AggressiveInlining)] public static ivec2 operator %(ivec2 A, ivec2 B) => new ivec2(A.x%B.x, A.y%B.y);
    [Impl(AggressiveInlining)] public static ivec2 operator %(ivec2 A, int   B) => new ivec2(A.x%B  , A.y%B  );
    [Impl(AggressiveInlining)] public static ivec2 operator %(int   A, ivec2 B) => new ivec2(A  %B.x, A  %B.y);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(ivec2 A, ivec2 B) => (A.x==B.x && A.y==B.y);
    [Impl(AggressiveInlining)] public static bool operator ==(ivec2 A, int   B) => (A.x==B   && A.y==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(ivec2 A, ivec2 B) => (A.x!=B.x || A.y!=B.y);
    [Impl(AggressiveInlining)] public static bool operator !=(ivec2 A, int   B) => (A.x!=B   || A.y!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(ivec2 A, ivec2 B) => (A.x< B.x && A.y< B.y);
    [Impl(AggressiveInlining)] public static bool operator  <(ivec2 A, int   B) => (A.x< B   && A.y< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(ivec2 A, ivec2 B) => (A.x> B.x && A.y> B.y);
    [Impl(AggressiveInlining)] public static bool operator  >(ivec2 A, int   B) => (A.x> B   && A.y> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(ivec2 A, ivec2 B) => (A.x<=B.x && A.y<=B.y);
    [Impl(AggressiveInlining)] public static bool operator <=(ivec2 A, int   B) => (A.x<=B   && A.y<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(ivec2 A, ivec2 B) => (A.x>=B.x && A.y>=B.y);
    [Impl(AggressiveInlining)] public static bool operator >=(ivec2 A, int   B) => (A.x>=B   && A.y>=B  );

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

        return $"({X},{Y})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3},{this.y,3})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
