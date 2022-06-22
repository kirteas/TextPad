using System.Collections.ObjectModel;
using System.Text;

namespace TextPad
{
    /* Реализация интерфейса 'INewStream';
    * Класс "Новый файл" - создаёт новый объект на основе класса 'Document'
    * и добавляет в список (коллекцию) 'Elements'. 
    * Данный объект является новым открытым файлом в программе. */
    internal class NewStream : INewStream
    {
        public Document New()
        {
            // Переменная для хранения массива байтов строки;
            byte[] buffer;
            // Создаём новый объект класса 'Document';
            Document document = new Document
            {
                // Создаём пустую строку (инициализируем);
                StringCode = ""
            };
            //// Выделяем объём памяти для хранения массива байтов;
            //buffer = new byte[Encoding.Default.GetBytes(document.StringCode).Length];
            // Заполняем массив байтов декодированной строки;
            buffer = Encoding.Default.GetBytes(document.StringCode);
            // Добавляем байт код в поле объекта для хранения;
            document.ByteCode = buffer;
            // Инициализируем путь пустой строкой, так как файл новый и он ещё не сохранялся ранее;
            document.Path = "";
            document.Title = "Новый файл";
            //// Добавляем в коллекцию;
            //Elements.Add(document);

            return document;
        }
    }
}

// Дописать реализацию с Кодировкой!!!! Она осталась одна в данном классе!
