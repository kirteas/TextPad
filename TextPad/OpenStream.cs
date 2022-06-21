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
        public void Open(ref ObservableCollection<Document> Elements)
        {
            // Создание нового объекта файла;
            ViewModel.File.Document document = new Document();
            // Открытие файла;
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                document.Path = dialog.FileName; // Сохраняем путь к файлу;
                document.Title = dialog.SafeFileName; // Сохраняем только имя файла;
                using (StreamReader reader = new StreamReader(document.Path))
                {
                    if (File.Exists(document.Path))
                    {
                        string temp = null;
                        while (!reader.EndOfStream)
                        {
                            temp += reader.ReadLine();
                        }
                        document.StringCode = temp;
                        Elements.Add(document);
                        
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
