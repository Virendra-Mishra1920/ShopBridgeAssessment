using ShopBridgeAssessment.API.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAssessment.Logic
{
    public interface IProduct
    {
        Task<SaveProductResponse> SaveProduct(SaveProductRequest request);
        Task<GetProductResponse> GetProductDetails(GetProductRequest request);
        Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request);
        Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request);
        Task<GetProductListresponse> GetProductList(GetProductListRequest request);
    }
}
