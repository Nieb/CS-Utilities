
namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float x;       [FieldOffset( 0)] public float r;
    [FieldOffset( 4)] public float y;       [FieldOffset( 4)] public float g;
    [FieldOffset( 8)] public float z;       [FieldOffset( 8)] public float b;
    [FieldOffset(12)] public float w;       [FieldOffset(12)] public float a;

    //==========================================================================================================================================================
    [FieldOffset( 0)] public vec3 xyz;      [FieldOffset( 0)] public vec3 rgb;

    [FieldOffset( 0)] public vec2 xy;
    [FieldOffset( 4)] public vec2 yz;
    [FieldOffset( 8)] public vec2 zw;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec2 xz {get => new vec2(x,z);  set {x=value.x; z=value.y;}}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec4() {}
    public vec4(float X, float Y, float Z, float W) {x=X;    y=Y;    z=Z;    w=W;   }
    public vec4(float XYZ                , float W) {x=XYZ;  y=XYZ;  z=XYZ;  w=W;   }
    public vec4(float XYZW                        ) {x=XYZW; y=XYZW; z=XYZW; w=XYZW;}

    public vec4( vec2 XY        , vec2 ZW         ) {x=XY.x; y=XY.y; z=ZW.x; w=ZW.y;}
    public vec4( vec3 V                  , float W) {x=V.x;  y=V.y;  z=V.z;  w=W;   }
    public vec4(ivec4 V                           ) {x=V.x;  y=V.y;  z=V.z;  w=V.w; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining)] public static implicit operator vec4((float X, float Y, float Z, float W) t) => new vec4(   t.X,    t.Y,    t.Z,    t.W);
    [Impl(AggressiveInlining)] public static implicit operator vec4((vec2 XY         , vec2 ZW         ) t) => new vec4(t.XY.x, t.XY.y, t.ZW.x, t.ZW.y);
    [Impl(AggressiveInlining)] public static implicit operator vec4((vec3 V,                    float W) t) => new vec4( t.V.x,  t.V.y,  t.V.z,    t.W);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public static implicit operator vec4(ivec4 A) => new vec4(A);        //  Directly assign 'ivec4' to 'vec4'.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining)] public static implicit operator bool(vec4 A) => (A != 0f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static vec4 operator +(vec4  A, vec4  B) => new vec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [Impl(AggressiveInlining)] public static vec4 operator +(vec4  A, float B) => new vec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [Impl(AggressiveInlining)] public static vec4 operator +(float A, vec4  B) => new vec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [Impl(AggressiveInlining)] public static vec4 operator -(vec4  A, vec4  B) => new vec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [Impl(AggressiveInlining)] public static vec4 operator -(vec4  A, float B) => new vec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [Impl(AggressiveInlining)] public static vec4 operator -(float A, vec4  B) => new vec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [Impl(AggressiveInlining)] public static vec4 operator -(vec4 A)           => new vec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [Impl(AggressiveInlining)] public static vec4 operator *(vec4  A, vec4  B) => new vec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [Impl(AggressiveInlining)] public static vec4 operator *(vec4  A, float B) => new vec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [Impl(AggressiveInlining)] public static vec4 operator *(float A, vec4  B) => new vec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [Impl(AggressiveInlining)] public static vec4 operator /(vec4  A, vec4  B) => new vec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [Impl(AggressiveInlining)] public static vec4 operator /(vec4  A, float B) => new vec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [Impl(AggressiveInlining)] public static vec4 operator /(float A, vec4  B) => new vec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [Impl(AggressiveInlining)] public static vec4 operator %(vec4  A, vec4  B) => new vec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [Impl(AggressiveInlining)] public static vec4 operator %(vec4  A, float B) => new vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [Impl(AggressiveInlining)] public static vec4 operator %(float A, vec4  B) => new vec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(vec4 A, vec4  B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [Impl(AggressiveInlining)] public static bool operator ==(vec4 A, float B) => (A.x==B   && A.y==B   && A.z==B   && A.w==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(vec4 A, vec4  B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);
    [Impl(AggressiveInlining)] public static bool operator !=(vec4 A, float B) => (A.x!=B   || A.y!=B   || A.z!=B   || A.w!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(vec4 A, vec4  B) => (A.x< B.x && A.y< B.y && A.z< B.z && A.w< B.w);
    [Impl(AggressiveInlining)] public static bool operator  <(vec4 A, float B) => (A.x< B   && A.y< B   && A.z< B   && A.w< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(vec4 A, vec4  B) => (A.x> B.x && A.y> B.y && A.z> B.z && A.w> B.w);
    [Impl(AggressiveInlining)] public static bool operator  >(vec4 A, float B) => (A.x> B   && A.y> B   && A.z> B   && A.w> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(vec4 A, vec4  B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z && A.w<=B.w);
    [Impl(AggressiveInlining)] public static bool operator <=(vec4 A, float B) => (A.x<=B   && A.y<=B   && A.z<=B   && A.w<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(vec4 A, vec4  B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z && A.w>=B.w);
    [Impl(AggressiveInlining)] public static bool operator >=(vec4 A, float B) => (A.x>=B   && A.y>=B   && A.z>=B   && A.w>=B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        string X = this.x.ToString(FormatStr).PadLeft(Padding);
        string Y = this.y.ToString(FormatStr).PadLeft(Padding);
        string Z = this.z.ToString(FormatStr).PadLeft(Padding);
        string W = this.w.ToString(FormatStr).PadLeft(Padding);

        return $"({X}, {Y}, {Z}, {W})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000}, {this.w,9:0.000000})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
