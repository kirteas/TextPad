using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPad
{
    /* Реализация интерфейса 'IOpenStream';
    * Класс "Открытый файл" - создаёт новый объект на основе класса 'Document'
    * и добавляет в список (коллекцию) 'Elements'. 
    * Данный объект является открывающимся файлом с компьютера в программе. 
    * Открыть необходимо хотя бы *.txt-файлы. */
    internal class OpenStream : IOpenStream
    {
        public bool Open(out Document newDocument)
        {
            // Создание нового объекта файла;
            Document document = new Document();
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
                        while (reader.EndOfStream != true)
                        {
                            temp += reader.ReadLine();
                        }
                        document.StringCode = temp;
                        //Elements.Add(document);
                        newDocument = document;
                        return true;
                    }
                }
            }
            else
            {
            }
            newDocument = null;
            return false;
        }
    }
}
