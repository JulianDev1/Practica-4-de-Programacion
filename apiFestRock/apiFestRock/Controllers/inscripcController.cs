using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiFestRock.Models;
using apiFestRock.Clases;
//Cors
using System.Web.Http.Cors;

namespace apiFestRock.Controllers
{
    [EnableCors(origins: "http://localhost:51700", headers: "*", methods: "*")]
    public class inscripcController : ApiController
    {
        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public tblInscrip Post([FromBody] tblInscrip objIn, int cmdo)
        {
            clsOpeInscrip oI = new clsOpeInscrip();
            oI.tblInsc = objIn;
            switch (cmdo)
            {
                case 101: //Consulta por código de inscripción
                    return oI.consultarInscrip();
                case 131: //Agregar una nueva inscripción
                    return oI.agregarInscrip();
                default:
                    return objIn;
            }
        }

        // PUT api/<controller>/5
        public string Put([FromBody] tblInscrip datIn, int comando)
        {
            clsOpeInscrip oIa = new clsOpeInscrip();
            oIa.tblInsc = datIn;
            if (comando == 1) // actualizar valor
            {
                return oIa.actValor();
            }
            else if (comando == 2)
            {
                return oIa.Modificar();
            }
            return null;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}