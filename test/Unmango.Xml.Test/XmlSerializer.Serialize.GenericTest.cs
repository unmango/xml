using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using Xunit;

namespace Unmango.Xml.Test
{
    [Trait("Category", "Unit")]
    public class XmlSerializerSerializeGenericTest
    {
        private readonly CancellationTokenSource _tokenSource = TestOptions.GetTokenSource();

        [Fact]
        public void SerializeAsBytes_HappyPath()
        {

        }
    }
}
