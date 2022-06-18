using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextPad.ViewModel.File;

namespace TextPad
{
    /* Реализация интерфейса 'ISaveStream';
    * Класс "Сохранить файл" - должен сохранять открытый ранее файл по тому же пути.
    * Если файл не был ранее открыт, а был создан на сонове нового объекта, то предлагать "сохранить как",
    * далее указать путь в открывшемся окне. 
    * P.S. после сохранения любым из двух методов поле 'Path' объекта 'Document' должно перезаписаться на новый
    * путь, во избежании дальнейших багов. */
    internal class SaveStream : ViewModel.File.ISaveStream
    {
        // Метод "сохранить" - сохраняет по старому пути, ранее открывшейся файл;
        public void Save(ref ObservableCollection<Document> Elements)
        {

        }
        // Метод "сохранить как" - с указанием места на диске, куда сохранить новый файл;
        public void SaveAs(ref ObservableCollection<Document> Elements)
        {

        }
    }
}
