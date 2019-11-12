using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterMango_Project.Data;

namespace WaterMango_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //ViewBag.Plants = DataStorage.plants;
            return View("Index",DataStorage.plants);
        }


        public ActionResult IndexAction(int id, bool value)
        {


            
            return View("Index", DataStorage.plants);
        }
    }
}
