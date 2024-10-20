using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiMVVMApp
{
    public class FlightViewModel : INotifyPropertyChanged
    {
        Flight flight = new();

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
}
