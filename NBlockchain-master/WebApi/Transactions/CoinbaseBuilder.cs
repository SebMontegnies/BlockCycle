using System.Collections.Generic;
using BlockCycle.Model;
using NBlockchain.Interfaces;
using NBlockchain.Models;
using NBlockchain.Services;

namespace BlockCycle.WebApi.Transactions
{
    public class CoinbaseBuilder : BlockbaseTransactionBuilder
    {
        public CoinbaseBuilder(IAddressEncoder addressEncoder, ISignatureService signatureService, ITransactionBuilder transactionBuilder) 
            : base(addressEncoder, signatureService, transactionBuilder)
        {
        }

        protected override ICollection<Instruction> BuildInstructions(KeyPair builderKeys, ICollection<Transaction> transactions)
        {
            var result = new List<Instruction>();
            var instruction = new ListInstruction
            {
                Course = new Course(){BCycles = new List<BCycle>()},
                PublicKey = builderKeys.PublicKey
            };

            SignatureService.SignInstruction(instruction, builderKeys.PrivateKey);
            result.Add(instruction);

            return result;
        }
    }
}
