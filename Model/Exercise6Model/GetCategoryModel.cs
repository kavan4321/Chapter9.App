
using Chapter9.EndPoint;
using Chapter9.Interface;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter9.Model.Exercise6Model
{
    public class GetCategoryModel
    {
        private GetCategoryEndPoint _getCategoryEndPoint;
        public List<string> CatogaryDetails { get; set; }

        public GetCategoryModel()
        {
            _getCategoryEndPoint = new GetCategoryEndPoint();
        }
        public async Task<Result> GetCatogaryDetailAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var responce = await _getCategoryEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var catogary = JsonConvert.DeserializeObject<List<string>>(data);
                    CatogaryDetails = catogary;
                    return new Result()
                    {
                        IsSuccess = true
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
                    Message = "No Internet connection"
                };
            }
        }
    }
}
