using System.Collections.Generic;

namespace BlockCycle.Model
{
    public class Course
    {
        public IEnumerable<BCycle> BCycles { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] PrivateKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}
