using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenData.Console.Entity;
using OpenData.Console.Model;

namespace OpenData.Console.Musee
{
    public class MuseeOperation
    {
        private readonly BlockChainEntities _blockChainEntities;
        private readonly OpenDataContext _openDataContext;

        public MuseeOperation(BlockChainEntities blockChainEntities, OpenDataContext openDataContext)
        {
            _blockChainEntities = blockChainEntities;
            _openDataContext = openDataContext;
        }

        public void SetData()
        {
            _blockChainEntities.Database.ExecuteSqlCommand("DELETE FROM MUSEE");

            var lines = File.ReadAllLines(_openDataContext.FileName, Encoding.GetEncoding(1252)).ToList();
            lines.RemoveAt(0);

            foreach (string line in lines)
            {
                var data = line.Split(';');
                MUSEE musee = new MUSEE()
                {
                    NOM = data[0],
                    GPS_X = decimal.Parse(data[1]),
                    GPS_Y = decimal.Parse(data[2])
                };
                _blockChainEntities.MUSEE.Add(musee);
            }

            _blockChainEntities.SaveChanges();
        }
    }
}
