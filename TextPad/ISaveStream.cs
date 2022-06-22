using System.Collections.ObjectModel;

namespace TextPad
{
    public interface ISaveStream
    {
        void Save(ref ObservableCollection<Document> Elements);
        void SaveAs(ref ObservableCollection<Document> Elements);
    }
}
