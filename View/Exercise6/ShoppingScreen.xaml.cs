using AndroidX.Lifecycle;
using Chapter9.ViewModel.Exercise6ViewModel.ViewModelShopping;

namespace Chapter9.View.Exercise6;

public partial class ShoppingScreen : ContentPage
{
	private ShoppingViewModel _shoppingViewModel;
	public ShoppingScreen()
	{
		InitializeComponent();
		_shoppingViewModel = (ShoppingViewModel)BindingContext;
        _=GetCatagoryList();
        _=GetProductList();
	}
    private async Task GetCatagoryList()
    {
        await _shoppingViewModel.GetCatagoryDetailAsync();
    }

    private async Task GetProductList()
    {
        await _shoppingViewModel.GetProductDetailAsync();
    }
}