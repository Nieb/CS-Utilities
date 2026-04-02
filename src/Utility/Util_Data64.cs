
namespace Utility;
internal static partial class DATA {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct Data64 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public f64 F = default;
    [FieldOffset(0)] public s64 I = default;
    [FieldOffset(0)] public u64 U = default;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public override string ToString() => $"[F:{this.F,9}  I:{this.I,11}  U:{this.U,11}]";

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public Data64() {}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator Data64(f64 F) => new Data64(){F = F}; //  double  to  Data64
    [Impl(AggressiveInlining)] public static implicit operator Data64(s64 I) => new Data64(){I = I}; //    long  to  Data64
    [Impl(AggressiveInlining)] public static implicit operator Data64(u64 U) => new Data64(){U = U}; //   ulong  to  Data64

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static f64 operator +(Data64 A, f64 B) => (A.F + B);
    [Impl(AggressiveInlining)] public static s64 operator +(Data64 A, s64 B) => (A.I + B);
    [Impl(AggressiveInlining)] public static u64 operator +(Data64 A, u64 B) => (A.U + B);

    [Impl(AggressiveInlining)] public static f64 operator -(Data64 A, f64 B) => (A.F - B);
    [Impl(AggressiveInlining)] public static s64 operator -(Data64 A, s64 B) => (A.I - B);
    [Impl(AggressiveInlining)] public static u64 operator -(Data64 A, u64 B) => (A.U - B);

  //[Impl(AggressiveInlining)] public static f64 operator -(Data64 A) => -A.F;
  //[Impl(AggressiveInlining)] public static s64 operator -(Data64 A) => -A.I;

    [Impl(AggressiveInlining)] public static f64 operator *(Data64 A, f64 B) => (A.F * B);
    [Impl(AggressiveInlining)] public static s64 operator *(Data64 A, s64 B) => (A.I * B);
    [Impl(AggressiveInlining)] public static u64 operator *(Data64 A, u64 B) => (A.U * B);

    [Impl(AggressiveInlining)] public static f64 operator /(Data64 A, f64 B) => (A.F / B);
    [Impl(AggressiveInlining)] public static s64 operator /(Data64 A, s64 B) => (A.I / B);
    [Impl(AggressiveInlining)] public static u64 operator /(Data64 A, u64 B) => (A.U / B);

    [Impl(AggressiveInlining)] public static f64 operator %(Data64 A, f64 B) => (A.F % B);
    [Impl(AggressiveInlining)] public static s64 operator %(Data64 A, s64 B) => (A.I % B);
    [Impl(AggressiveInlining)] public static u64 operator %(Data64 A, u64 B) => (A.U % B);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    [Impl(AggressiveInlining)] public static u64 operator ~(Data64 A) => (~A.U);

    [Impl(AggressiveInlining)] public static u64 operator &(Data64 A, Data64 B) => (A.U & B.U);
    [Impl(AggressiveInlining)] public static u64 operator &(Data64 A,    u64 B) => (A.U & B  );
    [Impl(AggressiveInlining)] public static u64 operator &(   u64 A, Data64 B) => (A   & B.U);

    [Impl(AggressiveInlining)] public static u64 operator |(Data64 A, Data64 B) => (A.U | B.U);
    [Impl(AggressiveInlining)] public static u64 operator |(Data64 A,    u64 B) => (A.U | B  );
    [Impl(AggressiveInlining)] public static u64 operator |(   u64 A, Data64 B) => (A   | B.U);

    [Impl(AggressiveInlining)] public static u64 operator ^(Data64 A, Data64 B) => (A.U ^ B.U);
    [Impl(AggressiveInlining)] public static u64 operator ^(Data64 A,    u64 B) => (A.U ^ B  );
    [Impl(AggressiveInlining)] public static u64 operator ^(   u64 A, Data64 B) => (A   ^ B.U);

    [Impl(AggressiveInlining)] public static u64 operator <<(Data64 A, int n)  => (A.U << n);
    [Impl(AggressiveInlining)] public static u64 operator >>(Data64 A, int n)  => (A.U >> n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(Data64 A, f64 B) => (A.F == B);
    [Impl(AggressiveInlining)] public static bool operator ==(Data64 A, s64 B) => (A.I == B);
    [Impl(AggressiveInlining)] public static bool operator ==(Data64 A, u64 B) => (A.U == B);

    [Impl(AggressiveInlining)] public static bool operator !=(Data64 A, f64 B) => (A.F != B);
    [Impl(AggressiveInlining)] public static bool operator !=(Data64 A, s64 B) => (A.I != B);
    [Impl(AggressiveInlining)] public static bool operator !=(Data64 A, u64 B) => (A.U != B);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(Data64 A, f64 B) => (A.F <  B);
    [Impl(AggressiveInlining)] public static bool operator  <(Data64 A, s64 B) => (A.I <  B);
    [Impl(AggressiveInlining)] public static bool operator  <(Data64 A, u64 B) => (A.U <  B);

    [Impl(AggressiveInlining)] public static bool operator  >(Data64 A, f64 B) => (A.F >  B);
    [Impl(AggressiveInlining)] public static bool operator  >(Data64 A, s64 B) => (A.I >  B);
    [Impl(AggressiveInlining)] public static bool operator  >(Data64 A, u64 B) => (A.U >  B);

    [Impl(AggressiveInlining)] public static bool operator <=(Data64 A, f64 B) => (A.F <= B);
    [Impl(AggressiveInlining)] public static bool operator <=(Data64 A, s64 B) => (A.I <= B);
    [Impl(AggressiveInlining)] public static bool operator <=(Data64 A, u64 B) => (A.U <= B);

    [Impl(AggressiveInlining)] public static bool operator >=(Data64 A, f64 B) => (A.F >= B);
    [Impl(AggressiveInlining)] public static bool operator >=(Data64 A, s64 B) => (A.I >= B);
    [Impl(AggressiveInlining)] public static bool operator >=(Data64 A, u64 B) => (A.U >= B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
