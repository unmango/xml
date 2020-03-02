using System;
using System.ComponentModel;
using System.IO.Pipelines;

namespace UnMango.Xml
{
    /// <summary>
    /// Reads XML.
    /// </summary>
    public class XmlReader
    {
        private readonly PipeReader _reader;

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlReader"/> with the
        /// specified <paramref name="buffer"/>.
        /// </summary>
        public XmlReader(PipeReader reader)
        {
            _reader = reader;
        }
    }
}
