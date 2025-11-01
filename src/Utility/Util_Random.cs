
namespace Utility;
internal static class Random {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                      *Inclusive*  *Exclusive*
    //  System.Random.Next( LowerBounds, UpperBounds );
    //
    //  Note:  Random is not ThreadSafe.
    //
    private static readonly System.Random R = new();

  //private static readonly object                ThreadLock = new();
  //private static readonly System.Threading.Lock ThreadLock = new();
    //  https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/#threading
    //  https://learn.microsoft.com/en-us/dotnet/api/system.threading.lock?view=net-9.0

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                  *Inclusive*  *Inclusive*
    //      RandomType( LowerBounds, UpperBounds );
    //
    internal static  byte RandomByte ( byte L = MIN_BYTE ,  byte U = MAX_BYTE -1) => ClampToByte (R.Next(L, U+1));
    internal static short RandomShort(short L = MIN_SHORT, short U = MAX_SHORT-1) => ClampToShort(R.Next(L, U+1));
    internal static   int RandomInt  (  int L = MIN_INT  ,   int U = MAX_INT  -1) =>              R.Next(L, U+1);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static  uint RandomUint ( uint L = MIN_UINT ,  uint U = MAX_UINT ) => ClampToUint(R.NextInt64((long)L, (long)U+1));

    //==========================================================================================================================================================
    internal static  void RandomBytes(this byte[] A) => R.NextBytes(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      -1.0 to 1.0
    //       0.0 to 1.0
    //
    internal static float Random1()  => ((float)R.Next(-1_000_000, 1_000_000+1))/1_000_000f;
    internal static float Random1u() => ((float)R.Next(         0, 1_000_000+1))/1_000_000f;

    internal static vec2  Random2()  => normalize(new vec2(Random1() ,Random1() ));
    internal static vec2  Random2u() => normalize(new vec2(Random1u(),Random1u()));

    internal static vec3  Random3()  => normalize(new vec3(Random1() ,Random1() ,Random1() ));
    internal static vec3  Random3u() => normalize(new vec3(Random1u(),Random1u(),Random1u()));

    //==========================================================================================================================================================
    //
    //  Pitch  RotX  -->   Latitude(South –90  +90 North)  -->  TextureCoord Y|V
    //  Yaw    RotY  -->  Longitude(West -180 +180 East )  -->  TextureCoord X|U
    //
    #if false
        internal static vec3 Random3a() {
            float Pch = (R.NextSingle() - 0.5f) * PI;
            float Yaw = (R.NextSingle() - 0.5f) * PI2;

            //  Bias away from poles to get an even distribution:
            Pch = asin(Pch);

            float CosPch = cos(Pch);

            return normalize(new vec3(
                 CosPch * sin(Yaw),
                         -sin(Pch),
                -CosPch * cos(Yaw)
            ));
        }
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
