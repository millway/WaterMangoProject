using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WaterMango_Project.DataAndProcess;

namespace WaterMango_Project
{
    public class PlantHub : Hub
    {
        public delegate void ConnectionStat(bool stat);
        public static event ConnectionStat OnConnectionStatusChanged;
       // private MonitorThread monitorThread;

        public void Send(string username, string message)
        {
            for (int i = 0; i < 10; i++)
            {
                Clients.All.sendMessage(username, message);
            }
        }

        public override Task OnConnected()
        {
            OnConnectionStatusChanged?.Invoke(true);

            //monitorThread = new MonitorThread();
            //monitorThread.StartMonitor();


            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
           // monitorThread?.StopMonitor();

            OnConnectionStatusChanged?.Invoke(stopCalled);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
           // monitorThread?.StartMonitor();
            OnConnectionStatusChanged?.Invoke(true);
            return base.OnReconnected();
        }
    }


}