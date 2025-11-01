using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec3 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;  [FieldOffset(0)] public int r;
    [FieldOffset(4)] public int y;  [FieldOffset(4)] public int g;
    [FieldOffset(8)] public int z;  [FieldOffset(8)] public int b;

    //==========================================================================================================================================================
    public ivec2 xy {  get => new ivec2(x, y);  set {x = value.x; y = value.y;}  }
    public ivec2 xz {  get => new ivec2(x, z);  set {x = value.x; z = value.y;}  }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec3() {}
    public ivec3(int X, int Y, int Z) { x=X; y=Y; z=Z; }
    public ivec3(int V              ) { x=V; y=V; z=V; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining)] public static implicit operator ivec3( (int X, int Y, int Z) t ) => new ivec3(t.X, t.Y, t.Z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(ivec3 A) => (A.x != 0 || A.y != 0 || A.z != 0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static ivec3 operator +(ivec3 A, ivec3 B) => new ivec3(A.x+B.x, A.y+B.y, A.z+B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator +(ivec3 A, int   B) => new ivec3(A.x+B  , A.y+B  , A.z+B  );
    [Impl(AggressiveInlining)] public static ivec3 operator +(int   A, ivec3 B) => new ivec3(A  +B.x, A  +B.y, A  +B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator -(ivec3 A, ivec3 B) => new ivec3(A.x-B.x, A.y-B.y, A.z-B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator -(ivec3 A, int   B) => new ivec3(A.x-B  , A.y-B  , A.z-B  );
    [Impl(AggressiveInlining)] public static ivec3 operator -(int   A, ivec3 B) => new ivec3(A  -B.x, A  -B.y, A  -B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator -(ivec3 A)          => new ivec3(   -A.x,    -A.y,    -A.z);

    [Impl(AggressiveInlining)] public static ivec3 operator *(ivec3 A, ivec3 B) => new ivec3(A.x*B.x, A.y*B.y, A.z*B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator *(ivec3 A, int   B) => new ivec3(A.x*B  , A.y*B  , A.z*B  );
    [Impl(AggressiveInlining)] public static ivec3 operator *(int   A, ivec3 B) => new ivec3(A  *B.x, A  *B.y, A  *B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator /(ivec3 A, ivec3 B) => new ivec3(A.x/B.x, A.y/B.y, A.z/B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator /(ivec3 A, int   B) => new ivec3(A.x/B  , A.y/B  , A.z/B  );
    [Impl(AggressiveInlining)] public static ivec3 operator /(int   A, ivec3 B) => new ivec3(A  /B.x, A  /B.y, A  /B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator %(ivec3 A, ivec3 B) => new ivec3(A.x%B.x, A.y%B.y, A.z%B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator %(ivec3 A, int   B) => new ivec3(A.x%B  , A.y%B  , A.z%B  );
    [Impl(AggressiveInlining)] public static ivec3 operator %(int   A, ivec3 B) => new ivec3(A  %B.x, A  %B.y, A  %B.z);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(ivec3 A, ivec3 B) => (A.x == B.x && A.y == B.y && A.z == B.z);
    [Impl(AggressiveInlining)] public static bool operator ==(ivec3 A, int   B) => (A.x == B   && A.y == B   && A.z == B  );

    [Impl(AggressiveInlining)] public static bool operator !=(ivec3 A, ivec3 B) => (A.x != B.x || A.y != B.y || A.z != B.z);
    [Impl(AggressiveInlining)] public static bool operator !=(ivec3 A, int   B) => (A.x != B   || A.y != B   || A.z != B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(ivec3 A, ivec3 B) => (A.x <  B.x && A.y <  B.y && A.z <  B.z);
    [Impl(AggressiveInlining)] public static bool operator  <(ivec3 A, int   B) => (A.x <  B   && A.y <  B   && A.z <  B  );

    [Impl(AggressiveInlining)] public static bool operator  >(ivec3 A, ivec3 B) => (A.x >  B.x && A.y >  B.y && A.z >  B.z);
    [Impl(AggressiveInlining)] public static bool operator  >(ivec3 A, int   B) => (A.x >  B   && A.y >  B   && A.z >  B  );

    [Impl(AggressiveInlining)] public static bool operator <=(ivec3 A, ivec3 B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z);
    [Impl(AggressiveInlining)] public static bool operator <=(ivec3 A, int   B) => (A.x <= B   && A.y <= B   && A.z <= B  );

    [Impl(AggressiveInlining)] public static bool operator >=(ivec3 A, ivec3 B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z);
    [Impl(AggressiveInlining)] public static bool operator >=(ivec3 A, int   B) => (A.x >= B   && A.y >= B   && A.z >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length;

        return $"( {this.x.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.y.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.z.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3}, {this.y,3}, {this.z,3})";

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
