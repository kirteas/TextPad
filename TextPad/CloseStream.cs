using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

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
            ViewModel.File.Document document = new Document();
            TabControl TC_WindowDocument = new TabControl();
            
             for (int i = 0; i < document.CountTab; i++)
            {
                
                if (System.Windows.Forms.MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       TC_WindowDocument.TabPages.RemoveAt(i);
                        break;
                    }
               
            }



        }
        public void CloseAll(ref ObservableCollection<Document> Elements)
        {
            TabControl TC_WindowDocument = new TabControl();
            for (int i = 0; i < TC_WindowDocument.TabCount; i++)
                if (i != TC_WindowDocument.SelectedIndex)
                { 
                    TC_WindowDocument.TabPages.RemoveAt(i--); 
                }
        }
    }
}
