using Stopwatch = System.Diagnostics.Stopwatch;

namespace Utility;
//internal ref struct Time {
internal struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public  f64 Delta64                { get; private set; }
    public  f32 Delta                  { get; private set; }

    public  f64 DeltaAvg_Weight = 1d/24d;
    public  f64 DeltaAvg64             { get; private set; }
    public  f32 DeltaAvg               { get; private set; }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
  //public  vec4 Cos                   { get; private set; } //  ( 1 hertz, 10 hertz, 30 hertz, 60 hertz )
  //public  vec4 Sin                   { get; private set; }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public  f64 SinceStart64           { get; private set; }
    public  f32 SinceStart             { get; private set; }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    private s64 PrevFrame = 0;
    private s64 ThisFrame = 0;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    private f64 Seconds = 0;
    private s64 Minutes = 0;
    private s64 Hours   = 0;

    public  string HMS => $"{Hours:00}:{Minutes:00}:{Seconds:00.000000}";

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    private f64  Frqncy = 0d;
    public  s64  Frequency => Stopwatch.Frequency;         //  Ticks PerSecond.                    10,000,000      1/t == 0.000_000_1      0.1 MicroSeconds
    public  bool IsHighRes => Stopwatch.IsHighResolution;  //                                      true

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public Time() : this(1d/24d) {}
    public Time(f64 Weight = 1d/24d) {
        this.Delta        = 0f;
        this.Delta64      = 0d;

        this.SinceStart   = 0f;
        this.SinceStart64 = 0d;

        this.DeltaAvg_Weight = Weight;
        this.DeltaAvg64 = 1d/60d;
        this.DeltaAvg   = f32(this.DeltaAvg64);

        this.Frqncy = f64(Stopwatch.Frequency);

        this.ThisFrame = Stopwatch.GetTimestamp();
        this.PrevFrame = this.ThisFrame;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //public void Update(f64 Speed = 1d) {
    public void Update() {
        this.ThisFrame = Stopwatch.GetTimestamp();

        this.Delta64 = f64(this.ThisFrame-this.PrevFrame) / this.Frqncy;
        this.Delta   = f32(this.Delta64);

        this.DeltaAvg64 += (this.Delta64 - this.DeltaAvg64) * DeltaAvg_Weight;
        this.DeltaAvg    = f32(this.DeltaAvg64);

        this.Seconds += this.Delta64;
        if (this.Seconds >= 60d) {
            this.Seconds -= 60d;
            this.Minutes +=  1;
            if (this.Minutes >= 60) {
                this.Minutes -= 60;
                this.Hours   +=  1;
            }
        }

        this.SinceStart64 = f64(this.Hours*3600L + this.Minutes*60L) + this.Seconds;
        this.SinceStart   = f32(this.SinceStart64);

        this.PrevFrame = this.ThisFrame;

        //(this.Sin.x, this.Cos.x) = ((f32, f32))Math.SinCos(this.Seconds * 0.10471975511965977462d); //  1 hertz
        //(this.Sin.y, this.Cos.y) = ((f32, f32))Math.SinCos(this.Seconds * 1.04719755119659774615d); // 10 hertz  https://www.desmos.com/calculator/e4f49ebeb2
        //(this.Sin.z, this.Cos.z) = ((f32, f32))Math.SinCos(this.Seconds * 3.14159265358979323846d); // 30 hertz
        //(this.Sin.w, this.Cos.w) = ((f32, f32))Math.SinCos(this.Seconds * 6.28318530717958647693d); // 60 hertz
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
