using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextPad.ViewModel.File;

namespace TextPad
{
    /* Реализация интерфейса 'IOpenStream';
    * Класс "Открытый файл" - создаёт новый объект на основе класса 'Document'
    * и добавляет в список (коллекцию) 'Elements'. 
    * Данный объект является открывающимся файлом с компьютера в программе. 
    * Открыть необходимо хотя бы *.txt-файлы. */
    internal class OpenStream : ViewModel.File.IOpenStream
    {
        public void Open(ref ObservableCollection<Document> Elements)
        {

        }
    }
}
