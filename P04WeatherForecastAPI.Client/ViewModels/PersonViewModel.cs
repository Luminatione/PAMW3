using P06Shop.Shared.Cars;
using P06Shop.Shared.Services.CarService.Interface;
using System.Collections.ObjectModel;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class PersonViewModel
    {
        private readonly IPersonService _personService;

        public ObservableCollection<Person> People { get; set; }

        public PersonViewModel(IPersonService personService)
        {
            _personService = personService;
            People = new ObservableCollection<Person>();
        }

        public async void GetPeople()
        {
            var peopleResult = await _personService.GetPeopleAsync();
            if (peopleResult.Success)
            {
                foreach (var p in peopleResult.Data)
                {
                    People.Add(p);
                }
            }
        }
    }
}
