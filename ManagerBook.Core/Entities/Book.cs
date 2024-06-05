using System.Text.Json.Serialization;

namespace ManagerBook.Core.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublished { get; set; }
        public int Stock { get; set; }
        public string StoreId { get; set; }
    }
}
