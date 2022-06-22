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

        public void Close(ref ObservableCollection<Document> Elements, object arg)
        {
            ViewModel.File.Document document = new Document();
            TabControl TC_WindowDocument = new TabControl();
            int closingIndex = (int)arg;

             
               
                if (System.Windows.Forms.MessageBox.Show("Вы хотите закрыть эту вкладку?", "Потвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    
     
                        Elements.RemoveAt(closingIndex);
                      
                    }
               
           



        }
        public void CloseAll(ref ObservableCollection<Document> Elements)
        {
            if (System.Windows.Forms.MessageBox.Show("Вы хотите закрыть эту вкладку?", "Потвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = Elements.Count;
                for (int i = 0; i < count; i++)
                {

                    Elements.RemoveAt(0);
                    break;
                }  

            }
        }
    }
}
