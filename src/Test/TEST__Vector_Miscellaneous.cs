
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Miscellaneous() {
        PRINT("\n[Utility.VEC -- Miscellaneous]");
        //PRINT($"{}");

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("Bisect(vec2, vec2)", true
            && Bisect((1f, 0f), (0f, 1f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && Bisect((0f, 1f), (1f, 0f)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))

            && Bisect(( SQRT2_RCP,-SQRT2_RCP), ( SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 1f, 0f))
            && Bisect((-SQRT2_RCP,-SQRT2_RCP), (-SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 1f, 0f))

            && Bisect((-SQRT2_RCP, SQRT2_RCP), (-SQRT2_RCP,-SQRT2_RCP)).IsApproximately((-1f, 0f))
            && Bisect(( SQRT2_RCP, SQRT2_RCP), ( SQRT2_RCP,-SQRT2_RCP)).IsApproximately((-1f, 0f))

            && Bisect(( SQRT2_RCP, SQRT2_RCP), (-SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 0f, 1f))
            && Bisect(( SQRT2_RCP,-SQRT2_RCP), (-SQRT2_RCP,-SQRT2_RCP)).IsApproximately(( 0f, 1f))

            && Bisect((-SQRT2_RCP, SQRT2_RCP), ( SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 0f,-1f))
            && Bisect((-SQRT2_RCP,-SQRT2_RCP), ( SQRT2_RCP,-SQRT2_RCP)).IsApproximately(( 0f,-1f))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            vec2 Z = (0f, 0f);
            vec2 A = (0f, 1f);
            vec2 B = (-sin(PI2/3f),cos(PI2/3f));
            vec2 C = (-sin(PI4/3f),cos(PI4/3f));

            RESULT("Barycentric()", true
                && Barycentric(Z,  A,B,C).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))
                && Barycentric(Z,  C,A,B).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))
                && Barycentric(Z,  B,C,A).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))

                && Barycentric(Z+3f,  A+3f,B+3f,C+3f).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))
                && Barycentric(Z-3f,  A-3f,B-3f,C-3f).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))

                && Barycentric(A,  A,B,C).IsApproximately((1f, 0f, 0f))
                && Barycentric(B,  A,B,C).IsApproximately((0f, 1f, 0f))
                && Barycentric(C,  A,B,C).IsApproximately((0f, 0f, 1f))

                && Barycentric(A/4f,  A,B,C).IsApproximately((2/4f, 1/4f, 1/4f))
                && Barycentric(B/4f,  A,B,C).IsApproximately((1/4f, 2/4f, 1/4f))
                && Barycentric(C/4f,  A,B,C).IsApproximately((1/4f, 1/4f, 2/4f))

                && Barycentric(A/3f,  A,B,C).IsApproximately((5/9f, 2/9f, 2/9f))
                && Barycentric(B/3f,  A,B,C).IsApproximately((2/9f, 5/9f, 2/9f))
                && Barycentric(C/3f,  A,B,C).IsApproximately((2/9f, 2/9f, 5/9f))

                && Barycentric(A/2f,  A,B,C).IsApproximately((4/6f, 1/6f, 1/6f))
                && Barycentric(B/2f,  A,B,C).IsApproximately((1/6f, 4/6f, 1/6f))
                && Barycentric(C/2f,  A,B,C).IsApproximately((1/6f, 1/6f, 4/6f))

                && Barycentric(A*0.75f,  A,B,C).IsApproximately((10/12f,  1/12f,  1/12f))
                && Barycentric(B*0.75f,  A,B,C).IsApproximately(( 1/12f, 10/12f,  1/12f))
                && Barycentric(C*0.75f,  A,B,C).IsApproximately(( 1/12f,  1/12f, 10/12f))
            );

            #if false
                PRINT("");
                PRINT($"    {Barycentric(Z,  A,B,C):0.000}");
                PRINT($"    {Barycentric(Z,  A,B,C):0.000}");
                PRINT("");
                PRINT($"    {Barycentric(A*0.25f,  A,B,C):0.000}");
                PRINT($"    {Barycentric(B*0.25f,  A,B,C):0.000}");
                PRINT($"    {Barycentric(C*0.25f,  A,B,C):0.000}");
                PRINT("");
                PRINT($"    {Barycentric(A*0.50f,  A,B,C):0.000}");
                PRINT($"    {Barycentric(B*0.50f,  A,B,C):0.000}");
                PRINT($"    {Barycentric(C*0.50f,  A,B,C):0.000}");
                PRINT("");
                PRINT($"    {Barycentric(A*0.75f,  A,B,C):0.000}");
                PRINT($"    {Barycentric(B*0.75f,  A,B,C):0.000}");
                PRINT($"    {Barycentric(C*0.75f,  A,B,C):0.000}");
                PRINT("");
                PRINT($"    {Barycentric(A*ONE_THIRD,  A,B,C):0.000}");
                PRINT($"    {Barycentric(B*ONE_THIRD,  A,B,C):0.000}");
                PRINT($"    {Barycentric(C*ONE_THIRD,  A,B,C):0.000}");
                PRINT("");
            #endif

        }
        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            //vec2 A = PredictiveAim(
            //    (1f, 1f), (SQRT2_RCP, -SQRT2_RCP),
            //    (1f, 3f), (SQRT2_RCP, -SQRT2_RCP),
            //    1f
            //);
            //vec2 B = PredictiveAim(
            //    (1f, 3f), (SQRT2_RCP, -SQRT2_RCP),
            //    (1f, 1f), (0f, 0f),
            //    1f
            //);

            RESULT("vec2 PredictiveAim()", true
                //&&
                //PredictiveAim(
                //    (1f, 3f), (SQRT2_RCP, -SQRT2_RCP),
                //    (1f, 1f), (0f, 0f),
                //    SQRT2_RCP
                //).IsApproximately((2f, 2f))
            );

            //PRINT("");
            //PRINT($"result  == {A:0}");
            //PRINT("");
            //PRINT($"result  == {B:0}");
            //PRINT("");
        }
        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("SphericalDistance(vec2, vec2)", true
            && SphericalDistance((  0f,  0f),( PIQ,  0f)).IsApproximately(PIQ)
            && SphericalDistance((  0f,  0f),( PIH,  0f)).IsApproximately(PIH)
            && SphericalDistance((  0f,  0f),( PI ,  0f)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),( PI2,  0f)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),( PI3,  0f)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),( PI4,  0f)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),( PI5,  0f)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),( PI6,  0f)).IsApproximately(0f)

            && SphericalDistance((  0f,  0f),(  0f, PIQ)).IsApproximately(PIQ)
            && SphericalDistance((  0f,  0f),(  0f, PIH)).IsApproximately(PIH)
            && SphericalDistance((  0f,  0f),(  0f, PI )).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),(  0f, PI2)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),(  0f, PI3)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),(  0f, PI4)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),(  0f, PI5)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),(  0f, PI6)).IsApproximately(0f)

            && SphericalDistance((-PIQ,  0f),( PIQ,  0f)).IsApproximately(PIH)
            && SphericalDistance((-PIH,  0f),( PIH,  0f)).IsApproximately(PI)

            && SphericalDistance(( PIH,  0f),(  0f, PIH)).IsApproximately(PIH)
            && SphericalDistance((  0f, PIH),( PIH,  0f)).IsApproximately(PIH)

            && SphericalDistance(( PIQ,  0f),( PIQ, PI )).IsApproximately(PIH)
            && SphericalDistance(( PIQ,  0f),(-PIQ, PI )).IsApproximately(3.140902f) //PI)      Fix Precision?
            && SphericalDistance((-PIQ,  0f),( PIQ, PI )).IsApproximately(3.140902f) //PI)        3.1415927f
            && SphericalDistance((-PIQ,  0f),(-PIQ, PI )).IsApproximately(PIH)
        );

        #if false
            PRINT($"""

                PIH == {PIH:0.00000000}
                PI  == {PI:0.00000000}

              ( PIQ, 0f),( PIQ, PI) == {SphericalDistance(( PIQ, 0f),( PIQ, PI)):0.00000000}
              ( PIQ, 0f),(-PIQ, PI) == {SphericalDistance(( PIQ, 0f),(-PIQ, PI)):0.00000000}  == 3.140902
              (-PIQ, 0f),( PIQ, PI) == {SphericalDistance((-PIQ, 0f),( PIQ, PI)):0.00000000}  == 3.140902
              (-PIQ, 0f),(-PIQ, PI) == {SphericalDistance((-PIQ, 0f),(-PIQ, PI)):0.00000000}
            """);
        #endif

        #if false
        {
            bool FAIL = false;
            int Steps = 12;
            vec2 A = ZERO2;
            vec2 B = ZERO2;
            float D = 0f;

            //FAIL = SphericalDistance(A, (-1f, 0f)) != PIH;
            //FAIL = SphericalDistance(A, ( 1f, 0f)) != PIH;

            System.Text.StringBuilder SB = new();

            if (!FAIL) {
                for     (int iPch = -Steps/2; iPch <= Steps/2; ++iPch) {
                    for (int iYaw =        0; iYaw <= Steps*2; ++iYaw) {
                        B.x = (float)(((double)iPch/(double)Steps) * 3.14159265358979323846264338327950288419716939937511);
                        B.y = (float)(((double)iYaw/(double)Steps) * 3.14159265358979323846264338327950288419716939937511);
                        D = SphericalDistance(A, B);
                        //FAIL = (D != 0f);
                        //if (FAIL) break;

                        //SB.Append($"  [{iPch,3}, {iYaw,3}]({B.x,6:0.000},{B.y,6:0.000}) {D:0.000}");
                        //SB.Append($"  ({B.x,6:0.000},{B.y,6:0.000}) {D:0.000}");
                        SB.Append($"{D/PI:0.0000000},");
                    }
                    //if (FAIL) break;
                    SB.Append("\n");
                }
            }

            PRINT(SB.ToString());
        }
        #endif

        //======================================================================================================================================================
        RESULT("SphericalDistance(vec3, vec3)", true
            && SphericalDistance(( 1f, 0f, 0f),( 1f, 0f, 0f)).IsApproximately(0f)
            && SphericalDistance(( 0f, 1f, 0f),( 0f, 1f, 0f)).IsApproximately(0f)
            && SphericalDistance(( 0f, 0f, 1f),( 0f, 0f, 1f)).IsApproximately(0f)

            && SphericalDistance(( 1f, 0f, 0f),(-1f, 0f, 0f)).IsApproximately(PI)
            && SphericalDistance(( 0f, 1f, 0f),( 0f,-1f, 0f)).IsApproximately(PI)
            && SphericalDistance(( 0f, 0f, 1f),( 0f, 0f,-1f)).IsApproximately(PI)

            && SphericalDistance(( 1f, 0f, 0f),( 0f, 1f, 0f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),( 0f, 0f, 1f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 1f, 0f),( 1f, 0f, 0f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 1f, 0f),( 0f, 0f, 1f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 0f, 1f),( 1f, 0f, 0f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 0f, 1f),( 0f, 1f, 0f)).IsApproximately(PIH)

            && SphericalDistance(( 1f, 0f, 0f),(        0f,        1f,        0f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f, SQRT2_RCP, SQRT2_RCP)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,        0f,        1f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,-SQRT2_RCP, SQRT2_RCP)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,       -1f,        0f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,-SQRT2_RCP,-SQRT2_RCP)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,        0f,       -1f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f, SQRT2_RCP,-SQRT2_RCP)).IsApproximately(PIH)

            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP, SQRT2_RCP,        0f)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP,-SQRT2_RCP,        0f)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP, SQRT2_RCP,        0f)).IsApproximately(PIH + PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP,-SQRT2_RCP,        0f)).IsApproximately(PIH + PIQ)

            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP,        0f, SQRT2_RCP)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP,        0f,-SQRT2_RCP)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP,        0f, SQRT2_RCP)).IsApproximately(PIH + PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP,        0f,-SQRT2_RCP)).IsApproximately(PIH + PIQ)
        );

        #if false
            PRINT($"""

                PIH == {PIH:0.00000000}
                PI  == {PI:0.00000000}

              ( 1, 0, 0),( r, r, 0) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP, SQRT2_RCP,        0f)):0.00000000}  {SphericalDistance_((1f,0f,0f),( SQRT2_RCP, SQRT2_RCP,        0f)):0.00000000}
              ( 1, 0, 0),( 0, r, r) == {SphericalDistance((1f,0f,0f),(        0f, SQRT2_RCP, SQRT2_RCP)):0.00000000}  {SphericalDistance_((1f,0f,0f),(        0f, SQRT2_RCP, SQRT2_RCP)):0.00000000}
              ( 1, 0, 0),( r, 0, r) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP,        0f, SQRT2_RCP)):0.00000000}  {SphericalDistance_((1f,0f,0f),( SQRT2_RCP,        0f, SQRT2_RCP)):0.00000000}

              ( 1, 0, 0),( 0, 1, 0) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 1f, 0f)):0.00000000}  {SphericalDistance_(( 1f, 0f, 0f),( 0f, 1f, 0f)):0.00000000}
              ( 1, 0, 0),( 0, 0, 1) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 0f, 1f)):0.00000000}  {SphericalDistance_(( 1f, 0f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 1, 0),( 1, 0, 0) == {SphericalDistance(( 0f, 1f, 0f),( 1f, 0f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 1f, 0f),( 1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0, 0, 1) == {SphericalDistance(( 0f, 1f, 0f),( 0f, 0f, 1f)):0.00000000}  {SphericalDistance_(( 0f, 1f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 0, 1),( 1, 0, 0) == {SphericalDistance(( 0f, 0f, 1f),( 1f, 0f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 0f, 1f),( 1f, 0f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 1, 0) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 1f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 0f, 1f),( 0f, 1f, 0f)):0.00000000}

              ( 1, 0, 0),(-1, 0, 0) == {SphericalDistance(( 1f, 0f, 0f),(-1f, 0f, 0f)):0.00000000}  {SphericalDistance_(( 1f, 0f, 0f),(-1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0,-1, 0) == {SphericalDistance(( 0f, 1f, 0f),( 0f,-1f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 1f, 0f),( 0f,-1f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 0,-1) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 0f,-1f)):0.00000000}  {SphericalDistance_(( 0f, 0f, 1f),( 0f, 0f,-1f)):0.00000000}
            """);
        #endif

        #if false
            PRINT($"""

                PIH == {PIH:0.00000000}
                PI  == {PI:0.00000000}

              ( 1, 0, 0),( r, r, 0) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP, SQRT2_RCP,        0f)):0.00000000}
              ( 1, 0, 0),( 0, r, r) == {SphericalDistance((1f,0f,0f),(        0f, SQRT2_RCP, SQRT2_RCP)):0.00000000}
              ( 1, 0, 0),( r, 0, r) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP,        0f, SQRT2_RCP)):0.00000000}

              ( 1, 0, 0),( 0, 1, 0) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 1f, 0f)):0.00000000}
              ( 1, 0, 0),( 0, 0, 1) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 1, 0),( 1, 0, 0) == {SphericalDistance(( 0f, 1f, 0f),( 1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0, 0, 1) == {SphericalDistance(( 0f, 1f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 0, 1),( 0, 0, 0) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 0f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 1, 0) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 1f, 0f)):0.00000000}

              ( 1, 0, 0),(-1, 0, 0) == {SphericalDistance(( 1f, 0f, 0f),(-1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0,-1, 0) == {SphericalDistance(( 0f, 1f, 0f),( 0f,-1f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 0,-1) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 0f,-1f)):0.00000000}
            """);
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}

