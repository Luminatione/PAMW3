using P06Shop.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
	public class MauiMessageDialogService : IMessageDialogService
	{
		public void ShowMessage(string message)
		{
			Shell.Current.DisplayAlert("Message", message, "OK");
		}
	}
}
