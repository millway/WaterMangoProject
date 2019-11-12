using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using WaterMango_Project.Data;
using WaterMango_Project.DataAndProcess;
using WaterMango_Project.Models;
//using WaterMango_Project.Data;

namespace WaterMango_Project.Controllers
{

    public class PlantsController : ApiController
    {
      


        public PlantsController()
        {
            PlantWateringProcessor.OnWatering += PlantWateringProcessor_OnWatering;
        }

        private void PlantWateringProcessor_OnWatering(Plant p)
        {
            var notification = GlobalHost.ConnectionManager.GetHubContext<PlantHub>();
            notification.Clients.All.sendMessage(JsonConvert.SerializeObject(new List<Plant>() {p}));
        }
        

        //[HttpGet]
        //public String Get()
        //{
        //    return "Hello World";
        //}

        //Get api/plants
        [HttpGet]
        [ActionName("getAll")]
        public List<Plant> Get()
        {
            if (DataStorage.plants.Any())
            {
                return DataStorage.plants;
            }
            else
            {
                return null;
            }

        }

        // GET api/plants/5
        [HttpGet]
        public Plant Get([FromUri]int id)
        {
            if (DataStorage.plants.Any())
            {
                return DataStorage.plants.FirstOrDefault(i => i.Id == id);
            }
            else
            {
                return null;
            }
            
        }

        

        // POST api/plants
        [HttpPost]
        [ActionName("modify")]
        public Plant Post([FromBody]Plant taskPlant)
        {
            //if (!string.IsNullOrWhiteSpace(tap))
            if(taskPlant != null)
            {
                Plant plant = DataStorage.plants.FirstOrDefault(p => p.Id == taskPlant.Id);

                //var pl = DataStorage.plants[1];

                if (plant != null)
                {
                    plant.lastTimeWatered = new TimeSpan(DateTime.Now.Ticks);
                    return plant;
                }
            }
            
            return null;
        }


        // POST api/plants
        [HttpPost]
        [ActionName("water")]
        public  Plant Post([FromBody]WaterPlant taskPlant)
        {
            //if (!string.IsNullOrWhiteSpace(tap))
            if(taskPlant != null)
            {
                Plant plant = DataStorage.plants.FirstOrDefault(p => p.Id == taskPlant.Id);


                if (plant != null)
                {


                    if (plant.canBeWatered && taskPlant.startWatering)
                    {


                        PlantWateringProcessor.StartWatering(plant);


                        plant.lastTimeWatered = DateTime.Now.TimeOfDay;
                        return plant;
                    }
                    else if (plant.canBeWatered && !taskPlant.startWatering)
                    {
                        PlantWateringProcessor.StopWatering(plant);
                    }
                    else
                    {
                        
                    }

                }
               

               
            }
            
            return null;
        }




        // PUT api/plants/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/plants/5
        [HttpDelete]
        [ActionName("Delete")]
        public void Delete(int id)
        {
        }



    }
}
