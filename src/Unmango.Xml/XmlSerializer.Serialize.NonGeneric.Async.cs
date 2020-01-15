using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static ValueTask<byte[]> SerializeAsync(
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(value, null, cancellationToken);

        public static ValueTask<byte[]> SerializeAsync(
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<byte[]> SerializeAsync(
            Type type,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, value, null, cancellationToken);

        public static ValueTask<byte[]> SerializeAsync(
            Type type,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(
            ref XmlWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(ref writer, value, null, cancellationToken);

        public static ValueTask SerializeAsync(
            ref XmlWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(
            Type type,
            ref XmlWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, ref writer, value, null, cancellationToken);

        public static ValueTask SerializeAsync(
            Type type,
            ref XmlWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(
            PipeWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(writer, value, null, cancellationToken);

        public static ValueTask SerializeAsync(
            PipeWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(
            Type type,
            PipeWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, writer, value, null, cancellationToken);

        public static ValueTask SerializeAsync(
            Type type,
            PipeWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(
            Stream stream,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(stream, value, null, cancellationToken);

        public static ValueTask SerializeAsync(
            Stream stream,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(
            Type type,
            Stream stream,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, stream, value, null, cancellationToken);

        public static ValueTask SerializeAsync(
            Type type,
            Stream stream,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
