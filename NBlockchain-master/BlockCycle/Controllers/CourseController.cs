using System.Linq;
using System.Text;
using System.Web.Mvc;
using BlockCycle.UI.DAL;
using BlockCycle.UI.Services;
using BlockCycle.UI.ViewModel;
using Unity;

namespace BlockCycle.UI.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index(string idCourse)
        {
            var openDataContainer = BlockCycleContainer.Container.Resolve<OpenData>();
            var blockService = BlockCycleContainer.Container.Resolve<BlockService>();

            //var meteoJour = openDataContainer.GetMeteoJour();
            //var meteoJour = new MeteoJour { date = DateTime.Now, DescriptionGlobal = "il fait bon" };
            var meteoPrevision = openDataContainer.GetMeteoPrevision();
            var sensors = openDataContainer.GetAirQualitySensors();
            var musees = openDataContainer.GetMusees();
            //var piste = openDataContainer.GetPiste("Pontpierre-Mondercange", TypePiste.pisteCyclable);

            var openData = new OpenDataVM()
            {
                //meteoJour = meteoJour,
                MeteoPrevision = meteoPrevision,
                AirQualitySensors = sensors,
                Musees = musees,
                CurrentCourse = blockService.Courses?.SingleOrDefault(c => c.PublicKey == Encoding.ASCII.GetBytes(idCourse))
                //Piste = piste
            };

            return View(openData);
        }
    }
}