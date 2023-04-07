using Chapter9.ViewModel.Exercise2ViewModel.ViewModelLibrary;

namespace Chapter9.View.Exercise2;

public partial class LibraryScreen : ContentPage
{
    private LibraryViewModel _viewModel;
	public LibraryScreen()
	{
		InitializeComponent();
        _viewModel=(LibraryViewModel)BindingContext;
        _viewModel.ChangeValue();
        _viewModel.FinishChange();
        _viewModel.FinishEvent += FinishEvent;
	}

    private void FinishEvent(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DashboardScreen());
    }

    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new DashboardScreen());
    }

   
}