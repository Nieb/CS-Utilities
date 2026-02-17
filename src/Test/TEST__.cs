
namespace UtilityTest;
internal static partial class Program {static void Test___() {
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    byte A = 0b001;
    byte B = 0b000;
    byte C = 0b100;

    byte Combination = u8(A | B | C);
    byte        Mask = 0b111;
    byte      Select = u8(Combination ^ Mask);

    CONOUT($"""
        {IntToBinaryString(Combination)}  xor  {IntToBinaryString(Mask)}  ==  {IntToBinaryString(Select)}
    """);
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    const int Iterations = (1 << 24);
    Time Timer = new();
    float Sum = 0f;

    {
        Sum = 0f;
        Timer.Update();
            for (int i = 0; i < Iterations; ++i) Sum += _minA(Random1(), Random1u(), Random1u(), Random1u());
        Timer.Update();
        CONOUT($"\n  _minA()    Iterations: {CommaDelimit(Iterations)}    Seconds: {Timer.Delta64:0.000000000}    Sum: {Sum:0.00}");
    }
    {
        Sum = 0f;
        Timer.Update();
            for (int i = 0; i < Iterations; ++i) Sum += _minA(Random1u(), Random1u(), Random1u(), Random1()); // ~40ms faster???
        Timer.Update();
        CONOUT($"  _minA()    Iterations: {CommaDelimit(Iterations)}    Seconds: {Timer.Delta64:0.000000000}    Sum: {Sum:0.00}");
    }

    {
        Sum = 0f;
        Timer.Update();
            for (int i = 0; i < Iterations; ++i) Sum += min(Random1(), Random1u(), Random1u(), Random1u());
        Timer.Update();
        CONOUT($"\n   min()     Iterations: {CommaDelimit(Iterations)}    Seconds: {Timer.Delta64:0.000000000}    Sum: {Sum:0.00}");
    }
    {
        Sum = 0f;
        Timer.Update();
            for (int i = 0; i < Iterations; ++i) Sum += min(Random1u(), Random1u(), Random1u(), Random1()); // ~120ms slower
        Timer.Update();
        CONOUT($"   min()     Iterations: {CommaDelimit(Iterations)}    Seconds: {Timer.Delta64:0.000000000}    Sum: {Sum:0.00}");
    }
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false

    static void F(params int[] args) {
        string str = $"ParamsArray contains {args.Length} elements:";
        foreach (int i in args)  str += $" {i}";
        CONOUT(str);
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
        CONOUT($"{i}");
        if (i>=10) break;
    }

    CONOUT($" ~");

    while (true) {
        inc();
        CONOUT($"{i}");
        if (i>=20) break;
    }


    //loop(()=>{
    //    inc();
    //    CONOUT($"{i}");
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
            CONOUT($"{iX + iY * SizeX}");
        });
    });

    //loop(5, i => {
    //    CONOUT($"{i}");
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

        CONOUT($"""
          [{iF:0.00}]  {A:00.000000000} == {B:00.000000000}    {abs(B-A) < EPS_5}
        """);
    }
#endif

#if false
{
    int i = 0;
    for (float iF = 0f; iF <= 1f; iF = 0.05f*(float)++i) {
        CONOUT($"  [{i,2}]  {iF}");
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
    CONOUT("["+STR+"]");
}
#endif

#if false
{
    vec3[] Filo3 = Phyllotaxis3(80);

    string STR = "";
    for (int i = 0; i < Filo3.Length; ++i) {
        STR += $"[{i,2}] {Filo3[i]}\n";
    }
    CONOUT(STR);
}
#endif

#if false
{
    for (int i = 0; i < 5; ++i) {
        CONOUT($"""

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
