
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    const int SizeOfByteVec4 = sizeof(uint);

    const int SizeOfVec2 = 2 * sizeof(float);
    const int SizeOfVec3 = 3 * sizeof(float);
    const int SizeOfVec4 = 4 * sizeof(float);

    const int SizeOfMat4 = 16 * sizeof(float);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this vec2[] Source) {
        int ByteCount = Source.Length * SizeOfVec2;
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
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this vec3[] Source) {
        int ByteCount = Source.Length * SizeOfVec3;
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
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this vec4[] Source) {
        int ByteCount = Source.Length * SizeOfVec4;
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
    [Impl(AggressiveOptimization)]
    internal static uint[] ToUintArray(this bvec4[] Source) {
        int ByteCount = Source.Length * SizeOfByteVec4;
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
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this mat4 Source) {
        const int ByteCount = SizeOfMat4;
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
