
namespace Utility;
internal static partial class VEC_Geometry {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static float   Area(float S_x, float S_y) => (S_x * S_y);
    [Impl(AggressiveInlining)] internal static float   Area( vec2 S)              => (S.x * S.y);

    [Impl(AggressiveInlining)] internal static int     Area(int   S_x, int   S_y) => (S_x * S_y);
    [Impl(AggressiveInlining)] internal static int     Area(ivec2 S)              => (S.x * S.y);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static float Volume(float S_x, float S_y, float S_z) => (S_x * S_y * S_z);
    [Impl(AggressiveInlining)] internal static float Volume( vec3 S)                         => (S.x * S.y * S.z);

    [Impl(AggressiveInlining)] internal static int   Volume(int   S_x, int   S_y, int   S_z) => (S_x * S_y * S_z);
    [Impl(AggressiveInlining)] internal static int   Volume(ivec3 S)                         => (S.x * S.y * S.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static float Circle_SurfaceArea(float Rds = 1f) => PI * (Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
  //[Impl(AggressiveInlining)] internal static float Cylinder_SurfaceA__a(float Rds = 1f, float Height = 2f) => (PI2 * (Rds*Rds)) + (PI2 * Rds * Height);
    [Impl(AggressiveInlining)] internal static float Cylinder_SurfaceArea(float Rds = 1f, float Height = 2f) => PI2 *  Rds      * (Rds + Height);
    [Impl(AggressiveInlining)] internal static float Cylinder_Volume     (float Rds = 1f, float Height = 2f) => PI  * (Rds*Rds) *        Height;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static float Sphere_SurfaceArea(float Rds = 1f) => PI4        * (Rds*Rds);
    [Impl(AggressiveInlining)] internal static float Sphere_Volume     (float Rds = 1f) => PI*(4f/3f) * (Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
