using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterMango_Project.Models
{
    public class Plant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short secondsWatered { get; set; }

        public TimeSpan lastTimeWatered { get; set; }

        public bool canBeWatered { get; set; }

        public string plantImageUrl { get; set; }

    }

    public class WaterPlant
    {
        public int Id { get; set; }

        public bool startWatering { get; set; }


        
    }
}

