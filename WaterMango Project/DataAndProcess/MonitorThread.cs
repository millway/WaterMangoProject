using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using WaterMango_Project.Data;
using WaterMango_Project.Models;

namespace WaterMango_Project.DataAndProcess
{
    public  class MonitorThread
    {
        BackgroundWorker plantMonitorWorker = new BackgroundWorker();
        public bool signalR_IsConnected { get; set; }
        public MonitorThread()
        {
            plantMonitorWorker.DoWork += PlantMonitorWorker_DoWork;
            plantMonitorWorker.ProgressChanged += PlantMonitorWorker_ProgressChanged;
            plantMonitorWorker.WorkerReportsProgress = true;

            PlantHub.OnConnectionStatusChanged += PlantHub_OnConnectionStatusChanged;
        }

        private void PlantHub_OnConnectionStatusChanged(bool stat)
        {
            this.StartMonitor();
           // throw new NotImplementedException();
        }

        public void StartMonitor()
        {
            if(!plantMonitorWorker.IsBusy)
                plantMonitorWorker?.RunWorkerAsync();
        }

        public void StopMonitor()
        {
            plantMonitorWorker.CancelAsync();
        }
        private void PlantMonitorWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                List<Plant> ChangedOnly = new List<Plant>();

                DataStorage.plants.ForEach(p =>
                {
                    if ((DateTime.Now.TimeOfDay - p.lastTimeWatered) >= TimeSpan.FromSeconds(60))
                    {
                        p.canBeWatered = true;
                        p.secondsWatered = 0;
                        ChangedOnly.Add(p);

                    }

                });

                var notification = GlobalHost.ConnectionManager.GetHubContext<PlantHub>();
                notification.Clients.All.sendMessage(JsonConvert.SerializeObject(ChangedOnly));


                Thread.Sleep(3000);
            }

        }

        private void PlantMonitorWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        


    }
}