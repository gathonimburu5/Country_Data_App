using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0.1, 99999.99)]
        public decimal Price { get; set; }
        [Required, Range(1, 99999)]
        public int Quantity { get; set; }
        public bool IsFeatured { get; set; } = false;
        [Required]
        public string ProductImage { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
