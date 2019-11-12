using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using WaterMango_Project.DataAndProcess;
using WaterMango_Project.Models;

namespace WaterMango_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            MonitorThread monitorThread = new MonitorThread();

            app.MapSignalR();
        }
    }
}