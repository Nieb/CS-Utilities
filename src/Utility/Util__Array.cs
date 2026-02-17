
namespace Utility;
internal static class Array {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [System.Runtime.CompilerServices.InlineArray( 2)] internal struct  InlineArray2_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 3)] internal struct  InlineArray3_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 4)] internal struct  InlineArray4_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 8)] internal struct  InlineArray8_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray(12)] internal struct InlineArray12_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray(16)] internal struct InlineArray16_Float {private float i;}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Is NULL or Empty.
    //
    [Impl(AggressiveInlining)] internal static bool IsVoid(this  s8[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this  u8[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this s16[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this u16[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this s32[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this u32[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this s64[] A) => (A?.Length ?? 0) == 0;
    [Impl(AggressiveInlining)] internal static bool IsVoid(this u64[] A) => (A?.Length ?? 0) == 0;

    [Impl(AggressiveInlining)] internal static bool IsVoid(this f32[] A) => (A?.Length ?? 0) == 0;   //(A == null || A.Length == 0);
    [Impl(AggressiveInlining)] internal static bool IsVoid(this f64[] A) => (A?.Length ?? 0) == 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Proper "Length" method.  (zero inclusive)
    //
    //                o----|--->|
    //                0    1    2
    //      Blarg = ["A", "B", "C"]
    //
    //  Blarg.Count()  == 3      0 is empty.
    //  Blarg.Length() == 2     -1 is empty.
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static int Count(this  s8[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this  u8[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this s16[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this u16[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this s32[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this u32[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this s64[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this u64[] A) => (A == null) ? 0 : A.Length;

    [Impl(AggressiveInlining)] internal static int Count(this f32[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this f64[] A) => (A == null) ? 0 : A.Length;

    [Impl(AggressiveInlining)] internal static int Count(this string A) => (A == null || A == "") ? 0 : A.Length;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static int Length(this  s8[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this  u8[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this s16[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this u16[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this s32[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this u32[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this s64[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this u64[] A) => (A == null) ? -1 : A.Length-1;

    [Impl(AggressiveInlining)] internal static int Length(this f32[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this f64[] A) => (A == null) ? -1 : A.Length-1;

    [Impl(AggressiveInlining)] internal static int Length(this string A) => (A == null || A == "") ? -1 : A.Length-1;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      MyArray.Clear();
    //
    [Impl(AggressiveInlining)] internal static void Clear(this  s8[] A) => System.Array.Clear(A);
    [Impl(AggressiveInlining)] internal static void Clear(this  u8[] A) => System.Array.Clear(A);
    [Impl(AggressiveInlining)] internal static void Clear(this s16[] A) => System.Array.Clear(A);
    [Impl(AggressiveInlining)] internal static void Clear(this u16[] A) => System.Array.Clear(A);
    [Impl(AggressiveInlining)] internal static void Clear(this s32[] A) => System.Array.Clear(A);
    [Impl(AggressiveInlining)] internal static void Clear(this u32[] A) => System.Array.Clear(A);

    [Impl(AggressiveInlining)] internal static void Clear(this f32[] A) => System.Array.Clear(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Immediately GarbageCollect an Array.
    //
    //  This only works when used upon the original ref from the originating scope.
    //  Also, there must be no additional references elsewhere.
    //
    //      Delete(ref MyArray);
    //      DeleteAndCollect(ref MyArray); ...
    //
    [Impl(AggressiveInlining)] internal static void Delete(ref  s8[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}
    [Impl(AggressiveInlining)] internal static void Delete(ref  u8[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}
    [Impl(AggressiveInlining)] internal static void Delete(ref s16[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}
    [Impl(AggressiveInlining)] internal static void Delete(ref u16[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}
    [Impl(AggressiveInlining)] internal static void Delete(ref s32[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}
    [Impl(AggressiveInlining)] internal static void Delete(ref u32[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}

    [Impl(AggressiveInlining)] internal static void Delete(ref f32[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      MyArray.Fill( WithThisValue );
    //
    [Impl(AggressiveInlining)] internal static void Fill(this  s8[] A,  s8 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this  u8[] A,  u8 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this s16[] A, s16 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this u16[] A, u16 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this s32[] A, s32 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void Fill(this u32[] A, u32 V) => System.Array.Fill(A, V);

    [Impl(AggressiveInlining)] internal static void Fill(this f32[] A, f32 V) => System.Array.Fill(A, V);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This method allocates a new array with the specified size,
    //  copies elements from the old array to the new one,
    //  and then replaces the old array reference with the new one.
    //
    //  Array must be one-dimensional.
    //
    //      MyArray.Resize( ItemCount );
    //
    [Impl(AggressiveInlining)] internal static void Resize(this  s8[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);
    [Impl(AggressiveInlining)] internal static void Resize(this  u8[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);
    [Impl(AggressiveInlining)] internal static void Resize(this s16[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);
    [Impl(AggressiveInlining)] internal static void Resize(this u16[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);
    [Impl(AggressiveInlining)] internal static void Resize(this s32[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);
    [Impl(AggressiveInlining)] internal static void Resize(this u32[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);

    [Impl(AggressiveInlining)] internal static void Resize(this f32[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This would be better, but alas...
    //      MyArray[i] = [Values, To, Set, Etc];
    //
    //      MyArray.SetFrom(i,   Values, To, Set, Etc);
    //
    [Impl(AggressiveInlining)] internal static void SetFrom(this  s8[] A, int FromHere, params  s8[] B) => B.CopyTo(A, FromHere);
    [Impl(AggressiveInlining)] internal static void SetFrom(this  u8[] A, int FromHere, params  u8[] B) => B.CopyTo(A, FromHere);
    [Impl(AggressiveInlining)] internal static void SetFrom(this s16[] A, int FromHere, params s16[] B) => B.CopyTo(A, FromHere);
    [Impl(AggressiveInlining)] internal static void SetFrom(this u16[] A, int FromHere, params u16[] B) => B.CopyTo(A, FromHere);
    [Impl(AggressiveInlining)] internal static void SetFrom(this s32[] A, int FromHere, params s32[] B) => B.CopyTo(A, FromHere);
    [Impl(AggressiveInlining)] internal static void SetFrom(this u32[] A, int FromHere, params u32[] B) => B.CopyTo(A, FromHere);

    [Impl(AggressiveInlining)] internal static void SetFrom(this f32[] A, int FromHere, params f32[] B) => B.CopyTo(A, FromHere);

    //==========================================================================================================================================================
    //
    //  Spread Operator (..)
    //
    //      int[] A = [1, 2];
    //      int[] B = [5, 6];
    //
    //      //  Combines elements into: [0, 1, 2, 3, 4, 5, 6]
    //      int[] Z = [0, ..A, 3, 4, ..B];
    //
    //
    //      DoThing([..existingArray, 4, 5]);
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
