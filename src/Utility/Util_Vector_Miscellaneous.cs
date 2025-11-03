
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
    //             o------A           o------A
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

        float wB = cross(dAP, dAC) * Scaler;
        float wC = cross(dAB, dAP) * Scaler;
        float wA = 1f - wB - wC;

        return new vec3(wA, wB, wC);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Test if a Point is inside of a Triangle's CircumCircle.
    //
    //      "Tolerance" is to prevent symmetrical triangles from getting stuck in an EdgeFlip loop.
    //
    internal static bool Delaunay(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc, float Tolerance = 0.001f) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;

        float Determinant = cross(dAB, dAC);

        vec2  Cp;   //  CircumCircle-Position
        float CrCr; //  CircumCircle-Radius Squared

        if (abs(Determinant) < EPSILON) {
            //  Triangle points are Collinear, define CircumCircle by delta between furthest points.
            vec2 Min = min(Ta, Tb, Tc);
            vec2 Max = max(Ta, Tb, Tc);

            Cp = (Min + Max) * 0.5f;

            CrCr = dot(Cp-Min);

        } else {
            //float AB_AB = dot(dAB, Ta+Tb); //  Local-space dotted with World-space sum, what is this doing???
            //float AC_AC = dot(dAC, Ta+Tc);

            float AA_BB = dot(Tb) - dot(Ta);
            float AA_CC = dot(Tc) - dot(Ta);

            Cp = new vec2(
                (dAC.y*AA_BB - dAB.y*AA_CC) / (2f * Determinant),
                (dAB.x*AA_CC - dAC.x*AA_BB) / (2f * Determinant)
            );

            CrCr = dot(Cp-Ta);
        }

        return dot(Cp-P)+Tolerance < CrCr;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/3d/p8hvpd8xwz
    //
    //  Falloff infinitely approaches zero.  AKA: "asymptotic"
    //
    internal static float Gaussian(float x, float y)          => exp(-pow(x  , 2f) - pow(y  , 2f));

    internal static float Gaussian(float x, float y, float S) => exp(-pow(x/S, 2f) - pow(y/S, 2f));

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
