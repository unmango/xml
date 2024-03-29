﻿using JetBrains.Annotations;

namespace UnMango.Xml
{
    /// <summary>
    /// Provides options to be used with <see cref="XmlSerializer"/>.
    /// </summary>
    [PublicAPI]
    public sealed record XmlSerializerOptions
    {
        internal static readonly XmlSerializerOptions DefaultOptions = new();

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlSerializerOptions"/>.
        /// </summary>
        public XmlSerializerOptions() { }
    }
}
