namespace Bibliotek.Book;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();

    public Task<IEnumerable<Book>> AllBooks(
        CancellationToken token = default
    ) => Task.FromResult(_books.AsEnumerable());

    public Task<Book?> GetById(long id, CancellationToken token = default) =>
        Task.FromResult(_books.SingleOrDefault(book => book.Id == id));

    public Task AddBook(Book book, CancellationToken token  = default)
    {
        _books.Add(book);
        return Task.CompletedTask;
    }
}
