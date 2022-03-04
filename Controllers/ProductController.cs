using Microsoft.AspNetCore.Mvc;
using ShopBridgeAssessment.API.Product;
using ShopBridgeAssessment.Common;
using ShopBridgeAssessment.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProduct _service;

        public ProductController(IProduct service)
        {
            _service = service;
        }

        [HttpGet("GetProduct/{id:int}")]
        public async Task< ActionResult<GetProductResponse>> GetProduct(int id)
        {
            try
            {
                return await _service.GetProductDetails
                    (
                        new GetProductRequest { ProductId = id }
                    );
            }
            catch (Exception ex)
            {

                return new GetProductResponse
                {
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = "Product not found"
                };
            }

        }


        [HttpGet("GetAllProductList")]
        public async Task<ActionResult<GetProductListresponse>> GetProducts()
        {
            try
            {
                return await _service.GetProductList
                     (
                            new GetProductListRequest() { }

                     );
            }
            catch (Exception ex)
            {

                return new GetProductListresponse
                {
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = "Product not found"
                };
            }

        }

        [HttpPost("SaveProduct")]
        public async Task<ActionResult<SaveProductResponse>> SaveProduct([FromBody]SaveProductRequest request)
        {
            try
            {
                return await _service.SaveProduct(

               new SaveProductRequest() { Info = request.Info }
               );

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


        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            try
            {
                return await _service.UpdateProduct
                     (
                             new UpdateProductRequest {Info=request.Info }
                     );
            }
            catch (Exception ex)
            {
                return new UpdateProductResponse
                {
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = "Product can't be added"
                };

            }

        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<ActionResult<DeleteProductResponse>> DeletProduct(int id)
        {
            try
            {
                return await _service.DeleteProduct
                    (
                        new DeleteProductRequest { ProductId=id }
                    );
            }
            catch (Exception ex)
            {

                return new DeleteProductResponse
                {
                    ResponseResult = ResponseTypeEnum.Success.ToString(),
                    ResponseMessage = "Product not found"
                };
            }

        }

    }
}
