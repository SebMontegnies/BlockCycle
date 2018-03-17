
using System.Collections.Generic;

namespace BlockCycle.Model
{
    public class Id
    {
        public string oid { get; set; }
    }

    public class TimeStamp
    {
        public long date { get; set; }
    }

    public class Statistics
    {
        public int BlockTime { get; set; }
        public TimeStamp TimeStamp { get; set; }
    }

    public class BlockId
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class PreviousBlock
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class MerkelRoot
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class Header
    {
        public BlockId BlockId { get; set; }
        public int Height { get; set; }
        public int Difficulty { get; set; }
        public int Status { get; set; }
        public long Timestamp { get; set; }
        public int Version { get; set; }
        public int Nonce { get; set; }
        public PreviousBlock PreviousBlock { get; set; }
        public MerkelRoot MerkelRoot { get; set; }
    }

    public class TransactionId
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class InstructionId
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class OriginKey
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class PublicKey
    {
        public string binary { get; set; }
        public string type { get; set; }
    }

    public class Signature
    {
        public string binary { get; set; }
        public string type { get; set; }
    }


    public class Entity
    {
        public string _t { get; set; }
        public InstructionId InstructionId { get; set; }
        public OriginKey OriginKey { get; set; }
        public PublicKey PublicKey { get; set; }
        public Signature Signature { get; set; }
        public Course Course { get; set; }
    }

    public class Instructions
    {
        public Entity Entity { get; set; }
        public Statistics Statistics { get; set; }
    }

    public class Transactions
    {
        public TransactionId TransactionId { get; set; }
        public IList<Instructions> Instructions { get; set; }
    }

    public class Value
    {
        public string binary { get; set; }
        public string type { get; set; }
    }


    public class MerkleRootNode
    {
        public Value Value { get; set; }
    }

    public class BlockChainJson
    {
        public Id _id { get; set; }
        public Statistics Statistics { get; set; }
        public Header Header { get; set; }
        public Transactions Transactions { get; set; }
        public MerkleRootNode MerkleRootNode { get; set; }
    }


}
