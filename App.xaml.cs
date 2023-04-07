namespace Chapter9;
using Chapter9.View.Exercise1;
using Chapter9.View.Exercise2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new LibraryScreen())
		{ BarBackgroundColor = Colors.DarkCyan };

	}
}
