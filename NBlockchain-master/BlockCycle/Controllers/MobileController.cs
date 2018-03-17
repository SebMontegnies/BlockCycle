using BlockCycle.UI.DAL;
using BlockCycle.UI.Services;
using BlockCycle.UI.ViewModel;
using System;
using System.Web.Mvc;
using Unity;

namespace BlockCycle.UI.Controllers
{
    public class MobileController : Controller
    {
        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            var blockService = BlockCycleContainer.Container.Resolve<BlockService>();
            Guid idCourse = Guid.NewGuid();

            //todo create course in block
            var model = new MobileVM { IdCourse = idCourse };
            return View("Index", model);
        }

        [HttpGet]
        public Guid StopCourse(Guid idCourse)
        {
            var blockService = BlockCycleContainer.Container.Resolve<BlockService>();

            //todo stop course in block

            return idCourse;
        }

        
    }
}