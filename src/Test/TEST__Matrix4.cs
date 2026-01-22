
namespace UtilityTest;
internal static partial class Program {
    static void Test__VectorMatrix4() {
        PRINT("\n[Utility.VEC Matrix4]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            mat4 A = new mat4(
                 1f,  2f,  3f,  4f,
                 5f,  6f,  7f,  8f,
                 9f, 10f, 11f, 12f,
                13f, 14f, 15f, 16f
            );
            bool Ex0 = false;  try {float Test = A[  -1 ];}  catch (System.IndexOutOfRangeException) {Ex0 = true;}
            bool Ex1 = false;  try {float Test = A[  16 ];}  catch (System.IndexOutOfRangeException) {Ex1 = true;}
            bool Ex2 = false;  try {float Test = A[-1, 0];}  catch (System.IndexOutOfRangeException) {Ex2 = true;}
            bool Ex3 = false;  try {float Test = A[ 0, 4];}  catch (System.IndexOutOfRangeException) {Ex3 = true;}

            RESULT("mat4 [i] [x,y]", true
                &&  A.xx   ==  1f  &&  A.yx   ==  2f &&  A.zx   ==  3f  &&  A.wx   ==  4f
                &&  A.xy   ==  5f  &&  A.yy   ==  6f &&  A.zy   ==  7f  &&  A.wy   ==  8f
                &&  A.xz   ==  9f  &&  A.yz   == 10f &&  A.zz   == 11f  &&  A.wz   == 12f
                &&  A.xw   == 13f  &&  A.yw   == 14f &&  A.zw   == 15f  &&  A.ww   == 16f

                &&  A[ 0]  ==  1f  &&  A[ 1]  ==  2f &&  A[ 2]  ==  3f  &&  A[ 3]  ==  4f
                &&  A[ 4]  ==  5f  &&  A[ 5]  ==  6f &&  A[ 6]  ==  7f  &&  A[ 7]  ==  8f
                &&  A[ 8]  ==  9f  &&  A[ 9]  == 10f &&  A[10]  == 11f  &&  A[11]  == 12f
                &&  A[12]  == 13f  &&  A[13]  == 14f &&  A[14]  == 15f  &&  A[15]  == 16f

                &&  A[0,0] ==  1f  &&  A[1,0] ==  2f &&  A[2,0] ==  3f  &&  A[3,0] ==  4f
                &&  A[0,1] ==  5f  &&  A[1,1] ==  6f &&  A[2,1] ==  7f  &&  A[3,1] ==  8f
                &&  A[0,2] ==  9f  &&  A[1,2] == 10f &&  A[2,2] == 11f  &&  A[3,2] == 12f
                &&  A[0,3] == 13f  &&  A[1,3] == 14f &&  A[2,3] == 15f  &&  A[3,3] == 16f

                && Ex0 && Ex1 && Ex2 && Ex3
            );
        }

        //======================================================================================================================================================
        {
            mat4 A = new mat4(0f);
            A.Col0 = new vec4( 1f,  5f,  9f, 13f);
            A.Col1 = new vec4( 2f,  6f, 10f, 14f);
            A.Col2 = new vec4( 3f,  7f, 11f, 15f);
            A.Col3 = new vec4( 4f,  8f, 12f, 16f);


            mat4 B = new mat4(0f);
            B.ColX = new vec4( 1f,  5f,  9f, 13f);
            B.ColY = new vec4( 2f,  6f, 10f, 14f);
            B.ColZ = new vec4( 3f,  7f, 11f, 15f);
            B.ColW = new vec4( 4f,  8f, 12f, 16f);

            mat4 C = new mat4(
                 1f,  2f,  3f,  4f,
                 5f,  6f,  7f,  8f,
                 9f, 10f, 11f, 12f,
                13f, 14f, 15f, 16f
            );

            RESULT("mat4 Col*", true
                &&  A == C
                &&  B == C
            );
        }

        //======================================================================================================================================================
        {
            mat4 A = new mat4(0f);
            A.Row0 = new vec4( 1f,  2f,  3f,  4f);
            A.Row1 = new vec4( 5f,  6f,  7f,  8f);
            A.Row2 = new vec4( 9f, 10f, 11f, 12f);
            A.Row3 = new vec4(13f, 14f, 15f, 16f);

            mat4 B = new mat4(0f);
            B.RowX = new vec4( 1f,  2f,  3f,  4f);
            B.RowY = new vec4( 5f,  6f,  7f,  8f);
            B.RowZ = new vec4( 9f, 10f, 11f, 12f);
            B.RowW = new vec4(13f, 14f, 15f, 16f);

            mat4 C = new mat4(
                 1f,  2f,  3f,  4f,
                 5f,  6f,  7f,  8f,
                 9f, 10f, 11f, 12f,
                13f, 14f, 15f, 16f
            );

            RESULT("mat4 Row*", true
                &&  A == C
                &&  B == C
            );
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            mat4 A = new mat4(
                1f, 0f, 0f, 0f,
                0f, 1f, 0f, 0f,
                0f, 0f, 1f, 0f,
                0f, 0f, 0f, 1f
            );
            mat4 B = new mat4(
                 1f,  2f,  3f,  4f,
                 5f,  6f,  7f,  8f,
                 9f, 10f, 11f, 12f,
                13f, 14f, 15f, 16f
            );

            RESULT("mat4 * mat4", true
                &&  A*B == B
                &&  B*A == B
            );

            //PRINT($"A:\n{(A)}");
            //PRINT($"B:\n{(B)}");
            //PRINT($"(A*B):\n{(A*B)}");
            //PRINT($"(B*A):\n{(B*A)}");
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
