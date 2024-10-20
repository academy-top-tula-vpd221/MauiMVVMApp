using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMVVMApp
{
    public class Flight
    {
        public string Name { get; set; } = "";
        public string ToCity { get; set; } = "";
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Passengers { get; set; }
        //public string? ImageSrc { get; set; }        
    }
}
