
using Chapter9.EndPoint;
using Chapter9.HttpModel;
using Chapter9.Interface;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter9.Model.Exercise6Model
{
    public class GetProductModel
    {
        private GetProductEndPoint _getProductEndPoint;

        public string Catagory { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public GetProductModel()
        {
            _getProductEndPoint = new GetProductEndPoint();
        }
        public async Task<Result> GetProduvtDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _getProductEndPoint.Category = Catagory;
                var responce = await _getProductEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<ProductResponceModel>(data);
                    ProductDetails = product.ProductsDetails;
                    return new Result()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "Somthing went wrong"
                    };
                }
            }
            else
            {
                return new Result()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }
    }
}
