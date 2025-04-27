using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTOs.ProductDto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[Precision(18,2)]
        public decimal Price { get; set; } = 0;
        //[Precision(18,2)]
        public decimal TotalPrice
        {
            get
            {
                return Price - (Price * Discount);
            }

        }
        [Required]
        public int StockAmount { get; set; }
        public int Discount { get; set; } = 0;
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string ImageLocalPath { get; set; }
        [Required, MaxLength(50)]
        public string ProductCode { get; set; }
        //[Precision("3,2")]
        public decimal AverageRating { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
    }
}
