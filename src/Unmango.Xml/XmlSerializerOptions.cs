namespace Unmango.Xml
{
    /// <summary>
    /// Provides options to be used with <see cref="XmlSerializer"/>.
    /// </summary>
    public sealed class XmlSerializerOptions
    {
        internal static readonly XmlSerializerOptions DefaultOptions = new XmlSerializerOptions();

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlSerializerOptions"/>.
        /// </summary>
        public XmlSerializerOptions() { }
    }
}
