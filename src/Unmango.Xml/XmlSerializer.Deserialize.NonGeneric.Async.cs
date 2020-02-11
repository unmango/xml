using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static ValueTask<object> DeserializeAsync(
            Type type,
            string xml,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, xml, null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            string xml,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(
            Type type,
            byte[] bytes,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, bytes.AsSpan(), null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            byte[] bytes,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, bytes.AsSpan(), options, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            byte[] bytes,
            int offset,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, bytes.AsSpan(offset), null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            byte[] bytes,
            int offset,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, bytes.AsSpan(offset), options, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            ReadOnlySpan<byte> span,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, span, null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            ReadOnlySpan<byte> span,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(
            Type type,
            ref XmlReader reader,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, ref reader, null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            ref XmlReader reader,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(
            Type type,
            PipeReader reader,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, reader, null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            PipeReader reader,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(
            Type type,
            Stream stream,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, stream, null, cancellationToken);

        public static ValueTask<object> DeserializeAsync(
            Type type,
            Stream stream,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => DeserializeAsync(type, PipeReader.Create(stream), options, cancellationToken);
    }
}
