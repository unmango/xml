using System;

namespace UnMango.Xml.Converters;

/// <summary>
/// Converts an object to or from XML.
/// </summary>
public class ObjectConverter : XmlConverter<object>
{
    internal static ObjectConverter Instance = new();

    /// <inheritdoc/>
    public override object Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
    {
        var result = Activator.CreateInstance(typeToConvert);

        if (result == null) throw new NotSupportedException($"Unable to deserialize type {typeToConvert}");

        foreach (var propertyInfo in typeToConvert.GetProperties())
        {
            if (propertyInfo.PropertyType == typeof(int))
            {
                var converter = options.ConverterFor<int>();
                var value = converter.Read(ref reader, typeof(int), options);
                propertyInfo.SetValue(result, value);
            }
        }
        
        return result;
    }

    /// <inheritdoc/>
    public override void Write(ref XmlWriter writer, object value, XmlSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
