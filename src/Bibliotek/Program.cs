using Bibliotek.Book;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();

var app = builder.Build();

{
    var bookRepo = app.Services.GetRequiredService<IBookRepository>();
    List<Book> books =
    [
        new(Id: 1,Title: "Dead Country", Author: "Max Gladstone"),
        new(Id: 2,Title: "Wicked Problems", Author: "Max Gladstone"),
        new(Id: 3,Title: "Name of the Wind", Author: "Patrick Rothfuss"),
    ];
    foreach (var book in books)
    {
        await bookRepo.AddBook(book);
    }
}

app.MapGet("/", () => "Hello World!");

app.MapGet(
    "/books",
    (IBookRepository bookRepository) => bookRepository.AllBooks()
);
app.MapGet(
    "/book/{id}",
    (long id, IBookRepository bookRepository) => bookRepository.GetById(id)
);
app.MapPost(
    "/book",
    (Book book, IBookRepository bookRepository) => bookRepository.AddBook(book)
);

app.Run();
