using System.Collections.Generic;
using System.Web.Mvc;
using BlockCycle.Model;
using BlockCycle.UI.Models;

namespace BlockCycle.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var model = BlockCycleContainer.Container.Resolve<BlockService>().Courses;
            var model = new List<Course>
            {
                new Course()
                {
                    Description = "Une suberbe course a velo a 4h du mat.",
                    Name = "Dur dur la course",
                    //IdCourse = 1
                }
            };

            return View(model);


            //var openDataContainer = BlockCycleContainer.Container.Resolve<OpenData>();

            //var meteoJour = openDataContainer.GetMeteoJour();
            //var meteoPrevision = openDataContainer.GetMeteoPrevision();
            //var sensors = openDataContainer.GetAirQualitySensors();
            //var piste = openDataContainer.GetPiste("Pontpierre-Mondercange", TypePiste.pisteCyclable);

            //var openData = new OpenDataVM()
            //{
            //    meteoJour = meteoJour,
            //    MeteoPrevision = meteoPrevision,
            //    AirQualitySensors = sensors,
            //    Piste = piste
            //};


        }
    }
}