using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPad
{
    class ViewModel
    {
        public ObservableCollection<Item>Elements;

        public ViewModel()
        {
            Elements = new ObservableCollection<Item>();
        }

        public class Item
        {
            byte ByteCode;
            string StringCode;
            string TypeEncoding;
            public Item() 
            {
                ByteCode = new byte();
                StringCode = null;
                TypeEncoding = null;
            }
        }

        public interface IFile
        {
            void NewStream(ref ObservableCollection<Item>Elements);
            void OpenStream(ref ObservableCollection<Item> Elements);
            void SaveStream(ref ObservableCollection<Item> Elements);
            void SaveStreamAs(ref ObservableCollection<Item> Elements);
            void CloseStream(ref ObservableCollection<Item> Elements);
            void CloseAllStreams(ref ObservableCollection<Item> Elements);
        }

        public interface IEdit
        {

        }

        public interface ISearch
        {

        }

        public interface IView
        {

        }

        public interface IEncoding
        {

        }
    }
}
