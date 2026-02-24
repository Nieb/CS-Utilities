
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
    [Impl(AggressiveInlining)] internal static bool PointVsBox   (vec3 P, vec3 Bp, vec3 Bs) => (P >= Bp && P <= Bp+Bs);
    [Impl(AggressiveInlining)] internal static bool PointVsBounds(vec3 P, vec3 b0, vec3 b1) => (P >= b0 && P <= b1);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      PointVsCylinder(  Point,  Cylinder-Position,  Cylinder-Radius,  Cylinder-Height  )
    //
    internal static bool PointVsCylinder(vec3 P, vec3 Cp, float Cr, float Ch) => (
           P.y >= Cp.y                  //  Is Point in same vertical space as Cylinder?
        && P.y <= Cp.y+Ch
        && dot(P.xz - Cp.xz) <= (Cr*Cr) //  Is Point inside of Cylinder-Radius?
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All RayVs~~~() functions return:  HitDistance                           HitPos = RayPos + (RayNrm*HitDist);
    //
    //                         Surface      Ray
    //      Distance < 0.0      |-->        -->  Surface/Volume is Behind Ray.
    //
    //      Distance = 0.0                       RayPos is inside Volume.
    //
    //      Distance > 0.0      |-->        <--  Surface/Volume is InFront of Ray.
    //
    //  If surface has bounds  and  Ray-Line does not intersect, it will return:  RAY_MISS
    //
    //==========================================================================================================================================================
    internal static readonly float RAY_MISS = float.NegativeInfinity;

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
    internal static float RayVsQuadX(vec3 Rp, vec3 Rn,    vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.x - Rp.x) / Rn.x;
        vec2 Hp2 = (Rp + (Rn*HitDist)).zy;
        vec2 Qp2 = Qp.zy;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    internal static float RayVsQuadY(vec3 Rp, vec3 Rn,    vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.y - Rp.y) / Rn.y;
        vec2 Hp2 = (Rp + (Rn*HitDist)).xz;
        vec2 Qp2 = Qp.xz;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    internal static float RayVsQuadZ(vec3 Rp, vec3 Rn,    vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.z - Rp.z) / Rn.z;
        vec2 Hp2 = (Rp + (Rn*HitDist)).xy;
        vec2 Qp2 = Qp.xy;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    //==========================================================================================================================================================
    //
    //      RayVsQuad(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Normal,  Quad-???  )
    //
    internal static float RayVsQuad(vec3 Rp, vec3 Rn,    vec3 Qp, vec3 Qn, vec3 Qt) {
        //float WhichSide =  dot(Qn, Rp-Qp);
        //float Dot_RnPn  = -dot(Rn, Qn);

        //float Distance  = WhichSide / Dot_RnPn;

        //vec3 HitPos = Rp + (Rn*Distance);

        //
        //  Hmm, how to express Quad orientation...
        //
        //      Use vec3 "Quad-Bounds" instead?  Normal & size can be derived...  "Quad-Extent" ?
        //          Nope, this still lacks orientation...
        //
        //      Need 3 Vec3s to define quad-plane.
        //          Quad_Pos, Quad_Nrm, Quad_NrmTangent
        //                    Quad_Nrm, Quad_NrmTangent, Quad_NrmBiTangent
        //
        //  Is this even something useful or practical...?
        //
        //      Or 1 Vec3 and 1 quaternion.  :(
        //          Quad_Pos, Quad_Orientation
        //

        return RAY_MISS;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsTriangle(  Ray-Position,  Ray-Normal,    Triangle-PointA,  Triangle-PointB,  Triangle-PointC,    BackFaceTest  )
    //
    internal static float RayVsTriangle(vec3 Rp, vec3 Rn,   vec3 Ta, vec3 Tb, vec3 Tc,   bool BackFaceTest = false) {
        vec3 dAB = Tb - Ta;
        vec3 dAC = Tc - Ta;

        vec3 H = cross(Rn, dAC);
        float Determinant = dot(dAB, H);

        //  Is Ray pointing in the same direction as SurfaceNormal?
        if (Determinant < 0f && !BackFaceTest)
            return RAY_MISS;

        //  Is Ray coplanar with Triangle Surface?
        //if (abs(Determinant) < EPSILON)
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
    //  Geometric solution.
    //
    //  https://www.desmos.com/calculator/zigiqzj8dm
    //
    //      RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    //
    internal static float RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec3  dRS  = Sp - Rp;
        float SrSr = Sr * Sr;

        float DistRP = dot(dRS, Rn); //  Distance         from  RayPos  to  ProjectedPoint.
        float DistRS = dot(dRS);     //  Distance-Squared from  RayPos  to  SpherePos.

        float dD = DistRS - DistRP*DistRP;

        //  Is ProjectedPoint inside Sphere?
        return (dD > SrSr) ? RAY_MISS
                           : DistRP - sqrt(SrSr - dD);

        //float HitDist0 = DistRP - dD;  vec3 HitPos0 = Rp + (Rn * HitDist0);
        //float HitDist1 = DistRP + dD;  vec3 HitPos1 = Rp + (Rn * HitDist1);
        //return new vec4(HitPos0, HitDist0);
    }

    //==========================================================================================================================================================
    //
    //  Analytic solution.
    //
    //      RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    //
    //internal static vec4 RayVsSphere_(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
    //    vec3 dSR = Rp - Sp;
    //
    //    float a =      dot( Rn, Rn );
    //    float b = 2f * dot( Rn, dSR);
    //    float c =      dot(dSR, dSR) - Sr*Sr;
    //
    //    float Qn = sqrt(b*b - 4f*a*c);
    //    float Qd = 2f * a;
    //
    //    float HitDist0 = (-b - Qn) / Qd;
    //    float HitDist1 = (-b + Qn) / Qd;
    //
    //    vec3 HitPos0 = Rp + (Rn * HitDist0);
    //    vec3 HitPos1 = Rp + (Rn * HitDist1);
    //
    //    return new vec4(HitPos0, HitDist0);
    //}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsBox(  Ray-Position,  Ray-Normal,  Box-Position,  Box-Size  )
    //
    internal static float RayVsBox(vec3 Rp, vec3 Rn, vec3 Bp, vec3 Bs) {
        //  Distance to bounding-planes from RayPos along RayNrm,
        //  for 3 Axes, Near & Far, 6 total.
        //
        //          DistNearX
        //              |   DistFarX
        //          +Y  v      v                                    |         |
        //              .      .                                    | +Z      |
        //          - - +------+ - -  <- DistFarY               - - +---------+ - -   <- DistFarZ
        //              |      |                             +Y    /         /
        //              |      |                                | /       | /
        //              |      |                                |/        |/
        //          - - ●------+ - -  <- DistNearY          - - ●---------+ - -   <- DistNearZ
        //              .      .                                            +X
        //              .      .  +X
        //
        vec3 DistNear = (Bp    - Rp) / Rn; //  Note: DivByZero == -∞|∞
        vec3 DistFar  = (Bp+Bs - Rp) / Rn; //        is desired in cases where ray is coplanar with an axis-plane.

        //  Reorient (swap) relative to RayPos:
        (DistNear.x, DistFar.x) = (DistNear.x > DistFar.x) ? (DistFar.x, DistNear.x) : (DistNear.x, DistFar.x);
        (DistNear.y, DistFar.y) = (DistNear.y > DistFar.y) ? (DistFar.y, DistNear.y) : (DistNear.y, DistFar.y);
        (DistNear.z, DistFar.z) = (DistNear.z > DistFar.z) ? (DistFar.z, DistNear.z) : (DistNear.z, DistFar.z);

        //  Select PlaneHits in Quadrant/Octant of Box:
        float DistToFrontFace = maxof(DistNear);
        float DistToBackFace  = minof(DistFar);

        return (DistToFrontFace > DistToBackFace) ? RAY_MISS          //  Miss.
             : (DistToBackFace  <             0f) ? DistToBackFace    //  Box is behind RayPos.  Though, Ray-Line does intersect.
             : (DistToFrontFace <=            0f) ? 0f                //  RayPos is inside Box.
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
            if      (VolumeCompare < 0) throw new System.ArgumentException("Voxel-Volume is lesser than Voxel.Length.");
            else if (VolumeCompare > 0) throw new System.ArgumentException("Voxel-Volume is greater than Voxel.Length.");
        }
        #endif

        //==========================================================================================================================================================
        //  Offset RayPos into VoxelChunk's local space:
        Rp = Rp - Vp;

        ivec3 Ray_StepDir = new ivec3(
            (Rn.x < 0f) ? -1 : 1,
            (Rn.y < 0f) ? -1 : 1,
            (Rn.z < 0f) ? -1 : 1
        );
        vec3 Ray_StepDist = abs(1f / Rn);

        ivec3 Ray_Coord = new ivec3(
            (Rn.x < 0f) ? (int)floor(Rp.x + EPSILON) : (int)floor(Rp.x - EPSILON),
            (Rn.y < 0f) ? (int)floor(Rp.y + EPSILON) : (int)floor(Rp.y - EPSILON),
            (Rn.z < 0f) ? (int)floor(Rp.z + EPSILON) : (int)floor(Rp.z - EPSILON)
        );
        vec3 Ray_Travel = new vec3(
            (Rn.x < 0f)  ?  (Rp.x - Ray_Coord.x) * Ray_StepDist.x  :  (Ray_Coord.x+1 - Rp.x) * Ray_StepDist.x,
            (Rn.y < 0f)  ?  (Rp.y - Ray_Coord.y) * Ray_StepDist.y  :  (Ray_Coord.y+1 - Rp.y) * Ray_StepDist.y,
            (Rn.z < 0f)  ?  (Rp.z - Ray_Coord.z) * Ray_StepDist.z  :  (Ray_Coord.z+1 - Rp.z) * Ray_StepDist.z
        );

        //======================================================================================================================================================
        float HitDist = 0f;
        int   HitSide = -1;

        while (true) {
            //  Which Axis has a closer GridStep along Ray?
            if      (Ray_Travel.x < Ray_Travel.y && Ray_Travel.x < Ray_Travel.z) {HitDist = Ray_Travel.x;  Ray_Travel.x += Ray_StepDist.x;  Ray_Coord.x += Ray_StepDir.x;  HitSide = 1-Ray_StepDir.x;}
            else if (Ray_Travel.y < Ray_Travel.x && Ray_Travel.y < Ray_Travel.z) {HitDist = Ray_Travel.y;  Ray_Travel.y += Ray_StepDist.y;  Ray_Coord.y += Ray_StepDir.y;  HitSide = 2-Ray_StepDir.y;}
            else                                                                 {HitDist = Ray_Travel.z;  Ray_Travel.z += Ray_StepDist.z;  Ray_Coord.z += Ray_StepDir.z;  HitSide = 5-Ray_StepDir.z;}

            //  Are we still inside the bounds of the VoxelChunk?
            bool InsideBounds = (
                Ray_Coord.x >= 0 && Ray_Coord.x <= Vs.x &&
                Ray_Coord.y >= 0 && Ray_Coord.y <= Vs.y &&
                Ray_Coord.z >= 0 && Ray_Coord.z <= Vs.z
            );

            if (!InsideBounds) {
                //  We hit/exited the bounds of the VoxelChunk:
                return (RAY_MISS, -1);

            } else {
                int iVox = Ray_Coord.x
                         + Ray_Coord.y * Vs.y
                         + Ray_Coord.z * Vs.z;

                if ((Voxel[iVox] & 0xFF000000) != 0) //  if (Alpha != 0)    Assuming:  AaBbGgRr (Alpha,Blue,Green,Red)
                    return (HitDist, HitSide);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
