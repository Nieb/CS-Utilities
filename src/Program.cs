
namespace UtilityTest;
internal static partial class Program {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static void Main(string[] args) {
        _ = args;

        #if false
            //Test__Float32_Comparison();
            //Test__Float32_Random1();
            //Test__Float32_BaseTenPrecision();
            Test__Float64_BaseTenPrecision();

            //Test__Intrinsics();

            //Gen__TurboColor();

        #else
            //CONOUT($"LineNumber: {LINE_NUMBER()}");

            CONOUTC($"                                 ~~~ START ~~~");
            Time Time = new();
            Time.Update();

            Test__Integer();

            Test__String();

            Test__Vector();
            Test__VectorArray();
            Test__VectorBasicOps();
            Test__VectorMatrix4();

            Test__Vector_Collision2();
            Test__Vector_Collision3();
            Test__Vector_Color();
            Test__Vector_Generate();
            Test__Vector_Geometry();
            Test__Vector_Interpolation();
            Test__Vector_Miscellaneous();
            Test__Vector_Rotation();

            Test___();

            Time.Update();
            CONOUT($"\n                                 ~~~ FINISH ~~~");
            CONOUT($"\n                                   {Time.Delta64:N12}\n");
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
