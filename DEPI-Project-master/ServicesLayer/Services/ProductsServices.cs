using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using Models;
using ServicesLayer.Contracts;
using ServicesLayer.DTOs.ProductDto;

namespace ServicesLayer.Services
{
    internal class ProductsServices :IProductsServices
    {
        private readonly IUnitofwork _uow;
        private readonly IProductRepository _productRepository;


        public ProductsServices(IUnitofwork uow, IProductRepository productRepository)
        {
            _uow = uow;
            _productRepository = productRepository;
        }
        //public IEnumerable<ProductsListDto> Get_All()
        //{

        //    return _productRepository
        //        .GetAll()
        //        .Select(p => new ProductsListDto
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            CategoryName = p.Category?.Name,
        //            Brand = p.Brand,
        //            StockAmount = p.StockAmount,
        //            Discount = p.Discount,
        //            ImageUrl = p.ImageUrl,
        //            ImageLocalPath = p.ImageLocalPath,
        //            ProductCode = p.ProductCode,
        //            AverageRating = p.AverageRating,
        //            ReviewCount = p.ReviewCount
        //        })
        //        ;
        //}
        public bool DeleteProduct(int id)
        {
            try
            {
                //_uow.products.Delete(id);
                _productRepository.Delete(id);
                // _uow.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

       


        //public ProductDetailDto Get_By_Id(int id)
        //{
        //    //var entity = _productRepository.GetById(id).p=>new ProductDetailDto {
        //    //    p.Id = entity.Id,
        //    //    p.Name = entity.Name,
        //    //    p.Description = entity.Description,
        //    //    p.Price = entity.Price,
        //    //    //p.TotalPrice = entity.TotalPrice,
        //    //    p.ProductCode = entity.ProductCode,
        //    //    p.StockAmount = entity.StockAmount,
        //    //    p.Discount = entity.Discount,
        //    //    p.ImageUrl = entity.ImageUrl,
        //    //    p.AverageRating = entity.AverageRating,
        //    //    p.ReviewCount = entity.ReviewCount,
        //    //    p.Brand = entity.Brand,
        //    //    p.CategoryName = entity.Category.Name
        //    //};  
        //}



        public async Task<bool> InsertProductAsync(ProductInsertDto productInsertDto)
        {
            try
            {
                if (productInsertDto.ImageUrl != null && productInsertDto.ImageUrl.Length > 0)
                {
                    //var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    var folderPath = "wwwroot/images";
                    var fileName = Path.GetFileName(productInsertDto.ImageUrl.FileName);
                    var imagePath = Path.Combine(folderPath, fileName);

                    //var imagePath = Path.Combine("wwwroot/images", productInsertDto.ImageUrl.FileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        /* await*/
                        productInsertDto.ImageUrl.CopyToAsync(stream);
                    }
                }
                Product model = new Product
                {
                    Name = productInsertDto.Name,
                    Description = productInsertDto.Description,
                    Price = productInsertDto.Price,
                    Discount = productInsertDto.Discount,
                    StockAmount = productInsertDto.StockAmount,
                    Brand = productInsertDto.Brand,
                    CategoryId = productInsertDto.CategoryId,
                    ImageUrl = "/images/" + productInsertDto.ImageUrl.FileName,
                    ImageLocalPath = productInsertDto.ImageUrl.FileName,
                    ProductCode = productInsertDto.ProductCode,
                    //Images = productInsertDto.Images,
                    //Reviews = productInsertDto.Reviews

                };

                _productRepository.Insert(model);
                //_uow.products.Insert(model);
               // _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            try
            {
                var entity = _productRepository.GetById(productUpdateDto.Id);
                if (entity == null)
                {
                    return false;
                }
                if (productUpdateDto.ImageUrl != null && productUpdateDto.ImageUrl.Length > 0)
                {
                    //var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    var folderPath = "wwwroot/images";
                    var fileName = Path.GetFileName(productUpdateDto.ImageUrl.FileName);
                    var imagePath = Path.Combine(folderPath, fileName);

                    //var imagePath = Path.Combine("wwwroot/images", productInsertDto.ImageUrl.FileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        /* await*/
                        productUpdateDto.ImageUrl.CopyToAsync(stream);
                    }
                }
                entity.Name = productUpdateDto.Name;
                entity.Description = productUpdateDto.Description;
                entity.Price = productUpdateDto.Price;
                entity.Discount = productUpdateDto.Discount;
                entity.StockAmount = productUpdateDto.StockAmount;
                entity.Brand = productUpdateDto.Brand;
                entity.CategoryId = productUpdateDto.CategoryId;
                entity.ImageUrl = "/images/" + productUpdateDto.ImageUrl.FileName;
                entity.ImageLocalPath = productUpdateDto.ImageUrl.FileName;
                entity.ProductCode = productUpdateDto.ProductCode;
                //Images = productUpdateDto.Images,
                //Reviews = productUpdateDto.Reviews


                _productRepository.Update(entity);
                //_uow.products.Update(model);
               // _uow.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public ProductDetailDto Get_By_Id(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductListDto> Get_All()
        {
            throw new NotImplementedException();
        }
    }
}

