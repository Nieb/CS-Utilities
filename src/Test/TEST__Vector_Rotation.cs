
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Rotation() {
        CONOUT("\n[Utility.VEC -- Rotation]");

        //======================================================================================================================================================
        TEST("vec2 rot(P,        Theta)", true
            && rot((0f,1f), ToRad(-450f)).IsApproximately((-1f, 0f))
            && rot((0f,1f), ToRad(-360f)).IsApproximately(( 0f, 1f))
            && rot((0f,1f), ToRad(-270f)).IsApproximately(( 1f, 0f))
            && rot((0f,1f), ToRad(-180f)).IsApproximately(( 0f,-1f))
            && rot((0f,1f), ToRad( -90f)).IsApproximately((-1f, 0f))
            && rot((0f,1f),          0f ).IsApproximately(( 0f, 1f))
            && rot((0f,1f), ToRad(  90f)).IsApproximately(( 1f, 0f))
            && rot((0f,1f), ToRad( 180f)).IsApproximately(( 0f,-1f))
            && rot((0f,1f), ToRad( 270f)).IsApproximately((-1f, 0f))
            && rot((0f,1f), ToRad( 360f)).IsApproximately(( 0f, 1f))
            && rot((0f,1f), ToRad( 450f)).IsApproximately(( 1f, 0f))

            && rot((0f,1f), ToRad(-405f)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && rot((0f,1f), ToRad(-315f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && rot((0f,1f), ToRad(-225f)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))
            && rot((0f,1f), ToRad(-135f)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && rot((0f,1f), ToRad( -45f)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && rot((0f,1f), ToRad(  45f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && rot((0f,1f), ToRad( 135f)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))
            && rot((0f,1f), ToRad( 225f)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && rot((0f,1f), ToRad( 315f)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && rot((0f,1f), ToRad( 405f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
        );

        TEST("vec2 rot(P, Pivot, Theta)", true
            && rot((2f,3f), (2f,2f),         0f ).IsApproximately((2f, 3f))
            && rot((2f,3f), (2f,2f), ToRad( 90f)).IsApproximately((3f, 2f))
            && rot((2f,3f), (2f,2f), ToRad(180f)).IsApproximately((2f, 1f))
            && rot((2f,3f), (2f,2f), ToRad(270f)).IsApproximately((1f, 2f))
            && rot((2f,3f), (2f,2f), ToRad(360f)).IsApproximately((2f, 3f))
        );

        //======================================================================================================================================================
        TEST("vec3 pch(P,        Theta)", true
            && pch((0f, 0f,-2f),         0f ).IsApproximately((0f, 0f,-2f))
            && pch((0f, 0f,-2f), ToRad( 90f)).IsApproximately((0f,-2f, 0f))
            && pch((0f, 0f,-2f), ToRad(180f)).IsApproximately((0f, 0f, 2f))
            && pch((0f, 0f,-2f), ToRad(270f)).IsApproximately((0f, 2f, 0f))
            && pch((0f, 0f,-2f), ToRad(360f)).IsApproximately((0f, 0f,-2f))
        );

        TEST("vec3 pch(P, Pivot, Theta)", true
            && pch((3f, 3f, 1f), (3f, 3f, 3f),         0f ).IsApproximately(( 3f, 3f, 1f))
            && pch((3f, 3f, 1f), (3f, 3f, 3f), ToRad( 90f)).IsApproximately(( 3f, 1f, 3f))
            && pch((3f, 3f, 1f), (3f, 3f, 3f), ToRad(180f)).IsApproximately(( 3f, 3f, 5f))
            && pch((3f, 3f, 1f), (3f, 3f, 3f), ToRad(270f)).IsApproximately(( 3f, 5f, 3f))
            && pch((3f, 3f, 1f), (3f, 3f, 3f), ToRad(360f)).IsApproximately(( 3f, 3f, 1f))
        );

        //======================================================================================================================================================
        TEST("vec3 yaw(P,        Theta)", true
            && yaw((0f, 0f,-2f),         0f ).IsApproximately(( 0f, 0f,-2f))
            && yaw((0f, 0f,-2f), ToRad( 90f)).IsApproximately(( 2f, 0f, 0f))
            && yaw((0f, 0f,-2f), ToRad(180f)).IsApproximately(( 0f, 0f, 2f))
            && yaw((0f, 0f,-2f), ToRad(270f)).IsApproximately((-2f, 0f, 0f))
            && yaw((0f, 0f,-2f), ToRad(360f)).IsApproximately(( 0f, 0f,-2f))
        );

        TEST("vec3 yaw(P, Pivot, Theta)", true
            && yaw((3f, 3f, 1f), (3f, 3f, 3f),         0f ).IsApproximately(( 3f, 3f, 1f))
            && yaw((3f, 3f, 1f), (3f, 3f, 3f), ToRad( 90f)).IsApproximately(( 5f, 3f, 3f))
            && yaw((3f, 3f, 1f), (3f, 3f, 3f), ToRad(180f)).IsApproximately(( 3f, 3f, 5f))
            && yaw((3f, 3f, 1f), (3f, 3f, 3f), ToRad(270f)).IsApproximately(( 1f, 3f, 3f))
            && yaw((3f, 3f, 1f), (3f, 3f, 3f), ToRad(360f)).IsApproximately(( 3f, 3f, 1f))
        );

        //======================================================================================================================================================
        TEST("vec3 rol(P,        Theta)", true
            && rol((0f, 2f, 0f),         0f ).IsApproximately(( 0f, 2f, 0f))
            && rol((0f, 2f, 0f), ToRad( 90f)).IsApproximately(( 2f, 0f, 0f))
            && rol((0f, 2f, 0f), ToRad(180f)).IsApproximately(( 0f,-2f, 0f))
            && rol((0f, 2f, 0f), ToRad(270f)).IsApproximately((-2f, 0f, 0f))
            && rol((0f, 2f, 0f), ToRad(360f)).IsApproximately(( 0f, 2f, 0f))
        );

        TEST("vec3 rol(P, Pivot, Theta)", true
            && rol((3f, 5f, 3f), (3f, 3f, 3f),         0f ).IsApproximately(( 3f, 5f, 3f))
            && rol((3f, 5f, 3f), (3f, 3f, 3f), ToRad( 90f)).IsApproximately(( 5f, 3f, 3f))
            && rol((3f, 5f, 3f), (3f, 3f, 3f), ToRad(180f)).IsApproximately(( 3f, 1f, 3f))
            && rol((3f, 5f, 3f), (3f, 3f, 3f), ToRad(270f)).IsApproximately(( 1f, 3f, 3f))
            && rol((3f, 5f, 3f), (3f, 3f, 3f), ToRad(360f)).IsApproximately(( 3f, 5f, 3f))
        );

        //======================================================================================================================================================
        TEST("vec3 rot(P,        Axis, Theta)", true
            && rot((0f,2f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),          0f ).IsApproximately((0f,2f,0f))
            && rot((0f,2f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad( 120f)).IsApproximately((2f,0f,0f))
            && rot((0f,2f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad( 240f)).IsApproximately((0f,0f,2f))
            && rot((0f,2f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad( 360f)).IsApproximately((0f,2f,0f))

            && rot((0f,2f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad(-270f)).IsApproximately(( SQRT2, 0f,-SQRT2))
            && rot((0f,2f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad( -90f)).IsApproximately((-SQRT2, 0f, SQRT2))
            && rot((0f,2f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad(  90f)).IsApproximately(( SQRT2, 0f,-SQRT2))
            && rot((0f,2f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad( 270f)).IsApproximately((-SQRT2, 0f, SQRT2))

            &&        rot((0f,1f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad(  45f)) .IsApproximately((0.5f,SQRT2_RCP,-0.5f))
            && length(rot((0f,1f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad(  45f))).IsApproximately(1f)

            &&        rot((0f,2f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad(  45f)) .IsApproximately((1f,SQRT2,-1f))
            && length(rot((0f,2f,0f), (SQRT2_RCP,        0f, SQRT2_RCP), ToRad(  45f))).IsApproximately(2f)
        );

        TEST("vec3 rot(P, Pivot, Axis, Theta)", true
            && rot((0f,5f,0f), (0f,3f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),         0f ).IsApproximately((0f,5f,0f))
            && rot((0f,5f,0f), (0f,3f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(120f)).IsApproximately((2f,3f,0f))
            && rot((0f,5f,0f), (0f,3f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(240f)).IsApproximately((0f,3f,2f))
            && rot((0f,5f,0f), (0f,3f,0f), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(360f)).IsApproximately((0f,5f,0f))
        );

        //======================================================================================================================================================
        TEST("vec3 rot(P,        ThetaVec)", true
            && rot((0f,1f,  0f), (       0f,        0f,        0f)).IsApproximately((        0f,        1f,        0f))
            && rot((0f,1f,  0f), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately(( TWO_THIRD,-ONE_THIRD, TWO_THIRD)) //  180 along diagonal axis
            && rot((0f,2f,  0f), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)).IsApproximately((        0f,        2f,        0f)) //  360 along diagonal axis

            && length(rot((  1f,  0f,  0f), (PI /SQRT3, PI /SQRT3, PI /SQRT3))).IsApproximately(1f)
            && length(rot((  0f,  2f,  0f), (PI /SQRT3, PI /SQRT3, PI /SQRT3))).IsApproximately(2f)
            && length(rot((  0f,  0f,  3f), (PI /SQRT3, PI /SQRT3, PI /SQRT3))).IsApproximately(3f)
            && length(rot(( PI ,  0f,  0f), (PI /SQRT3, PI /SQRT3, PI /SQRT3))).IsApproximately(PI)
            && length(rot((  0f, PI2,  0f), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3))).IsApproximately(PI2)
            && length(rot((  0f,  0f, PI3), (PI3/SQRT3, PI3/SQRT3, PI3/SQRT3))).IsApproximately(PI3)
            && length(rot(( PI4,  0f,  0f), (PI4/SQRT3, PI4/SQRT3, PI4/SQRT3))).IsApproximately(PI4)

            && rot((-SQRT2_RCP, 0f, SQRT2_RCP), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately(( SQRT2_RCP, 0f,-SQRT2_RCP)) //  180 along diagonal axis
            && rot((-SQRT2_RCP, 0f, SQRT2_RCP), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)).IsApproximately((-SQRT2_RCP, 0f, SQRT2_RCP)) //  360 along diagonal axis

            && rot((0f,0f,1f), ( PI/SQRT2, 0f, PI/SQRT2)).IsApproximately(( 1f, 0f, 0f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), (-PI/SQRT2, 0f,-PI/SQRT2)).IsApproximately(( 1f, 0f, 0f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), (-PI/SQRT2, 0f, PI/SQRT2)).IsApproximately((-1f, 0f, 0f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), ( PI/SQRT2, 0f,-PI/SQRT2)).IsApproximately((-1f, 0f, 0f)) //  180 along diagonal-ish axis

            && rot((0f,0f,1f), ( 0f, PI/SQRT2, PI/SQRT2)).IsApproximately(( 0f, 1f, 0f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), ( 0f,-PI/SQRT2,-PI/SQRT2)).IsApproximately(( 0f, 1f, 0f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), ( 0f,-PI/SQRT2, PI/SQRT2)).IsApproximately(( 0f,-1f, 0f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), ( 0f, PI/SQRT2,-PI/SQRT2)).IsApproximately(( 0f,-1f, 0f)) //  180 along diagonal-ish axis

            && rot((0f,0f,1f), ( PI/SQRT2, PI/SQRT2, 0f)).IsApproximately(( 0f, 0f,-1f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), (-PI/SQRT2,-PI/SQRT2, 0f)).IsApproximately(( 0f, 0f,-1f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), (-PI/SQRT2, PI/SQRT2, 0f)).IsApproximately(( 0f, 0f,-1f)) //  180 along diagonal-ish axis
            && rot((0f,0f,1f), ( PI/SQRT2,-PI/SQRT2, 0f)).IsApproximately(( 0f, 0f,-1f)) //  180 along diagonal-ish axis

            && rot((0f,0f,1f), ( PIH/SQRT2, 0f, PIH/SQRT2)).IsApproximately(( 0.5f     , SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), (-PIH/SQRT2, 0f,-PIH/SQRT2)).IsApproximately(( 0.5f     ,-SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), (-PIH/SQRT2, 0f, PIH/SQRT2)).IsApproximately((-0.5f     ,-SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), ( PIH/SQRT2, 0f,-PIH/SQRT2)).IsApproximately((-0.5f     , SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis

            && rot((0f,0f,1f), ( 0f, PIH/SQRT2, PIH/SQRT2)).IsApproximately((-SQRT2_RCP, 0.5f     , 0.5f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), ( 0f,-PIH/SQRT2,-PIH/SQRT2)).IsApproximately(( SQRT2_RCP, 0.5f     , 0.5f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), ( 0f,-PIH/SQRT2, PIH/SQRT2)).IsApproximately(( SQRT2_RCP,-0.5f     , 0.5f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), ( 0f, PIH/SQRT2,-PIH/SQRT2)).IsApproximately((-SQRT2_RCP,-0.5f     , 0.5f)) //  90 along diagonal-ish axis

            && rot((0f,0f,1f), ( PIH/SQRT2, PIH/SQRT2, 0f)).IsApproximately((-SQRT2_RCP, SQRT2_RCP, 0.0f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), (-PIH/SQRT2,-PIH/SQRT2, 0f)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP, 0.0f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), (-PIH/SQRT2, PIH/SQRT2, 0f)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP, 0.0f)) //  90 along diagonal-ish axis
            && rot((0f,0f,1f), ( PIH/SQRT2,-PIH/SQRT2, 0f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP, 0.0f)) //  90 along diagonal-ish axis
        );

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        TEST("vec3 rot(P, Pivot, ThetaVec)", true
            && rot((5f,6f,5f), (5f,5f,5f), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately((5f+TWO_THIRD          ,5f-ONE_THIRD          ,5f+TWO_THIRD          ))
            && rot((5f,7f,5f), (5f,5f,5f), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately((5f+TWO_THIRD+TWO_THIRD,5f-ONE_THIRD-ONE_THIRD,5f+TWO_THIRD+TWO_THIRD))

            && rot((5f,6f,5f), (5f,5f,5f), (PIH/SQRT2,        0f, PIH/SQRT2)).IsApproximately((5f+SQRT2_RCP          ,5f                    ,5f-SQRT2_RCP          ))

            && length(rot((5f,6f,5f    ), (5f,5f,5f), (PI /SQRT3, PI /SQRT3, PI /SQRT3)) - (5f,5f,5f)).IsApproximately(1f)
            && length(rot((5f,7f,5f    ), (5f,5f,5f), (PI /SQRT3, PI /SQRT3, PI /SQRT3)) - (5f,5f,5f)).IsApproximately(2f)
            && length(rot((5f,5f,5f+PI ), (5f,5f,5f), (PI /SQRT3, PI /SQRT3, PI /SQRT3)) - (5f,5f,5f)).IsApproximately(PI)
            && length(rot((5f,5f,5f+PI2), (5f,5f,5f), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)) - (5f,5f,5f)).IsApproximately(PI2)
            && length(rot((5f,5f,5f+PI3), (5f,5f,5f), (PI3/SQRT3, PI3/SQRT3, PI3/SQRT3)) - (5f,5f,5f)).IsApproximately(PI3)
            && length(rot((5f,5f,5f+PI4), (5f,5f,5f), (PI4/SQRT3, PI4/SQRT3, PI4/SQRT3)) - (5f,5f,5f)).IsApproximately(PI4)
        );

        //======================================================================================================================================================
    }
}
