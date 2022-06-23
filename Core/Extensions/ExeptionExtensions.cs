using System.Diagnostics;

namespace Core.Extensions;

public static class ExeptionExtensions
{
    public static AdditionalInformation AnalyzeExeption(this Exception ex)
    {
        var trace = new StackTrace(ex, true);
        var stackFrame = trace.GetFrame(0);
        var reflectedType = trace.GetFrame(0).GetMethod().ReflectedType;
        var additionalInformation = new AdditionalInformation();
        if (reflectedType != null)
        {
            additionalInformation = new AdditionalInformation()
            {
                Column = stackFrame.GetFileColumnNumber(),
                Line = stackFrame.GetFileLineNumber(),
                MethodName = reflectedType.FullName,
                File = stackFrame.GetFileName()
            };
        }
        return additionalInformation;
    }
}