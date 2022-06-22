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
        private readonly NewStream newstream = new NewStream();
        private readonly OpenStream openstream = new OpenStream();

        // Конструктор, для инициализации списка;
        public ViewModel()
        {
            //Elements = new ObservableCollection<Document>();

            // Инициализация команд делегатами методов которые они должны исполнять.
            CreateNewDocumentCommand = new RelayCommand(CreateNewDocument);
            OpenNewDocumentCommand = new RelayCommand(OpenNewDocument);

            if(IsInDesignMode)
            {
                // Здесь нужно создать несколько Document
                // чтобы удобнее работать в конструкторе
                Elements.Add(new Document() { Title = "Первый" });
                Elements.Add(new Document() { Title = "Второй" });
            }
        }

        //// Геттер для доступа к коллекции файлов;
        //public ObservableCollection<Document> GetDocumentCollection
        //{
        //    get { return Elements; }
        //}

        /* Закрытый для реализации Абстрактный класс;
        * Нельзя создать экземпляр класса, необходим для содержания Интерфейсов;
        * Использовать для создания объектов на основе вложенного класса 'Document' для хранения открытых файлов;
        * Использовать для реализации вложенных Интерфейсов; */

        //**********************************************************************
        // Методы для взаимодействия с классами:
        // Не надо в методы передавать внутренние элементы ViewModel.
        // Надо получать из них ланные и обрабатывать их в ViewModel так как ей нужно.
        //**********************************************************************
        public void CreateNewDocument()
        {
           Elements.Add(newstream.New());
        }
        public void OpenNewDocument()
        {
            if (openstream.Open(out Document document))
                Elements.Add(document);
        }

        //**********************************************************************
        // Команды для использования в привязках UI элементов: кнопки, меню и др.
        //**********************************************************************
        public RelayCommand CreateNewDocumentCommand { get; }
        public RelayCommand OpenNewDocumentCommand { get; }
    }
}
