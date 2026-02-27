
namespace Utility;
internal static partial class VEC_Geometry {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static v1 Area(v1 S_x, v1 S_y) => (S_x * S_y);
    [Impl(AggressiveInlining)] internal static v1 Area(v2 S)           => (S.x * S.y);

    [Impl(AggressiveInlining)] internal static i1 Area(i1 S_x, i1 S_y) => (S_x * S_y);
    [Impl(AggressiveInlining)] internal static i1 Area(i2 S)           => (S.x * S.y);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1 Volume(v1 S_x, v1 S_y, v1 S_z) => (S_x * S_y * S_z);
    [Impl(AggressiveInlining)] internal static v1 Volume(v3 S)                   => (S.x * S.y * S.z);

    [Impl(AggressiveInlining)] internal static i1 Volume(i1 S_x, i1 S_y, i1 S_z) => (S_x * S_y * S_z);
    [Impl(AggressiveInlining)] internal static i1 Volume(i3 S)                   => (S.x * S.y * S.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static v1 Circle_SurfaceArea(v1 Rds = 1f) => PI * (Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
  //[Impl(AggressiveInlining)] internal static v1 Cylinder_SurfaceA__a(v1 Rds = 1f, v1 Height = 2f) => (PI2 * (Rds*Rds)) + (PI2 * Rds * Height);
    [Impl(AggressiveInlining)] internal static v1 Cylinder_SurfaceArea(v1 Rds = 1f, v1 Height = 2f) => PI2 *  Rds      * (Rds + Height);
    [Impl(AggressiveInlining)] internal static v1 Cylinder_Volume     (v1 Rds = 1f, v1 Height = 2f) => PI  * (Rds*Rds) *        Height;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 Sphere_SurfaceArea(v1 Rds = 1f) => PI4   * (Rds*Rds);
    [Impl(AggressiveInlining)] internal static v1 Sphere_Volume     (v1 Rds = 1f) => PI_43 * (Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
