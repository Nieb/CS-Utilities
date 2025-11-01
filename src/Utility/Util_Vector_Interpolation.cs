
namespace Utility;
using v1 = float;
using v2 = vec2;
using v3 = vec3;
using v4 = vec4;
internal static class VEC_Interpolation {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Mix" functions use a Weight to return an interpolation of A and B.
    //
    //  "Step" functions return an interpolated-Weight reflecting V's position between A and B.
    //
    //      https://www.desmos.com/calculator/5fe71775ae
    //
    //
    //  Note:  Order of parameters differs from GLSL.  Also, TitleCase.
    //
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Linear Interpolation"
    //  Mix(
    //      V: 0..1     Weighted position between A and B.
    //      A: any      Values to be mixed.
    //      B: any      Values to be mixed.
    //  )
    //
    //  OUTPUT: A..B
    //
    //    GLSL: mix(X, Y, A)
    //              Linear interpolation between X & Y, using A to weight between them.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/mix.xhtml
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 Mix(v1 V, v1 A, v1 B) => A*(1f-V) + B*V;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 Mix(v1 V, v2 A, v2 B) => A*(1f-V) + B*V;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 Mix(v2 V, v2 A, v2 B) => A*(1f-V) + B*V;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 Mix(v1 V, v3 A, v3 B) => A*(1f-V) + B*V;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 Mix(v3 V, v3 A, v3 B) => A*(1f-V) + B*V;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 Mix(v1 V, v4 A, v4 B) => A*(1f-V) + B*V;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 Mix(v4 V, v4 A, v4 B) => A*(1f-V) + B*V;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                              "Bilinear Interpolation"
    //  BiMix(
    //      V: (0..1, 0..1)     Weighted position for X & Y axis.
    //      A: any              Values to be mixed.
    //      B: any              Values to be mixed.
    //      C: any              Values to be mixed.
    //      D: any              Values to be mixed.
    //  )
    //
    //  OUTPUT: A..B
    //          :  :
    //          C..D
    //
    internal static v1 BiMix(v2 V,  v1 A, v1 B, v1 C, v1 D) {v2 iV = (1f - V); return A*(iV.x*iV.y) + B*(V.x*iV.y)
                                                                                    + C*(iV.x* V.y) + D*(V.x* V.y);}

    internal static v2 BiMix(v2 V,  v2 A, v2 B, v2 C, v2 D) {v2 iV = (1f - V); return A*(iV.x*iV.y) + B*(V.x*iV.y)
                                                                                    + C*(iV.x* V.y) + D*(V.x* V.y);}

    internal static v3 BiMix(v2 V,  v3 A, v3 B, v3 C, v3 D) {v2 iV = (1f - V); return A*(iV.x*iV.y) + B*(V.x*iV.y)
                                                                                    + C*(iV.x* V.y) + D*(V.x* V.y);}

