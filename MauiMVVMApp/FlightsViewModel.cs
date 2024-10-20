//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace MauiMVVMApp
//{
//    public class FlightsViewModel : INotifyPropertyChanged
//    {
//        Flight flight;
//        public ObservableCollection<Flight> Flights { get; set; } = new();

//        public FlightsViewModel(Flight flight) => this.flight = flight;

//        public string Name
//        {
//            get => flight.Name;
//            set
//            {
//                if(flight.Name != value)
//                {
//                    flight.Name = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        public string ToCity
//        {
//            get => flight.ToCity;
//            set
//            {
//                if (flight.ToCity != value)
//                {
//                    flight.ToCity = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        public int Passengers
//        {
//            get => flight.Passengers;
//            set
//            {
//                if (flight.Passengers != value)
//                {
//                    flight.Passengers = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        public DateTime Date
//        {
//            get => flight.Date;
//            set
//            {
//                if (flight.Date != value)
//                {
//                    flight.Date = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        public TimeSpan Time
//        {
//            get => flight.Time;
//            set
//            {
//                if (flight.Time != value)
//                {
//                    flight.Time = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

        

//        public ICommand AddCommand { set; get; }
//        public ICommand DeleteCommand { set; get; }

//        public FlightsViewModel()
//        {
//            Flights.Add(new()
//            {
//                Name = "AHJ-987",
//                ToCity = "St.Peterburg",
//                Date = new DateTime(2024, 11, 20),
//                Time = new TimeSpan(13, 0, 0),
//                Passengers = 112
//            });
//            Flights.Add(new()
//            {
//                Name = "HGT-011",
//                ToCity = "Irkutsk",
//                Date = new DateTime(2024, 12, 6),
//                Time = new TimeSpan(21, 30, 0),
//                Passengers = 90
//            });

//            AddCommand = new Command(() =>
//            {
//                Flights.Add(new Flight()
//                {
//                    Name = Flight.Name,
//                    ToCity = Flight.ToCity,
//                    Date = Flight.Date,
//                    Time = Flight.Time,
//                    Passengers = Flight.Passengers
//                });

//                Flight.Name = "";
//                Flight.ToCity = "";
//                Flight.Passengers = 0;
//            },
//            () => 
//            {
//                return Name.Trim().Length > 0 && ToCity.Trim().Length > 2;
//                //return true;
//            });

//            //DeleteCommand = new Command((object? param) =>
//            //{
//            //    if (param is Flight flight)
//            //        Flights.Remove(flight);
//            //});

//            DeleteCommand = new Command<Flight>((Flight flight) =>
//            {
//                Flights?.Remove(flight);
//            },
//            (Flight f) =>
//            {
//                return Flights.Count > 0;
//            });
//        }

        

//        public event PropertyChangedEventHandler? PropertyChanged;

//        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//            ((Command)AddCommand).ChangeCanExecute();
//            ((Command)DeleteCommand).ChangeCanExecute();
//        }
//    }

//    public class FlightsEditModel : INotifyPropertyChanged
//    {
//        string name;
//        string toCity;
//        DateTime date { get; set; }
//        TimeSpan time { get; set; }
//        int passengers;


//        public event PropertyChangedEventHandler? PropertyChanged;

//        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }
     
//    public class FlightsMainModel : INotifyPropertyChanged
//    {

//        public event PropertyChangedEventHandler? PropertyChanged;

//        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//            ((Command)AddCommand).ChangeCanExecute();
//            ((Command)DeleteCommand).ChangeCanExecute();
//        }
//    }
//}
