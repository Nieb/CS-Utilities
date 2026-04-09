
namespace Utility;
internal static class VEC_Collision3 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                        ●      > 0
    //                    |
    //              ------+---●--    = 0
    //
    //                        ●      < 0
    //
    //      WhichSideOfPlane(  Point,  Plane-Position,  Plane-Normal  )
    //
    [Impl(AggressiveInlining)] internal static float WhichSideOfPlane(vec3 Pnt, vec3 Pp, vec3 Pn) => dot(Pn, Pnt-Pp);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
  //[Impl(AggressiveInlining)] internal static bool PointVsPoint(vec3 Pa, vec3 Pb, float Tolerance) => PointVsSphere(Pa, Pb, Tolerance);

    //==========================================================================================================================================================
    //
    //      PointVsSphere(  Point,  Sphere-Position,  Sphere-Radius  )
    //
    [Impl(AggressiveInlining)] internal static bool PointVsSphere(vec3 P, vec3 Sp, float Sr) => dot(Sp-P) <= (Sr*Sr);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //                +Y           BoxSize
    //                   *-------●
    //                   |       |
    //                   |       |
    //                   |       |
    //                   ●-------*
    //             BoxPos          +X
    //
    //      PointVsBox(  Point,  Box-Position,  Box-Size  )
    //
    [Impl(AggressiveInlining)] internal static bool PointVsBox(v3 P, v3 Bp, v3 Bs) => (P >= Bp && P <= Bp+Bs);
    [Impl(AggressiveInlining)] internal static bool PointVsBox(i3 P, i3 Bp, i3 Bs) => (P >= Bp && P <  Bp+Bs);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static bool PointVsBounds(v3 P, v3 b0, v3 b1) => (P >= b0 && P <= b1);
    [Impl(AggressiveInlining)] internal static bool PointVsBounds(i3 P, i3 b0, i3 b1) => (P >= b0 && P <  b1);

    //==========================================================================================================================================================
    //
    //  Axis-Aligned.
    //
    //      BoxVsBox(  Rectangle1-Position,  Rectangle1-Size,  Rectangle2-Position,  Rectangle2-Size)
    //
    [Impl(AggressiveInlining)] internal static bool BoxVsBox(v3 Bp1, v3 Bs1, v3 Bp2, v3 Bs2) => (Bp1+Bs1 >= Bp2  &&  Bp1 <= Bp2+Bs2);
    [Impl(AggressiveInlining)] internal static bool BoxVsBox(i3 Bp1, i3 Bs1, i3 Bp2, i3 Bs2) => (Bp1+Bs1 >= Bp2  &&  Bp1 <  Bp2+Bs2);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      PointVsCylinder(  Point,  Cylinder-Position,  Cylinder-Radius,  Cylinder-Height  )
    //
    [Impl(AggressiveInlining)] internal static bool PointVsCylinder(vec3 P, vec3 Cp, float Cr, float Ch) => (
         P.y >= Cp.y && P.y <= Cp.y+Ch  //  Is Point in same vertical space as Cylinder?
        && dot(P.xz - Cp.xz) <= (Cr*Cr) //  Is Point inside of Cylinder-Radius?
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      SphereVsBox(  SpherePosition, SphereRadius,  BoxPosition, BoxSize  )
    //
    [Impl(AggressiveInlining)] internal static bool SphereVsBox(vec3 Sp, float Sr, vec3 Bp, vec3 Bs)   => dot(min(0f,Sp-Bp) + max(0f,Sp-(Bp+Bs))) <= Sr*Sr;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static bool SphereVsBounds(vec3 Sp, float Sr, vec3 b0, vec3 b1) => dot(min(0f,Sp-b0) + max(0f,Sp-b1)) <= Sr*Sr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All RayVs*() functions return:  HitDistance                             HitPos = RayPos + (RayNrm * HitDist);
    //
    //                         Surface      Ray
    //       HitDist < 0.0      |-->        -->  Surface/Volume is Behind Ray.
    //
    //       HitDist = 0.0                       RayPos is inside Volume.
    //
    //       HitDist > 0.0      |-->        <--  Surface/Volume is InFront of Ray.
    //
    internal const float RAY_MISS = float.NegativeInfinity;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Surface
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RayVsPlaneX(  Ray-Position,  Ray-Normal,    Plane-Position_X  )      Plane spans ZY.
    //      RayVsPlaneY(  Ray-Position,  Ray-Normal,    Plane-Position_Y  )      Plane spans XZ.
    //      RayVsPlaneZ(  Ray-Position,  Ray-Normal,    Plane-Position_Z  )      Plane spans XY.
    //
    [Impl(AggressiveInlining)] internal static float RayVsPlaneX(vec3 Rp, vec3 Rn, float Pp_x) => (Pp_x - Rp.x) / Rn.x;
    [Impl(AggressiveInlining)] internal static float RayVsPlaneY(vec3 Rp, vec3 Rn, float Pp_y) => (Pp_y - Rp.y) / Rn.y;
    [Impl(AggressiveInlining)] internal static float RayVsPlaneZ(vec3 Rp, vec3 Rn, float Pp_z) => (Pp_z - Rp.z) / Rn.z;

    //==========================================================================================================================================================
    //
    //      RayVsPlane(  Ray-Position,  Ray-Normal,    Plane-Position,  Plane-Normal  )
    //
    [Impl(AggressiveInlining)] internal static float RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn) => dot(Pn, Rp-Pp) / -dot(Rn, Pn);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RayVsQuadX(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Size  )     Quad spans ZY.
    //      RayVsQuadY(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Size  )     Quad spans XZ.
    //      RayVsQuadZ(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Size  )     Quad spans XY.
    //
    internal static float RayVsQuadX(vec3 Rp, vec3 Rn, vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.x - Rp.x) / Rn.x;
        vec2 Hp2 = (Rp + (Rn*HitDist)).zy;
        vec2 Qp2 = Qp.zy;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    internal static float RayVsQuadY(vec3 Rp, vec3 Rn, vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.y - Rp.y) / Rn.y;
        vec2 Hp2 = (Rp + (Rn*HitDist)).xz;
        vec2 Qp2 = Qp.xz;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    internal static float RayVsQuadZ(vec3 Rp, vec3 Rn, vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.z - Rp.z) / Rn.z;
        vec2 Hp2 = (Rp + (Rn*HitDist)).xy;
        vec2 Qp2 = Qp.xy;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Not CoordinateSystem agnostic.
    //  Weinding is Anti-Clockwise.
    //
    //      RayVsTriangle(  Ray-Position,  Ray-Normal,    Triangle-PointA,  Triangle-PointB,  Triangle-PointC,    BackFaceTest  )
    //
    internal static float RayVsTriangle(vec3 Rp, vec3 Rn,   vec3 Ta, vec3 Tb, vec3 Tc,   bool BackFaceTest=false) {
        vec3 dAB = Tb - Ta;
        vec3 dAC = Tc - Ta;

        vec3 H = cross(Rn, dAC);
        float Determinant = dot(dAB, H);

        //  Is Ray pointing in the same direction as SurfaceNormal?
        if (Determinant < 0f && !BackFaceTest)
            return RAY_MISS;

        //  Is Ray coplanar with Triangle Surface?
        //if (abs(Determinant) < EPS6)
        if (Determinant == 0f)
            return RAY_MISS;

        vec3 dAP = Rp - Ta;
        float DtrRcp = 1f/Determinant;
        float U = dot(dAP, H) * DtrRcp;

        //  Will intersection be inside of triangle?
        if (U < 0f || U > 1f)
            return RAY_MISS;

        vec3 Q = cross(dAP, dAB);
        float V = dot(Rn, Q) * DtrRcp;

        //  Will intersection be inside of triangle?
        if (V < 0f || U+V > 1f)
            return RAY_MISS;

        return dot(dAC, Q) * DtrRcp;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Volume
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsPoint(  Ray-Position,  Ray-Normal,  Point-Position,  Radius  )
    //
    [Impl(AggressiveInlining)] internal static float RayVsPoint(vec3 Rp, vec3 Rn,    vec3 P, float Radius) => RayVsSphere(Rp,Rn, P,Radius);

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/calculator/zigiqzj8dm
    //
    //      RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    //
    internal static float RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec3  dRS = Sp - Rp;
        float  RR = Sr * Sr; //  SphereRadius squared.

        float DistRP = dot(dRS, Rn); //  Distance         from  RayPos  to  ProjectedPoint.
        float DistRS = dot(dRS);     //  Distance-Squared from  RayPos  to  SpherePos.

        float dD = DistRS - DistRP*DistRP;

        //  Is ProjectedPoint inside Sphere?
        return (dD > RR) ? RAY_MISS
                         : DistRP - sqrt(RR - dD);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsLine(  Ray-Position,  Ray-Normal,    LinePointA, RadiusA,  LinePointB, RadiusB  )
    //
    [Impl(AggressiveInlining)] internal static float RayVsLine(vec3 Rp, vec3 Rn,    vec3 A, float Ar, vec3 B, float Br) => RayVsCapsule(Rp,Rn, A,Ar,B,Br);

    //==========================================================================================================================================================
    //
    //                                       RadiusB
    //                RadiusA        ___---+--.._
    //                      ,-+---```      |     `.
    //                    .`  |            |       \
    //                   /    | A          | B     |
    //                   +----●------------●-------+
    //                   \    |            |       |
    //                    *,  |            |       /
    //                      `-+---___      |    _.`
    //                               ```---+--``
    //
    //      RayVsLine(  Ray-Position,  Ray-Normal,       PointA, RadiusA,  PointB, RadiusB  )
    //
    internal static float RayVsCapsule(vec3 Rp, vec3 Rn,    vec3 A, float Ar, vec3 B, float Br) {
        vec3 dAB =  B - A;
        vec3 dAP = Rp - A;

        float dotL  = dot(dAB);
        float dotRL = dot(Rn,dAB);

        float Determinant = dotL - dotRL*dotRL;

        if (abs(Determinant) < EPS7)
            return RAY_MISS;

        float DtrmA =         dot(dAB, dAP);  //  This appears to be a vertical-alignment thing...?    Since all Wall-PointLines are vertical, this could be precomputed.
        float DtrmB = dotRL * dot( Rn, dAP);
        float DtrmC = (DtrmA - DtrmB);

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float DistA = clamp(DtrmC / Determinant);

        /*PRINT($"""

            ({DtrmA,8:0.00} - {DtrmB,8:0.00})
                  {DtrmC,8:0.00}
            ---------------------    ==    {DistA,7:0.00}
                  {Determinant,8:0.00}
        """);*/

        vec3 NearestPointOnLine = A + dAB * DistA;

        //  Find the ClosestPointOnRay from NearestPointOnLine
        float DistR = max(0f, dot(NearestPointOnLine - Rp, Rn)); //  max(0,d) -> Clamp to infront-of-Ray.
        vec3 ClosestPointOnRay = Rp + Rn * DistR;

        float DistToLine = dot(ClosestPointOnRay - NearestPointOnLine);

        float RadiusAtNearestPoint = Lerp(DistA, Ar, Br);

        if (DistToLine > RadiusAtNearestPoint*RadiusAtNearestPoint)
            return RAY_MISS;

        //  Not the actual distance to the surface of the Capsule...
        //  Hmm, projecting an arbitrarily aligned Ray to an arbitrarily aligned CapsuleSurface, that is also tapered, sounds hairy...
        return DistR - RadiusAtNearestPoint;
        //  Offset towards RayPos, so adjacent RayVsTri & RayVsQuad hits don't "eat" the LineHit.
        //  Well, this isn't a RayVsLine function...  Create a distinct version of the function for Lines...??
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsBox(  Ray-Position,  Ray-Normal,  Box-Position,  Box-Size  )
    //
    [Impl(AggressiveInlining)] internal static float RayVsBox(vec3 Rp, vec3 Rn,    vec3 Bp, vec3 Bs) => RayVsBounds(Rp,Rn, Bp,Bp+Bs);

    //==========================================================================================================================================================
    //
    //      RayVsBounds(  Ray-Position,  Ray-Normal,  MinimumBounds,  MaximumBounds  )
    //
    internal static float RayVsBounds(vec3 Rp, vec3 Rn, vec3 b0, vec3 b1) {
        //  Distance to bounding-planes from RayPos along RayNrm,
        //  for 3 Axes, Near & Far, 6 total.
        //
        //                        Near X     Far X
        //                           |         |
        //                           v         v
        //                        +Y .         .
        //           Far Y ->  - - - +---------+
        //                          /|        /|
        //                         / |       / |
        //                        /  |      /  |
        //                       +---------+   | +X
        //          Near Y ->  - | - ●-----|---+ - -   <- Near Z
        //                       |  /      |  /
        //                       | /       | /
        //                       |/        |/
        //                       +---------+ - -   <- Far Z
        //                    +Z
        //
        vec3 DistNear = (b0 - Rp) / Rn; //* Rnr;     //  NOTE: DivByZero == -∞|∞
        vec3 DistFar  = (b1 - Rp) / Rn; //* Rnr;     //        is desired in cases where ray is coplanar with an axis-plane.

        //  Reorient (swap) relative to RayPos:
        (DistNear.x,DistFar.x) = (DistNear.x > DistFar.x) ? (DistFar.x,DistNear.x) : (DistNear.x,DistFar.x);
        (DistNear.y,DistFar.y) = (DistNear.y > DistFar.y) ? (DistFar.y,DistNear.y) : (DistNear.y,DistFar.y);
        (DistNear.z,DistFar.z) = (DistNear.z > DistFar.z) ? (DistFar.z,DistNear.z) : (DistNear.z,DistFar.z);

        //  Select PlaneHits in Quadrant/Octant of Box:
        float DistToBackFace  = minof(DistFar);
        float DistToFrontFace = maxof(DistNear);

        return (DistToFrontFace > DistToBackFace) ? RAY_MISS          //  Miss.
             : (DistToBackFace  <             0f) ? DistToBackFace    //  Box is behind RayPos.  Though, Ray-Line does intersect.
             : (DistToFrontFace <             0f) ? 0f                //  RayPos is inside Box.
                                                  : DistToFrontFace;  //  Hit.
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  3D Grid Traversal
    //
    //      (float HitDist, int HitSide) = RayVsVoxelChunk(  Ray-Position,  Ray-Normal,  VoxelChunk-Position,  VoxelChunk-Size,  Voxels  )
    //
    //                   X    Y              Z
    //              -    1    2    -    -    5    6    -
    //                  / \  / \            / \  / \
    //                 /   \/   \          /   \/   \
    //                /    /\    \        /    /\    \
    //               /    /  \    \      /    /  \    \
    //    HitSide:  0    1    2    3    4    5    6    7
    //             -x   -Y   +x   +Y   -z        +z
    //
    //  Todo (unused/untested since porting to C#):
    //      Currently, input-param RayPos must start at/within bounds of VoxelChunk....?
    //
    internal static float RayVsGrid(vec3 Rp, vec3 Rn,    vec3 Vp, ivec3 Vs, uint[] Voxel) {
        (float HitDist, _) = RayVsVoxelChunk(Rp,Rn,  Vp,Vs,Voxel);
        return HitDist;
    }

    internal static (float, int) RayVsVoxelChunk(vec3 Rp, vec3 Rn,    vec3 Vp, ivec3 Vs, uint[] Voxel) {
        #if DEBUG
        {
            int VolumeCompare = Volume(Vs) - Voxel.Length;
            if      (VolumeCompare < 0) throw new System.ArgumentException("  Voxel-Volume is less than Voxel.Length.\n");
            else if (VolumeCompare > 0) throw new System.ArgumentException("  Voxel-Volume is greater than Voxel.Length.\n");
        }
        #endif

        //==========================================================================================================================================================
        float PreHitDist = 0f;
        #if true
            //  Have we yet to enter the bounds?
            PreHitDist = RayVsBox(Rp, Rn, Vp, Vs);

            if (PreHitDist < 0f)
                return (RAY_MISS, -1);

            Rp = (Rp-Vp) + (Rn*PreHitDist);

        #else
            //  Offset RayPos into local-space:
            Rp = (Rp-Vp);
        #endif

        //==========================================================================================================================================================
        ivec3 RayStep_Dir = new ivec3(
            (Rn.x < 0f) ? -1 : 1,
            (Rn.y < 0f) ? -1 : 1,
            (Rn.z < 0f) ? -1 : 1
        );
        vec3 RayStep_Dist = abs(1f / Rn);

        ivec3 RayCoord = new ivec3(
            (Rn.x < 0f) ? (int)floor(Rp.x + EPS6) : (int)floor(Rp.x - EPS6),
            (Rn.y < 0f) ? (int)floor(Rp.y + EPS6) : (int)floor(Rp.y - EPS6),
            (Rn.z < 0f) ? (int)floor(Rp.z + EPS6) : (int)floor(Rp.z - EPS6)
        );
        vec3 NextDist = new vec3(
            (Rn.x < 0f) ? (Rp.x  -  RayCoord.x) * RayStep_Dist.x
                        : (RayCoord.x+1 - Rp.x) * RayStep_Dist.x,
            (Rn.y < 0f) ? (Rp.y  -  RayCoord.y) * RayStep_Dist.y
                        : (RayCoord.y+1 - Rp.y) * RayStep_Dist.y,
            (Rn.z < 0f) ? (Rp.z  -  RayCoord.z) * RayStep_Dist.z
                        : (RayCoord.z+1 - Rp.z) * RayStep_Dist.z
        );

        //======================================================================================================================================================
        float HitDist = 0f;
        int   HitSide = -1;

        while (true) {
            //  Which Axis has a closer GridStep along Ray?
            if      (NextDist.x < NextDist.y && NextDist.x < NextDist.z) {RayCoord.x += RayStep_Dir.x;  HitSide = 1-RayStep_Dir.x;  HitDist = NextDist.x;  NextDist.x += RayStep_Dist.x;}
            else if (NextDist.y < NextDist.x && NextDist.y < NextDist.z) {RayCoord.y += RayStep_Dir.y;  HitSide = 2-RayStep_Dir.y;  HitDist = NextDist.y;  NextDist.y += RayStep_Dist.y;}
            else                                                         {RayCoord.z += RayStep_Dir.z;  HitSide = 5-RayStep_Dir.z;  HitDist = NextDist.z;  NextDist.z += RayStep_Dist.z;}

            if (RayCoord >= 0  &&  RayCoord < Vs) {
                int iVxl = RayCoord.x  +  RayCoord.y*Vs.x  +  RayCoord.z*Vs.x*Vs.y;

                if ((Voxel[iVxl] & 0x000000FFu) != 0u) //  if (Alpha != 0)      Assuming: RrGgBbAa (Red,Green,Blue,Alpha)
                    return (PreHitDist + HitDist, HitSide);

            } else {
                //  We have exited the bounds of the VoxelChunk:
                return (RAY_MISS, -1);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
