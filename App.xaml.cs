namespace Chapter9;
using Chapter9.View.Exercise1;
using Chapter9.View.Exercise2;
using Chapter9.View.Exercise3;
using Chapter9.View.Exercise4;

public partial class App : Application
{
	public App()
	{

		InitializeComponent();
		MainPage = new NavigationPage(new FoodOrderScreen());
		//{ BarBackgroundColor = Colors.DarkCyan };

	}
}
