using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiFestRock.Models;
namespace apiFestRock.Clases
{
    public class clsOpeEvento
    {
        //Atributo
        private bdEventosEntities oEFR = new bdEventosEntities();
        //Propiedad
        public tblEvento tblEv { get; set; }

        public List<tblEvento> listarEvento()
        {
            return oEFR.tblEventoes
             .OrderBy(x => x.Nombre)
             .ToList();
        }
    }
}