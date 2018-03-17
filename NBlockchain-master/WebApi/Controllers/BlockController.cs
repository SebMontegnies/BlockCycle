using System;
using System.Collections.Generic;
using BlockCycle.Model;
using BlockCycle.WebApi.Transactions;
using Microsoft.AspNetCore.Mvc;
using NBlockchain.Models;

namespace BlockCycle.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BlockController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<BCycle> GetBlock(byte[] publicKey)
        {
            return Startup._txnRepo.GetBlocks(Startup._addressEncoder.EncodeAddress(publicKey, 0));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Course> GetCourse()
        {
            return Startup._txnRepo.GetCourses();
        }

        // POST api/values
        [HttpPost]
        public void AddBlock([FromBody]BCycle bCycle, byte[] publicKey, byte[] privateKey)
        {
            Console.WriteLine($"Signing instruction");

            var instruction = new AddInstruction()
            {
                PublicKey = publicKey,
                Course = new Course() { BCycles = new List<BCycle>() { bCycle }},
            };

            Startup._sigService.SignInstruction(instruction, privateKey);
            var txn = Startup._txnBuilder.Build(new List<Instruction>() { instruction }).Result;

            Console.WriteLine($"Sending transaction {BitConverter.ToString(txn.TransactionId)}");
            Startup._host.SendTransaction(txn);

            //Startup._miner.Start(new KeyPair() { PrivateKey = privateKey, PublicKey = publicKey }, false);

        }

        [HttpPost]
        public Course AddCourse([FromBody]Course course)
        {
            var keys = Startup._sigService.GetKeyPairFromPhrase("123");
            course.PublicKey = keys.PublicKey;
            course.PrivateKey = keys.PrivateKey;

            Startup._miner.Start(new KeyPair() { PrivateKey = keys.PrivateKey, PublicKey = keys.PublicKey }, true);

            return course;
        }
    }
}
