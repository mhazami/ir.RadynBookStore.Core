using SQLite.Net.Attributes;

namespace DataStructure
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Amount { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; }



    }
}
