using System.Collections;

namespace _30_BuiltInInterface.Example2
{
    public class Bookcase : ICollection<Book>, IList<Book>
    {
        private List<Book> InnerList = new List<Book>();
        public int Count => InnerList.Count;

        public bool IsReadOnly => false; //hem okunabilir hem yazılabilir

        public void Add(Book item) //ayrı kitap ekle metodu yazmana gerek yok diğerine göre
        {
            InnerList.Add(item);
        }

        public void Clear()
        {
            InnerList.Clear();
        }

        public bool Contains(Book item)
        {
            return InnerList.Contains(item);
        }

        public void CopyTo(Book[] array, int arrayIndex)
        {
            InnerList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Book item)
        {
            return InnerList.Remove(item);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in InnerList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //IList ile eklenenler
        public Book this[int index] { get => InnerList[index]; set => InnerList[index] = value; }

        public int IndexOf(Book item)
        {
            return InnerList.IndexOf(item);
        }

        public void Insert(int index, Book item)
        {
            InnerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }
    }
}
