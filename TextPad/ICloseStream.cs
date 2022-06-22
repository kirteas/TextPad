using System.Collections.ObjectModel;

namespace TextPad
{
    public interface ICloseStream
    {
        void Close(ref ObservableCollection<Document> Elements);
        void CloseAll(ref ObservableCollection<Document> Elements);
    }
}
