
using Chapter9.Interface;
using Refit;

namespace Chapter9.EndPoint
{
    public class GetCategoryEndPoint
    {   
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IShoppingApi>("https://dummyjson.com/products").
                GetCategoryList();
        }
    }
}
