using System.Diagnostics;

namespace Core;

public class ValidString
{
    private string _value;

    [StackTraceHidden]
    public ValidString(string value)
    {
        Validate(value);
        _value = value;
    }

    [StackTraceHidden]
    private void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(nameof(value));
        }
    }

    [StackTraceHidden]
    public static implicit operator ValidString(string value)
    {
        if (value == null)
        {
            return null;
        }

        return new ValidString(value);
    }

    public static implicit operator string(ValidString validString) => validString._value.ToString();

    public override string ToString() => _value.ToString();

}
