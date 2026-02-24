
namespace TEST;
internal static partial class Program {
    static void Test__Vector() {
        CONOUT("\n[Utility.VEC]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST(" vec2 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf< vec2>() ==  8);
        TEST("ivec2 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec2>() ==  8);

        TEST(" vec3 is 12 bytes", System.Runtime.InteropServices.Marshal.SizeOf< vec3>() == 12);
        TEST("ivec3 is 12 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec3>() == 12);

        TEST(" vec4 is 16 bytes", System.Runtime.InteropServices.Marshal.SizeOf< vec4>() == 16);
        TEST("ivec4 is 16 bytes", System.Runtime.InteropServices.Marshal.SizeOf<ivec4>() == 16);

        TEST("bvec4 is  4 bytes", System.Runtime.InteropServices.Marshal.SizeOf<bvec4>() ==  4);
        TEST("bvec8 is  8 bytes", System.Runtime.InteropServices.Marshal.SizeOf<bvec8>() ==  8);

        TEST(" mat4 is 64 bytes", System.Runtime.InteropServices.Marshal.SizeOf<mat4>()  == 64);

        #if false
            CONOUT($"""
                                   bool: {sizeof(bool  ),2} bytes

                                  sbyte: {sizeof(sbyte ),2} bytes       byte: {sizeof(byte  ),2} bytes
                                  short: {sizeof(short ),2} bytes     ushort: {sizeof(ushort),2} bytes
                                    int: {sizeof(int   ),2} bytes       uint: {sizeof(uint  ),2} bytes
                                   long: {sizeof(long  ),2} bytes      ulong: {sizeof(ulong ),2} bytes

                                  float: {sizeof(float ),2} bytes
                                 double: {sizeof(double),2} bytes

                System.Numerics.Vector2: {System.Runtime.InteropServices.Marshal.SizeOf<System.Numerics.Vector2>(),2} bytes
                System.Numerics.Vector3: {System.Runtime.InteropServices.Marshal.SizeOf<System.Numerics.Vector3>(),2} bytes
                System.Numerics.Vector4: {System.Runtime.InteropServices.Marshal.SizeOf<System.Numerics.Vector4>(),2} bytes

                System.Numerics.Matrix4: {System.Runtime.InteropServices.Marshal.SizeOf<System.Numerics.Matrix4x4>(),2} bytes
            """);
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
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

        //######################################################################################################################################################
        //######################################################################################################################################################
        #if false
            CONOUT($"""

                {BitCast_ToF32(0x3EAAAAABu):F98}
                {ONE_THIRD:F98}

                {IntToBinaryString(0x3EAAAAABu)}
                {IntToBinaryString(BitCast_ToU32(ONE_THIRD))}


                {BitCast_ToF32(0x3F2AAAABu):F98}
                {TWO_THIRD:F98}
                {IntToBinaryString(0x3F2AAAABu)}
                {IntToBinaryString(BitCast_ToU32(TWO_THIRD))}



                {0.000000000000123456f:F98}
            """);
            /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                CONOUT($"""
                    ...
                    {BitCast_ToF32(0x3EAAAAABu):F98}
                    {ONE_THIRD:F98}

                    {IntToBinaryString(0x3EAAAAABu)}
                    {IntToBinaryString(BitCast_ToU32(ONE_THIRD))}
                    ...
                """);

                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000
                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000

                    00111110_10101010_10101010_10101011
                                                                                wtf?    where did this newline come from???    only happens with full CONOUT() from above...
                    00111110_10101010_10101010_10101011

            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                CONOUT($"""
                    ...
                    {BitCast_ToF32(0x3EAAAAABu):F98}
                    {ONE_THIRD:F98}
                    {IntToBinaryString(0x3EAAAAABu)}
                    {IntToBinaryString(BitCast_ToU32(ONE_THIRD))}
                    ...
                """);

                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000
                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000
                    00111110_10101010_10101010_10101011
                    00111110_10101010_10101010_10101011

            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
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
        #if false
            CONOUT($"""

                    {(uint)new bvec4(247,  31,   0, 255):X8}    {new bvec4(247,  31,   0, 255)}    {new bvec4(0x__F7_1F_00__FF)}
                    {(uint)new bvec4(103, 255,   0, 255):X8}    {new bvec4(103, 255,   0, 255)}    {new bvec4(0x__67_FF_00__FF)}
                    {(uint)new bvec4(  0, 128, 255, 255):X8}    {new bvec4(  0, 128, 255, 255)}    {new bvec4(0x__00_80_FF__FF)}
            """);
        #endif

        #if false
        {
            bvec8 V = 0L;
            V.b0=0x12; V.b1=0x34; V.b2=0x56; V.b3=0x78; V.b4=0x9A; V.b5=0xBC; V.b6=0xDE; V.b7=0xF0;

            CONOUT($"""
                B:  {V.b0:X} {V.b1:X} {V.b2:X} {V.b3:X} {V.b4:X} {V.b5:X} {V.b6:X} {V.b7:X}
                S:  {V.s0:X}  {V.s1:X}  {V.s2:X}  {V.s3:X}
                I:   {V.i0:X}    {V.i1:X}
                L:     {V.L:X}
            """);

            /*
                B:  12 34 56 78 9A BC DE F0
                S:  1234  5678  9ABC  DEF0
                I:   12345678    9ABCDEF0
                L:     123456789ABCDEF0
            */
        }
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
