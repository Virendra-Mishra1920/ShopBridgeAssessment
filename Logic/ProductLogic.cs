using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopBridgeAssessment.API.Product;
using ShopBridgeAssessment.Common;
using ShopBridgeAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAssessment.Logic
{
    public class ProductLogic: IProduct
    {
        private readonly ProductDbContext _productDbContext;

        public ProductLogic(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<GetProductResponse> GetProductDetails(GetProductRequest request)
        {
            try
            {
                Validation.RequiredParameter("request", request);
                Product product = await _productDbContext.Product.SingleOrDefaultAsync(p => p.ProductId == request.ProductId);
                if (product == null)
                {
                    return new GetProductResponse
                    {
                        Info = null,
                        ResponseResult = ResponseTypeEnum.Warning.ToString(),
                        ResponseMessage=$"Product not available with ProductId{request.ProductId}"

                    };
                    
                }

                return new GetProductResponse
                {
                    Info = new ProductInfo { ProductName=product.ProductName, ProductDescription=product.ProductDescription,ProductPrice=product.ProductPrice},
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = $"Product found  with ProductId{request.ProductId}"

                };

            }
            catch (Exception ex)
            {
                return new GetProductResponse
                {  
                    ResponseResult = ResponseTypeEnum.Warning.ToString(),
                    ResponseMessage = $"Product not  found  with ProductId{request.ProductId}"
                };
            }
            
        }

        public async Task<SaveProductResponse> SaveProduct(SaveProductRequest request)
        {
            try
            {
                Validation.RequiredParameter("request", request);
                Validation.RequiredParameter("requestInfo", request.Info);
                Validation.RequiredParameter("ProductName", request.Info.ProductName);
                Validation.RequiredParameter("ProductDescription", request.Info.ProductDescription);
                Validation.RequiredParameter("ProductPrice", request.Info.ProductPrice);

                Product product = new Product
                {
                    ProductName = request.Info.ProductName,
                    ProductDescription = request.Info.ProductDescription,
                    ProductPrice = request.Info.ProductPrice
                };

                _productDbContext.Product.Add(product);
                var i = await _productDbContext.SaveChangesAsync();
                return new SaveProductResponse
                {
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = "Product Added Successfully"
                };

            }
            catch (Exception ex)
            {
                return new SaveProductResponse
                {
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = "Product can't be added"
                };
            }
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            try
            {
                Validation.RequiredParameter("request", request);
                Validation.RequiredParameter("request", request.Info);
                Product product = await _productDbContext.Product.SingleOrDefaultAsync(p => p.ProductId == request.Info.ProductId);
                if (product == null)
                {
                    return new UpdateProductResponse
                    {

                        ResponseResult = ResponseTypeEnum.Warning.ToString(),
                        ResponseMessage = $"Product not available with ProductId{request.Info.ProductId}"
                    };
                }

                product.ProductName = request.Info.ProductName;
                product.ProductDescription = request.Info.ProductDescription;
                product.ProductPrice = request.Info.ProductPrice;
                await _productDbContext.SaveChangesAsync();

                return new UpdateProductResponse
                {

                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage ="Product Updated successfully"
                };
            }
            catch (Exception ex)
            {

                return new UpdateProductResponse
                {

                    ResponseResult = ResponseTypeEnum.Warning.ToString(),
                    ResponseMessage = "Product not found"
                };
            }
            
        }

        public async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request)
        {
            try
            {
                Validation.RequiredParameter("request", request);
                Product product = await _productDbContext.Product.SingleOrDefaultAsync(p => p.ProductId == request.ProductId);
                if (product == null)
                {
                    return new DeleteProductResponse
                    {
                        
                        ResponseResult = ResponseTypeEnum.Warning.ToString(),
                        ResponseMessage = $"Product not available with ProductId{request.ProductId}"
                    };
                }

                _productDbContext.Product.Remove(product);
                await _productDbContext.SaveChangesAsync();
                return new DeleteProductResponse
                {

                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = $"Product deleted successfully"

                };

            }
            catch (Exception ex)
            {
                return new DeleteProductResponse
                {

                    ResponseResult = ResponseTypeEnum.Warning.ToString(),
                    ResponseMessage = $"Product can't be not deleted with ProductId{request.ProductId}"

                };

            }
        }

        public async  Task<GetProductListresponse> GetProductList(GetProductListRequest request)
        {
            try
            {
                Validation.RequiredParameter("request", request);

                var obj = await _productDbContext.Product.ToListAsync();
                var _listInfo = JsonConvert.DeserializeObject<List<ProductInfo>>(JsonConvert.SerializeObject(obj));

                return new GetProductListresponse
                {
                    ListInfo = _listInfo,
                    ResponseResult = ResponseTypeEnum.Warning.ToString(),

                };


            }
            catch (Exception ex)
            {

                return new GetProductListresponse
                {
                    ResponseResult = ResponseTypeEnum.Warning.ToString(),

                };
            }

        }
    }

}
