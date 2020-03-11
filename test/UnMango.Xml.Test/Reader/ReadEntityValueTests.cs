using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader
{
    [Trait("Category", "Unit")]
    public class ReadEntityValueTests
    {
        [Fact]
        public void Valid_Entity_Value()
        {
            const string value = "\"Entity\"";
            var bytes = Encoding.UTF8.GetBytes(value);
            var reader = new XmlReader(bytes);

            var resultSpan = reader.ReadEntityValue();

            var result = Encoding.UTF8.GetString(resultSpan);
            Assert.Equal("Entity", result);
        }
    }
}
