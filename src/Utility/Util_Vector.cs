
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    /*##########################################################################################################################################################
                                                                    Component-wise Comparison  (result is not component-wise)

                                                                               |
                                                                               | (B >= A) == TRUE
                                                                               o
                                                                               |      (B > A) == TRUE
                                                                               |     o
                                                                               |            (B > A) == FALSE
                                                                               o-----------o----
                                                                              A

                                                                        o
                                                                         (B > A) == FALSE

    //########################################################################################################################################################*/
    //##########################################################################################################################################################
    #if DEBUG || true
        internal static bool IsApproximatelyZero(this float A) => abs(A) < EPSILON;
        internal static bool IsApproximatelyZero(this vec2  A) => abs(A) < EPSILON;
        internal static bool IsApproximatelyZero(this vec3  A) => abs(A) < EPSILON;
        internal static bool IsApproximatelyZero(this vec4  A) => abs(A) < EPSILON;

        internal static bool IsApproximately(this float A, float B) => abs(B-A) < EPSILON;
        internal static bool IsApproximately(this vec2  A, vec2  B) => abs(B-A) < EPSILON;
        internal static bool IsApproximately(this vec3  A, vec3  B) => abs(B-A) < EPSILON;
        internal static bool IsApproximately(this vec4  A, vec4  B) => abs(B-A) < EPSILON;

        internal static bool IsRoughly(this float A, float B) => abs(B-A) < EPSILISH;
        internal static bool IsRoughly(this vec2  A, vec2  B) => abs(B-A) < EPSILISH;
        internal static bool IsRoughly(this vec3  A, vec3  B) => abs(B-A) < EPSILISH;
        internal static bool IsRoughly(this vec4  A, vec4  B) => abs(B-A) < EPSILISH;
    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if USE_QUOTE_CONSTRUCTORS_UNQUOTE || false
        [Impl(AggressiveInlining)] internal static ivec2 ivec2(int X, int Y) => new ivec2(X, Y);
        [Impl(AggressiveInlining)] internal static ivec2 ivec2(int XY      ) => new ivec2(XY, XY);

        [Impl(AggressiveInlining)] internal static  vec2  vec2(float X, float Y) => new vec2(X, Y);
        [Impl(AggressiveInlining)] internal static  vec2  vec2(float XY        ) => new vec2(XY, XY);

        [Impl(AggressiveInlining)] internal static ivec3 ivec3(int X, int Y, int Z) => new ivec3(X, Y, Z);
        [Impl(AggressiveInlining)] internal static ivec3 ivec3(int XYZ            ) => new ivec3(XYZ, XYZ, XYZ);

        [Impl(AggressiveInlining)] internal static  vec3  vec3(float X, float Y, float Z) => new vec3(X, Y, Z);
        [Impl(AggressiveInlining)] internal static  vec3  vec3(float XYZ                ) => new vec3(XYZ, XYZ, XYZ);

        [Impl(AggressiveInlining)] internal static ivec4 ivec4(int X, int Y, int Z, int W) => new ivec4(X, Y, Z, W);
        [Impl(AggressiveInlining)] internal static ivec4 ivec4(ivec3 XYZ          , int W) => new ivec4(XYZ.x, XYZ.y, XYZ.z, W);
        [Impl(AggressiveInlining)] internal static ivec4 ivec4(int XYZ            , int W) => new ivec4(XYZ, XYZ, XYZ, W);
        [Impl(AggressiveInlining)] internal static ivec4 ivec4(int XYZW                  ) => new ivec4(XYZW, XYZW, XYZW, XYZW);

        [Impl(AggressiveInlining)] internal static  vec4  vec4(float X, float Y, float Z, float W) => new vec4(X, Y, Z, W);
        [Impl(AggressiveInlining)] internal static  vec4  vec4(vec3 XYZ                 , float W) => new vec4(XYZ.x, XYZ.y, XYZ.z, W);
        [Impl(AggressiveInlining)] internal static  vec4  vec4(float XYZ                , float W) => new vec4(XYZ, XYZ, XYZ, W);
        [Impl(AggressiveInlining)] internal static  vec4  vec4(float XYZW                        ) => new vec4(XYZW, XYZW, XYZW, XYZW);
    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
