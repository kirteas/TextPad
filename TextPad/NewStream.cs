using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextPad.ViewModel.File;

namespace TextPad
{
    /* Реализация интерфейса 'INewStream';
    * Класс "Новый файл" - создаёт новый объект на основе класса 'Document'
    * и добавляет в список (коллекцию) 'Elements'. 
    * Данный объект является новым открытым файлом в программе. */
    internal class NewStream : ViewModel.File.INewStream
    {
        public void New(ref ObservableCollection<Document> Elements)
        {
            // Переменная для хранения массива байтов строки;
            byte[] buffer;
            // Создаём новый объект класса 'Document';
            ViewModel.File.Document document = new Document();
            // Создаём пустую строку (инициализируем);
            document.StringCode = "";
            // Выделяем объём памяти для хранения массива байтов;
            buffer = new byte[Encoding.Default.GetBytes(document.StringCode).Length];
            // Заполняем массив байтов декодированной строки;
            buffer = Encoding.Default.GetBytes(document.StringCode);

            // Добавляем байт код в поле объекта для хранения;
            document.ByteCode = buffer;
            // Добавляем в коллекцию;
            Elements.Add(document);
        }
    }
}
