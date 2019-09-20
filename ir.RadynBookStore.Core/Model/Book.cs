using System.ComponentModel.DataAnnotations;
using SQLite.Net.Attributes;

namespace DataStructure
{
    public class Book
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int FileId { get; set; }

        public string Abstract { get; set; }

        public decimal Price { get; set; }

    }
}
