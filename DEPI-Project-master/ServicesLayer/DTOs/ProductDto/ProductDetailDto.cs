using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.DTOs.ProductDto
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

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
        public int CategoryName { get; set; }
        [ForeignKey("CategoryId")]

        public string ImageUrl { get; set; }
        public string ImageLocalPath { get; set; }
        [Required, MaxLength(50)]
        public string ProductCode { get; set; }
        //[Precision("3,2")]
        public decimal AverageRating { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;

        public static explicit operator ProductDetailDto(Models.Product v)
        {
            throw new NotImplementedException();
        }
    }
}
