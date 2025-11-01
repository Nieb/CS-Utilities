

namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/ct29koavbu
    //
    internal static vec2[] Phyllotaxis2(int Count, float CircleCoverage = 1f, bool CenterPoint = true) {
        int iStart = (CenterPoint) ? 0 : 1;  //  WTF: empty vec at index-0 ???
        int iEnd   = Count;

        vec2[] Result = new vec2[Count];

        for (int i = iStart; i < Count; ++i) {
            float Ang = i * PHI_RAD;
            float Rds = CircleCoverage * sqrt((float)i / (float)Count);

            Result[i].x = Rds * cos(Ang);
            Result[i].y = Rds * sin(Ang);
        }

        return Result;
    }

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/3d/nrzvi76avc
    //
    internal static vec3[] Phyllotaxis3(int Count, float SphereCoverage = 1f, bool Poles = true) {
        SphereCoverage = 1f - cos(SphereCoverage*PI);

        int iStart = (Poles) ?       0 :     1;  //  WTF: empty vec at index-0 ???
        int iEnd   = (Poles) ? Count+1 : Count;

        vec3[] Result = new vec3[iEnd];

        for (int i = iStart; i < iEnd; ++i) {
            float    Pch = asin(1f - (SphereCoverage*(float)i / (float)Count));
            float CosPch = cos(Pch);
            float    Yaw = i * PI2_PHI;

            Result[i].x = sin(Yaw) *  CosPch;
            Result[i].y = sin(Pch);
            Result[i].z = cos(Yaw) * -CosPch;

            Result[i] = normalize(Result[i]);
        }

        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
