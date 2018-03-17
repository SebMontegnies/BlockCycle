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

namespace OpenData.Console.PisteCyclable
{
    public class PisteCyclableOperation
    {
        private readonly BlockChainEntities _blockChainEntities;
        private readonly OpenDataContext _openDataContext;

        public PisteCyclableOperation(BlockChainEntities blockChainEntities, OpenDataContext openDataContext)
        {
            _blockChainEntities = blockChainEntities;
            _openDataContext = openDataContext;
        }

        public void SetData()
        {
            PisteCyclableModel pistesCyclable = JsonConvert.DeserializeObject<PisteCyclableModel>(File.ReadAllText(_openDataContext.FileName));

            foreach (var piste in pistesCyclable.features)
            {
                PISTE_CYCLABLE_ENTETE pisteCyclableEntete = new PISTE_CYCLABLE_ENTETE()
                {
                    NOM = piste.properties.name,
                    PISTE_CYCLABLE_DETAIL = new List<PISTE_CYCLABLE_DETAIL>()
                };

                int ordre = 0;
                if (piste.geometry.coordinates.Length > 2)
                    foreach (var relais in piste.geometry.coordinates)
                    {
                        ordre++;
                        pisteCyclableEntete.PISTE_CYCLABLE_DETAIL.Add(new PISTE_CYCLABLE_DETAIL()
                        {
                            ORDRE = ordre,
                            GPS_X = Decimal.Parse(relais[0].ToString()),
                            GPS_Y = Decimal.Parse(relais[1].ToString())
                        });
                    }

                _blockChainEntities.PISTE_CYCLABLE_ENTETE.Add(pisteCyclableEntete);
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
