using Chapter9.ViewModel.Exercise1ViewModel.ViewModelCredit;

namespace Chapter9.View.Exercise1;

public partial class CreditCardScreen : ContentPage
{
	private CreditCardViewModel _viewModel;
	public CreditCardScreen()
	{
		InitializeComponent();
		_viewModel=(CreditCardViewModel)BindingContext;
	}
}