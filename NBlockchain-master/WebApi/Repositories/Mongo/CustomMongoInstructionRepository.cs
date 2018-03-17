using System.Collections.Generic;
using System.Linq;
using BlockCycle.Model;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using NBlockchain.Interfaces;
using NBlockchain.MongoDB.Models;
using NBlockchain.MongoDB.Services;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace BlockCycle.WebApi.Repositories.Mongo
{
    public class CustomMongoInstructionRepository : MongoInstructionRepository, ICustomInstructionRepository
    {

        private readonly IAddressEncoder _addressEncoder;

        public CustomMongoInstructionRepository(IMongoDatabase database, IAddressEncoder addressEncoder)
            : base(database)
        {
            _addressEncoder = addressEncoder;
        }

        protected override void CreateIndexes()
        {
        }

        public IEnumerable<BCycle> GetBlocks(string address)
        {
            //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //var tmp = MainChain.Aggregate().Unwind(x => x.Transactions).ToList().Select(s => s.ToJson(jsonWriterSettings)).Select(s =>
            //    JsonConvert.DeserializeObject<BCycle>(s)?.Transactions?.Instructions[0]?.Entity?.Course).Where(w => w != null);
            return null;
        }

        public IEnumerable<Course> GetCourses()
        {
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var tmp = MainChain.Aggregate().Unwind(x => x.Transactions).ToList().Select(s => s.ToJson(jsonWriterSettings)).Select(s =>
JsonConvert.DeserializeObject<BlockChainJson>(s)?.Transactions?.Instructions[0]?.Entity?.Course).Where(w => w != null);
            return tmp;
        }

    }
}
