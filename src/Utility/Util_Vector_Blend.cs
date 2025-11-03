
namespace Utility;
internal static partial class VEC_Blend {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      Blend_*(  Source,  Destination  )
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################

    //==========================================================================================================================================================
    internal static v1 Blend_Screen(v1 S, v1 D) => (S+D - S*D);
    internal static v3 Blend_Screen(v3 S, v3 D) => (S+D - S*D);
    internal static v3 Blend_Screen(v3 S, v1 D) => (S+D - S*D);
    internal static v3 Blend_Screen(v1 S, v3 D) => (S+D - S*D);

    //==========================================================================================================================================================
    internal static v1 Blend_Overlay(v1 S, v1 D) => (D <= 0.5f) ?      2f*(   S)*(   D)
                                                                : 1f - 2f*(1f-S)*(1f-D);

    internal static v3 Blend_Overlay(v3 S, v3 D) => new v3(Blend_Overlay(S.r, D.r),Blend_Overlay(S.g, D.g),Blend_Overlay(S.b, D.b));
    internal static v3 Blend_Overlay(v3 S, v1 D) => new v3(Blend_Overlay(S.r, D  ),Blend_Overlay(S.g, D  ),Blend_Overlay(S.b, D  ));
    internal static v3 Blend_Overlay(v1 S, v3 D) => new v3(Blend_Overlay(S  , D.r),Blend_Overlay(S  , D.g),Blend_Overlay(S  , D.b));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static v1 Blend_SoftLight(v1 S, v1 D) => (S <= 0.5f              ) ? D - (1f-2f*S   ) * D*(       1f - D     )
                                                    : (S >  0.5f && D <= 0.25f) ? D + (   2f*S-1f) * D*((16f*D-12f)*D + 3f)
                                                                                : D + (   2f*S-1f) *   (  sqrt(D) - D     );

    internal static v3 Blend_SoftLight(v3 S, v3 D) => new v3(Blend_SoftLight(S.r, D.r),Blend_SoftLight(S.g, D.g),Blend_SoftLight(S.b, D.b));
    internal static v3 Blend_SoftLight(v3 S, v1 D) => new v3(Blend_SoftLight(S.r, D  ),Blend_SoftLight(S.g, D  ),Blend_SoftLight(S.b, D  ));
    internal static v3 Blend_SoftLight(v1 S, v3 D) => new v3(Blend_SoftLight(S  , D.r),Blend_SoftLight(S  , D.g),Blend_SoftLight(S  , D.b));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static v1 Blend_HardLight(v1 S, v1 D) => (S <= 0.5f) ?      2f*(   S)*(   D)
                                                                  : 1f - 2f*(1f-S)*(1f-D);

    internal static v3 Blend_HardLight(v3 S, v3 D) => new v3(Blend_HardLight(S.r, D.r),Blend_HardLight(S.g, D.g),Blend_HardLight(S.b, D.b));
    internal static v3 Blend_HardLight(v3 S, v1 D) => new v3(Blend_HardLight(S.r, D  ),Blend_HardLight(S.g, D  ),Blend_HardLight(S.b, D  ));
    internal static v3 Blend_HardLight(v1 S, v3 D) => new v3(Blend_HardLight(S  , D.r),Blend_HardLight(S  , D.g),Blend_HardLight(S  , D.b));

    //==========================================================================================================================================================
    internal static v1 Blend_Difference(v1 S, v1 D) => abs(D-S);
    internal static v3 Blend_Difference(v3 S, v3 D) => abs(D-S);
    internal static v3 Blend_Difference(v3 S, v1 D) => abs(D-S);
    internal static v3 Blend_Difference(v1 S, v3 D) => abs(D-S);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static v1 Blend_Exclusion(v1 S, v1 D) => (S+D - 2f*S*D);
    internal static v3 Blend_Exclusion(v3 S, v3 D) => (S+D - 2f*S*D);
    internal static v3 Blend_Exclusion(v3 S, v1 D) => (S+D - 2f*S*D);
    internal static v3 Blend_Exclusion(v1 S, v3 D) => (S+D - 2f*S*D);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}

#if  false
    //Mode                      Blend
    //--------------------      -----------------------------------

      Multiply(S,D)           = S*D

      Darken(S,D)             = min(S,D)
      Lighten(S,D)            = max(S,D)

      Invert(S,D)             =     1-D
      Invert_RGB(S,D)         = S*(1-D)


      HardMix(S,D)            = (S+D < 1) ? 0 : 1


      LinearDodge(S,D)        = (S+D <= 1) ?  S+D    : 1
      LinearBurn(S,D)         = (S+D >  1) ?  S+D-1  : 0


      ColorDodge(S,D)         = (D <= 0           ) ? 0
                                (D >  0 and S <  1) ? min(1, D/(1-S))
                                (D >  0 and S >= 1) ? 1

      ColorBurn(S,D)          = (D >= 1           ) ? 1
                                (D <  1 and S >  0) ? 1 - min(1, (1-D)/S)
                                (D <  1 and S <= 0) ? 0




      VividLight(S,D)         = (       S <= 0  ) ? 0
                                (0   <  S <  0.5) ? 1-min(1, (1-D)/(2*S))
                                (0.5 <= S <  1  ) ?   min(1, D/(2*(1-S)))
                                (       S >= 1  ) ? 1

      LinearLight(S,D)        = (    2*S+D <= 1) ? 0
                                (1 < 2*S+D <= 2) ? 2*S+D-1
                                (    2*S+D >  2) ? 1

      PinLight(S,D)           = (2*S-1> D and S< 0.5  ) ? 0
                                (2*S-1> D and S>=0.5  ) ? 2*S-1
                                (2*S-1<=D and S< 0.5*D) ? 2*S
                                (2*S-1<=D and S>=0.5*D) ? D
#endif
