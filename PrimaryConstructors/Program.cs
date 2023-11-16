using Microsoft.EntityFrameworkCore;
using PrimaryConstructors.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookContext>(options => options.UseSqlite("Filename=Books.db"));
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// GenerateBooks();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void GenerateBooks()
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<BookContext>();

    db.Database.EnsureCreated();

    var books = new List<Book>
        {
            new Book { Title = "Dr No", Year = 1958 },
            new Book { Title = "Goldfinger", Year = 1959 },
            new Book { Title = "Twelve", Year = 2009 },
            new Book { Title = "Thirteen Years Later", Year = 2010 },
            new Book { Title = "Emma", Year = 1816 },
            new Book { Title = "Persuasion", Year = 1818 }
        };

    db.Books.AddRange(books);

    db.SaveChanges();
}