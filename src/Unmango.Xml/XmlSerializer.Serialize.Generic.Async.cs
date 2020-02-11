using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static ValueTask<byte[]> SerializeAsync<T>(
            T value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(value, null, cancellationToken);

        public static ValueTask<byte[]> SerializeAsync<T>(
            T value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync<T>(
            ref XmlWriter writer,
            T value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(ref writer, value, null, cancellationToken);

        public static ValueTask SerializeAsync<T>(
            ref XmlWriter writer,
            T value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync<T>(
            PipeWriter writer,
            T value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(writer, value, null, cancellationToken);

        public static ValueTask SerializeAsync<T>(
            PipeWriter writer,
            T value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync<T>(
            Stream stream,
            T value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(PipeWriter.Create(stream), value, null, cancellationToken);

        public static ValueTask SerializeAsync<T>(
            Stream stream,
            T value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => SerializeAsync<T>(PipeWriter.Create(stream), value, options, cancellationToken);
    }
}
