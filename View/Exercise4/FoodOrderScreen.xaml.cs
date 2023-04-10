using Chapter9.View.Exercise2;
using Chapter9.ViewModel.Exercise4ViewModel.ViewModelOrder;

namespace Chapter9.View.Exercise4;

public partial class FoodOrderScreen : ContentPage
{
	private FoodOrderViewModel _viewModel;
	public FoodOrderScreen()
	{
		InitializeComponent();
		_viewModel=(FoodOrderViewModel)BindingContext;
        _viewModel.NextPageEvent += NextPageEvent;
	}

    private void NextPageEvent(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DashboardScreen());
    }

    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new DashboardScreen());
    }
}