﻿namespace BookPublish.Entites.BindingModel
{
    public class BookBindingModel
    {
        public int BookId { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set ;}
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }

    }
}
