using Simplified;
using System.Collections.ObjectModel;

namespace TextPad
{
    public class ViewModel : ViewModelBase
    {
        //**********************************************************************
        // Поля:
        //**********************************************************************
        // Коллекция хранения открытых файлов для привязки к форме;
        public ObservableCollection<Document> Elements { get; } = new ObservableCollection<Document>();

        private Document _selectedDocument;
        public Document SelectedDocument { get => _selectedDocument; set =>Set(ref _selectedDocument, value); }

        private readonly NewStream newstream = new NewStream();
        private readonly OpenStream openstream = new OpenStream();

        // Конструктор, для инициализации списка;
        public ViewModel()
        {

            // Инициализация команд делегатами методов которые они должны исполнять.
            CreateNewDocumentCommand = new RelayCommand(CreateNewDocument);
            OpenNewDocumentCommand = new RelayCommand(OpenNewDocument);

            CloseDocumentCommand = new RelayCommand<Document>(CloseDocument);
            RemoveDocumentCommand = new RelayCommand<Document>(RemoveDocument);

            if (IsInDesignMode)
            {
                // Здесь нужно создать несколько Document
                // чтобы удобнее работать в конструкторе
                Elements.Add(new Document() { Title = "Первый" });
                Elements.Add(new Document() { Title = "Второй" });
            }
        }

        private  void CreateNewDocument()
        {
            Elements.Add(newstream.New());
        }
        private void OpenNewDocument()
        {
            if (openstream.Open(out Document document))
                Elements.Add(document);
        }

        //**********************************************************************
        // Команды для использования в привязках UI элементов: кнопки, меню и др.
        //**********************************************************************
        public RelayCommand CreateNewDocumentCommand { get; }
        public RelayCommand OpenNewDocumentCommand { get; }

        public RelayCommand CloseDocumentCommand { get; }
        public RelayCommand RemoveDocumentCommand { get; }
        private void CloseDocument(Document document)
        {
            // Закрываем document
        }
        private void RemoveDocument(Document document)
        {
            // Удаляем document
        }


    }
}
