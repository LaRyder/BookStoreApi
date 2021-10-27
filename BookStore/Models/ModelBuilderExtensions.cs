using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookDetails>().HasData(
                new BookDetails { Id = 1, Title = "American Marxism", YearPublished = 2021, Pages = 320, SellPrice = 16.74M, AuthorName = "Mark R.Levin", Genre = "Historical", Type = "Non-Fiction", IsAvailable = true },
                new BookDetails { Id = 2, Title = "If Animals Kissed Good Night", YearPublished = 2014, Pages = 34, SellPrice = 5.00M, AuthorName = "Anne Whitford Paul", Genre = "Childrens Books", Type = "Fiction", IsAvailable = false },
                new BookDetails { Id = 3, Title = "Oh, the Places You'll Go!", YearPublished = 1990, Pages = 56, SellPrice = 10.00M, AuthorName = "Dr. Seuss", Genre = "Childrens Books", Type = "Fiction", IsAvailable = true });

        }
    }
}
