using System.Collections;

namespace _30_BuiltInInterface.Example2
{
    //Liste yerine dizi şeklinde deneme. Kendi listeni yazdın aslında
    public class Bookcase2 : ICollection<Book>, IList<Book>
    {
        private Book[] InnerList;

        public Bookcase2()
        {
            InnerList = new Book[2];
            Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity => InnerList.Length;

        public bool IsReadOnly => false; //hem okunabilir hem yazılabilir

        public void Add(Book item)
        {
            if (InnerList.Length == Count)
                DoubleArray();
            InnerList[Count] = item;
            Count++;
        }

        public void Clear()
        {
            InnerList = new Book[2];
            Count = 0;
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
            if (Count == 0)
                throw new Exception("There is no more item to be removed from to array");

            if (InnerList.Length / 2 == Count)
                HalfArray();

            if (Count > 0)
                Count--;

            return true;
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

        public Book this[int index] { get => InnerList[index]; set => InnerList[index] = value; }

        public int IndexOf(Book item)
        {
            return Array.IndexOf(InnerList, item);
        }

        public void Insert(int index, Book item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        private void DoubleArray()
        {
            var temp = new Book[InnerList.Length * 2];
            Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }

        private void HalfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new Book[InnerList.Length / 2];
                Array.Copy(InnerList, temp, InnerList.Length / 4);
                InnerList = temp;
            }
        }
    }
}
