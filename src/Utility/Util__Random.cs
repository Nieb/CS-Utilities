
namespace Utility;
internal static class Random {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Note:  Random is not ThreadSafe...
    //
    //                      *Inclusive*  *Exclusive*
    //  System.Random.Next( LowerBounds, UpperBounds );
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
    internal static  byte RandomByte ( byte L=MIN_U8 ,  byte U=MAX_U8 ) => ClampToByte (R.Next     (i32(L), i32(U)+1));
    internal static short RandomShort(short L=MIN_I16, short U=MAX_I16) => ClampToShort(R.Next     (i32(L), i32(U)+1));
    internal static   int RandomInt  (  int L=MIN_I32,   int U=MAX_I32) => ClampToInt  (R.NextInt64(i64(L), i64(U)+1));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static  uint RandomUint ( uint L=MIN_U32,  uint U=MAX_U32) => ClampToUint (R.NextInt64(i64(L), i64(U)+1));

    //==========================================================================================================================================================
    //
    //  Fill byte[] array with random values.
    //
    //      byte[] MyArray = new byte[256];
    //      MyArray.Randomize();
    //
    internal static void Randomize(this byte[] A) => R.NextBytes(A);

    //==========================================================================================================================================================
    //
    //      -1.0 to 1.0
    //       0.0 to 1.0
    //
    internal static float Random1()  => f32(R.Next(-1_000_000, 1_000_000+1))/1_000_000f;
    internal static float Random1u() => f32(R.Next(         0, 1_000_000+1))/1_000_000f;

    internal static vec2  Random2()  => normalize(new vec2(Random1() ,Random1() ));
    internal static vec2  Random2u() => normalize(new vec2(Random1u(),Random1u()));

    internal static vec3  Random3()  => normalize(new vec3(Random1() ,Random1() ,Random1() ));
    internal static vec3  Random3u() => normalize(new vec3(Random1u(),Random1u(),Random1u()));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
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
