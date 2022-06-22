namespace TextPad
{
    public class Document
    {
        private string title;
        private byte[] byteCode;
        private string stringCode;
        private string typeEncoding;
        private string path;
        public Document()
        {
            title = "Новый файл";
            stringCode = "";
            typeEncoding = null;
            path = "";
        }
        // Аксессоры (мутаторы) для доступа и работы с переменными;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public byte[] ByteCode
        {
            get { return byteCode; }
            set { byteCode = value; }
        }
        public string StringCode
        {
            get { return stringCode; }
            set { stringCode = value; }
        }
        public string TypeEncoding
        {
            get { return typeEncoding; }
            set { typeEncoding = value; }
        }
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        /* Метод для сравнения получаемой переменной типа 'String' с переменной класса 'stringCode';
        * Необходимый метод позволяет сравнить открытый файл "до" и "после" внесения изменений;
        * Если метод возвращает "true", то файлы одинаковые (не были изменены), если "false", то файлы отличны друг от друга. */
        public bool Compare(string document)
        {
            if (document != null)
            {
                if (stringCode.Length == document.Length)
                {
                    for (int i = 0; i < stringCode.Length; i++)
                    {
                        if (stringCode[i] != document[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
