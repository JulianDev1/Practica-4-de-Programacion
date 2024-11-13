using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;

namespace apiFestRock.Clases
{
    public class clsOpeCiudad
    {
        //Atributo
        private readonly bdEventosEntities oEFR = new bdEventosEntities();
        //Propiedad
        public tblCiudad tblCiudad { get; set; }

        public List<tblCiudad> listarCiudadades(int idD)
        {
            return oEFR.tblCiudads          //Tabla del modelo Entity
                .Where(x => x.idDpto == idD)
                .OrderBy(x => x.Nombre)
                .ToList();
        }
    }
}