using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec3 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;    [FieldOffset(0)] public float r;
    [FieldOffset(4)] public float y;    [FieldOffset(4)] public float g;
    [FieldOffset(8)] public float z;    [FieldOffset(8)] public float b;

    //==========================================================================================================================================================
    public vec2 xy {  get => new vec2(x,y);  set {x = value.x; y = value.y;}  }
    public vec2 xz {  get => new vec2(x,z);  set {x = value.x; z = value.y;}  }

    public vec2 yz {  get => new vec2(y,z);  set {y = value.x; z = value.y;}  }
    public vec2 zy {  get => new vec2(z,y);  set {z = value.x; y = value.y;}  }

    //==========================================================================================================================================================
    //  NOTE: Length is computed each time it is accessed.
    public float length {
        get => sqrt(x*x + y*y + z*z);
        set => this = (this == 0f) ? this : this*(value/sqrt(x*x + y*y + z*z));
    }
    public readonly float length2 => (x*x + y*y + z*z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec3() {}
    public vec3(float X, float Y, float Z) { x=X;          y=Y;          z=Z;          }
    public vec3(float V                  ) { x=V;          y=V;          z=V;          }

    public vec3( vec2 V,          float Z) { x=V.x;        y=V.y;        z=Z;          }
    public vec3(ivec2 V,          float Z) { x=(float)V.x; y=(float)V.y; z=Z;          }

    public vec3(ivec3 V                  ) { x=(float)V.x; y=(float)V.y; z=(float)V.z; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining)] public static implicit operator vec3( (float x, float y, float z) t ) => new vec3(t.x, t.y, t.z);

    [Impl(AggressiveInlining)] public static implicit operator vec3( (vec2 V, float z) t ) => new vec3(t.V.x, t.V.y, t.z);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public static implicit operator vec3( ivec3 A ) => new vec3(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(vec3 A) => (A.x != 0f || A.y != 0f || A.z != 0f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static vec3 operator +(vec3  A, vec3  B) => new vec3(A.x+B.x, A.y+B.y, A.z+B.z);
    [Impl(AggressiveInlining)] public static vec3 operator +(vec3  A, float B) => new vec3(A.x+B  , A.y+B  , A.z+B  );
    [Impl(AggressiveInlining)] public static vec3 operator +(float A, vec3  B) => new vec3(A  +B.x, A  +B.y, A  +B.z);

    [Impl(AggressiveInlining)] public static vec3 operator -(vec3  A, vec3  B) => new vec3(A.x-B.x, A.y-B.y, A.z-B.z);
    [Impl(AggressiveInlining)] public static vec3 operator -(vec3  A, float B) => new vec3(A.x-B  , A.y-B  , A.z-B  );
    [Impl(AggressiveInlining)] public static vec3 operator -(float A, vec3  B) => new vec3(A  -B.x, A  -B.y, A  -B.z);

    [Impl(AggressiveInlining)] public static vec3 operator -(vec3 A)           => new vec3(   -A.x,    -A.y,    -A.z);

    [Impl(AggressiveInlining)] public static vec3 operator *(vec3  A, vec3  B) => new vec3(A.x*B.x, A.y*B.y, A.z*B.z);
    [Impl(AggressiveInlining)] public static vec3 operator *(vec3  A, float B) => new vec3(A.x*B  , A.y*B  , A.z*B  );
    [Impl(AggressiveInlining)] public static vec3 operator *(float A, vec3  B) => new vec3(A  *B.x, A  *B.y, A  *B.z);

    [Impl(AggressiveInlining)] public static vec3 operator /(vec3  A, vec3  B) => new vec3(A.x/B.x, A.y/B.y, A.z/B.z);
    [Impl(AggressiveInlining)] public static vec3 operator /(vec3  A, float B) => new vec3(A.x/B  , A.y/B  , A.z/B  );
    [Impl(AggressiveInlining)] public static vec3 operator /(float A, vec3  B) => new vec3(A  /B.x, A  /B.y, A  /B.z);

    [Impl(AggressiveInlining)] public static vec3 operator %(vec3  A, vec3  B) => new vec3(A.x%B.x, A.y%B.y, A.z%B.z);
    [Impl(AggressiveInlining)] public static vec3 operator %(vec3  A, float B) => new vec3(A.x%B  , A.y%B  , A.z%B  );
    [Impl(AggressiveInlining)] public static vec3 operator %(float A, vec3  B) => new vec3(A  %B.x, A  %B.y, A  %B.z);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(vec3  A, vec3  B) => (A.x == B.x && A.y == B.y && A.z == B.z);
    [Impl(AggressiveInlining)] public static bool operator ==(vec3  A, float B) => (A.x == B   && A.y == B   && A.z == B  );

    [Impl(AggressiveInlining)] public static bool operator !=(vec3  A, vec3  B) => (A.x != B.x || A.y != B.y || A.z != B.z);
    [Impl(AggressiveInlining)] public static bool operator !=(vec3  A, float B) => (A.x != B   || A.y != B   || A.z != B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(vec3  A, vec3  B) => (A.x <  B.x && A.y <  B.y && A.z <  B.z);
    [Impl(AggressiveInlining)] public static bool operator  <(vec3  A, float B) => (A.x <  B   && A.y <  B   && A.z <  B  );

    [Impl(AggressiveInlining)] public static bool operator  >(vec3  A, vec3  B) => (A.x >  B.x && A.y >  B.y && A.z >  B.z);
    [Impl(AggressiveInlining)] public static bool operator  >(vec3  A, float B) => (A.x >  B   && A.y >  B   && A.z >  B  );

    [Impl(AggressiveInlining)] public static bool operator <=(vec3  A, vec3  B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z);
    [Impl(AggressiveInlining)] public static bool operator <=(vec3  A, float B) => (A.x <= B   && A.y <= B   && A.z <= B  );

    [Impl(AggressiveInlining)] public static bool operator >=(vec3  A, vec3  B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z);
    [Impl(AggressiveInlining)] public static bool operator >=(vec3  A, float B) => (A.x >= B   && A.y >= B   && A.z >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        return "("+this.x.ToString(FormatStr).PadLeft(Padding)
             +", "+this.y.ToString(FormatStr).PadLeft(Padding)
             +", "+this.z.ToString(FormatStr).PadLeft(Padding)+")";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000})";

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
