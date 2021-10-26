using System;
using Xunit;

namespace UnMango.Xml.Test.Serializer.Deserialize.Generic;

public class PropertyTests
{
    private record TestObject
    {
        public int Test { get; set; }
    }

    private class TestConverter : XmlConverter<TestObject>
    {
        public override TestObject Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
        {
            if (!options.ConverterCache.TryGetValue(typeof(object), out var objectConverter))
                throw new InvalidOperationException("Test failed");
            
            return (TestObject)((XmlConverter<object>)objectConverter).Read(ref reader, typeToConvert, options);
        }

        public override void Write(ref XmlWriter writer, TestObject value, XmlSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(42069)]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    public void DeserializeInteger(int value)
    {
        var xml = $"<Test>{value}</Test>";
        var options = XmlSerializerOptions.DefaultOptions.WithConverter(typeof(TestObject), new TestConverter());

        var result = XmlSerializer.Deserialize<TestObject>(xml, options);
        
        Assert.Equal(value, result.Test);
    }
}
