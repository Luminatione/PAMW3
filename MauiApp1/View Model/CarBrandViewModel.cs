using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06Shop.Shared.Cars;
using P06Shop.Shared.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.View_Model
{
	public partial class CarBrandViewModel : ObservableObject
	{
		private readonly ICarBrandService _carBrandService;
		private readonly IMessageDialogService _messageDialogService;
		private readonly IConnectivity _connectivity;
		public ObservableCollection<CarBrand> CarBrands { get; set; }

		[ObservableProperty]
		private CarBrand selectedCarBrand;

		public CarBrandViewModel(ICarBrandService productService, IMessageDialogService messageDialogService,
			IConnectivity connectivity)
		{
			_messageDialogService = messageDialogService;
			_carBrandService = productService;
			_connectivity = connectivity; // set the _connectivity field
			CarBrands = new ObservableCollection<CarBrand>();
			GetCarBrands();
		}

		public async Task GetCarBrands()
		{
			CarBrands.Clear();
			if (_connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				_messageDialogService.ShowMessage("Internet not available!");
				return;
			}

			var productsResult = await _carBrandService.GetCarBrandsAsync();
			if (productsResult.Success)
			{
				foreach (var p in productsResult.Data)
				{
					CarBrands.Add(p);
				}
			}
			else
			{
				_messageDialogService.ShowMessage(productsResult.Message);
			}
		}

		[RelayCommand]
		public async Task ShowDetails(CarBrand carBrand)
		{
			if (_connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				_messageDialogService.ShowMessage("Internet not available!");
				return;
			}

			await Shell.Current.GoToAsync(nameof(CarBrandView), true, new Dictionary<string, object>
			{
				{"Car Brand", carBrand },
				{nameof(CarBrandViewModel), this }
			});
			SelectedCarBrand = carBrand;
		}

		[RelayCommand]
		public async Task New()
		{
			if (_connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				_messageDialogService.ShowMessage("Internet not available!");
				return;
			}

			CarBrand newCarBrand = new CarBrand(); // Initialize with default values if needed
			CarBrands.Insert(0, newCarBrand);
			SelectedCarBrand = newCarBrand;
		}

		[RelayCommand]
		public async Task Save()
		{
			foreach (var carBrand in CarBrands)
			{
				if (carBrand.Id == 0)
				{
					await _carBrandService.CreateCarBrandAsync(carBrand);
				}
				else
				{
					await _carBrandService.UpdateCarBrandAsync(carBrand);
				}
			}
		}

		[RelayCommand]
		public async Task Delete(CarBrand carBrand)
		{
			CarBrands.Remove(carBrand);
			SelectedCarBrand = null;
			await _carBrandService.DeleteCarBrandAsync(carBrand.Id);
		}
	}
}
