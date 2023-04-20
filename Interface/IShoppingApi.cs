using Refit;

namespace Chapter9.Interface
{
    public interface IShoppingApi
    {
        [Get("/categories")]
        Task<HttpResponseMessage> GetCategoryList();

        [Get("/category/{category}")]
        Task<HttpResponseMessage> GetProductList(string category);
    }
}
