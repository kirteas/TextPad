using System.Collections.ObjectModel;

namespace TextPad
{
    public interface IOpenStream
    {
        bool Open(out Document newDocument);
    }
}
