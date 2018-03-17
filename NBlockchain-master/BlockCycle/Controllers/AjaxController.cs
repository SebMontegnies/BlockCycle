using System;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using BlockCycle.Model;
using BlockCycle.UI.ViewModel;
using Newtonsoft.Json;
using BlockCycle.UI.Services;
using BlockCycle.UI.DAL;
using System.Collections.Generic;
using Unity;
using System.Linq;

namespace BlockCycle.UI.Controllers
{
    public class AjaxController : Controller
    {
        [HttpGet]
        public ActionResult GetBikeInfo()
        {
            Ant ant ;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52503/");
                HttpContent httpContent = client.GetAsync("api/ant/get").Result.Content;
                ant = JsonConvert.DeserializeObject<Ant>(httpContent.ReadAsStringAsync().Result);
            }

            var model = new OpenDataVM()
            {
                Ant = ant
            };

            return PartialView("~/Views/Course/_Ant.cshtml", model);
        }

        [HttpGet]
        public string GetCompleteCourseXml(string idCourse)
        {
            var blockService = BlockCycleContainer.Container.Resolve<BlockService>();
            //Course course = blockService.Courses.FirstOrDefault(c => c.IdCourse == idCourse);
            Course course = new Course();
            course.BCycles = new List<BCycle> {
                new BCycle { Longitude = "6.0656587" , Latitude = "49.607695" },
                new BCycle { Longitude = "5.155934" , Latitude = "50.007021" },
                //new BCycle { Longitude = "5.149669" , Latitude = "50.009669" },
                //new BCycle { Longitude = "5.136686" , Latitude = "5.156686" },
                //new BCycle { Longitude = "5.126686" , Latitude = "5.156686" }
            };
            var gpx = new StringBuilder();
            gpx.Append("<gpx xmlns=\"http://www.topografix.com/GPX/1/1\" xmlns:gpxx=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\" xmlns:gpxtpx=\"http://www.garmin.com/xmlschemas/TrackPointExtension/v1\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" creator=\"Oregon 300\" version=\"1.1\" xsi:schemaLocation=\"http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd http://www.garmin.com/xmlschemas/GpxExtensions/v3 http://www.garmin.com/xmlschemas/GpxExtensionsv3.xsd http://www.garmin.com/xmlschemas/TrackPointExtension/v1 http://www.garmin.com/xmlschemas/TrackPointExtensionv1.xsd\">");
            gpx.Append("<metadata>");
            gpx.Append("<link href=\"http://www.garmin.com\">");
            gpx.Append("<text>Garmin International</text>");
            gpx.Append("</link>");
            gpx.Append("<time>2010-08-01T13:47:45Z</time>");
            gpx.Append("</metadata>");
            gpx.Append("<trk>");
            gpx.Append("<name>AUG-01-10 15:47:43 </name>");
            gpx.Append("<trkseg>");


            var time = DateTime.Now;
            foreach (var item in course.BCycles)
            {
                var val = string.Format("<trkpt lat=\"{0}\" lon=\"{1}\" >", item.Latitude, item.Longitude);
                gpx.Append(val);
                gpx.Append("<ele>1776.65</ele>");
                gpx.Append("<time>").Append(time).Append("</time>");
                gpx.Append("</trkpt>");
                time = time.AddMinutes(10);
            }

            gpx.Append("</trkseg>");
            gpx.Append("</trk>");
            gpx.Append("</gpx>");

            return gpx.ToString(); ;
        }

       
        [HttpPost]
        public ActionResult AddPointCourse(Guid idCourser, string pos)
        {
            var blockService = BlockCycleContainer.Container.Resolve<BlockService>();

            //todo add in blockchain

            var model = new MobileVM();
            //model.Latitude = latitude;
            //model.Longitude = longitude;

            return PartialView("~/Views/Mobile/_Position.cshtml", model);
        }
    }
}