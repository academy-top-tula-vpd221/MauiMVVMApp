using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace MauiMVVMApp
{

    public class FlightsListViewModel : INotifyPropertyChanged
    {
        FlightViewModel flight;
        
        public FlightViewModel SelectedFlight
        {
            get => flight;
            set
            {
                if(flight != value)
                {
                    flight = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<FlightViewModel> Flights { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FlightsEditViewModel : INotifyPropertyChanged
    {
        FlightViewModel flight = new();

        public string Name
        {
            get => flight.Name;
            set
            {
                if (flight.Name != value)
                {
                    flight.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ToCity
        {
            get => flight.ToCity;
            set
            {
                if (flight.ToCity != value)
                {
                    flight.ToCity = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Passengers
        {
            get => flight.Passengers;
            set
            {
                if (flight.Passengers != value)
                {
                    flight.Passengers = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get => flight.Date;
            set
            {
                if (flight.Date != value)
                {
                    flight.Date = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeSpan Time
        {
            get => flight.Time;
            set
            {
                if (flight.Time != value)
                {
                    flight.Time = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FlightsMainViewModel
    {
        bool isEdit = false;

        public Button ButtonAdd { get; set; } = new();

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public FlightsListViewModel FlightsListViewModel { get; set; } = new();
        public FlightsEditViewModel FlightsEditViewModel { get; set; } = new();

        public FlightsMainViewModel()
        {
            FlightsEditViewModel.Name = "";
            FlightsEditViewModel.ToCity = "";
            FlightsEditViewModel.Date = DateTime.Now;
            FlightsEditViewModel.Time = new TimeSpan();
            FlightsEditViewModel.Passengers = 0;

            FlightsListViewModel.Flights = new()
            {
                new()
                {
                    Name = "AHJ-987",
                    ToCity = "St.Peterburg",
                    Date = new DateTime(2024, 11, 20),
                    Time = new TimeSpan(13, 0, 0),
                    Passengers = 112
                },
                new()
                {
                    Name = "TRE-765",
                    ToCity = "Irkutsk",
                    Date = new DateTime(2024, 12, 2),
                    Time = new TimeSpan(21, 30, 0),
                    Passengers = 90
                },
            };

            AddCommand = new Command(() =>
            {
                if(isEdit)
                {
                    FlightsListViewModel.SelectedFlight.Name = FlightsEditViewModel.Name;
                    FlightsListViewModel.SelectedFlight.ToCity = FlightsEditViewModel.ToCity;
                    FlightsListViewModel.SelectedFlight.Date = FlightsEditViewModel.Date;
                    FlightsListViewModel.SelectedFlight.Time = FlightsEditViewModel.Time;
                    FlightsListViewModel.SelectedFlight.Passengers = FlightsEditViewModel.Passengers;

                    FlightsEditViewModel.Name = "";
                    FlightsEditViewModel.ToCity = "";
                    FlightsEditViewModel.Date = DateTime.Now;
                    FlightsEditViewModel.Time = new TimeSpan();
                    FlightsEditViewModel.Passengers = 0;

                    isEdit = false;
                    ButtonAdd.Text = "Add Flight";
                }
                else
                {
                    FlightViewModel flight = new()
                    {
                        Name = FlightsEditViewModel.Name,
                        ToCity = FlightsEditViewModel.ToCity,
                        Date = FlightsEditViewModel.Date,
                        Time = FlightsEditViewModel.Time,
                        Passengers = FlightsEditViewModel.Passengers,
                    };
                    FlightsListViewModel.Flights.Add(flight);
                    FlightsEditViewModel.Name = "";
                    FlightsEditViewModel.ToCity = "";
                    FlightsEditViewModel.Date = DateTime.Now;
                    FlightsEditViewModel.Time = new TimeSpan();
                    FlightsEditViewModel.Passengers = 0;
                }
            });

            DeleteCommand = new Command<FlightViewModel>((FlightViewModel flight) =>
            {
                FlightsListViewModel.Flights.Remove(flight);
            });

            EditCommand = new Command<FlightViewModel>((FlightViewModel flight) =>
            {
                isEdit = true;
                ButtonAdd.Text = "Save Flight";

                FlightsEditViewModel.Name = flight.Name;
                FlightsEditViewModel.ToCity = flight.ToCity;
                FlightsEditViewModel.Date = flight.Date;
                FlightsEditViewModel.Time = flight.Time;
                FlightsEditViewModel.Passengers = flight.Passengers;
            });
        }
    }
}
