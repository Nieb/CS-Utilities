
namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  The starting orientations are selected for being practical, not "correct".
    //
    //  Theta in Radians.  +Theta is Clockwise, from perspective of +Axis looking towards Zero.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Direction(X, Y)  FROM  Angle(in radians).
    //
    [Impl(AggressiveInlining)] internal static vec2 FromAng(float Theta) => new vec2(sin(Theta), cos(Theta));

    //==========================================================================================================================================================
    //
    //  Direction(X, Y, Z)  FROM  Angle(in radians)
    //
    [Impl(AggressiveInlining)] internal static vec3 FromPch(float Theta, bool Z_Up=false) => !Z_Up ? new vec3(         0f,-sin(Theta),-cos(Theta))
                                                                                                   : new vec3(         0f,-sin(Theta), cos(Theta));

    [Impl(AggressiveInlining)] internal static vec3 FromYaw(float Theta, bool Z_Up=false) => !Z_Up ? new vec3( sin(Theta),         0f,-cos(Theta))
                                                                                                   : new vec3( sin(Theta), cos(Theta),         0f);

    [Impl(AggressiveInlining)] internal static vec3 FromRol(float Theta, bool Z_Up=false) => !Z_Up ? new vec3( sin(Theta), cos(Theta),         0f)
                                                                                                   : new vec3(-sin(Theta), cos(Theta),         0f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Direction(X, Y, Z)  FROM  Rotation(Pitch, Yaw)
    //
    [Impl(AggressiveInlining)]
    internal static vec3 FromPchYaw(float Pch, float Yaw, bool Z_Up=false) {
        (float SinPch, float CosPch) = sincos(Pch);
        (float SinYaw, float CosYaw) = sincos(Yaw);

        return !Z_Up ? new vec3(CosPch*SinYaw, -SinPch       , -CosPch*CosYaw)  // Y Up
                     : new vec3(CosPch*SinYaw,  CosPch*CosYaw, -SinPch       ); // Z Up
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Rotation(Pitch, Yaw, 0)    FROM    Direction(X, Y, Z)
    //
    [Impl(AggressiveInlining)]
    internal static vec3 RotFromDir(vec3 V) {
        float Pch, Yaw;

        V.z = -V.z;
        Pch = atan2(-V.y, sqrt(V.x*V.x + V.z*V.z));

        if (abs(Pch) >= (PIH-EPS6)) {
            Pch = sign(PIH, Pch);
            Yaw = 0f;
        } else {
            Yaw = wrap(atan2(V.x, V.z), -PI, PI);
        }

        return new vec3(Pch, Yaw, 0f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
