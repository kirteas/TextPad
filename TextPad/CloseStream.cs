using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextPad.ViewModel.File;

namespace TextPad
{
    /* Реализация интерфейса 'ICloseStream';
    * Класс "Закрыть файл" - должен закрывать открытый файл (вкладка), либо закрывать все открытые файлы (вкладки);
    * Перед закрытием файла(ов) в методе должно быть сравнение файла "до" открытия и "после" открытия.
    * Данный метод уже реализован в классе 'Document'.
    * Данная проверка нужна, если файл был изменён, то программа должна запросить у пользователя "сохранить его перед закрытием или нет?". 
    * Для запроса можно вопсользовать созданием дополнительного окна 'MessageBox'. */
    internal class CloseStream : ViewModel.File.ICloseStream
    {
        public void Close(ref ObservableCollection<Document> Elements)
        {

        }
        public void CloseAll(ref ObservableCollection<Document> Elements)
        {

        }
    }
}
