using apiFestRock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiFestRock.Clases
{
    public class clsOpeInscrip
    {
        //Atributos
        private bdEventosEntities oEFR = new bdEventosEntities();
        //propiedades
        public tblInscrip tblInsc { get; set; }

        public tblInscrip consultarInscrip()
        {
            try
            {
                var rpta = oEFR.tblInscrips
                .Where(x => x.Codigo == tblInsc.Codigo)
                .ToList();
                tblInsc.Codigo = Convert.ToInt32(rpta[0].Codigo);
                tblInsc.idEvento = Convert.ToInt32(rpta[0].idEvento);
                tblInsc.idBanda = Convert.ToInt32(rpta[0].idBanda);
                tblInsc.Represenante = rpta[0].Represenante; // cuidado es representante pero yo lo copie mal quizas
                tblInsc.Telefono = rpta[0].Telefono;
                tblInsc.valor = Convert.ToInt32(rpta[0].valor); //tambien se escribio valor y era Valor (v) mayuscula
                return tblInsc;
            }
            catch
            {
                tblInsc.Codigo = 0;
                return tblInsc;
            }

        }

        public tblInscrip agregarInscrip()
        {
            int nroI = 0;
            nroI = oEFR.tblInscrips.DefaultIfEmpty().Max(r => r == null ? 1 : r.Codigo + 1);
            if (nroI > 0)
            {
                tblInsc.Codigo = nroI;
                oEFR.tblInscrips.Add(tblInsc);
                oEFR.SaveChanges();
                return tblInsc;
            }
            else
                return tblInsc;
        }
        public string actValor()
        {
            try
            {
                tblInscrip tInsc = oEFR.tblInscrips.FirstOrDefault(s => s.Codigo == tblInsc.Codigo);
                tInsc.valor = tblInsc.valor;
                oEFR.SaveChanges();
                return "Se actualizo el valor del registro: " + tInsc.Codigo;
            }
            catch
            {
                return "Error, hubo fallo al actualizar registro: " + tblInsc.Codigo + ", reintente por favor";
            }
        }

        public string Modificar()
        {
            try
            {
                tblInscrip tInsc = oEFR.tblInscrips.FirstOrDefault(s => s.Codigo == tblInsc.Codigo);
                tInsc.Represenante = tblInsc.Represenante;
                tInsc.Telefono = tblInsc.Telefono;
                oEFR.SaveChanges();
                return "Se actualizo el registro de: " + tInsc.Codigo;
            }
            catch
            {
                return "Error, hubo fallo al actualizar registro: " + tblInsc.Codigo + ", reintente por favor";
            }
        }
    }
}