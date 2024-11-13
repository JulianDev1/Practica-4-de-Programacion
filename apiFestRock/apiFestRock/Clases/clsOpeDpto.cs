using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;

namespace apiFestRock.Clases
{
    public class clsOpeDpto
    {

        private bdEventosEntities oERF = new bdEventosEntities();

        public tblDpto tblDpt { get; set; }

        public List<tblDpto> listarDpto()
        {
            return oERF.tblDptoes.OrderBy(x => x.Nombre).ToList();
        }
    }
}