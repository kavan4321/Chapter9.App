using Chapter9.View.Exercise2;
using Chapter9.ViewModel.Exercise3ViewModel;

namespace Chapter9.View.Exercise3;

public partial class FoodDeliveryScreen : ContentPage
{
	private FoodDeliveryViewModel _viewModel;
	public FoodDeliveryScreen()
	{
		InitializeComponent();
		_viewModel =(FoodDeliveryViewModel)BindingContext;
        _viewModel.NextPageEvent += NextPageEvent;
	}

    private void NextPageEvent(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DashboardScreen());
    }
}