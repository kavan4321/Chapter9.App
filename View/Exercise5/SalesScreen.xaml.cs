using Chapter9.View.Exercise2;

namespace Chapter9.View.Exercise5;

public partial class SalesScreen : ContentPage
{
	public SalesScreen()
	{
		InitializeComponent();
	}

    private void ButtonClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DashboardScreen());
    }
}