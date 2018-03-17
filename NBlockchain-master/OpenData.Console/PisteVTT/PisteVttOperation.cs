using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenData.Console.Entity;
using OpenData.Console.Model;

namespace OpenData.Console.PisteVTT
{
    public class PisteVttOperation
    {
        private readonly BlockChainEntities _blockChainEntities;
        private readonly OpenDataContext _openDataContext;

        public PisteVttOperation(BlockChainEntities blockChainEntities, OpenDataContext openDataContext)
        {
            _blockChainEntities = blockChainEntities;
            _openDataContext = openDataContext;
        }

        public void SetData()
        {
            PisteVtt pistesVtt = JsonConvert.DeserializeObject<PisteVtt>(File.ReadAllText(_openDataContext.FileName));

            foreach (var piste in pistesVtt.features)
            {
                PISTE_VTT_ENTETE pisteVttEntete = new PISTE_VTT_ENTETE()
                {
                    NOM = piste.properties.name,
                    PISTE_VTT_DETAIL = new List<PISTE_VTT_DETAIL>()
                };

                int ordre = 0;
                if (piste.geometry.coordinates.Length > 2)
                    foreach (var relais in piste.geometry.coordinates)
                    {
                        var coordonnee = relais.ToString().Split(' ');
                        ordre++;
                        pisteVttEntete.PISTE_VTT_DETAIL.Add(new PISTE_VTT_DETAIL()
                        {
                            ORDRE = ordre,
                            GPS_X = Decimal.Parse(coordonnee[2].Replace(".",",").Substring(0, coordonnee[2].Length-5)),
                            GPS_Y = Decimal.Parse(coordonnee[4].Replace(".", ",").Substring(0, coordonnee[4].Length - 5))
                        });
                    }

                _blockChainEntities.PISTE_VTT_ENTETE.Add(pisteVttEntete);
            }

            try
            {
                _blockChainEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