    internal static v4 BiMix(v2 V,  v4 A, v4 B, v4 C, v4 D) {v2 iV = (1f - V); return A*(iV.x*iV.y) + B*(V.x*iV.y)
                                                                                    + C*(iV.x* V.y) + D*(V.x* V.y);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Hermite Interpolation"
    //  SmoothMix(
    //      V: 0..1     Weighted position between A and B.
    //      A: any      Values to be mixed.
    //      B: any      Values to be mixed.
    //  )
    //
    //  OUTPUT: A..B
    //
    internal static v1 SmoothMix(v1 V,   v1 A, v1 B) {
        v1 dAB = B - A;
        v1 LinStep = clamp((V*dAB) / dAB);
        v1 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    internal static v2 SmoothMix(v1 V,   v2 A, v2 B) {
        v2 dAB = B - A;
        v2 LinStep = clamp((V*dAB) / dAB);
        v2 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    internal static v3 SmoothMix(v1 V,   v3 A, v3 B) {
        v3 dAB = B - A;
        v3 LinStep = clamp((V*dAB) / dAB);
        v3 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    internal static v4 SmoothMix(v1 V,   v4 A, v4 B) {
        v4 dAB = B - A;
        v4 LinStep = clamp((V*dAB) / dAB);
        v4 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                          "Spherical Linear Interpolation"
    //  Slerp(
    //      V: 0..1     Weighted position between A and B.
    //      A: any      ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: A..B
    //
    internal static v2 Clerp(v1 V,   v2 A, v2 B) {
        float ThetaAB = acos( dot(A,B) );
        float SinT = sin(ThetaAB);
        float iV = (1f - V);

        A *= sin(ThetaAB * iV) / SinT;
        B *= sin(ThetaAB *  V) / SinT;
        return A + B;
    }

    internal static v3 Slerp(v1 V,   v3 A, v3 B) {
        float ThetaAB = acos( dot(A,B) );
        float SinT = sin(ThetaAB);
        float iV = (1f - V);

        A *= sin(ThetaAB * iV) / SinT;
        B *= sin(ThetaAB *  V) / SinT;
        return A + B;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Threshold"               In the same spirit as "Nearest Neighbor Interpolation".
    //  Step(
    //      V: any      Value
    //      T: any      Threshold
    //  )
    //
    //  OUTPUT: 0|1
    //
    //    GLSL: step(Edge, X);
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 Step(v1 V, v1 T) => (V < T) ? 0f : 1f;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 Step(v2 V, v1 T) => new v2( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 Step(v2 V, v2 T) => new v2( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f );

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 Step(v3 V, v1 T) => new v3( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f,  (V.z < T  ) ? 0f : 1f );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 Step(v3 V, v3 T) => new v3( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f,  (V.z < T.z) ? 0f : 1f );

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 Step(v4 V, v1 T) => new v4( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f,  (V.z < T  ) ? 0f : 1f,  (V.w < T  ) ? 0f : 1f );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 Step(v4 V, v4 T) => new v4( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f,  (V.z < T.z) ? 0f : 1f,  (V.w < T.w) ? 0f : 1f );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Linear Interpolation"
    //  LinearStep(
    //      V: any      Value to weigh between A and B.
    //      A: any      ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 LinearStep(v1 V, v1 A, v1 B) => clamp((V-A) / (B-A));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 LinearStep(v1 V, v2 A, v2 B) => clamp((V-A) / (B-A));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 LinearStep(v2 V, v2 A, v2 B) => clamp((V-A) / (B-A));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 LinearStep(v1 V, v3 A, v3 B) => clamp((V-A) / (B-A));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 LinearStep(v3 V, v3 A, v3 B) => clamp((V-A) / (B-A));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Hermite Interpolation"
    //  SmoothStep(
    //      V: any      Value to weigh between A and B.
    //      A: any      ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //    GLSL: smoothstep(Edge0, Edge1, X)
    //              Smooth Hermite-interpolation between 0 & 1 when Edge0 < X < Edge1.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/smoothstep.xhtml
    //
    //  -2*(x^3) + 3*(x^2)
    //   x*x * (-2*x + 3)
    //
    internal static v1 SmoothStep(v1 V)               {V = clamp(V);              return V*V * (3f - 2f*V);}
    internal static v1 SmoothStep(v1 V,   v1 A, v1 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}

    internal static v2 SmoothStep(v2 V)               {V = clamp(V);              return V*V * (3f - 2f*V);}
    internal static v2 SmoothStep(v2 V,   v2 A, v2 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}
    internal static v2 SmoothStep(v2 V,   v1 A, v1 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}
  //internal static v2 SmoothStep(v1 V,   v2 A, v2 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}

    internal static v3 SmoothStep(v3 V)               {V = clamp(V);              return V*V * (3f - 2f*V);}
    internal static v3 SmoothStep(v3 V,   v3 A, v3 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}
    internal static v3 SmoothStep(v3 V,   v1 A, v1 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}
  //internal static v3 SmoothStep(v1 V,   v3 A, v3 B) {V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);}

    //==========================================================================================================================================================
    //
    //  SharpStep(
    //      V: any      Value to weigh between A and B.
    //      A: any      ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //  6*(x^5) - 15*(x^4) + 10*(x^3)
    //
    //   x*x*x * ((6*x - 15)*x + 10)
    //
    //  AKA: "SmootherStep()"
    //      Not actually "Smoother".
    //          The sharper/tighter bends bring this more inline with Step.
    //
    //          Or, in a way, more inline with the sharp/abrupt bends of LinearStep,
    //          albeit with a shorter middle transition than LinearStep (the part around 0.5).
    //
    internal static v1 SharpStep(v1 V)             {V = clamp(V);              return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v1 SharpStep(v1 V, v1 A, v1 B) {V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);}

    internal static v2 SharpStep(v2 V)             {V = clamp(V);              return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v2 SharpStep(v2 V, v2 A, v2 B) {V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v2 SharpStep(v2 V, v1 A, v1 B) {V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);}

    internal static v3 SharpStep(v3 V)             {V = clamp(V);              return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v3 SharpStep(v3 V, v3 A, v3 B) {V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v3 SharpStep(v3 V, v1 A, v1 B) {V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);}

    //==========================================================================================================================================================
    //
    //  SharperStep(
    //      V: any      Value to weigh between A and B.
    //      A: any      ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //  AKA: "SmoothestStep()"
    //
    internal static v1 SharperStep(v1 V,   v1 A, v1 B) {
        if (B == A)
            return (V > B) ? 1f : 0f;

        V = clamp((V-A) / (B-A));

        float VV   = V   * V;
        float VVV  = VV  * V;
        float VVVV = VVV * V;

        return VVVV * (-20f*VVV + 70f*VV - 84f*V + 35f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
