using System.Collections.Generic;
using BlockCycle.Model;
using MongoDB.Bson;
using NBlockchain.Models;
using Newtonsoft.Json;

namespace BlockCycle.WebApi.Transactions
{    
    [InstructionType("txn-v1")]
    public class AddInstruction : ValueInstruction
    {
        public override ICollection<byte[]> ExtractSignableElements()
        {
            var result = base.ExtractSignableElements();
            result.Add(Block);
            return result;
        }
    }
}
