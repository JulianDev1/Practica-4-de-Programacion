using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;

namespace apiFestRock.Clases
{
    public class clsOpeGenero
    {   
        //Atributo
        private bdEventosEntities oEFR = new bdEventosEntities();
        //Propiedad
        public tblGenero tblGen { get; set; }
        //------------------------------------------
        public List<tblGenero> listarGenero() { 
        
            return oEFR.tblGeneroes // tabla del modelo entity
                .OrderBy(x => x.Nombre).ToList();
        
        
        
        }
    }
}