using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public int Pages { get; set; }
        public decimal SellPrice { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }

    }
}
