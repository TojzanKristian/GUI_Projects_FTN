using System.Collections.Generic;

namespace NetworkService.Model
{
    public class DodavanjeSlike
    {
        static List<string> tipovi = new List<string>() { "Interval Meter", "Smart Meter" };

        static List<string> slike = new List<string>()
        {
            @"C:\Users\38162\Desktop\NetworkService\NetworkService\Pictures/intervalMeter.jpg",
            @"C:\Users\38162\Desktop\NetworkService\NetworkService\Pictures/smartMeter.jpg"
        };

        public static List<Tip> tipovi_potrosnje = new List<Tip>
        {
            new Tip(tipovi[0], slike[0]),
            new Tip(tipovi[1], slike[1])
        };
    }
}