
namespace Utility;
internal static class ARY {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Proper "Length" method.  (zero inclusive)
    //
    //                o----|--->|
    //                0    1    2
    //      Blarg = {"A", "B", "C"}
    //
    //  Blarg.count()  == 3      0 is empty.
    //  Blarg.length() == 2     -1 is empty.
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static int  count(this  float[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this double[] A) => (A == null) ? 0 : A.Length;

    [Impl(AggressiveInlining)] internal static int  count(this  sbyte[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this   byte[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this  short[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this ushort[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this    int[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this   uint[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this   long[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int  count(this  ulong[] A) => (A == null) ? 0 : A.Length;

    [Impl(AggressiveInlining)] internal static int  count(this  string  A) =>  A.IsVoid() ? 0 : A.Length;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static int length(this  float[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this double[] A) => (A == null) ? -1 : A.Length - 1;

    [Impl(AggressiveInlining)] internal static int length(this   byte[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this  sbyte[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this  short[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this ushort[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this    int[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this   uint[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this   long[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining)] internal static int length(this  ulong[] A) => (A == null) ? -1 : A.Length - 1;

    [Impl(AggressiveInlining)] internal static int length(this  string  A) =>  A.IsVoid() ? -1 : A.Length - 1;

    //==========================================================================================================================================================
    //
    //  Generic version.
    //  Works on Arrays, Lists, Strings, etc.
    //
    //[Impl(AggressiveInlining|AggressiveOptimization)]
    //internal static int  count<T>(this System.Collections.Generic.IEnumerable<T> Enmrbl) => (Enmrbl == null) ?  0 : System.Linq.Enumerable.Count(Enmrbl);
    //
    //[Impl(AggressiveInlining|AggressiveOptimization)]
    //internal static int length<T>(this System.Collections.Generic.IEnumerable<T> Enmrbl) => (Enmrbl == null) ? -1 : System.Linq.Enumerable.Count(Enmrbl) - 1;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      MyArray.Fill( WithThisValue );
    //
    [Impl(AggressiveInlining)] internal static void Fill(this  float[] A,  float V) => System.Array.Fill(A, V);

    [Impl(AggressiveInlining)] internal static void Fill(this   byte[] A,   byte V) => System.Array.Fill(A, V);

    [Impl(AggressiveInlining)] internal static void Fill(this  short[] A,  short V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this ushort[] A, ushort V) => System.Array.Fill(A, V);

    [Impl(AggressiveInlining)] internal static void Fill(this    int[] A,    int V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this   uint[] A,   uint V) => System.Array.Fill(A, V);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This method allocates a new array with the specified size,
    //  copies elements from the old array to the new one,
    //  and then replaces the old array reference with the new one.
    //
    //  Array must be one-dimensional.
    //
    //      MyArray.Resize( IndexCount );
    //
    [Impl(AggressiveInlining)] internal static void Resize(this  sbyte[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);
    [Impl(AggressiveInlining)] internal static void Resize(this   byte[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);

    [Impl(AggressiveInlining)] internal static void Resize(this  short[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);
    [Impl(AggressiveInlining)] internal static void Resize(this ushort[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);

    [Impl(AggressiveInlining)] internal static void Resize(this    int[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);
    [Impl(AggressiveInlining)] internal static void Resize(this   uint[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);

    [Impl(AggressiveInlining)] internal static void Resize(this  float[] A, int S) => System.Array.Resize(ref A, (S<0)?0:S);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      MyArray.SetFrom( ThisIndex,   Values, To, Set, Etc);
    //
    [Impl(AggressiveInlining)] internal static void SetFrom(this  sbyte[] Dest, int I, params  sbyte[] V) => V.CopyTo(Dest, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this   byte[] Dest, int I, params   byte[] V) => V.CopyTo(Dest, I);

    [Impl(AggressiveInlining)] internal static void SetFrom(this  short[] Dest, int I, params  short[] V) => V.CopyTo(Dest, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this ushort[] Dest, int I, params ushort[] V) => V.CopyTo(Dest, I);

    [Impl(AggressiveInlining)] internal static void SetFrom(this    int[] Dest, int I, params    int[] V) => V.CopyTo(Dest, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this   uint[] Dest, int I, params   uint[] V) => V.CopyTo(Dest, I);

    [Impl(AggressiveInlining)] internal static void SetFrom(this  float[] Dest, int I, params  float[] V) => V.CopyTo(Dest, I);

    //==========================================================================================================================================================
    //[Impl(AggressiveInlining)] internal static void SetFrom<T>(this T[] Dest, int Index, params T[] Values) => Values.CopyTo(Dest, Index);
    //[Impl(AggressiveInlining)] internal static void SetFrom(this float[] Dest, int I, params float[] V) {for (int i = 0; i < V.Length; ++i) Dest[I+i] = V[i];}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
