
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector() {
        CONOUT("\n[Utility.VEC]");

        //======================================================================================================================================================
        TEST(" vec2 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<vec2>()  ==  8);
        TEST("ivec2 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec2>() ==  8);

        TEST(" vec3 is 12 bytes", System.Runtime.InteropServices.Marshal.SizeOf<vec3>()  == 12);
        TEST("ivec3 is 12 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec3>() == 12);

        TEST(" vec4 is 16 bytes", System.Runtime.InteropServices.Marshal.SizeOf<vec4>()  == 16);
        TEST("ivec4 is 16 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec4>() == 16);

        TEST("bvec4 is  4 bytes", System.Runtime.InteropServices.Marshal.SizeOf<bvec4>() ==  4);
        TEST("bvec8 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<bvec8>() ==  8);

        TEST(" mat4 is 64 bytes", System.Runtime.InteropServices.Marshal.SizeOf<mat4>()  == 64);

        //======================================================================================================================================================
        TEST("iVec2 has Value/Magnitude/Length", true
            && new ivec2(0, 0) == false
            && new ivec2(1, 0)
            && new ivec2(0, 1)
            && new ivec2(1, 1)
        );
        TEST("Vec2 has Value/Magnitude/Length", true
            && new vec2(0f, 0f) == false
            && new vec2(1f, 0f)
            && new vec2(0f, 1f)
            && new vec2(1f, 1f)
        );

        //======================================================================================================================================================
        TEST("iVec3 has Value/Magnitude/Length", true
            && new ivec3(0, 0, 0) == false
            && new ivec3(1, 0, 0)
            && new ivec3(0, 1, 0)
            && new ivec3(1, 1, 0)
            && new ivec3(0, 0, 1)
            && new ivec3(1, 0, 1)
            && new ivec3(0, 1, 1)
            && new ivec3(1, 1, 1)
        );
        TEST("Vec3 has Value/Magnitude/Length", true
            && new vec3(0f, 0f, 0f) == false
            && new vec3(1f, 0f, 0f)
            && new vec3(0f, 1f, 0f)
            && new vec3(1f, 1f, 0f)
            && new vec3(0f, 0f, 1f)
            && new vec3(1f, 0f, 1f)
            && new vec3(0f, 1f, 1f)
            && new vec3(1f, 1f, 1f)
        );

        //======================================================================================================================================================
        TEST("iVec4 has Value/Magnitude/Length", true
            && new ivec4(0, 0, 0, 0) == false
            && new ivec4(0, 0, 0, 1)
            && new ivec4(0, 0, 1, 0)
            && new ivec4(0, 0, 1, 1)
            && new ivec4(0, 1, 0, 0)
            && new ivec4(0, 1, 0, 1)
            && new ivec4(0, 1, 1, 0)
            && new ivec4(0, 1, 1, 1)
            && new ivec4(1, 0, 0, 0)
            && new ivec4(1, 0, 0, 1)
            && new ivec4(1, 0, 1, 0)
            && new ivec4(1, 0, 1, 1)
            && new ivec4(1, 1, 0, 0)
            && new ivec4(1, 1, 0, 1)
            && new ivec4(1, 1, 1, 0)
            && new ivec4(1, 1, 1, 1)
        );
        TEST("Vec4 has Value/Magnitude/Length", true
            && new vec4(0f, 0f, 0f, 0f) == false
            && new vec4(0f, 0f, 0f, 1f)
            && new vec4(0f, 0f, 1f, 0f)
            && new vec4(0f, 0f, 1f, 1f)
            && new vec4(0f, 1f, 0f, 0f)
            && new vec4(0f, 1f, 0f, 1f)
            && new vec4(0f, 1f, 1f, 0f)
            && new vec4(0f, 1f, 1f, 1f)
            && new vec4(1f, 0f, 0f, 0f)
            && new vec4(1f, 0f, 0f, 1f)
            && new vec4(1f, 0f, 1f, 0f)
            && new vec4(1f, 0f, 1f, 1f)
            && new vec4(1f, 1f, 0f, 0f)
            && new vec4(1f, 1f, 0f, 1f)
            && new vec4(1f, 1f, 1f, 0f)
            && new vec4(1f, 1f, 1f, 1f)
        );

        //======================================================================================================================================================
        #if false
            CONOUT($"");
            CONOUT($"{BitCast.ToFloat(0x3EAAAAABu):F98}");
            CONOUT($"{ONE_THIRD:F98}");
            CONOUT($"");
            CONOUT($"{IntToBinaryString(0x3EAAAAABu)}");
            CONOUT($"{IntToBinaryString(BitCast.ToUint(ONE_THIRD))}");
            CONOUT($"");
            CONOUT($"");
            CONOUT($"{BitCast.ToFloat(0x3F2AAAABu):F98}");
            CONOUT($"{TWO_THIRD:F98}");
            CONOUT($"{IntToBinaryString(0x3F2AAAABu)}");
            CONOUT($"{IntToBinaryString(BitCast.ToUint(TWO_THIRD))}");
            CONOUT($"");
            CONOUT($"");
            CONOUT($"");
            CONOUT($"{0.000000000000123456f:F98}");
        #endif

        //======================================================================================================================================================
        #if false
        {
            bvec4 A = 0xFF_CC_99_33u;
            CONOUT($"");
            CONOUT($"    A: {A:x}");
            CONOUT($"  A.x: {A.x:x}");
            CONOUT($"  A.y: {A.y:x}");
            CONOUT($"  A.z: {A.z:x}");
            CONOUT($"  A.w: {A.w:x}");

            uint  B = A;
            CONOUT($"");
            CONOUT($"    B: {B:x}");

            bvec4 C = B - 0x11111111u;
            CONOUT($"");
            CONOUT($"    C: {C:x}");
            C.x += 0x11;
            C.y += 0x11;
            C.z += 0x11;
            C.w += 0x11;
            CONOUT($"    C: {C:x}");

            bvec4 D = new bvec4(0xFF, 0xCC, 0x99, 0x33);
            CONOUT($"");
            CONOUT($"    D: {D:x}");

            bvec4 E = (0xFF, 0xCC, 0x99, 0x33);
            CONOUT($"");
            CONOUT($"    E: {E:x}");
            E = E.ByteFlip;
            CONOUT($"    E: {E:x}");

            //uint S = 0b_0101_0101; // = 0x55 =  85
            //uint Z = 0b_1010_1010; // = 0xAA = 170
        }
        #endif

        //======================================================================================================================================================
    }
}
