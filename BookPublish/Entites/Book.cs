using System;
using System.Collections.Generic;

namespace BookPublish.Entites;

public partial class Book
{
    public int BookId { get; set; }

    public string? Publisher { get; set; }

    public string? Title { get; set; }

    public string? AuthorFirstName { get; set; }

    public string? AuthorLastName { get; set; }
    public decimal? Price { get; set; }
}
