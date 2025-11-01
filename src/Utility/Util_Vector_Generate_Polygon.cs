

namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Generate array of points of a regular polygon.
    //
    //  Point weinding is anti-clockwise.
    //  Though, using a negative radius will reverse the order.
    //
    //  https://www.desmos.com/calculator/ljqolw7ab1
    //
    internal static vec2[] Polygon2(int Sides, float Radius = 1f) {
        #if DEBUG
            if (Sides < 3) throw new System.ArgumentException("Derp?");
        #endif

        vec2[] Polygon = new vec2[Sides];

        for (int i = 0; i < Sides; ++i) {
            float rad = -i * (PI2/Sides);
            Polygon[i] = new vec2(sin(rad)*Radius, cos(rad)*Radius);
        }

        return Polygon;
    }

    //==========================================================================================================================================================
    internal static vec3[] Polygon3(int Sides, float Radius = 1f) {
        #if DEBUG
            if (Sides < 3) throw new System.ArgumentException("Derp?");
        #endif

        vec3[] Polygon = new vec3[Sides];

        for (int i = 0; i < Sides; ++i) {
            float rad = -i * (PI2/Sides);
            Polygon[i] = new vec3(sin(rad)*Radius, 0f, -cos(rad)*Radius);
        }

        return Polygon;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      LINE(  A = (x,y), B = (x,y),    Segs = 2, Rds = 1f  )
    //
    //                        0            9
    //                    1 .-+------------+-. 8
    //                     / \|            |/ \
    //                  2 +---a------------b---+ 7
    //                     \ /|            |\ /
    //                    3 *-+------------+-* 6
    //                        4            5
    //
    //  Segments is per-Quadrant.
    //
    internal static vec2[] Polygon2_Line(vec2 A, vec2 B, int Segments, float Radius = 1f) {
        Segments = max(1, Segments);

        vec2 dAB = normalize(B-A);
        vec2 P0 = (-dAB.y, dAB.x); //  RotateLeft   a <---> 0

        vec2[] P = new vec2[4*Segments + 2];

        P[         0  ] = A + (P0  * Radius); //  a <---> 0
        P[  Segments  ] = A - (dAB * Radius); //  a <---> 2
        P[2*Segments  ] = A - (P0  * Radius); //  a <---> 4

        P[2*Segments+1] = B - (P0  * Radius); //  b <---> 5
        P[3*Segments+1] = B + (dAB * Radius); //  b <---> 7
        P[4*Segments+1] = B + (P0  * Radius); //  b <---> 9

        if (Segments > 1) {
            int i1 =   Segments;
            int i2 = 2*Segments + 1;
            int i3 = 3*Segments + 1;

            float ThetaStep = -PIH/Segments;
            vec2 nP;

            for (int iSeg = 1; iSeg < Segments; ++iSeg) {
                nP = rot(P0, ThetaStep * (float)iSeg);
                P[   iSeg] = A + Radius*nP;
                P[i1+iSeg] = A + Radius*new vec2(-nP.y,  nP.x);
                P[i2+iSeg] = B + Radius*new vec2(-nP.x, -nP.y);
                P[i3+iSeg] = B + Radius*new vec2( nP.y, -nP.x);
            }
        }

        return P;
    }

#if false
    internal static void DrawCircleX(vec3 C, float Cr, int Segments) {
        float A_y = Cr, A_z = 0f;
        float B_y = 0f, B_z = 0f;

        if (Segments > 1) {
            float StepSize = PIH/Segments;

            for (int iSeg = 1; iSeg < Segments; ++iSeg) {
                B_y = cos(StepSize*iSeg) * Cr;
                B_z = sin(StepSize*iSeg) * Cr;
                DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z-A_z), WorldToScreen(C.x, C.y+B_y, -C.z-B_z) );
                DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z-A_z), WorldToScreen(C.x, C.y-B_y, -C.z-B_z) );
                DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z+A_z), WorldToScreen(C.x, C.y-B_y, -C.z+B_z) );
                DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z+A_z), WorldToScreen(C.x, C.y+B_y, -C.z+B_z) );
                A_y = B_y;
                A_z = B_z;
            }
        }

        B_y = 0f;
        B_z = Cr;
        DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z-A_z), WorldToScreen(C.x, C.y+B_y, -C.z-B_z) );
        DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z-A_z), WorldToScreen(C.x, C.y-B_y, -C.z-B_z) );
        DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z+A_z), WorldToScreen(C.x, C.y-B_y, -C.z+B_z) );
        DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z+A_z), WorldToScreen(C.x, C.y+B_y, -C.z+B_z) );
    }

    internal static vec2 WorldToScreen(vec3 W) => WorldToScreen(W.x, W.y, W.z);
    internal static vec2 WorldToScreen(float W_x, float W_y, float W_z) {
        vec2 ScreenPos = new();
        return ScreenPos;
    }
    internal static void DrawLine(vec2 A, vec2 B) {return;}
#endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
