using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct mat4 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float xx;  [FieldOffset( 4)] public float yx;  [FieldOffset( 8)] public float zx;  [FieldOffset(12)] public float wx;
    [FieldOffset(16)] public float xy;  [FieldOffset(20)] public float yy;  [FieldOffset(24)] public float zy;  [FieldOffset(28)] public float wy;
    [FieldOffset(32)] public float xz;  [FieldOffset(36)] public float yz;  [FieldOffset(40)] public float zz;  [FieldOffset(44)] public float wz;
    [FieldOffset(48)] public float xw;  [FieldOffset(52)] public float yw;  [FieldOffset(56)] public float zw;  [FieldOffset(60)] public float ww;

    //==========================================================================================================================================================
    //[FieldOffset(0)] private fixed float index[16];
    //#if DEBUG
    //    public readonly float this[int i]        => (i < 0 || i > 15)                  ? throw new System.IndexOutOfRangeException() : this.index[i];
    //    public readonly float this[int x, int y] => (x < 0 || x > 3 || y < 0 || y > 3) ? throw new System.IndexOutOfRangeException() : this.index[x + 4*y];
    //#else
    //    public readonly float this[int i]        => this.index[i];
    //    public readonly float this[int x, int y] => this.index[x + 4*y];
    //#endif

    public float this[int i] {
        get {
            switch (i) {
                case  0:return xx;  case  1:return yx;  case  2:return zx;  case  3:return wx;
                case  4:return xy;  case  5:return yy;  case  6:return zy;  case  7:return wy;
                case  8:return xz;  case  9:return yz;  case 10:return zz;  case 11:return wz;
                case 12:return xw;  case 13:return yw;  case 14:return zw;  case 15:return ww;
            }
            throw new System.IndexOutOfRangeException();
        }
        set {
            switch (i) {
                case  0:xx = value;return;  case  1:yx = value;return;  case  2:zx = value;return;  case  3:wx = value;return;
                case  4:xy = value;return;  case  5:yy = value;return;  case  6:zy = value;return;  case  7:wy = value;return;
                case  8:xz = value;return;  case  9:yz = value;return;  case 10:zz = value;return;  case 11:wz = value;return;
                case 12:xw = value;return;  case 13:yw = value;return;  case 14:zw = value;return;  case 15:ww = value;return;
            }
            throw new System.IndexOutOfRangeException();
        }
    }

    public float this[int x, int y] {
        get {
            switch (y) {
                case 0:switch (x) {case 0:return xx;  case 1:return yx;  case 2:return zx;  case 3:return wx;} break;
                case 1:switch (x) {case 0:return xy;  case 1:return yy;  case 2:return zy;  case 3:return wy;} break;
                case 2:switch (x) {case 0:return xz;  case 1:return yz;  case 2:return zz;  case 3:return wz;} break;
                case 3:switch (x) {case 0:return xw;  case 1:return yw;  case 2:return zw;  case 3:return ww;} break;
            }
            throw new System.IndexOutOfRangeException();
        }
        set {
            switch (y) {
                case 0:switch (x) {case 0:xx = value;return;  case 1:yx = value;return;  case 2:zx = value;return;  case 3:wx = value;return;} break;
                case 1:switch (x) {case 0:xy = value;return;  case 1:yy = value;return;  case 2:zy = value;return;  case 3:wy = value;return;} break;
                case 2:switch (x) {case 0:xz = value;return;  case 1:yz = value;return;  case 2:zz = value;return;  case 3:wz = value;return;} break;
                case 3:switch (x) {case 0:xw = value;return;  case 1:yw = value;return;  case 2:zw = value;return;  case 3:ww = value;return;} break;
            }
            throw new System.IndexOutOfRangeException();
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public mat4() {
        xx = 1f; yx = 0f; zx = 0f; wx = 0f;
        xy = 0f; yy = 1f; zy = 0f; wy = 0f;
        xz = 0f; yz = 0f; zz = 1f; wz = 0f;
        xw = 0f; yw = 0f; zw = 0f; ww = 1f;
    }

    public mat4(float XX, float YX, float ZX, float WX,
                float XY, float YY, float ZY, float WY,
                float XZ, float YZ, float ZZ, float WZ,
                float XW, float YW, float ZW, float WW) {
        xx = XX; yx = YX; zx = ZX; wx = WX;
        xy = XY; yy = YY; zy = ZY; wy = WY;
        xz = XZ; yz = YZ; zz = ZZ; wz = WZ;
        xw = XW; yw = YW; zw = ZW; ww = WW;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    public static mat4 operator *(mat4 A, mat4 B) => new mat4(
        // Row X
        A.xx*B.xx + A.yx*B.xy + A.zx*B.xz + A.wx*B.xw,  // XX = dot( A.RowX, B.ColX )
        A.xx*B.yx + A.yx*B.yy + A.zx*B.yz + A.wx*B.yw,  // YX = dot( A.RowX, B.ColY )
        A.xx*B.zx + A.yx*B.zy + A.zx*B.zz + A.wx*B.zw,  // ZX = dot( A.RowX, B.ColZ )
        A.xx*B.wx + A.yx*B.wy + A.zx*B.wz + A.wx*B.ww,  // WX = dot( A.RowX, B.ColW )

        // Row Y
        A.xy*B.xx + A.yy*B.xy + A.zy*B.xz + A.wy*B.xw,  // XY
        A.xy*B.yx + A.yy*B.yy + A.zy*B.yz + A.wy*B.yw,  // YY
        A.xy*B.zx + A.yy*B.zy + A.zy*B.zz + A.wy*B.zw,  // ZY
        A.xy*B.wx + A.yy*B.wy + A.zy*B.wz + A.wy*B.ww,  // WY

        // Row Z
        A.xz*B.xx + A.yz*B.xy + A.zz*B.xz + A.wz*B.xw,  // XZ
        A.xz*B.yx + A.yz*B.yy + A.zz*B.yz + A.wz*B.yw,  // YZ
        A.xz*B.zx + A.yz*B.zy + A.zz*B.zz + A.wz*B.zw,  // ZZ
        A.xz*B.wx + A.yz*B.wy + A.zz*B.wz + A.wz*B.ww,  // WZ

        // Row W
        A.xw*B.xx + A.yw*B.xy + A.zw*B.xz + A.ww*B.xw,  // XW
        A.xw*B.yx + A.yw*B.yy + A.zw*B.yz + A.ww*B.yw,  // YW
        A.xw*B.zx + A.yw*B.zy + A.zw*B.zz + A.ww*B.zw,  // ZW
        A.xw*B.wx + A.yw*B.wy + A.zw*B.wz + A.ww*B.ww   // WW
    );

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
                                                                  fma(V.x,M.xw, fma(V.y,M.yw, fma(V.z,M.zw, (V.w*M.ww)))));

        public static vec3 operator *(vec3 V, mat4 M) => new vec3(fma(V.x,M.xx, fma(V.y,M.yx, (V.z*M.zx))),
                                                                  fma(V.x,M.xy, fma(V.y,M.yy, (V.z*M.zy))),
                                                                  fma(V.x,M.xz, fma(V.y,M.yz, (V.z*M.zz))));

    #else
        public static vec4 operator *(vec4 V, mat4 M) => new vec4(V.x*M.xx + V.y*M.yx + V.z*M.zx + V.w*M.wx,
                                                                  V.x*M.xy + V.y*M.yy + V.z*M.zy + V.w*M.wy,
                                                                  V.x*M.xz + V.y*M.yz + V.z*M.zz + V.w*M.wz,
                                                                  V.x*M.xw + V.y*M.yw + V.z*M.zw + V.w*M.ww);

        public static vec3 operator *(vec3 V, mat4 M) => new vec3(V.x*M.xx + V.y*M.yx + V.z*M.zx,
                                                                  V.x*M.xy + V.y*M.yy + V.z*M.zy,
                                                                  V.x*M.xz + V.y*M.yz + V.z*M.zz);
    #endif

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    public static bool operator ==(mat4 A, mat4 B) => (A.xx==B.xx  &&  A.yx==B.yx  &&  A.zx==B.zx  &&  A.wx==B.wx  &&
                                                       A.xy==B.xy  &&  A.yy==B.yy  &&  A.zy==B.zy  &&  A.wy==B.wy  &&
                                                       A.xz==B.xz  &&  A.yz==B.yz  &&  A.zz==B.zz  &&  A.wz==B.wz  &&
                                                       A.xw==B.xw  &&  A.yw==B.yw  &&  A.zw==B.zw  &&  A.ww==B.ww);

    public static bool operator !=(mat4 A, mat4 B) => (A.xx!=B.xx  ||  A.yx!=B.yx  ||  A.zx!=B.zx  ||  A.wx!=B.wx  ||
                                                       A.xy!=B.xy  ||  A.yy!=B.yy  ||  A.zy!=B.zy  ||  A.wy!=B.wy  ||
                                                       A.xz!=B.xz  ||  A.yz!=B.yz  ||  A.zz!=B.zz  ||  A.wz!=B.wz  ||
                                                       A.xw!=B.xw  ||  A.yw!=B.yw  ||  A.zw!=B.zw  ||  A.ww!=B.ww);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly override string ToString() => $"""
        |  {xx,6:0.000}  {yx,6:0.000}  {zx,6:0.000}  {wx,6:0.000}  |
        |  {xy,6:0.000}  {yy,6:0.000}  {zy,6:0.000}  {wy,6:0.000}  |
        |  {xz,6:0.000}  {yz,6:0.000}  {zz,6:0.000}  {wz,6:0.000}  |
        |  {xw,6:0.000}  {yw,6:0.000}  {zw,6:0.000}  {ww,6:0.000}  |
    """;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by "object" type:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
