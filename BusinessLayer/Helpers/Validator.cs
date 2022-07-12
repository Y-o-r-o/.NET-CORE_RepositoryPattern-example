using System.Diagnostics;
using System.Text;

namespace BusinessLayer.Helpers;

internal static class Validator
{
    [StackTraceHidden]
    public static void CheckIfAllObjectNonNullablePropertiesIsNotNull<TObject>(TObject obj)
    {
        var objType = typeof(TObject);
        var properties = objType.GetProperties();

        StringBuilder? stringBuilder = null;

        foreach (var property in properties)
        {
            var propType = property.GetType();

            if (Nullable.GetUnderlyingType(propType) == null) continue;
            if (property.GetValue(obj) != null) continue;

            if (stringBuilder is null)
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Append($"The non-nullable properties of {objType.FullName} is null: \n");
            }
            stringBuilder.Append($"{propType.Name}\n");
        }

        if (stringBuilder is null) return;
        throw new Exception(stringBuilder.ToString());
    }

}