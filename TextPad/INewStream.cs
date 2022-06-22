using System.Collections.ObjectModel;

namespace TextPad
{
    /* Интерфейсы, необходимые для реализации методов;
     * Берём нижеуказанные интерфейсы и реализовываем их; */
    public interface INewStream
    {
        Document New();
    }
}
