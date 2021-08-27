using JetBrains.Annotations;

namespace UnMango.Xml
{
    /// <summary>
    /// An XML token.
    /// </summary>
    [PublicAPI]
    public enum XmlToken : byte
    {
        None = 0,
        
        /// <summary> < </summary>
        BeginElement = 1,
        
        /// <summary> > </summary>
        EndElement = 2,
    }
}
