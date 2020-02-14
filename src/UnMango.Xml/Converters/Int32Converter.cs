using System;
using System.Collections.Generic;
using System.Text;

namespace UnMango.Xml.Converters
{
    public class Int32Converter : XmlConverter<int>
    {
        public override int Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(ref XmlWriter writer, int value, XmlSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
