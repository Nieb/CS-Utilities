
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector() {
        TESTOUT("\n[Utility.VEC]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        /*
        TEST("iVec2 has Value/Magnitude/Length", true
            && !new ivec2(0, 0)  &&  new ivec2(1, 0)
            &&  new ivec2(0, 1)  &&  new ivec2(1, 1)
        );
        TEST("Vec2 has Value/Magnitude/Length", true
            && !new vec2(0f, 0f)  &&  new vec2(1f, 0f)
            &&  new vec2(0f, 1f)  &&  new vec2(1f, 1f)
        );

        //======================================================================================================================================================
        TEST("iVec3 has Value/Magnitude/Length", true
            && !new ivec3(0, 0, 0)  &&  new ivec3(1, 0, 0)
            &&  new ivec3(0, 0, 1)  &&  new ivec3(1, 0, 1)
            &&  new ivec3(0, 1, 0)  &&  new ivec3(1, 1, 0)
            &&  new ivec3(0, 1, 1)  &&  new ivec3(1, 1, 1)
        );
        TEST("Vec3 has Value/Magnitude/Length", true
            && !new vec3(0f, 0f, 0f)  &&  new vec3(1f, 0f, 0f)
            &&  new vec3(0f, 0f, 1f)  &&  new vec3(1f, 0f, 1f)
            &&  new vec3(0f, 1f, 0f)  &&  new vec3(1f, 1f, 0f)
            &&  new vec3(0f, 1f, 1f)  &&  new vec3(1f, 1f, 1f)
        );

        //======================================================================================================================================================
        TEST("iVec4 has Value/Magnitude/Length", true
            && !new ivec4(0, 0, 0, 0)  &&  new ivec4(1, 0, 0, 0)
            &&  new ivec4(0, 0, 0, 1)  &&  new ivec4(1, 0, 0, 1)
            &&  new ivec4(0, 0, 1, 0)  &&  new ivec4(1, 0, 1, 0)
            &&  new ivec4(0, 0, 1, 1)  &&  new ivec4(1, 0, 1, 1)
            &&  new ivec4(0, 1, 0, 0)  &&  new ivec4(1, 1, 0, 0)
            &&  new ivec4(0, 1, 0, 1)  &&  new ivec4(1, 1, 0, 1)
            &&  new ivec4(0, 1, 1, 0)  &&  new ivec4(1, 1, 1, 0)
            &&  new ivec4(0, 1, 1, 1)  &&  new ivec4(1, 1, 1, 1)
        );
        TEST("Vec4 has Value/Magnitude/Length", true
            && !new vec4(0f, 0f, 0f, 0f)  &&  new vec4(1f, 0f, 0f, 0f)
            &&  new vec4(0f, 0f, 0f, 1f)  &&  new vec4(1f, 0f, 0f, 1f)
            &&  new vec4(0f, 0f, 1f, 0f)  &&  new vec4(1f, 0f, 1f, 0f)
            &&  new vec4(0f, 0f, 1f, 1f)  &&  new vec4(1f, 0f, 1f, 1f)
            &&  new vec4(0f, 1f, 0f, 0f)  &&  new vec4(1f, 1f, 0f, 0f)
            &&  new vec4(0f, 1f, 0f, 1f)  &&  new vec4(1f, 1f, 0f, 1f)
            &&  new vec4(0f, 1f, 1f, 0f)  &&  new vec4(1f, 1f, 1f, 0f)
            &&  new vec4(0f, 1f, 1f, 1f)  &&  new vec4(1f, 1f, 1f, 1f)
        );
        */
        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            bvec4 A = (247,  31,   0, 255);
            bvec4 B = (103, 255,   0, 255);
            bvec4 C = (  0, 128, 255, 255);

            bvec4 D = 0xF7_1F_00__FF;
            bvec4 E = 0x67_FF_00__FF;
            bvec4 F = 0x00_80_FF__FF;

            bvec4 G = default;  G.r=0x12; G.g=0x34; G.b=0x56; G.a=0x78;
            bvec4 H = default;  H.x=0x9A; H.y=0xBC; H.z=0xDE; H.w=0xF0;

            TEST("bvec4", true
                && A == D
                && B == E
                && C == F
                && G == 0x1234_5678u
                && H == 0x9ABC_DEF0u
            );
        }
        //======================================================================================================================================================
        #if false
        {
            bvec4 A = 0xFF_CC_99_33u;
            TESTOUT($"");
            TESTOUT($"    A: {A:x}");
            TESTOUT($"  A.x: {A.x:x}");
            TESTOUT($"  A.y: {A.y:x}");
            TESTOUT($"  A.z: {A.z:x}");
            TESTOUT($"  A.w: {A.w:x}");

            uint  B = A;
            TESTOUT($"");
            TESTOUT($"    B: {B:x}");

            bvec4 C = B - 0x11111111u;
            TESTOUT($"");
            TESTOUT($"    C: {C:x}");
            C.x += 0x11;
            C.y += 0x11;
            C.z += 0x11;
            C.w += 0x11;
            TESTOUT($"    C: {C:x}");

            bvec4 D = new bvec4(0xFF, 0xCC, 0x99, 0x33);
            TESTOUT($"");
            TESTOUT($"    D: {D:x}");

            bvec4 E = (0xFF, 0xCC, 0x99, 0x33);
            TESTOUT($"");
            TESTOUT($"    E: {E:x}");
            E = E.ByteFlip;
            TESTOUT($"    E: {E:x}");

            //uint S = 0b_0101_0101; // = 0x55 =  85
            //uint Z = 0b_1010_1010; // = 0xAA = 170
        }
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            bvec8 A = default;
            A.b0=0x12; A.b1=0x34; A.b2=0x56; A.b3=0x78; A.b4=0x9A; A.b5=0xBC; A.b6=0xDE; A.b7=0xF0;

            bvec8 B = 0x_1234_5678_9ABC_DEF0u;

            TEST("bvec8", true
                && A.b0 == 0x12 && A.b1 == 0x34 && A.b2 == 0x56 && A.b3 == 0x78 && A.b4 == 0x9A && A.b5 == 0xBC && A.b6 == 0xDE && A.b7 == 0xF0
                && A.s0 == 0x1234 && A.s1 == 0x5678 && A.s2 == 0x9ABC && A.s3 == 0xDEF0
                && A.i0 == 0x_1234_5678u && A.i1 == 0x9ABC_DEF0u
                && A    == 0x_1234_5678_9ABC_DEF0u

                && B.b0 == 0x12 && B.b1 == 0x34 && B.b2 == 0x56 && B.b3 == 0x78 && B.b4 == 0x9A && B.b5 == 0xBC && B.b6 == 0xDE && B.b7 == 0xF0
                && B.s0 == 0x1234 && B.s1 == 0x5678 && B.s2 == 0x9ABC && B.s3 == 0xDEF0
                && B.i0 == 0x_1234_5678u && B.i1 == 0x9ABC_DEF0u
                && B    == 0x_1234_5678_9ABC_DEF0u
            );

            #if false
                TESTOUT($"""

                     u8:  {A.b0:X} {A.b1:X} {A.b2:X} {A.b3:X} {A.b4:X} {A.b5:X} {A.b6:X} {A.b7:X}
                    u16:  {A.s0:X}  {A.s1:X}  {A.s2:X}  {A.s3:X}
                    u32:   {A.i0:X}    {A.i1:X}
                    u64:     {A.L:X}

                     u8:  {B.b0:X} {B.b1:X} {B.b2:X} {B.b3:X} {B.b4:X} {B.b5:X} {B.b6:X} {B.b7:X}
                    u16:  {B.s0:X}  {B.s1:X}  {B.s2:X}  {B.s3:X}
                    u32:   {B.i0:X}    {B.i1:X}
                    u64:     {B.L:X}
                """);
            #endif
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
