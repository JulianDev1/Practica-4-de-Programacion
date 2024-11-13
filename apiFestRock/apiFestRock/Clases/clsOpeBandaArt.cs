using apiFestRock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiFestRock.Clases
{
    public class clsOpeBandaArt
    {
        //atributo 
        private bdEventosEntities oEFR = new bdEventosEntities();
        //propiedad
        public tblBandaArt tblBA { get; set; }

        public IQueryable listarArtistasXBand(int idB)
        {
            return from tBA in oEFR.Set<tblBandaArt>()
                   join tA in oEFR.Set<tblArtista>()
                   on tBA.idArtista equals tA.Codigo
                   where tBA.idBanda == idB
                   select new
                   {
                       Codigo = tBA.idArtista,
                       Nombre = tA.Nombre
                   };
        }
        public IQueryable consultaInstArtBand(int idArtBand)
        {
            return from tBA in oEFR.Set<tblBandaArt>()
                   join tI in oEFR.Set<tblInstrum>()
                   on tBA.idInstrum equals tI.Codigo
                   where tBA.Codigo == idArtBand
                   select new
                   {
                       Nombre = tI.Nombre
                   };
        }
    }
}