using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static ValueTask<T> DeserializeAsync<T>(
            string xml,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(xml, null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            string xml,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(
            byte[] bytes,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(bytes.AsSpan(), null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            byte[] bytes,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(bytes.AsSpan(), options, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            byte[] bytes,
            int offset,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(bytes.AsSpan(offset), null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            byte[] bytes,
            int offset,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(bytes.AsSpan(offset), options, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            ReadOnlySpan<byte> span,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(span, null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            ReadOnlySpan<byte> span,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            var reader = new XmlReader(span);

            return DeserializeAsync<T>(ref reader, options, cancellationToken);
        }

        public static ValueTask<T> DeserializeAsync<T>(
            ref XmlReader reader,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(ref reader, null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            ref XmlReader reader,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(
            PipeReader reader,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(reader, null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            PipeReader reader,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(
            Stream stream,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(stream, null, cancellationToken);

        public static ValueTask<T> DeserializeAsync<T>(
            Stream stream,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => DeserializeAsync<T>(PipeReader.Create(stream), options, cancellationToken);
    }
}
