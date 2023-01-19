using Microsoft.EntityFrameworkCore;
using myBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Book).WithMany(ba => ba.BookAuthor).HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Author).WithMany(ba => ba.BookAuthor).HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BooksAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
