
namespace UtilityTest;
internal static partial class Program {
static void Test___() {
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{

    for(int i=-5; i<36; ++i) {
        //CONOUT($"  [{i,2}]  {        max(0,    (1 << min(30,i))  )         ,2}");
        CONOUT($"  [{i,2}]  {                  (1 << clamp(i, 0,30))            ,2}");
    }



    byte A = 0b001;
    byte B = 0b000;
    byte C = 0b100;

    byte Combination = u8(A | B | C);
    byte        Mask = 0b111;
    byte      Select = u8(Combination ^ Mask);

    TESTOUT($"""
        {IntToBinString(Combination)}  xor  {IntToBinString(Mask)}  ==  {IntToBinString(Select)}
    """);
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    TESTOUT("\nTesting \"min(A,B,C,D)\" ...");

    const int I = (1 << 24);

     float[] Sum    = new  float[8];
    double[] Result = new double[8];

    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[0] +=   min(Random1 (), Random1u(), Random1u(), Random1u());  PROFILE_End();  Result[0] = PROFILE_Result();
    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[1] +=   min(Random1u(), Random1u(), Random1u(), Random1 ());  PROFILE_End();  Result[1] = PROFILE_Result();     //  ~120ms slower.

    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[2] += _minA(Random1 (), Random1u(), Random1u(), Random1u());  PROFILE_End();  Result[2] = PROFILE_Result();
    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[3] += _minA(Random1u(), Random1u(), Random1u(), Random1 ());  PROFILE_End();  Result[3] = PROFILE_Result();     //  ~40ms faster???   on i7-3930k

    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[4] += _minB(Random1 (), Random1u(), Random1u(), Random1u());  PROFILE_End();  Result[4] = PROFILE_Result();
    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[5] += _minB(Random1u(), Random1u(), Random1u(), Random1 ());  PROFILE_End();  Result[5] = PROFILE_Result();     //  ~40ms faster???

    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[6] += _minC(Random1 (), Random1u(), Random1u(), Random1u());  PROFILE_End();  Result[6] = PROFILE_Result();
    PROFILE_Start();  for(int i=0;i<I;++i)  Sum[7] += _minC(Random1u(), Random1u(), Random1u(), Random1 ());  PROFILE_End();  Result[7] = PROFILE_Result();     //  ~40ms faster???

    TESTOUT($"""

       min()     Iterations: {CommaDelimit(I)}    Seconds: {Result[0]:F9}    Sum: {Sum[0]:F2}
       min()     Iterations: {CommaDelimit(I)}    Seconds: {Result[1]:F9}    Sum: {Sum[1]:F2}

      _minA()    Iterations: {CommaDelimit(I)}    Seconds: {Result[2]:F9}    Sum: {Sum[2]:F2}
      _minA()    Iterations: {CommaDelimit(I)}    Seconds: {Result[3]:F9}    Sum: {Sum[3]:F2}

      _minB()    Iterations: {CommaDelimit(I)}    Seconds: {Result[4]:F9}    Sum: {Sum[4]:F2}
      _minB()    Iterations: {CommaDelimit(I)}    Seconds: {Result[5]:F9}    Sum: {Sum[5]:F2}

      _minC()    Iterations: {CommaDelimit(I)}    Seconds: {Result[6]:F9}    Sum: {Sum[6]:F2}
      _minC()    Iterations: {CommaDelimit(I)}    Seconds: {Result[7]:F9}    Sum: {Sum[7]:F2}

    """);
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false

    static void F(params int[] args) {
        string str = $"ParamsArray contains {args.Length} elements:";
        foreach (int i in args)  str += $" {i}";
        TESTOUT(str);
    }

    F(new int[] {1, 2, 3});
    F(10, 20, 30, 40);
    F();

#endif
#if false

    double[][] Pnt = new double[5][];

    x[0] = new double[10];
    x[1] = new double[5];
    x[2] = new double[3];
    x[3] = new double[100];
    x[4] = new double[1];

#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    int i = 0;
    void inc() => ++i;

    for (;;) {
        inc();
        TESTOUT($"{i}");
        if (i>=10) break;
    }

    TESTOUT($" ~");

    while (true) {
        inc();
        TESTOUT($"{i}");
        if (i>=20) break;
    }


    //loop(()=>{
    //    inc();
    //    TESTOUT($"{i}");
    //    if (i>=30) break; //  No enclosing loop out of which to break or continue.
    //});

}
#endif

#if false
    int SizeX = 4, SizeY = 4;
    int[,] Thing = new int[SizeX, SizeY];

    loop(SizeY, iY => {
        loop(SizeX, iX => {
            Thing[iX, iY] = iX + iY * SizeX;
        });
    });

    loop(SizeY, iY => {
        loop(SizeX, iX => {
            TESTOUT($"{iX + iY * SizeX}");
        });
    });

    //loop(5, i => {
    //    TESTOUT($"{i}");
    //});

#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
    for (float iF = 0f; iF <= 2.000001f; iF += 0.05f) {
        float A = Cylinder_SurfaceA__a(iF, 2f*iF);
        float B = Cylinder_SurfaceArea(iF, 2f*iF);

        TESTOUT($"""
          [{iF:0.00}]  {A:00.000000000} == {B:00.000000000}    {abs(B-A) < EPS5}
        """);
    }
#endif

#if false
{
    int i = 0;
    for (float iF = 0f; iF <= 1f; iF = 0.05f*(float)++i) {
        TESTOUT($"  [{i,2}]  {iF}");
    }
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    vec2[] Filo2 = Phyllotaxis2(360, 0.5f);

    string STR = "";
    for (int i = 0; i < Filo2.Length; ++i) {
        STR += $"{Filo2[i]}, ";
    }
    TESTOUT("["+STR+"]");
}
#endif

#if false
{
    vec3[] Filo3 = Phyllotaxis3(80);

    string STR = "";
    for (int i = 0; i < Filo3.Length; ++i) {
        STR += $"[{i,2}] {Filo3[i]}\n";
    }
    TESTOUT(STR);
}
#endif

#if false
{
    for (int i = 0; i < 5; ++i) {
        TESTOUT($"""

            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
        """);
    }
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
}}
