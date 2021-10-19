using System;
using System.Threading;

namespace UnMango.Xml.Test;

internal static class TestOptions
{
    public const int DEFAULT_TIMEOUT_MS = 30 * 1000; // 30s

    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(DEFAULT_TIMEOUT_MS);
    public static readonly XmlSerializerOptions DefaultSerializerOptions = XmlSerializerOptions.DefaultOptions;

    public static CancellationTokenSource GetTokenSource() => new CancellationTokenSource(DEFAULT_TIMEOUT_MS);
}