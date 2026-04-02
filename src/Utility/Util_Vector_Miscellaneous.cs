
namespace Utility;
internal static partial class VEC_Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/0bfrvyicjc
    //
    //          B     M            M
    //           \   /              \
    //            \ /                \
    //             o-----A            o-----A
    //                               /
    //                              /
    //                             B
    //
    internal static vec2 Bisect(vec2 A, vec2 B) {
        float tA = atan2(A.y, A.x);
        float tB = atan2(B.y, B.x);

        float dAB = (tB-tA + PI2) % PI2; //  "+ PI2" to compensate for negative modulo behavior.

        float tM = tA + (dAB * 0.5f);

        return new vec2(cos(tM), sin(tM));
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/9d31eb577f
    //
    //  Returns 3 weights corresponding to a position relative to the 3 Points of a Triangle.
    //      Center == (1/3, 1/3, 1/3)
    //
    internal static vec3 Barycentric(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;
        vec2 dAP = P -Ta;

        float Scaler = 1f / cross(dAB, dAC);

        float wC = cross(dAB, dAP) * Scaler;
        float wB = cross(dAP, dAC) * Scaler;
        float wA = 1f - wB - wC;

        return new vec3(wA, wB, wC);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //     (0,1)
    //          C
    //          |`.
    //          |  `.
    //          |    `.
    //          A------B
    //     (0,0)        (1,0)
    //
    [Impl(AggressiveInlining)] internal static v3 Barycentric(v2 P) => new vec3(1f-P.x-P.y, P.x, P.y);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v3 NormalizeBary(v3 W) => W / (W.x + W.y + W.z);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 WeightedSum(v1 A, v1 B,             v2 W) => (A*W.x + B*W.y);
    [Impl(AggressiveInlining)] internal static v2 WeightedSum(v2 A, v2 B,             v2 W) => (A*W.x + B*W.y);
    [Impl(AggressiveInlining)] internal static v3 WeightedSum(v3 A, v3 B,             v2 W) => (A*W.x + B*W.y);
    [Impl(AggressiveInlining)] internal static v4 WeightedSum(v4 A, v4 B,             v2 W) => (A*W.x + B*W.y);

    [Impl(AggressiveInlining)] internal static v1 WeightedSum(v1 A, v1 B, v1 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [Impl(AggressiveInlining)] internal static v2 WeightedSum(v2 A, v2 B, v2 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [Impl(AggressiveInlining)] internal static v3 WeightedSum(v3 A, v3 B, v3 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [Impl(AggressiveInlining)] internal static v4 WeightedSum(v4 A, v4 B, v4 C,       v3 W) => (A*W.x + B*W.y + C*W.z);

    [Impl(AggressiveInlining)] internal static v1 WeightedSum(v1 A, v1 B, v1 C, v1 D, v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [Impl(AggressiveInlining)] internal static v2 WeightedSum(v2 A, v2 B, v2 C, v2 D, v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [Impl(AggressiveInlining)] internal static v3 WeightedSum(v3 A, v3 B, v3 C, v3 D, v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [Impl(AggressiveInlining)] internal static v4 WeightedSum(v4 A, v4 B, v4 C, v4 D, v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 BaryLinear(v1 A, v1 B, v1 C,  v2 P) => WeightedSum(A,B,C,  Barycentric(P));
    [Impl(AggressiveInlining)] internal static v2 BaryLinear(v2 A, v2 B, v2 C,  v2 P) => WeightedSum(A,B,C,  Barycentric(P));
    [Impl(AggressiveInlining)] internal static v3 BaryLinear(v3 A, v3 B, v3 C,  v2 P) => WeightedSum(A,B,C,  Barycentric(P));
    [Impl(AggressiveInlining)] internal static v4 BaryLinear(v4 A, v4 B, v4 C,  v2 P) => WeightedSum(A,B,C,  Barycentric(P));

    [Impl(AggressiveInlining)] internal static v1 BaryLinear(v1 A, v1 B, v1 C,  v2 P, v2 Ta, v2 Tb, v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [Impl(AggressiveInlining)] internal static v2 BaryLinear(v2 A, v2 B, v2 C,  v2 P, v2 Ta, v2 Tb, v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [Impl(AggressiveInlining)] internal static v3 BaryLinear(v3 A, v3 B, v3 C,  v2 P, v2 Ta, v2 Tb, v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [Impl(AggressiveInlining)] internal static v4 BaryLinear(v4 A, v4 B, v4 C,  v2 P, v2 Ta, v2 Tb, v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/2uan3xr9qq
    //
    //  Test if a Point is inside of a Triangle's CircumCircle.
    //
    //      "Tolerance" is to prevent symmetrical triangles from getting stuck in an EdgeFlip loop.
    //          Value should be (T > 1.0) and (T < 1.1~)
    //
    internal static bool Delaunay(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc, float Tolerance = 1.0001f) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;

        float Determinant = cross(normalize(dAB), normalize(dAC)); //  Epsilon check only works if this is normalized...

        vec2  Cp;   //  CircumCircle-Position
        float CrCr; //  CircumCircle-Radius   Squared

        if (abs(Determinant) < 0.001f) {
            //  Triangle points are Colinear, define CircumCircle by delta between furthest points.
            vec2 Tmin = min(Ta, Tb, Tc);
            vec2 Tmax = max(Ta, Tb, Tc);

            Cp = (Tmin + Tmax) * 0.5f;

            CrCr = dot(Cp-Tmin);

        } else {
            Determinant = cross(dAB, dAC);

            float AB_AB = dot(dAB, Ta+Tb);
            float AC_AC = dot(dAC, Ta+Tc);

            Cp = new vec2(
                (dAC.y*AB_AB - dAB.y*AC_AC),
                (dAB.x*AC_AC - dAC.x*AB_AB)
            );
            Cp /= (2f * Determinant);

            CrCr = dot(Cp-Ta);
        }

        //  Scale Delta by Tolerance, because precision-error scales with magnitude.
        //  Do so before squaring, because a linear value doesn't work in "squared-space".
        //  All this to avoid a couple of pesky sqrts.  :P
        return dot((Cp-P) * Tolerance) < CrCr;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  ViewAspectX == ViewSizeX/ViewSizeY      1.777~ == 16/9
    //  ViewAspectY == ViewSizeY/ViewSizeX      0.5625 ==  9/16
    //
    [Impl(AggressiveInlining)] internal static float FovX_FromY(float FovY, float ViewAspectX) => 2f * atan(tan(FovY/2f) * ViewAspectX);
    [Impl(AggressiveInlining)] internal static float FovY_FromX(float FovX, float ViewAspectY) => 2f * atan(tan(FovX/2f) * ViewAspectY);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/mqajs8tfgd
    //  https://www.desmos.com/3d/p8hvpd8xwz
    //
    //  Asymptotic  AKA: "Falloff infinitely approaches zero."
    //      Result < 0.1           at radius: 1.51742712939~
    //      Result < 0.01          at radius: 2.14596602629~
    //      Result < 0.001         at radius: 2.62826088488~
    //      Result < 0.000_1       at radius: 3.03485425877~
    //      Result < 0.000_01      at radius: 3.39307021221~
    //      Result < 0.000_001     at radius: 3.71692218885~
    //      Result < 0.000_000_1   at radius: 4.01473481702~
    //      Result < 0.000_000_01  at radius: 4.29193205258~
    //      Result < 0.000_000_001 at radius: 4.55228138816~
    //
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1  Gaussian(v1 x)             => exp(-(x*x));
    [Impl(AggressiveInlining)] internal static v1 iGaussian(v1 y)             => sqrt(-log(y));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1  Gaussian(v1 x, v1 y)       => exp(-  (x*x) -   (y*y));
    [Impl(AggressiveInlining)] internal static v1  Gaussian(v1 x, v1 y, v1 S) => exp(-sq(x/S) - sq(y/S));

    [Impl(AggressiveInlining)] internal static v1  Gaussian(v2 V)             => Gaussian(V.x, V.y);

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/calculator/ku1ahcyzyw
    //  https://www.desmos.com/3d/gohoq8tutz
    //
    //  "x * PI" gives a period of 2, instead of PI.
    //
    //  NOTE:   Formula undefined at zero.
    //              Lanczos(0.0) == NaN
    //
    [Impl(AggressiveInlining)] internal static v1 Lanczos(v1 x) {x = x*PI;  return (2f * sin(x) * sin(x/2f)) / (x*x);}

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 Sigmoid(v1 x) => 1f / (1f + exp(-x));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  AKA: HaversineDistance
    //
    //  Inputs are a Rotation-Vector (Pitch, Yaw) in radians.
    //  Output is Distance in radians (0 to PI).
    //
    internal static float SphericalDistance(vec2 A, vec2 B) {
        vec2 d = 0.5f - 0.5f*cos(B-A);
        return 2f * asin(sqrt( d.x  +  d.y*cos(A.x)*cos(B.x) ));
    }

    //==========================================================================================================================================================
    //
    //  Inputs are a Unit-Direction-Vector.
    //  Output is Distance in radians (0 to PI).
    //
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(dot(A,B));                    //  Not numerically stable?    acos() == NaN  from tiny overshoots.
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(clamp(dot(A,B), -1f, 1f));
    internal static float SphericalDistance(vec3 A, vec3 B) => atan2(length(cross(A,B)), dot(A,B));

    //==========================================================================================================================================================
    //
    //  Spherical Coordinates
    //
    //      ( r,  θ,  φ )
    //
    //          X   Depth/Elevation     r               Radial Distance         Distance along the line connecting Point to Sphere-Origin.
    //          Y   Pitch               θ "theta"       Polar Angle             Angle between this radial line and a given polar axis.
    //          Z   Yaw                 φ "phi"         Azimuthal Angle         Angle of rotation of the radial line around the polar axis.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static vec3 ProjectRayToLine(vec3 Rp, vec3 Rn, vec3 La, vec3 Lb) {
        vec3 dAB = Lb - La;
        vec3 dAP = Rp - La;

        float dotL  = dot(dAB);
        float dotRL = dot(Rn,dAB);

        float Determinant = dotL - dotRL*dotRL;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = (abs(Determinant) < EPS7) ?  dot(dAP,dAB)                        / dotL        //  If RayLine & Line near parallel, project RayPos to Line.
                                               : (dot(dAB,dAP) - dotRL * dot(Rn,dAP)) / Determinant;
        return La + dAB*Dist;
    }

    //==========================================================================================================================================================
    internal static vec3 ProjectLineToLine(vec3 L1a, vec3 L1b, vec3 L2a, vec3 L2b) {
        vec3 dAB1 = L1b - L1a;
        vec3 dAB2 = L2b - L2a;
        vec3 dAA  = L1a - L2a;

        float dotL1 = dot(dAB1);
        float dotL2 = dot(dAB2);
        float dotLL = dot(dAB1, dAB2);

        float Determinant = dotL1*dotL2 - dotLL*dotLL;

        //  Are Line1 & Line2 near parallel?               return mid point?
        if (abs(Determinant) < EPS7)
            return L2a;

        //  Distance from Line2PointA to NearestPointOnLine, as multiple of DeltaAB2:
        float Dist = (dotL1*dot(dAB2,dAA) - dotLL*dot(dAB1,dAA)) / Determinant;

        return L2a + dAB2*Dist;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
