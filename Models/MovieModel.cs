using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title  { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string  Description { get; set; }
        
    }
}
