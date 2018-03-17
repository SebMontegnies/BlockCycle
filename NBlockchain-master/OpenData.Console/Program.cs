using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using OpenData.Console.AirQuality;
using OpenData.Console.Entity;
using OpenData.Console.Meteo;
using OpenData.Console.Model;
using OpenData.Console.Musee;
using OpenData.Console.PisteCyclable;
using OpenData.Console.PisteVTT;
using Unity;
using Unity.Lifetime;

namespace OpenData.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            InitIoc();

            #region DONE
            // Pistes Cyclable - Ok DONE
            //using (var childContainer = OpenDataContainer.Container.CreateChildContainer())
            //{
            //    var ctx = new OpenDataContext()
            //    {
            //        FileName = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["PisteCyclable"]}"
            //    };
            //    childContainer.RegisterInstance(ctx);

            //    childContainer.Resolve<PisteCyclableOperation>().SetData();
            //}

            // Pistes VTT - Ok DONE
            //using (var childContainer = OpenDataContainer.Container.CreateChildContainer())
            //{
            //    var ctx = new OpenDataContext()
            //    {
            //        FileName = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["PisteVtt"]}"
            //    };
            //    childContainer.RegisterInstance(ctx);

            //    childContainer.Resolve<PisteVttOperation>().SetData();
            //} 

            #endregion

            // Musée 
            using (var childContainer = OpenDataContainer.Container.CreateChildContainer())
            {
                var ctx = new OpenDataContext()
                {
                    FileName = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["Musee"]}"
                };
                childContainer.RegisterInstance(ctx);

                childContainer.Resolve<MuseeOperation>().SetData();
            }

            // Air Quality
            using (var childContainer = OpenDataContainer.Container.CreateChildContainer())
            {
                var ctx = new OpenDataContext()
                {
                    Uri = new Uri(ConfigurationManager.AppSettings["AirQualityApiUri"])
                };
                childContainer.RegisterInstance(ctx);

                childContainer.Resolve<AirQualityOperation>().SetData();
            }

            // Day Forecast
            using (var childContainer = OpenDataContainer.Container.CreateChildContainer())
            {
                var ctx = new OpenDataContext()
                {
                    FileName = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["Forecast"]}"
                };
                childContainer.RegisterInstance(ctx);

                childContainer.Resolve<MeteoDayOperation>().SetData();
            }

            // Forecast 5days
            using (var childContainer = OpenDataContainer.Container.CreateChildContainer())
            {
                var ctx = new OpenDataContext()
                {
                    FileName = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["Forecast5Days"]}"
                };
                childContainer.RegisterInstance(ctx);

                childContainer.Resolve<MeteoOperation>().SetData();
            }
        }

        static void InitIoc()
        {
            BlockChainEntities blockChainEntities = new BlockChainEntities();
            OpenDataContainer.Container.RegisterType<BlockChainEntities>(new SingletonLifetimeManager());

            OpenDataContainer.Container.RegisterType<AirQualityOperation>(new PerResolveLifetimeManager());
            OpenDataContainer.Container.RegisterType<MeteoOperation>(new PerResolveLifetimeManager());
            OpenDataContainer.Container.RegisterType<MeteoDayOperation>(new PerResolveLifetimeManager());
            OpenDataContainer.Container.RegisterType<PisteVttOperation>(new PerResolveLifetimeManager());
            OpenDataContainer.Container.RegisterType<PisteCyclableOperation>(new PerResolveLifetimeManager());
            OpenDataContainer.Container.RegisterType<MuseeOperation>(new PerResolveLifetimeManager());
        }
    }
}
