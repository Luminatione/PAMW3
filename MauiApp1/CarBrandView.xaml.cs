using MauiApp1.View_Model;

namespace MauiApp1
{
	public partial class CarBrandView : ContentPage
	{
		public CarBrandView(CarBrandViewModel carBrandViewModel)
		{
			BindingContext = carBrandViewModel;
			InitializeComponent();
		}
	}
}