
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    const int SIZE_OF_BVEC4 = 1 * 4; //sizeof(uint);

    const int SIZE_OF_VEC2 =  2 * 4; //sizeof(float);
    const int SIZE_OF_VEC3 =  3 * 4; //sizeof(float);
    const int SIZE_OF_VEC4 =  4 * 4; //sizeof(float);

    const int SIZE_OF_MAT4 = 16 * 4; //sizeof(float);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static float[] ToFloatArray(this vec2[] Source) {
        int ByteCount = Source.Length * SIZE_OF_VEC2;
        float[] Result = new float[Source.Length * 2];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed ( vec2* pSrc = &Source[0])
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //==========================================================================================================================================================
    internal static float[] ToFloatArray(this vec3[] Source) {
        int ByteCount = Source.Length * SIZE_OF_VEC3;
        float[] Result = new float[Source.Length * 3];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed ( vec3* pSrc = &Source[0])
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //==========================================================================================================================================================
    internal static float[] ToFloatArray(this vec4[] Source) {
        int ByteCount = Source.Length * SIZE_OF_VEC4;
        float[] Result = new float[Source.Length * 4];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed ( vec4* pSrc = &Source[0])
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static uint[] ToUintArray(this bvec4[] Source) {
        int ByteCount = Source.Length * SIZE_OF_BVEC4;
        uint[] Result = new uint[Source.Length];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed (bvec4* pSrc = &Source[0])
            fixed (uint*  pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static float[] ToFloatArray(this mat4 Source) {
        const int ByteCount = SIZE_OF_MAT4;
        float[] Result = new float[16];
        unsafe {
            //  Pin array so the GC doesn't move it:
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: &Source,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
