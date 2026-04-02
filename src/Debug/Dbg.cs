using Conditional = System.Diagnostics.ConditionalAttribute;

namespace DEBUG;
internal static partial class DEBUG {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  A hack to see DebugOutput outside of VisualStudio.
    //
    [Conditional("DEBUG")]
    public static void Pipe_DebugOutput_To_StdErr() {
        #if DEBUG && true
            System.Diagnostics.Trace.Listeners.Clear();                                                                     //  Remove the default Listener.
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(System.Console.Error));   //  Pipe DebugOutput to StdErr.
            System.Diagnostics.Trace.AutoFlush = true;                                                                      //  Write Output immediately.
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
