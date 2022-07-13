using System.Diagnostics;

namespace Core.Extensions;

public static class StackTraceExtensions
{
    public static StackFrame GeFirstFrame(this StackTrace stackTrace)
    {
        foreach (StackFrame stackFrame in stackTrace.GetFrames())
        {
            bool marked = stackFrame.GetMethod().DeclaringType.CustomAttributes.Any(ca => ca.AttributeType == typeof(StackTraceHiddenAttribute));
            if (!marked)
            {
                return stackFrame;
            }
        }
        return null;
    }
}