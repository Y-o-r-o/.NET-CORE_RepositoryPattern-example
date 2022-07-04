using System.Diagnostics;

namespace Core;

[StackTraceHidden]
public class ValidString
{
    private string _value;

    public ValidString(string value)
    {
        Validate(value);
        _value = value;
    }

    private void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(nameof(value));
        }
    }

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
