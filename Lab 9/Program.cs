using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            context.Database.EnsureCreated();
            Console.WriteLine(context.Books.Find(1));

            //dodawanie
            // context.Books.Add(new Book() { Title = "PHP", EditionYear = 2000, AuthorId = 1 })

            //usuwanie
            // context.Books.Remove(context.Books.Find(1));

            //update
            // Book book = context.Books.Find(2);
            // book.EditionYear = 2010;
            // context.Books.Update(book);

            //po kazdej akcji mutujacej
            // context.SaveChanges();

            IQueryable<Book> books = from b in context.Books
                                     select b;
            Console.WriteLine(string.Join("\n", books));
            var booksWithAuthors =
            from book in context.Books
            join author in context.Authors
            on book.AuthorId equals author.Id
            select new { Title = book.Title, Author = author.Name };
            Console.WriteLine("****************************");
            Console.WriteLine(string.Join("\n", booksWithAuthors));
            Console.WriteLine("****************************");
            foreach (var item in booksWithAuthors)
            {
                Console.WriteLine(item.Author + " " + item.Title);
            }
            //zapisz LINQ któe zwróci liste rokordow z polami id ksiazki i nazwisko autora dla
            //ksiazek wydanych po 2019
            var idBooksWithName =
                from book in context.Books
                join author in context.Authors
                on book.AuthorId equals author.Id
                where book.EditionYear >= 2019
                select new { Book = book.Id, Name = author.Name };
            Console.WriteLine("****************************");
            foreach (var item in idBooksWithName)
            {
                Console.WriteLine(item.Book + " " + item.Name);
            }
            //wersja w fluent api
            var booksWithAuthors2 = context.Books.Join(
                    context.Authors,
                    book => book.AuthorId,
                    author => author.Id,
                    (book, author) => new { Book = book.Id, Name = author.Name }
            );
            string xml = 
                "<books>" +
                    "<book>" +
                        "<id>" +
                            "1" +
                        "</id>" +
                        "<title>" +
                            "C#" +
                        "</title>" +
                        "<editionYear>" +
                            "2000" +
                        "</editionYear>" +
                    "</book>" +
                    "<book>" +
                        "<id>" +
                            "2" +
                        "</id>" +
                        "<title>" +
                            "PHP" +
                        "</title>" +
                        "<editionYear>" +
                            "2002" +
                        "</editionYear>" +
                    "</book>" +
                "</books>";
            Console.WriteLine("****************************");
            XDocument doc = XDocument.Parse(xml);
            var xmlBooks = doc
                .Elements("books")
                .Elements("book")
                .Select(e => new { Id = e.Element("id").Value, Title = e.Element("title").Value, EditionYear = e.Element("editionYear").Value });
            foreach(var item in xmlBooks)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(string.Join("\n", xmlBooks));
            Console.WriteLine("****************************");
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/xml");
            string xmlRate = client.DownloadString("http://api.nbp.pl/api/exchangerates/tables/C");
            XDocument rateDoc = XDocument.Parse(xmlRate);
            rateDoc
                .Elements("ArrayOfExchangeRatesTable")
                .Elements("ExchangeRatesTable")
                .Elements("Rates")
                .Elements("Rate")
                .Select(e => new { 
                    Name = e.Element("Code").Value, 
                    Bid = e.Element("Bid").Value 
                });
            Console.WriteLine(string.Join("\n", rateDoc));

        }
    }
    //kolekcje, link xml?, wyciagniecie jednego obiektu bez kolekcji? encje? itp

    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int EditionYear { get; set; }
    }

    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATASOURCE=d:\\database\\data.db");
  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .ToTable("books")
                .HasData(
                    new Book() { Id = 1, AuthorId = 1, EditionYear = 2020, Title = "C#" },
                    new Book() { Id = 2, AuthorId = 1, EditionYear = 2021, Title = "JS" },
                    new Book() { Id = 3, AuthorId = 2, EditionYear = 2018, Title = "CSS" },
                    new Book() { Id = 4, AuthorId = 2, EditionYear = 2019, Title = "HTML" }
                   );
            modelBuilder
                .Entity<Author>()
                .ToTable("authors")
                .HasData(
                    new Author() { Id = 1, Name = "Pablito" },
                    new Author() { Id = 2, Name = "Masha" });
        }
    }
}
