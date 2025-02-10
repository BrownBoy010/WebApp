namespace WebApp
{
    public class BookRepository
    {
        private static readonly List<Books> Books = new List<Books>
        {
            new Books { Id = 1, BookName = "Books One" },
            new Books { Id = 2, BookName = "Books Two" }
        };

        public static IEnumerable<Books> GetAll() => Books;

        public static Books GetById(int id) => Books.FirstOrDefault(b => b.Id == id);

        public static void Add(Books book) => Books.Add(book);

        public static void Update(Books book)
        {
            var existing = Books.FirstOrDefault(b => b.Id == book.Id);
            if (existing != null)
            {
                existing.BookName = book.BookName;
            }
        }

        public static void Delete(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                Books.Remove(book);
            }
        }
    }
}
