using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_UI.Static
{
    public static class EndPoints
    {
        public static string BaseUrl = "https://localhost:64250/";

        public static string AuthorsEndpoints = $"{BaseUrl}api/authors";
        
        public static string BooksEndpoints = $"{BaseUrl}api/books";
    }
}
