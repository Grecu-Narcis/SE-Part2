using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class AdvertisementStatistics
    {
        public AdvertisementStatistics(int views, int clicks, int buys, int time)
        {
            this.Views = views;
            this.Clicks = clicks;
            this.Buys = buys;
            this.Time = time;
        }

        public int Views { get; set; }

        public int Clicks { get; set; }

        public int Buys { get; set; }

        public int Time { get; set; }
    }
}
