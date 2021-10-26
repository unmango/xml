using System;
using System.Text;

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
                reader.ReadOpenElement();
                var name = reader.ReadNameToken();
                var temp = Encoding.UTF8.GetString(name.ToArray());
                // TODO: Something about matching name with the prop name
                reader.ReadCloseElement();
                
                var converter = options.ConverterFor<int>();
                var value = converter.Read(ref reader, typeof(int), options);
                propertyInfo.SetValue(result, value);
                
                // TODO: Advance past the close tag, validate, etc.
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
