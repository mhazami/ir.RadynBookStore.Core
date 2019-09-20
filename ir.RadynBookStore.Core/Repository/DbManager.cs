using SQLite.Net;
using SQLite.Net.Interop;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Repository
{
    public class DbManager
    {
        private SQLiteConnection connection;
        public DbManager(ISQLitePlatform platform, string dbPath)
        {
            connection = new SQLiteConnection(platform, dbPath);
            connection.CreateTable<Book>();
            connection.CreateTable<Order>();
        }

        public File GetFile(int id)
        {
            return connection.Table<File>().FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return connection.Table<Book>().ToList();
        }

        public Book GetBook(int id)
        {
            return connection.Table<Book>().FirstOrDefault(x => x.Id == id);
        }

        public int InsertBook(Book book)
        {
            return connection.Insert(book);
        }

        public int DeleteBook(int id)
        {
            return connection.Delete<Book>(id);
        }

        public int UpdateBook(Book book)
        {
            return connection.Update(book);
        }

    }
}
