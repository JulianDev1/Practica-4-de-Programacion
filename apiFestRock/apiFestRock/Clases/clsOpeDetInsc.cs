using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;


namespace apiFestRock.Clases
{
    public class clsOpeDetInsc
    {
        private bdEventosEntities oEFR = new bdEventosEntities();

        public tblDetInsc tblDIns { get; set; }

        public IQueryable llenarTabla(int idCod)
        {
            return from tDI in oEFR.Set<tblDetInsc>()
                   join tBA in oEFR.Set<tblBandaArt>()
                   on tDI.idBandArt equals tBA.Codigo
                   join tAr in oEFR.Set<tblArtista>()
                   on tBA.idArtista equals tAr.Codigo
                   join tIn in oEFR.Set<tblInstrum>()
                   on tBA.idInstrum equals tIn.Codigo
                   where tDI.idNroInsc == idCod
                   select new
                   {
                       Quitar = "<a class='btn btn-info btn-sm' href=''><i class='fas fa-trash-alt'></i>Quitar</a>",
                       idDetIns = tDI.Codigo,
                       idBanArt = tDI.idBandArt,
                       Artista = tAr.Nombre,
                       idInst = tBA.idInstrum,
                       Instrumento = tIn.Nombre,
                       Edad = tDI.Edad
                   };
        }

        public tblDetInsc Agregar()
        {
            int cod = oEFR.tblDetInscs.DefaultIfEmpty().Max(r => r == null ? 1 : r.Codigo + 1);
            if (cod > 0)
            {
                tblDIns.Codigo = cod;
                oEFR.tblDetInscs.Add(tblDIns);
                oEFR.SaveChanges();
                return tblDIns;
            }
            else
                return tblDIns;
        }

        public string Eliminar(int codDetMat)
        {
            try
            {
                tblDetInsc oDI = oEFR.tblDetInscs.FirstOrDefault(x => x.Codigo == codDetMat);
                if (oDI == null)
                {
                    return "Error: No se encontró el registro en la base de datos";
                }
                oEFR.tblDetInscs.Remove(oDI);
                oEFR.SaveChanges();
                return "Se eliminó el registro del artista de la inscripción";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }




    }
}