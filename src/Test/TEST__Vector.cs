
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector() {
        PRINT("\n[Utility.VEC]");

        //======================================================================================================================================================
        RESULT(" vec2 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<vec2>()  ==  8);
        RESULT("ivec2 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec2>() ==  8);

        RESULT(" vec3 is 12 bytes", System.Runtime.InteropServices.Marshal.SizeOf<vec3>()  == 12);
        RESULT("ivec3 is 12 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec3>() == 12);

        RESULT(" vec4 is 16 bytes", System.Runtime.InteropServices.Marshal.SizeOf<vec4>()  == 16);
        RESULT("ivec4 is 16 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec4>() == 16);

        RESULT("bvec4 is  4 bytes", System.Runtime.InteropServices.Marshal.SizeOf<bvec4>() ==  4);
        RESULT("bvec8 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<bvec8>() ==  8);

        RESULT(" mat4 is 64 bytes", System.Runtime.InteropServices.Marshal.SizeOf<mat4>()  == 64);

        //======================================================================================================================================================
        RESULT("iVec2 has Value/Magnitude/Length", true
            && new ivec2(0, 0) == false
            && new ivec2(1, 0)
            && new ivec2(0, 1)
            && new ivec2(1, 1)
        );
        RESULT("Vec2 has Value/Magnitude/Length", true
            && new vec2(0f, 0f) == false
            && new vec2(1f, 0f)
            && new vec2(0f, 1f)
            && new vec2(1f, 1f)
        );

        //======================================================================================================================================================
        RESULT("iVec3 has Value/Magnitude/Length", true
            && new ivec3(0, 0, 0) == false
            && new ivec3(1, 0, 0)
            && new ivec3(0, 1, 0)
            && new ivec3(1, 1, 0)
            && new ivec3(0, 0, 1)
            && new ivec3(1, 0, 1)
            && new ivec3(0, 1, 1)
            && new ivec3(1, 1, 1)
        );
        RESULT("Vec3 has Value/Magnitude/Length", true
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
        RESULT("iVec4 has Value/Magnitude/Length", true
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
        RESULT("Vec4 has Value/Magnitude/Length", true
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
            PRINT($"");
            PRINT($"{BitCast.ToFloat(0x3EAAAAABu):F98}");
            PRINT($"{ONE_THIRD:F98}");
            PRINT($"");
            PRINT($"{IntToBinaryString(0x3EAAAAABu)}");
            PRINT($"{IntToBinaryString(BitCast.ToUint(ONE_THIRD))}");
            PRINT($"");
            PRINT($"");
            PRINT($"{BitCast.ToFloat(0x3F2AAAABu):F98}");
            PRINT($"{TWO_THIRD:F98}");
            PRINT($"{IntToBinaryString(0x3F2AAAABu)}");
            PRINT($"{IntToBinaryString(BitCast.ToUint(TWO_THIRD))}");
            PRINT($"");
            PRINT($"");
            PRINT($"");
            PRINT($"{0.000000000000123456f:F98}");
        #endif

        //======================================================================================================================================================
        #if false
        {
            bvec4 A = 0xFF_CC_99_33u;
            PRINT($"");
            PRINT($"    A: {A:x}");
            PRINT($"  A.x: {A.x:x}");
            PRINT($"  A.y: {A.y:x}");
            PRINT($"  A.z: {A.z:x}");
            PRINT($"  A.w: {A.w:x}");

            uint  B = A;
            PRINT($"");
            PRINT($"    B: {B:x}");

            bvec4 C = B - 0x11111111u;
            PRINT($"");
            PRINT($"    C: {C:x}");
            C.x += 0x11;
            C.y += 0x11;
            C.z += 0x11;
            C.w += 0x11;
            PRINT($"    C: {C:x}");

            bvec4 D = new bvec4(0xFF, 0xCC, 0x99, 0x33);
            PRINT($"");
            PRINT($"    D: {D:x}");

            bvec4 E = (0xFF, 0xCC, 0x99, 0x33);
            PRINT($"");
            PRINT($"    E: {E:x}");
            E = E.ByteFlip;
            PRINT($"    E: {E:x}");

            //uint S = 0b_0101_0101; // = 0x55 =  85
            //uint Z = 0b_1010_1010; // = 0xAA = 170
        }
        #endif

        //======================================================================================================================================================
    }
}
