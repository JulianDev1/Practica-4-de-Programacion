using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;

namespace apiFestRock.Clases
{
    public class clsOpeTipoDoc
    {
        private bdEventosEntities oERF = new bdEventosEntities();

        public tblTipoDoc tblDoc { get; set; }

        public List<tblTipoDoc> listarTipoDoc()
        {
            return oERF.tblTipoDocs.OrderBy(x => x.Nombre).ToList();
        }

    }
}