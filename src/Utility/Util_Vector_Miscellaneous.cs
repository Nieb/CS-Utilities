
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
    //  Returns 3 weights corresponding to a position relative to the 3 points of a triangle.
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

        float Determinant = cross(dAB, dAC);

        vec2  Cp;   //  CircumCircle-Position
        float CrCr; //  CircumCircle-Radius   Squared

        if (abs(Determinant) < EPSILON) {
            //  Triangle points are Collinear, define CircumCircle by delta between furthest points.
            vec2 Tmin = min(Ta, Tb, Tc);
            vec2 Tmax = max(Ta, Tb, Tc);

            Cp = (Tmin + Tmax) * 0.5f;

            CrCr = dot(Cp-Tmin);

        } else {
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
    //  https://www.desmos.com/3d/p8hvpd8xwz
    //
    //  Falloff infinitely approaches zero.  AKA: Asymptotic
    //
    //  Result < 0.1         at radius: 1.51742712939~
    //  Result < 0.01        at radius: 2.14596602629~
    //  Result < 0.001       at radius: 2.62826088488~
    //
    //  Result < 0.0001      at radius: 3.03485425877~
    //  Result < 0.00001     at radius: 3.39307021221~
    //  Result < 0.000001    at radius: 3.71692218885~
    //
    //  Result < 0.0000001   at radius: 4.01473481702~
    //  Result < 0.00000001  at radius: 4.29193205258~
    //  Result < 0.000000001 at radius: 4.55228138816~
    //
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1  Gaussian(v1 x)               => exp(-(x*x));
    [Impl(AggressiveInlining)] internal static v1 iGaussian(v1 y)               => sqrt(-log(y));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1  Gaussian(v1 x, v1 y)         => exp(-sq(x  ) - sq(y  ));
    [Impl(AggressiveInlining)] internal static v1  Gaussian(v1 x, v1 y, v1 S)   => exp(-sq(x/S) - sq(y/S));

    [Impl(AggressiveInlining)] internal static v1  Gaussian(v2 V)               => Gaussian(V.x, V.y);

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
    internal static v1 Lanczos(v1 x) {x = x*PI;  return (2f * sin(x) * sin(x/2f)) / (x*x);}

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
        vec2 dAB = B-A;
        dAB = sin(dAB * 0.5f);

        float D = dAB.x*dAB.x
                + dAB.y*dAB.y * cos(A.x) * cos(B.x);

        return 2f * asin( sqrt(D) );
    }

    //==========================================================================================================================================================
    //
    //  Inputs are a Unit-Pointing-Vector.
    //  Output is Distance in radians (0 to PI).
    //
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(dot(A,B));            //  Not numerically stable?    acos() == NaN  from tiny overshoots.
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(clamp(dot(A,B), -PIH, PIH));
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(clamp(dot(A,B), -1.5707963f, 1.5707963f));
    internal static float SphericalDistance(vec3 A, vec3 B) => atan2(length(cross(A,B)), dot(A,B));

    //==========================================================================================================================================================
    //
    //  Spherical Coordinates
    //
    //      ( r,  θ,  φ )
    //
    //          X   Depth/Elevation     r               Radial Distance         Distance along the line connecting Point to Sphere-Origin.
    //          Y   Pitch               θ "theta"       Polar Angle             Angle between this radial line and a given polar axis.
    //          Z   Yaw                 φ "phi"         Azimuthal Angle         Angle which is the angle of rotation of the radial line around the polar axis.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
