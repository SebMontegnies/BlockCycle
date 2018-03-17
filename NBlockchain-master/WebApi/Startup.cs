using System;
using System.Collections.Generic;
using AntPlusRacer;
using ANT_Managed_Library;
using BlockCycle.Model;
using BlockCycle.WebApi.Repositories;
using BlockCycle.WebApi.Repositories.Mongo;
using BlockCycle.WebApi.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using NBlockchain.Interfaces;
using NBlockchain.Models;
using System.Web.Hosting;
using AntPlusRacer.DataSources;
using BlockCycle.WebApi.Controllers;

namespace BlockCycle.WebApi
{
    public class Startup
    {
        public static IBlockchainNode _host;
        public static IBlockMiner _miner;
        private static IPeerNetwork _network;
        public static ISignatureService _sigService;
        public static IAddressEncoder _addressEncoder;
        public static ICustomInstructionRepository _txnRepo;
        public static IBlockRepository _blockRepo;
        public static ITransactionBuilder _txnBuilder;
        private static AntPlusDevMgr _antPlusDev;
        public static Ant _ant;
        public static ds_AntPlus_BikeSpdCad _speed;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var serviceProvider = ConfigureForMongoDB("DigitalCurrency", 27017);

            _host = serviceProvider.GetService<IBlockchainNode>();
            _miner = serviceProvider.GetService<IBlockMiner>();
            _network = serviceProvider.GetService<IPeerNetwork>();
            _sigService = serviceProvider.GetService<ISignatureService>();
            _addressEncoder = serviceProvider.GetService<IAddressEncoder>();
            _txnRepo = serviceProvider.GetService<ICustomInstructionRepository>();
            _blockRepo = serviceProvider.GetService<IBlockRepository>();
            _txnBuilder = serviceProvider.GetService<ITransactionBuilder>();

            //if (true)
            //{
            _ant = new Ant();
            _antPlusDev = new AntPlusDevMgr();
            _speed = new ds_AntPlus_BikeSpdCad();
            _antPlusDev.resetConnection(new AntPlusDevMgr.AntPlus_Connection(new ds_AntPlus_BikeSpdCad()));

            foreach (var antPlusConnection in _antPlusDev.deviceList)
            {
                if (antPlusConnection.connectedChannel != null)
                    antPlusConnection.connectedChannel.Dispose();

            }

            foreach (var antPlusConnection in _antPlusDev.deviceList)
            {
                while (antPlusConnection.connectedChannel == null)
                {
                }

                if (antPlusConnection.connectedChannel != null)
                    antPlusConnection.connectedChannel.channelResponse += antChannel_channelResponse_DataFetch;
            }
            //}

            //var ctr = new BlockController();
            //var course = ctr.AddCourse(new Course(){Name = "test", Description = "desc"});
            //ctr.AddBlock(new BCycle(){AirQuality = AirQuality.Bad, Speed = 5, Meteo = Meteo.Bad, Distance = 10, Altitude = 3, Longitude = 6}, course.PublicKey, course.PrivateKey);
            //var c = ctr.GetCourse();
        }



        public void antChannel_channelResponse_DataFetch(ANT_Response response)
        {

            _speed.handleChannelResponse(response);
            if (_speed != null)
            {
                _ant.Cadence = _speed.calculatedCadence;
                _ant.Distance = _speed.calculatedSpeed;
                _ant.Speed = _speed.calculatedDistIncrease;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseMvc();
        }

        private static IServiceProvider ConfigureForMongoDB(string db, uint port)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddBlockchain(x =>
            {
                x.UseTcpPeerNetwork(port);
                x.UseUpnpAutoNatTraversal("My Currency");
                x.UseMongoDB(@"mongodb://localhost:27017", db)
                    .UseInstructionRepository<ICustomInstructionRepository, CustomMongoInstructionRepository>();
                //x.AddPeerDiscovery(sp => new StaticPeerDiscovery("tcp://localhost:503"));
                x.UseMulticastDiscovery("My Currency", "224.100.0.1", 8088);
                x.AddInstructionType<ListInstruction>();
                x.AddInstructionType<AddInstruction>();
                x.UseBlockbaseProvider<CoinbaseBuilder>();
                x.UseParameters(new StaticNetworkParameters()
                {
                    BlockTime = TimeSpan.FromSeconds(120),
                    HeaderVersion = 1
                });
            });

            services.AddLogging();
            var serviceProvider = services.BuildServiceProvider();

            //config logging
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddDebug();
            loggerFactory.AddFile("node.log", LogLevel.Debug);

            return serviceProvider;
        }
    }
}
