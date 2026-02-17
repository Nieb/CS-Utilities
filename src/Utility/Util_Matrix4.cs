using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct mat4 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                                          |       Col 0           Col 1           Col 2           Col 3
    //                                  --------+-------------------------------------------------------------------
    //                                    Row 0 |   [ 0] [0,0] XX   [ 1] [1,0] YX   [ 2] [2,0] ZX   [ 3] [3,0] WX
    //                  [i] [x,y] **      Row 1 |   [ 4] [0,1] XY   [ 5] [1,1] YY   [ 6] [2,1] ZY   [ 7] [3,1] WY
    //                   [Col, Row]       Row 2 |   [ 8] [0,2] XZ   [ 9] [1,2] YZ   [10] [2,2] ZZ   [11] [3,2] WZ
    //                                    Row 3 |   [12] [0,3] XW   [13] [1,3] YW   [14] [2,3] ZW   [15] [3,3] WW
    //                                          |
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float xx;  [FieldOffset( 4)] public float yx;  [FieldOffset( 8)] public float zx;  [FieldOffset(12)] public float wx;
    [FieldOffset(16)] public float xy;  [FieldOffset(20)] public float yy;  [FieldOffset(24)] public float zy;  [FieldOffset(28)] public float wy;
    [FieldOffset(32)] public float xz;  [FieldOffset(36)] public float yz;  [FieldOffset(40)] public float zz;  [FieldOffset(44)] public float wz;
    [FieldOffset(48)] public float xw;  [FieldOffset(52)] public float yw;  [FieldOffset(56)] public float zw;  [FieldOffset(60)] public float ww;

    //==========================================================================================================================================================
    public vec4 Col0 {get => new vec4(xx,xy,xz,xw); set {xx=value.x; xy=value.y; xz=value.z; xw=value.w;}}
    public vec4 Col1 {get => new vec4(yx,yy,yz,yw); set {yx=value.x; yy=value.y; yz=value.z; yw=value.w;}}
    public vec4 Col2 {get => new vec4(zx,zy,zz,zw); set {zx=value.x; zy=value.y; zz=value.z; zw=value.w;}}
    public vec4 Col3 {get => new vec4(wx,wy,wz,ww); set {wx=value.x; wy=value.y; wz=value.z; ww=value.w;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [FieldOffset( 0)] public vec4 Row0;
    [FieldOffset(16)] public vec4 Row1;
    [FieldOffset(32)] public vec4 Row2;
    [FieldOffset(48)] public vec4 Row3;

    //==========================================================================================================================================================
    [FieldOffset(0)] private InlineArray16_Float index = default;

    public float this[int i] {
        get => this.index[i];
        set => this.index[i] = value;
    }

    public float this[int x, int y] {
        get =>                       (x<0 || x>3 || y<0 || y>3) ? throw new System.IndexOutOfRangeException() : this.index[x + 4*y];
        set => this.index[x + 4*y] = (x<0 || x>3 || y<0 || y>3) ? throw new System.IndexOutOfRangeException() : value;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public mat4() {
        xx=1f; yx=0f; zx=0f; wx=0f;
        xy=0f; yy=1f; zy=0f; wy=0f;
        xz=0f; yz=0f; zz=1f; wz=0f;
        xw=0f; yw=0f; zw=0f; ww=1f;
    }

    public mat4(float V) {
        xx=V; yx=V; zx=V; wx=V;
        xy=V; yy=V; zy=V; wy=V;
        xz=V; yz=V; zz=V; wz=V;
        xw=V; yw=V; zw=V; ww=V;
    }

    public mat4(float XX, float YX, float ZX, float WX,
                float XY, float YY, float ZY, float WY,
                float XZ, float YZ, float ZZ, float WZ,
                float XW, float YW, float ZW, float WW) {
        xx=XX; yx=YX; zx=ZX; wx=WX;
        xy=XY; yy=YY; zy=ZY; wy=WY;
        xz=XZ; yz=YZ; zz=ZZ; wz=WZ;
        xw=XW; yw=YW; zw=ZW; ww=WW;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    #if false
        public static mat4 operator *(mat4 A, mat4 B) => new mat4(
            dot(A.Row0, B.Col0),  dot(A.Row0, B.Col1),  dot(A.Row0, B.Col2),  dot(A.Row0, B.Col3),
            dot(A.Row1, B.Col0),  dot(A.Row1, B.Col1),  dot(A.Row1, B.Col2),  dot(A.Row1, B.Col3),
            dot(A.Row2, B.Col0),  dot(A.Row2, B.Col1),  dot(A.Row2, B.Col2),  dot(A.Row2, B.Col3),
            dot(A.Row3, B.Col0),  dot(A.Row3, B.Col1),  dot(A.Row3, B.Col2),  dot(A.Row3, B.Col3)
        );
    #else
        public static mat4 operator *(mat4 A, mat4 B) => new mat4(
            A.xx*B.xx + A.yx*B.xy + A.zx*B.xz + A.wx*B.xw,  // XX = dot( A.Row0, B.Col0 )
            A.xx*B.yx + A.yx*B.yy + A.zx*B.yz + A.wx*B.yw,  // YX = dot( A.Row0, B.Col1 )
            A.xx*B.zx + A.yx*B.zy + A.zx*B.zz + A.wx*B.zw,  // ZX = dot( A.Row0, B.Col2 )
            A.xx*B.wx + A.yx*B.wy + A.zx*B.wz + A.wx*B.ww,  // WX = dot( A.Row0, B.Col3 )

            A.xy*B.xx + A.yy*B.xy + A.zy*B.xz + A.wy*B.xw,  // XY
            A.xy*B.yx + A.yy*B.yy + A.zy*B.yz + A.wy*B.yw,  // YY
            A.xy*B.zx + A.yy*B.zy + A.zy*B.zz + A.wy*B.zw,  // ZY
            A.xy*B.wx + A.yy*B.wy + A.zy*B.wz + A.wy*B.ww,  // WY

            A.xz*B.xx + A.yz*B.xy + A.zz*B.xz + A.wz*B.xw,  // XZ
            A.xz*B.yx + A.yz*B.yy + A.zz*B.yz + A.wz*B.yw,  // YZ
            A.xz*B.zx + A.yz*B.zy + A.zz*B.zz + A.wz*B.zw,  // ZZ
            A.xz*B.wx + A.yz*B.wy + A.zz*B.wz + A.wz*B.ww,  // WZ

            A.xw*B.xx + A.yw*B.xy + A.zw*B.xz + A.ww*B.xw,  // XW
            A.xw*B.yx + A.yw*B.yy + A.zw*B.yz + A.ww*B.yw,  // YW
            A.xw*B.zx + A.yw*B.zy + A.zw*B.zz + A.ww*B.zw,  // ZW
            A.xw*B.wx + A.yw*B.wy + A.zw*B.wz + A.ww*B.ww   // WW
        );
    #endif

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Result = (Vec * Mat);
    //
    //         Vx      Vy      Vz      Vw   |
    //      --------------------------------+------
    //         Mxx  +  Myx  +  Mzx  +  Mwx  |  Rx
    //                                      |
    //         Mxy  +  Myy  +  Mzy  +  Mwy  |  Ry
    //                                      |
    //         Mxz  +  Myz  +  Mzz  +  Mwz  |  Rz
    //                                      |
    //         Mxw  +  Myw  +  Mzw  +  Mww  |  Rw
    //                                      |
    //
    #if false
        public static vec4 operator *(vec4 V, mat4 M) => new vec4(fma(V.x,M.xx, fma(V.y,M.yx, fma(V.z,M.zx, (V.w*M.wx)))),
                                                                  fma(V.x,M.xy, fma(V.y,M.yy, fma(V.z,M.zy, (V.w*M.wy)))),
                                                                  fma(V.x,M.xz, fma(V.y,M.yz, fma(V.z,M.zz, (V.w*M.wz)))),
                                                                  fma(V.x,M.xw, fma(V.y,M.yw, fma(V.z,M.zw, (V.w*M.ww)))) );

        public static vec3 operator *(vec3 V, mat4 M) => new vec3(fma(V.x,M.xx, fma(V.y,M.yx, (V.z*M.zx))),
                                                                  fma(V.x,M.xy, fma(V.y,M.yy, (V.z*M.zy))),
                                                                  fma(V.x,M.xz, fma(V.y,M.yz, (V.z*M.zz))) );
    #else
        public static vec4 operator *(vec4 V, mat4 M) => new vec4(V.x*M.xx + V.y*M.yx + V.z*M.zx + V.w*M.wx,
                                                                  V.x*M.xy + V.y*M.yy + V.z*M.zy + V.w*M.wy,
                                                                  V.x*M.xz + V.y*M.yz + V.z*M.zz + V.w*M.wz,
                                                                  V.x*M.xw + V.y*M.yw + V.z*M.zw + V.w*M.ww );

        public static vec3 operator *(vec3 V, mat4 M) => new vec3(V.x*M.xx + V.y*M.yx + V.z*M.zx,     // + V.w*M.wx,
                                                                  V.x*M.xy + V.y*M.yy + V.z*M.zy,     // + V.w*M.wy,
                                                                  V.x*M.xz + V.y*M.yz + V.z*M.zz );   // + V.w*M.wz
    #endif

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Result = (Mat * Vec);
    //
    //          |
    //       Vx |  Mxx  Myx  Mzx  Mwx
    //          |  +    +    +    +
    //       Vy |  Mxy  Myy  Mzy  Mwy
    //          |  +    +    +    +
    //       Vz |  Mxz  Myz  Mzz  Mwz
    //          |  +    +    +    +
    //       Vw |  Mxw  Myw  Mzw  Mww
    //      ----+----------------------
    //          |  Rx   Ry   Rz   Rw
    //


    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    public static bool operator ==(mat4 A, mat4 B) => (A.xx==B.xx && A.yx==B.yx && A.zx==B.zx && A.wx==B.wx &&
                                                       A.xy==B.xy && A.yy==B.yy && A.zy==B.zy && A.wy==B.wy &&
                                                       A.xz==B.xz && A.yz==B.yz && A.zz==B.zz && A.wz==B.wz &&
                                                       A.xw==B.xw && A.yw==B.yw && A.zw==B.zw && A.ww==B.ww );

    public static bool operator !=(mat4 A, mat4 B) => (A.xx!=B.xx || A.yx!=B.yx || A.zx!=B.zx || A.wx!=B.wx ||
                                                       A.xy!=B.xy || A.yy!=B.yy || A.zy!=B.zy || A.wy!=B.wy ||
                                                       A.xz!=B.xz || A.yz!=B.yz || A.zz!=B.zz || A.wz!=B.wz ||
                                                       A.xw!=B.xw || A.yw!=B.yw || A.zw!=B.zw || A.ww!=B.ww );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly override string ToString() => $"""
        |  {xx,8:0.00000}  {yx,8:0.00000}  {zx,8:0.00000}  {wx,8:0.00000}  |
        |  {xy,8:0.00000}  {yy,8:0.00000}  {zy,8:0.00000}  {wy,8:0.00000}  |
        |  {xz,8:0.00000}  {yz,8:0.00000}  {zz,8:0.00000}  {wz,8:0.00000}  |
        |  {xw,8:0.00000}  {yw,8:0.00000}  {zw,8:0.00000}  {ww,8:0.00000}  |
    """;

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
