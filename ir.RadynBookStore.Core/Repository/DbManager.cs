using SQLite;
using System.Collections.Generic;

namespace DataStructure.Repository
{
    public class DbManager
    {
        private SQLiteConnection connection;
        public DbManager(string dbPath)
        {
            //connection = new SQLiteConnection(platform, dbPath);
            connection = new SQLiteConnection(dbPath, false);
            connection.CreateTable<Book>();
            connection.CreateTable<Order>();
        }

        public File GetFile(int id)
        {
            return connection.Table<File>().FirstOrDefault(x => x.Id == id);
            //return new File();
        }

        public List<Book> GetAllBooks()
        {
            return connection.Table<Book>().ToList();
            //return new List<Book>();
        }

        public Book GetBook(int id)
        {
            return connection.Table<Book>().FirstOrDefault(x => x.Id == id);
            //return new Book();
        }

        public int InsertBook(Book book)
        {
            return connection.Insert(book);
            //return 0;
        }

        public int DeleteBook(int id)
        {
            return connection.Delete<Book>(id);
            //return 0;
        }

        public int UpdateBook(Book book)
        {
            return connection.Update(book);
            //return 0;
        }

    }
}
