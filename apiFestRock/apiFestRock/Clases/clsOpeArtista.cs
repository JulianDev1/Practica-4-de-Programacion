using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiFestRock.Models;
namespace apiFestRock.Clases
{
    public class clsOpeArtista
    {
        //Atributo
        private readonly bdEventosEntities oEFR = new bdEventosEntities();
        //Propiedad
        public tblArtista tblArt { get; set; }

        public IQueryable listarArtistas()
        {
            return from tA in oEFR.Set<tblArtista>()
                   join tTd in oEFR.Set<tblTipoDoc>()
                   on tA.idtipoDoc equals tTd.Codigo
                   join tG in oEFR.Set<tblGenero>()
                   on tA.idGenero equals tG.Codigo
                   join tC in oEFR.Set<tblCiudad>()
                   on tA.idCiudad equals tC.Codigo
                   join tD in oEFR.Set<tblDpto>()
                   on tC.idDpto equals tD.Codigo
                   orderby tA.nroDoc
                   select new
                   {
                       Editar = "<a class='btn btn-info btn.sm' href=''><i class='fas fa-pencil-alt'></i>Editar</a>",
                       Código = tA.Codigo,
                       Nombre = tA.Nombre,
                       idTD = tA.idtipoDoc,
                       Tipo_Doc = tTd.Nombre,
                       Nro_Doc = tA.nroDoc,
                       idG = tG.Codigo,
                       Género = tG.Nombre,
                       idDep = tD.Codigo,
                       Dpto = tD.Nombre,
                       idC = tC.Codigo,
                       Ciudad = tC.Nombre
                   };
        }

        public IQueryable artistaXCod(int nroDoc)
        {
            return from tA in oEFR.Set<tblArtista>()
                   join tC in oEFR.Set<tblCiudad>()
                   on tA.idCiudad equals tC.Codigo
                   join tD in oEFR.Set<tblDpto>()
                   on tC.idDpto equals tD.Codigo
                   where tA.nroDoc == nroDoc
                   select new
                   {
                       Código = tA.Codigo,
                       Nombre = tA.Nombre,
                       idTD = tA.idtipoDoc,
                       nroDoc = tA.nroDoc,
                       idGen = tA.idGenero,
                       idDep = tD.Codigo,
                       idCiu = tA.idCiudad
                   };
        }

        public string Agregar()
        {
            var maxId = 0;
            try // Hallar el nuevo código
            {
                maxId = oEFR.tblArtistas.DefaultIfEmpty().Max(r => r == null ? 1 : r.Codigo + 1);
            }
            catch
            {
                return "Error, hubo fallo al grabar registro: " + tblArt.Nombre + ", con nroDoc: " + tblArt.nroDoc;
            }
            tblArt.Codigo = maxId;
            try
            {
                oEFR.tblArtistas.Add(tblArt);
                oEFR.SaveChanges();
                return "Registro grabado con éxito: " + tblArt.Nombre + ", con nroDoc: " + tblArt.nroDoc;
            }
            catch
            {
                return "Error, hubo fallo al grabar registro: " + tblArt.Nombre + ", con nroDoc: " + tblArt.nroDoc;
            }
        }

        public string Modificar()
        {
            try
            {
                tblArtista est = oEFR.tblArtistas.FirstOrDefault(s => s.Codigo == tblArt.Codigo);
                est.Codigo = tblArt.Codigo;
                est.Nombre = tblArt.Nombre;
                est.idtipoDoc = tblArt.idtipoDoc;
                est.nroDoc = tblArt.nroDoc;
                est.idGenero = tblArt.idGenero;
                est.idCiudad = tblArt.idCiudad;
                oEFR.SaveChanges();
                return "Se actualizo el registro" +
                    " de: " + est.nroDoc;
            }
            catch
            {
                return "Error, hubo fallo al actualizar registro: " + tblArt.Codigo + ", reintente por favor";
            }
        }
    }
}