namespace _32_Relationship
{
    public class Author
    {
        public Author(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        public string Name { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Nationality}";
        }

        //Navigation property olarak adlandırılır bunlar
        public List<Book> Books { get; set; } = new List<Book>(); //author has a books 1-N
        //public Book Books2 { get; set; } //author has a books 1-1
    }

    public class Book
    {
        public Book(string title, Author author)
        {
            Title = title;
            Author = author;
        }

        public string Title { get; set; }

        public Author Author { get; set; } //book has a author
        public Library Library { get; set; } //1-1

        public override string ToString()
        {
            return $"{Title} - {Author}";
        }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public override string ToString()
        {
            string books = "";
            foreach (var item in Books)
            {
                books += "\t- " + item.ToString() + "\n";
            }

            return $"{Name}: \n {books}";
        }
    }
}
