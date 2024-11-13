using apiFestRock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace apiFestRock.Clases
{
    public class clsOpeBanda
    {
        //Atributo
        private bdEventosEntities oEFR = new bdEventosEntities();
        //Propiedad
        public tblEvento tblBan { get; set; }

        public List<tblBanda> listarBanda()
        {
            return oEFR.tblBandas
             .OrderBy(x => x.Nombre)
             .ToList();
        }
    }
}