using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WaterMango_Project.Data;
using WaterMango_Project.Models;
using Timer = System.Timers.Timer;

namespace WaterMango_Project.DataAndProcess
{
    public static class PlantWateringProcessor
    {
        public delegate void WateringDelegate(Plant p);

        public static event WateringDelegate OnWatering;
        private static readonly Timer _timer = new Timer();
        private static ObservableCollection<Plant> plantsToWaterCollection = new ObservableCollection<Plant>();

        /// <summary>
        /// Starts the thread to do the watering process
        /// </summary>
        /// <returns> status of the thread</returns>
        public static void StartProcessor()
        {
            _timer.Interval = 1000;
            _timer.Elapsed += Timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Start();

        }

        public static void StopProcessor()
        {
            

            _timer?.Stop();
            _timer?.Dispose();

        }



        public static void StartWatering(Plant plant)
        {

            if (!_timer.Enabled)
            {
                StartProcessor();
            }

            if (plant != null && plant.canBeWatered)
            {

                plantsToWaterCollection.Add(plant);

            }


        }

        public static void StopWatering(Plant plant)
        {
            if (!_timer.Enabled)
            {
                StartProcessor();
            }

            plantsToWaterCollection.Remove(plant);

        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (plantsToWaterCollection)
            {

                for (var i = 0; i < plantsToWaterCollection.Count; i++)
                {
                    
                
                    if (plantsToWaterCollection[i].canBeWatered && plantsToWaterCollection[i].secondsWatered < 10)
                    {
                        plantsToWaterCollection[i].secondsWatered++;
                        OnWatering?.Invoke(plantsToWaterCollection[i]);
                    }
                    else
                    {
                        OnWatering?.Invoke(plantsToWaterCollection[i]);
                        StopWatering(plantsToWaterCollection[i]);
                    }
                    
                    
                }
            }
        }

        private static void OnOnWatering(Plant p)
        {
            OnWatering?.Invoke(p);
        }
    }
}