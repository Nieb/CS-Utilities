

namespace Utility;
internal static partial class MAT {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct mat2 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                                          |       Col 0           Col 1
    //                                  --------+-----------------------------------
    //                  [i] [x,y] **      Row 0 |   [ 0] [0,0] XX   [ 1] [1,0] YX
    //                   [Col, Row]       Row 1 |   [ 2] [0,1] XY   [ 3] [1,1] YY
    //                                          |
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float xx;  [FieldOffset( 4)] public float yx;
    [FieldOffset( 8)] public float xy;  [FieldOffset(12)] public float yy;

    //==========================================================================================================================================================
    public vec2 Col0 {get => new vec2(xx,xy); set {xx=value.x; xy=value.y;}}
    public vec2 Col1 {get => new vec2(yx,yy); set {yx=value.x; yy=value.y;}}

    [FieldOffset(0)] public vec2 Row0;    [FieldOffset(0)] public vec2 RowX;
    [FieldOffset(8)] public vec2 Row1;    [FieldOffset(8)] public vec2 RowY;

    //==========================================================================================================================================================
    [FieldOffset(0)] private InlineArray4_Float index;

    public float this[int i] {
        [Impl(AggressiveInlining)] get => this.index[i];
        [Impl(AggressiveInlining)] set => this.index[i] = value;
    }

    public float this[int x, int y] {
        #if DEBUG
            get =>                       (x<0||x>1||y<0||y>1) ? throw new System.IndexOutOfRangeException() : this.index[x + 2*y];
            set => this.index[x + 2*y] = (x<0||x>1||y<0||y>1) ? throw new System.IndexOutOfRangeException() : value;
        #else
            [Impl(AggressiveInlining)] get => this.index[x + 2*y];
            [Impl(AggressiveInlining)] set => this.index[x + 2*y] = value;
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      mat2 A = default;   Zeroed out.
    //      mat2 B = new();     Identity.
    //
    public mat2() {
        xx=1f; yx=0f;
        xy=0f; yy=1f;
    }

    public mat2(float V) {
        xx=V; yx=V;
        xy=V; yy=V;
    }

    public mat2(float XX, float YX,
                float XY, float YY) {
        xx=XX; yx=YX;
        xy=XY; yy=YY;
    }

    //  Truncate Mat3 to Mat2:
    public mat2(mat3 M) {
        xx=M.xx; yx=M.yx;
        xy=M.xy; yy=M.yy;
    }

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator mat2(mat3 M) => new mat2(M); //  mat3  to  mat2

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //      Result = (Mat * Mat)
    //
    #if false
        [Impl(AggressiveInlining)] public static mat2 operator *(mat2 A, mat2 B) => new mat2(dot(A.Row0, B.Col0),  dot(A.Row0, B.Col1),
                                                                                             dot(A.Row1, B.Col0),  dot(A.Row1, B.Col1) );
    #else
        [Impl(AggressiveInlining)] public static mat2 operator *(mat2 A, mat2 B) => new mat2(XX: A.xx*B.xx + A.yx*B.xy,  YX: A.xx*B.yx + A.yx*B.yy,
                                                                                             XY: A.xy*B.xx + A.yy*B.xy,  YY: A.xy*B.yx + A.yy*B.yy );
    #endif

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //                                     Vx    Vy   |
    //                                  --------------+----
    //                                     Mxx + Myx  | Rx
    //      Result = (Vec * Mat)                      |
    //                                     Mxy + Myy  | Ry
    //                                                |
    //
    #if false
        [Impl(AggressiveInlining)] public static vec2 operator *(vec2 V, mat2 M) => new vec2(fma(V.x,M.xx, (V.y*M.yx)),
                                                                                             fma(V.x,M.xy, (V.y*M.yy)) );
    #else
        [Impl(AggressiveInlining)] public static vec2 operator *(vec2 V, mat2 M) => new vec2(V.x*M.xx + V.y*M.yx,
                                                                                             V.x*M.xy + V.y*M.yy );
    #endif

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //                                      |
    //                                   Vx |  Mxx  Myx
    //      Result = (Mat * Vec)            |  +    +
    //                                   Vy |  Mxy  Myy
    //                                  ----+------------
    //                                      |  Rx   Ry
    //
    #if false
        [Impl(AggressiveInlining)] public static vec2 operator *(mat2 M, vec2 V) => new vec2(fma(V.x,M.xx, (V.x*M.xy)),
                                                                                             fma(V.y,M.yx, (V.y*M.yy)) );
    #else
        [Impl(AggressiveInlining)] public static vec2 operator *(mat2 M, vec2 V) => new vec2(V.x*M.xx + V.x*M.xy,
                                                                                             V.y*M.yx + V.y*M.yy );
    #endif

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(mat2 A, mat2 B) => (A.xx==B.xx && A.yx==B.yx &&
                                                                                  A.xy==B.xy && A.yy==B.yy );

    [Impl(AggressiveInlining)] public static bool operator !=(mat2 A, mat2 B) => (A.xx!=B.xx || A.yx!=B.yx ||
                                                                                  A.xy!=B.xy || A.yy!=B.yy );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly override string ToString() => $"""
        |  {xx,8:0.00000}  {yx,8:0.00000}  |
        |  {xy,8:0.00000}  {yy,8:0.00000}  |
    """;

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
