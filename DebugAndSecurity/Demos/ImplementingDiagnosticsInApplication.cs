using System.Diagnostics;

namespace DebugAndSecurity.Demos
{
    class ImplementingDiagnosticsInApplication
    {
        internal static void DebugClass()
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }

        // Reference Page: 232
        internal static void TraceSourceClass()
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });

            traceSource.Flush();
            traceSource.Close();

            // Outputs:
            // myTraceSource Information: 0 : Tracing application..
            // myTraceSource Critical: 0 : Critical trace
            // myTraceSource Information: 1 : a, b, c
        }
    }
}
