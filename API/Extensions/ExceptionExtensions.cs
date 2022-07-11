using Core.Extensions;
using System.Diagnostics;

namespace API.Extensions;

public static class ExceptionExtensions
{
    public static AdditionalInformation AnalyzeException(this Exception ex)
    {
        
        var trace = new StackTrace(ex, true);
        
        var stackFrame = trace.GeFirstFrame();
        var reflectedType = trace.GeFirstFrame().GetMethod().ReflectedType;
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