using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLayer.DTOs.ProductDto;

namespace ServicesLayer.Contracts
{
    public interface IProductsServices
    {
        public ProductDetailDto Get_By_Id(int id);
        public IEnumerable<ProductListDto> Get_All();
        public  Task<bool>  InsertProductAsync(ProductInsertDto productInsertDto);
        bool UpdateProduct(ProductUpdateDto productUpdateDto);
        bool DeleteProduct(int id);
    }
}
