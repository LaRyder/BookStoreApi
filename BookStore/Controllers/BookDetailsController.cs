using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;



namespace BookStore.Controllers
{
    [Route("api/BookDetails")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly BookContext _context;

        public BookDetailsController(BookContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/BookDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetailsDTO>>> GetBookDetails()
        {
            return await _context.BookDetails
                .Select(x => BookToDTO(x))
                .ToListAsync();
        }


        // GET: api/BookDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBookDetails(int id)
        {
            var bookDetails = await _context.BookDetails.FindAsync(id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            return BookToDTO(bookDetails);
        }

        // PUT: api/BookDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookDetails(int id, BookDetailsDTO bookDetailsDTO)
        {
            if (id != bookDetailsDTO.Id)
            {
                return BadRequest();
            }

            var bookDetails = await _context.BookDetails.FindAsync(id);
            if(bookDetails == null)
            {
                return NotFound();
            }
            bookDetails.AuthorName = bookDetailsDTO.AuthorName;
            bookDetails.Title = bookDetailsDTO.Title;
            bookDetails.YearPublished = bookDetailsDTO.YearPublished;
            bookDetails.Pages = bookDetailsDTO.Pages;
            bookDetails.SellPrice = bookDetailsDTO.SellPrice;
            bookDetails.Genre = bookDetailsDTO.Genre;
            bookDetails.Type = bookDetailsDTO.Type;
            bookDetails.IsAvailable = bookDetailsDTO.IsAvailable;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!BookDetailsExists(id))

                {
                    return NotFound();
                }

            return NoContent();
        }

        // POST: api/BookDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDetailsDTO>> CreateBookDetails(BookDetailsDTO bookDetailsDTO)
        {
            var bookdetails = new BookDetails
            {
                IsAvailable = bookDetailsDTO.IsAvailable,
                AuthorName = bookDetailsDTO.AuthorName,
                Title = bookDetailsDTO.Title,
                YearPublished = bookDetailsDTO.YearPublished,
                Pages = bookDetailsDTO.Pages,
                SellPrice = bookDetailsDTO.SellPrice,
                Genre = bookDetailsDTO.Genre,
                Type = bookDetailsDTO.Type,
        };
            _context.BookDetails.Add(bookdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBookDetails),
                new { id = bookdetails.Id },
                BookToDTO(bookdetails));
        }

        // DELETE: api/BookDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDetails(int id)
        {
            var bookDetails = await _context.BookDetails.FindAsync(id);
            if (bookDetails == null)
            {
                return NotFound();
            }

            _context.BookDetails.Remove(bookDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookDetailsExists(int id) =>
            _context.BookDetails.Any(e => e.Id == id);

        private static BookDetailsDTO BookToDTO(BookDetails bookdetails) =>
            new BookDetailsDTO
            {
                Id = bookdetails.Id,
                IsAvailable = bookdetails.IsAvailable,
                AuthorName = bookdetails.AuthorName,
                Title = bookdetails.Title,
                YearPublished = bookdetails.YearPublished,
                Pages = bookdetails.Pages,
                SellPrice = bookdetails.SellPrice,
                Genre = bookdetails.Genre,
                Type = bookdetails.Type,
            };

    }
}
