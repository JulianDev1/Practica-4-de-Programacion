using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;

namespace apiFestRock.Clases
{
    public class clsOpeGenero
    {
        //Crear atributo 
        private bdEventosEntities oEFR = new bdEventosEntities();

        //Crear Propiedad
        public tblGenero tblGen { get; set; }

        public List<tblGenero> listarGenero()
        {
            return oEFR.tblGeneroes  //Tabla del modelo Entity
            .OrderBy(x => x.Nombre)
            .ToList();
        }
    }
}