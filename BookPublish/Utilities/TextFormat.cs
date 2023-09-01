using BookPublish.Entites;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace BookPublish.Utilities
{
    public static class TextFormat
    {
        #region MLA Format
        
        public static List<string> MLAFormat(List<Book> book)
        {
            List<string> formats = new List<string>();
            foreach (Book item in book)
            {
                StringBuilder mlaBuilder = new StringBuilder();
                mlaBuilder.Append((!string.IsNullOrEmpty(item.AuthorLastName) ? item.AuthorLastName.Split().Last() : string.Empty) + ", " + (!string.IsNullOrEmpty(item.AuthorFirstName) ? item.AuthorFirstName.Split().First() : string.Empty + ". "));
                mlaBuilder.Append(item.Title + ". ");
                mlaBuilder.Append(item.Publisher + ", ");
                formats.Add(mlaBuilder.ToString());
            }
            return formats;
        }

        #endregion

        #region ChicagoFormat
        
        public static List<string> ChicagoFormat(List<Book> book)
        {
            List<string> formats = new List<string>();
            foreach (Book item in book)
            {
                StringBuilder mlaBuilder = new StringBuilder();
                mlaBuilder.Append((!string.IsNullOrEmpty(item.AuthorLastName) ? item.AuthorLastName.Split().Last() : string.Empty) + ", " + (!string.IsNullOrEmpty(item.AuthorFirstName) ? item.AuthorFirstName.Split().First() : string.Empty + ". "));
                mlaBuilder.Append(item.Title + ". ");
                mlaBuilder.Append(item.Publisher + ", ");
                formats.Add(mlaBuilder.ToString());
            }
            return formats;
        }
        #endregion

    }
}
