using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        string title = "";
        private string getPatch(ref string title)
        {
            var dilog = new OpenFileDialog();

            if (dilog.ShowDialog() == true)
            {

                title = dilog.FileName;
                return title;
            }
            else
            {
                return null;
            }
        }
        public void Open(ref ObservableCollection<Document> Elements)
        {
            ViewModel.File.Document document = new Document();
            string str_Main_pad = "";
            getPatch(ref title);
            document.Title = title;
            StreamReader sr = new StreamReader(title);
            if (File.Exists(title))//условия для записи
            {

                str_Main_pad = sr.ReadToEnd();//почему то не работает запись хз почем
                document.StringCode = str_Main_pad;
                sr.Close();
                Elements.Add(document);
            }

        }
    }
}
