﻿using System.ComponentModel.DataAnnotations.Schema;

namespace books_api.Data
{
    [Table ("Books")]
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public string Isbn { get; set; }

        public int? AuthorId { get; set; }
     
    }
}