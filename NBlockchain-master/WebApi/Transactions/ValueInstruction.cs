using System.Collections.Generic;
using System.Text;
using BlockCycle.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NBlockchain.Models;
using Newtonsoft.Json;

namespace BlockCycle.WebApi.Transactions
{
    public abstract class ValueInstruction : Instruction
    {
        public Course Course { get; set; }

        public byte[] Block
        {
            get { return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Course)); }
        }

        public override ICollection<byte[]> ExtractSignableElements()
        {
            return new List<byte[]>() { Block };
        }
    }
}
