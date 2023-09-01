using BookPublish.Entites;
using BookPublish.Entites.BindingModel;
using BookPublish.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BookPublish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestingContext _context;
        public BookController(TestingContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #region Sortedlist
        [HttpGet("get-sorted")]
        public IActionResult GetSortedBooks()
        {
            var sortedBooks = _context.Books.OrderBy(b => b.Publisher)
                                     .ThenBy(b => b.AuthorLastName)
                                     .ThenBy(b => b.AuthorFirstName)
                                     .ThenBy(b => b.Title)
                                     .ToList();

            return Ok(sortedBooks);
        }
        #endregion

        #region SortedbyAuthor

        [HttpGet("sortedByAuthor")]
        public IActionResult GetBooksSortedByAuthor()
        {
            var sortedBooks = _context.Books.OrderBy(b => b.AuthorLastName)
                                     .ThenBy(b => b.AuthorFirstName)
                                     .ThenBy(b => b.Title)
                                     .ToList();

            return Ok(sortedBooks);
        }
        #endregion

        #region SP GetAllSortedByBooks

        [HttpGet("get-all-sortedBybooks")]
        public IActionResult GetBooksSortedBybooks()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("GetBooksSortedByPublisher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using SqlDataReader reader = command.ExecuteReader();
                        var books = new List<Book>();
                        while (reader.Read())
                        {
                            var book = new Book
                            {
                                BookId= (int)reader["BookId"],
                                Publisher = reader["Publisher"].ToString(),
                                AuthorLastName = reader["AuthorLastName"].ToString(),
                                AuthorFirstName = reader["AuthorFirstName"].ToString(),
                                Title = reader["Title"].ToString(),
                            };
                            books.Add(book);
                        }
                        return Ok(books);
                    }
                }
                catch (Exception ex)
                {
                    throw new(ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        #endregion

        #region SP GetAllSortedbyAuthor

        [HttpGet("get-all-sortedByAuthor")]
        public IActionResult GetBooksSortedByAuthors()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetBooksSortedByAuthor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var books = new List<Book>();
                        while (reader.Read())
                        {
                            var book = new Book
                            {
                                BookId = (int)reader["BookId"],
                                AuthorLastName = reader["AuthorLastName"].ToString(),
                                AuthorFirstName = reader["AuthorFirstName"].ToString(),
                                Title = reader["Title"].ToString(),
                            };
                            books.Add(book);
                        }
                        return Ok(books);
                    }
                }
            }
        }
        #endregion

        #region GetAllTotalPrice

        [HttpGet("get-totalPrice")]
        public IActionResult GetTotalPrice()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetTotalprice", connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalPrice = Convert.ToDecimal(result);
                        return Ok(new { TotalPrice = totalPrice });
                    }
                    else
                    {
                        return Ok(new { TotalPrice = 0 });
                    }
                }
            }
        }
        #endregion

        #region MLA Format
      
        [HttpGet("mlaFormat")]
        public IActionResult GetMLAFormat()
        {
            var sortedBooks = _context.Books.OrderBy(b => b.AuthorLastName)
                                     .ThenBy(b => b.AuthorFirstName)
                                     .ThenBy(b => b.Title)
                                     .ThenBy(b => b.Publisher)
                                     .ThenBy(b => b.Price)
                                     .ToList();

            return Ok(TextFormat.MLAFormat(sortedBooks));
        }
        #endregion

        #region Chicago Format

        [HttpGet("chicagoFormat")]
        public IActionResult GetChicagoFormat()
        {
            var sortedBooks = _context.Books.OrderBy(b => b.Title)
                                    .ThenBy(b => b.AuthorLastName)
                                     .ThenBy(b => b.AuthorFirstName)
                                     .ThenBy(b => b.Publisher)
                                     .ThenBy(b => b.Price)
                                    .ToList();


            return Ok(TextFormat.ChicagoFormat(sortedBooks));
        }
        #endregion

    }
}
