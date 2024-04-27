namespace Bibliotek.Book;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> AllBooks(CancellationToken token = default);
    public Task<Book?> GetById(long id, CancellationToken token = default);
    public Task AddBook(Book book, CancellationToken token = default);
}
