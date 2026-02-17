using System;
using Rune          = System.Text.Rune;
using StringBuilder = System.Text.StringBuilder;

namespace Utility;
public struct DimString {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public int CursorPosX;
    public int CursorPosY;
    public int CursorPos => (CursorPosY * this.SizeX) + CursorPosX;

    public readonly int SizeX;
    public readonly int SizeY;
    public readonly int Size => SizeX * SizeY;

    private Rune[] Text; //  Rune[] insures:  Array.Length == MaxCharacterCount

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public DimString(int CharsPerLine, int NumOfLines) {
        if (CharsPerLine <= 0) throw new System.ArgumentOutOfRangeException(nameof(CharsPerLine));
        if (NumOfLines   <= 0) throw new System.ArgumentOutOfRangeException(nameof(NumOfLines));

        this.CursorPosX = 0;
        this.CursorPosY = 0;

        this.SizeX = CharsPerLine;
        this.SizeY = NumOfLines;

        this.Text = new Rune[CharsPerLine * NumOfLines];
        this.FillWith(' ');
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void Clear(bool ClearToSpaces = true) {
        this.CursorPosX = 0;
        this.CursorPosY = 0;
        if (ClearToSpaces)
            this.FillWith(' ');
        else
            System.Array.Clear(this.Text);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] private void FillWith(char c) => this.Text.AsSpan().Fill(new Rune(c));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] private void AdvanceCursorToNextLine() {
        this.CursorPosX = 0;
        this.CursorPosY++;
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public void SetCursorPosX(int X) => this.CursorPosX = clamp(X, 0, this.SizeX);
    public void SetCursorPosY(int Y) => this.CursorPosY = clamp(Y, 0, this.SizeY);
    public void SetCursorPos(int X, int Y) {
        this.CursorPosX = clamp(X, 0, this.SizeX);
        this.CursorPosY = clamp(Y, 0, this.SizeY);
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] private int Index(int X, int Y) => (Y * this.SizeX) + X;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void Append(string S) => Append(S.AsSpan());
    public void Append(ReadOnlySpan<char> S) {
        if (this.CursorPosY >= this.SizeY)
            return;
        if (S.IsEmpty)
            return;

        int i = 0;
        char c;
        while (i < S.Length) {
            if (this.CursorPosY >= this.SizeY)
                return;

            //  If CursorPosX is beyond CharsPerLine, advance until NewLine or EndOfString.
            if (this.CursorPosX >= this.SizeX) {
                while (i < S.Length) {
                    c = S[i++];
                    if (c == '\n') {
                        this.AdvanceCursorToNextLine();
                        break;
                    } else if (c == '\r') {
                        if (i < S.Length && S[i] == '\n') ++i; // consume \n
                        this.AdvanceCursorToNextLine();
                        break;
                    }
                }
                continue;
            }

            // Newline handling (ASCII only; treated specially)
            c = S[i];
            if (c == '\n') {
                ++i;
                this.AdvanceCursorToNextLine();
                continue;
            }
            if (c == '\r') {
                ++i;
                if (i < S.Length && S[i] == '\n') ++i; // consume \n
                this.AdvanceCursorToNextLine();
                continue;
            }

            // Decode one Rune from UTF-16
            System.Buffers.OperationStatus DecodeStatus = Rune.DecodeFromUtf16(S.Slice(i), out Rune DecodedRune, out int DecodeConsumed);
            if (DecodeStatus != System.Buffers.OperationStatus.Done || DecodeConsumed <= 0) {
                // Replace invalid sequences with U+FFFD
                DecodedRune = Rune.ReplacementChar;
                DecodeConsumed = 1;
            }

            this.Text[Index(this.CursorPosX, this.CursorPosY)] = DecodedRune;
            ++this.CursorPosX;
            i += DecodeConsumed;
        }
    }

    //==========================================================================================================================================================
    public void AppendLine(string S) => AppendLine(S.AsSpan());
    public void AppendLine(ReadOnlySpan<char> S) {
        if (this.CursorPosY >= this.SizeY) return;
        this.Append(S);
        this.AdvanceCursorToNextLine();
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public void AppendLine() {
        if (this.CursorPosY >= this.SizeY) return;
        this.AdvanceCursorToNextLine();
    }

    //==========================================================================================================================================================
    //public void WriteAt(int X, int Y, string S) {
    //    int OldX = this.CursorPosX;
    //    int OldY = this.CursorPosY;
    //    this.CursorPosX = X;
    //    this.CursorPosY = Y;
    //    this.Append(S);
    //    this.CursorPosX = OldX;
    //    this.CursorPosY = OldY;
    //}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //public override string ToString() => this.Text.ToString();
    //public override string ToString() => this.Text.AsSpan().ToString();

    public override string ToString() => ToString(TrimLines: true);
    public string ToString(bool TrimLines) {
        // Worst-case: each cell could be surrogate pair (2 chars), plus newlines.
        int approxCapacity = (this.SizeX * this.SizeY * 2) + (this.SizeY - 1);
        var SB = new StringBuilder(2*approxCapacity);

        Span<char> tmp = stackalloc char[2];

        for (int iY = 0; iY < this.SizeY; iY++) {
            int lineEndX = this.SizeX;

            if (TrimLines) {
                // Trim trailing spaces (and default \0 if you chose not to fill spaces)
                int iX = this.SizeX - 1;
                for (; iX >= 0; iX--) {
                    Rune r = this.Text[Index(iX,iY)];
                    if (r.Value != 0 && r.Value != ' ') break;
                }
                lineEndX = iX + 1;
            }

            for (int iX = 0; iX < lineEndX; iX++) {
                Rune r = this.Text[Index(iX,iY)];
                if (r.Value == 0)
                    r = new Rune(' ');

                int written = r.EncodeToUtf16(tmp);

                SB.Append(tmp.Slice(0, written));
            }

            if (iY != this.SizeY - 1)
                SB.Append('\n');
        }

        return SB.ToString();
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
