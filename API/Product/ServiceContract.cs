using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ShopBridgeAssessment.API.Product
{
    public class SaveProductRequest
    {
        public SaveProductInfo Info { get; set; }
    }

    public class SaveProductResponse
    {
        public string ResponseResult{ get; set; }
        public string ResponseMessage { get; set; }
    }

    public class GetProductListRequest
    {
       
    }
    public class GetProductListresponse
    {
        public List<ProductInfo> ListInfo { get; set; }
        public string ResponseResult { get; set; }
        public string ResponseMessage { get; set; }

    }

    public class UpdateProductRequest
    {
        public SaveProductInfo Info { get; set; }
    }

    public class UpdateProductResponse
    {
        public string ResponseResult { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class GetProductRequest
    {
        public int ProductId { get; set; }
    }

    public class GetProductResponse
    {
        public ProductInfo Info { get; set; }
        public string ResponseResult { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class DeleteProductRequest
    {
        public int ProductId { get; set; }
    }

    public class DeleteProductResponse
    {
        public string ResponseResult { get; set; }
        public string ResponseMessage { get; set; }

    }

}
