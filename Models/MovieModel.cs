using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        
        public string Title  { get; set; }

        public string Director { get; set; }

        public string  Description { get; set; }
    }
}
