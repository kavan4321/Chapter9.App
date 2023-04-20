
using Chapter9.Interface;
using Refit;

namespace Chapter9.EndPoint
{
    public class GetProductEndPoint
    {
        public string Category { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IShoppingApi>("https://dummyjson.com/products").
                GetProductList(Category);
        }
    }
}
