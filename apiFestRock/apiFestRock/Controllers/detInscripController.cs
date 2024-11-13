using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiFestRock.Models;
using apiFestRock.Clases;

namespace apiFestRock.Controllers
{
    public class detInscripController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IQueryable Get(int comando, int dato)
        {
            clsOpeDetInsc oDI = new clsOpeDetInsc();
            if (comando == 1) {
                return oDI.llenarTabla(dato); //<-- codigo de inscripcion
  
            }
            return null;
        }
       
        // POST api/<controller>
        public tblDetInsc Post([FromBody] tblDetInsc objIn)
        {
            clsOpeDetInsc opeDM = new clsOpeDetInsc();
            opeDM.tblDIns = objIn;
            return opeDM.Agregar();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public string Delete(int idDetI)
        {
            clsOpeDetInsc opeDM = new clsOpeDetInsc();
            return opeDM.Eliminar(idDetI);

        }
    }
}