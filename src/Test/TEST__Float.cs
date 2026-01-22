
namespace UtilityTest;
internal static partial class Program {
    static void Test__Float() {
        //######################################################################################################################################################
        //######################################################################################################################################################
        #pragma warning disable 1718 // "Comparison made to same variable."
        string b(bool b) => (b ? " •" : "  "); //  ✓ ✔ ✅
        PRINT($"""

        [FLOAT]
                          |  !=  |   <  <=  |  ==  |  >=   >
            --------------+------+----------+------+----------
              -1      -0  |  {b(-1f != FLOAT_NEG_ZERO)}  |  {b(-1f < FLOAT_NEG_ZERO)}  {b(-1f <= FLOAT_NEG_ZERO)}  |  {b(-1f == FLOAT_NEG_ZERO)}  |  {b(-1f >= FLOAT_NEG_ZERO)}  {b(-1f > FLOAT_NEG_ZERO)}
               0      -0  |  {b( 0f != FLOAT_NEG_ZERO)}  |  {b( 0f < FLOAT_NEG_ZERO)}  {b( 0f <= FLOAT_NEG_ZERO)}  |  {b( 0f == FLOAT_NEG_ZERO)}  |  {b( 0f >= FLOAT_NEG_ZERO)}  {b( 0f > FLOAT_NEG_ZERO)}
               1      -0  |  {b( 1f != FLOAT_NEG_ZERO)}  |  {b( 1f < FLOAT_NEG_ZERO)}  {b( 1f <= FLOAT_NEG_ZERO)}  |  {b( 1f == FLOAT_NEG_ZERO)}  |  {b( 1f >= FLOAT_NEG_ZERO)}  {b( 1f > FLOAT_NEG_ZERO)}
            --------------+------+----------+------+----------
              -1     MIN  |  {b(-1f !=      FLOAT_MIN)}  |  {b(-1f <      FLOAT_MIN)}  {b(-1f <=      FLOAT_MIN)}  |  {b(-1f ==      FLOAT_MIN)}  |  {b(-1f >=      FLOAT_MIN)}  {b(-1f >      FLOAT_MIN)}
               0     MIN  |  {b( 0f !=      FLOAT_MIN)}  |  {b( 0f <      FLOAT_MIN)}  {b( 0f <=      FLOAT_MIN)}  |  {b( 0f ==      FLOAT_MIN)}  |  {b( 0f >=      FLOAT_MIN)}  {b( 0f >      FLOAT_MIN)}
               1     MIN  |  {b( 1f !=      FLOAT_MIN)}  |  {b( 1f <      FLOAT_MIN)}  {b( 1f <=      FLOAT_MIN)}  |  {b( 1f ==      FLOAT_MIN)}  |  {b( 1f >=      FLOAT_MIN)}  {b( 1f >      FLOAT_MIN)}
                          |      |          |      |
              -1     MAX  |  {b(-1f !=      FLOAT_MAX)}  |  {b(-1f <      FLOAT_MAX)}  {b(-1f <=      FLOAT_MAX)}  |  {b(-1f ==      FLOAT_MAX)}  |  {b(-1f >=      FLOAT_MAX)}  {b(-1f >      FLOAT_MAX)}
               0     MAX  |  {b( 0f !=      FLOAT_MAX)}  |  {b( 0f <      FLOAT_MAX)}  {b( 0f <=      FLOAT_MAX)}  |  {b( 0f ==      FLOAT_MAX)}  |  {b( 0f >=      FLOAT_MAX)}  {b( 0f >      FLOAT_MAX)}
               1     MAX  |  {b( 1f !=      FLOAT_MAX)}  |  {b( 1f <      FLOAT_MAX)}  {b( 1f <=      FLOAT_MAX)}  |  {b( 1f ==      FLOAT_MAX)}  |  {b( 1f >=      FLOAT_MAX)}  {b( 1f >      FLOAT_MAX)}
            --------------+------+----------+------+----------
              -1    -Inf  |  {b(-1f !=  FLOAT_NEG_INF)}  |  {b(-1f <  FLOAT_NEG_INF)}  {b(-1f <=  FLOAT_NEG_INF)}  |  {b(-1f ==  FLOAT_NEG_INF)}  |  {b(-1f >=  FLOAT_NEG_INF)}  {b(-1f >  FLOAT_NEG_INF)}
               0    -Inf  |  {b( 0f !=  FLOAT_NEG_INF)}  |  {b( 0f <  FLOAT_NEG_INF)}  {b( 0f <=  FLOAT_NEG_INF)}  |  {b( 0f ==  FLOAT_NEG_INF)}  |  {b( 0f >=  FLOAT_NEG_INF)}  {b( 0f >  FLOAT_NEG_INF)}
               1    -Inf  |  {b( 1f !=  FLOAT_NEG_INF)}  |  {b( 1f <  FLOAT_NEG_INF)}  {b( 1f <=  FLOAT_NEG_INF)}  |  {b( 1f ==  FLOAT_NEG_INF)}  |  {b( 1f >=  FLOAT_NEG_INF)}  {b( 1f >  FLOAT_NEG_INF)}
                          |      |          |      |
              -1     Inf  |  {b(-1f !=      FLOAT_INF)}  |  {b(-1f <      FLOAT_INF)}  {b(-1f <=      FLOAT_INF)}  |  {b(-1f ==      FLOAT_INF)}  |  {b(-1f >=      FLOAT_INF)}  {b(-1f >      FLOAT_INF)}
               0     Inf  |  {b( 0f !=      FLOAT_INF)}  |  {b( 0f <      FLOAT_INF)}  {b( 0f <=      FLOAT_INF)}  |  {b( 0f ==      FLOAT_INF)}  |  {b( 0f >=      FLOAT_INF)}  {b( 0f >      FLOAT_INF)}
               1     Inf  |  {b( 1f !=      FLOAT_INF)}  |  {b( 1f <      FLOAT_INF)}  {b( 1f <=      FLOAT_INF)}  |  {b( 1f ==      FLOAT_INF)}  |  {b( 1f >=      FLOAT_INF)}  {b( 1f >      FLOAT_INF)}
            --------------+------+----------+------+----------


            NaN == NaN:  {FLOAT_NaN == FLOAT_NaN}
            NaN != NaN:  {FLOAT_NaN != FLOAT_NaN}

            Inf == Inf:  {FLOAT_INF == FLOAT_INF}
            Inf != Inf:  {FLOAT_INF != FLOAT_INF}

            -0  ==   0:  {FLOAT_NEG_ZERO == 0f}
            -0  !=   0:  {FLOAT_NEG_ZERO != 0f}

             Inf /   0  ==  {FLOAT_INF     / 0f}
            -Inf /   0  ==  {FLOAT_NEG_INF / 0f}

             Inf / EPS  ==  {FLOAT_INF     / EPS9}
            -Inf / EPS  ==  {FLOAT_NEG_INF / EPS9}


            RAY_MISS:  {RAY_MISS}
            RAY_MISS == RAY_MISS:  {RAY_MISS == RAY_MISS}

        """);
        #pragma warning restore 1718 // "Comparison made to same variable."

        //######################################################################################################################################################
        //######################################################################################################################################################
        #if false
        PRINT($"""

        [FLOAT -- Random1() Range]
                                            *Inclusive*  *Exclusive*
                        System.Random.Next( LowerBounds, UpperBounds );
            Random1()  => (  (float)R.Next(  -1_000_000, 1_000_000+1 )  )/  1_000_000f;     -1_000_000/1_000_000:  {-1_000_000f/1_000_000f,4:0.0}
            Random1u() => (  (float)R.Next(           0, 1_000_000+1 )  )/  1_000_000f;      1_000_000/1_000_000:  { 1_000_000f/1_000_000f,4:0.0}

        """);
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
