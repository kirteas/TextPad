using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextPad.ViewModel.File;

namespace TextPad
{
    class ViewModel
    {
        // Коллекция хранения открытых файлов для привязки к форме;
        private ObservableCollection<File.Document> Elements;

        // Конструктор, для инициализации списка;
        public ViewModel()
        {
            Elements = new ObservableCollection<File.Document>();
        }
        /* Закрытый для реализации Абстрактный класс;
        * Нельзя создать экземпляр класса, необходим для содержания Интерфейсов;
        * Использовать для создания объектов на основе вложенного класса 'Document' для хранения открытых файлов;
        * Использовать для реализации вложенных Интерфейсов; */
        abstract public class File
        {
            // Закрытый конструктор для запрета создания экземпляра класса;
            private File() { }

            // Класс, на основе которого будут создаваться открытые документы;
            public class Document
            {
                private byte[] byteCode;
                private string stringCode;
                private string typeEncoding;
                private string path;
                public Document()
                {
                    stringCode = null;
                    typeEncoding = null;
                    path = null;
                }
                // Аксессоры (мутаторы) для доступа и работы с переменными;
                public byte[] ByteCode
                {
                    get { return byteCode; }
                    set { byteCode = value; }
                }
                public string StringCode
                {
                    get { return stringCode; }
                    set { stringCode = value; }
                }
                public string TypeEncoding
                {
                    get { return typeEncoding; }
                    set { typeEncoding = value; }
                }
                public string Path
                {
                    get { return path; }
                    set { path = value; }
                }
                /* Метод для сравнения получаемой переменной типа 'String' с переменной класса 'stringCode';
                * Необходимый метод позволяет сравнить открытый файл "до" и "после" внесения изменений;
                * Если метод возвращает "true", то файлы одинаковые (не были изменены), если "false", то файлы отличны друг от друга. */
                public bool Compare(string document)
                {
                    if (document != null)
                    {
                        if (stringCode.Length == document.Length)
                        {
                            for (int i = 0; i < stringCode.Length; i++)
                            {
                                if (stringCode[i] != document[i])
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                    return false;
                }
            }

            /* Интерфейсы, необходимые для реализации методов;
            * Берём нижеуказанные интерфейсы и реализовываем их; */
            public interface INewStream
            {
                void New(ref ObservableCollection<Document> Elements);
            }
            public interface IOpenStream
            {
                void Open(ref ObservableCollection<Document> Elements);
            }
            public interface ISaveStream
            {
                void Save(ref ObservableCollection<Document> Elements);
                void SaveAs(ref ObservableCollection<Document> Elements);
            }
            public interface ICloseStream
            {
                void Close(ref ObservableCollection<Document> Elements);
                void CloseAll(ref ObservableCollection<Document> Elements);
            }
        }
    }
}
