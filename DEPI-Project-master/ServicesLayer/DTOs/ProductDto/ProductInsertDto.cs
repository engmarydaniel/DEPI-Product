using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServicesLayer.DTOs.ProductDto
{
    public class ProductInsertDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //[Precision(18,2)]
        public decimal Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        [Required]
        public int StockAmount { get; set; }
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        [FromForm]
        public IFormFile ImageUrl { get; set; }
        public string ImageLocalPath { get; set; }
        [Required, MaxLength(50)]
        public string ProductCode { get; set; }
    }
}
