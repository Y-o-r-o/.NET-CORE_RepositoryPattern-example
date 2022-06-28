using System.Diagnostics;

namespace Core.Extensions;

public static class StackTraceExtensions
{
    public static StackFrame GeFirstFrame(this StackTrace stackTrace)
    {
        foreach(StackFrame stackFrame in stackTrace.GetFrames())
        {
            if (!stackFrame.GetMethod().IsDefined(typeof(StackTraceHiddenAttribute), true))
            {
                return stackFrame;
            }
        }
        return null;
    }
}
