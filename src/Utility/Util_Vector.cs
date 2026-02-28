
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    /*##########################################################################################################################################################
    //
    //                                          Some of these vector functions are not CoordinateSystem agnostic.
    //
    //                                                                          +Y
    //                                                                         |
    //                                                                         |
    //                                                                         |
    //                                                                         |        +X
    //                                                                         ●--------
    //                                                                        /
    //                                                                       /
    //                                                                      /
    //                                                                      +Z
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
                                                                    Component-wise Comparison
                                                                  (result is not component-wise)

                                               |                                                                       ●
                                               | (B >= A) == TRUE                                      (B < A) == FALSE
                                               ●
                                               |      (B > A) == TRUE                                            A
                                               |     ●                                          ----●-----------●
                                               |            (B > A) == FALSE        (B < A) == FALSE            |
                                               ●-----------●----                                          ●     |
                                              A                                            (B < A) == TRUE      |
                                                                                                                ●
                                        ●                                                      (B <= A) == TRUE |
                                         (B > A) == FALSE                                                       |

    //########################################################################################################################################################*/
    //##########################################################################################################################################################
    #if DEBUG || false
        internal static bool IsApproximatelyZero(this float A)      => abs(A)   < EPS_6;
        internal static bool IsApproximatelyZero(this vec2  A)      => abs(A)   < EPS_6;
        internal static bool IsApproximatelyZero(this vec3  A)      => abs(A)   < EPS_6;
        internal static bool IsApproximatelyZero(this vec4  A)      => abs(A)   < EPS_6;

        internal static bool IsApproximately(this float A, float B) => abs(B-A) < EPS_6;
        internal static bool IsApproximately(this vec2  A, vec2  B) => abs(B-A) < EPS_6;
        internal static bool IsApproximately(this vec3  A, vec3  B) => abs(B-A) < EPS_6;
        internal static bool IsApproximately(this vec4  A, vec4  B) => abs(B-A) < EPS_6;

        internal static bool IsRoughly(this float A, float B)       => abs(B-A) < EPS_4;
        internal static bool IsRoughly(this vec2  A, vec2  B)       => abs(B-A) < EPS_4;
        internal static bool IsRoughly(this vec3  A, vec3  B)       => abs(B-A) < EPS_4;
        internal static bool IsRoughly(this vec4  A, vec4  B)       => abs(B-A) < EPS_4;
    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
