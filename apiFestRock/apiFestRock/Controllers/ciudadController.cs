using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiFestRock.Clases;
using apiFestRock.Models;
using System.Web.Http.Cors;

namespace apiFestRock.Controllers
{
    [EnableCors(origins: "http://localhost:51700", headers: "*", methods: "*")]
    public class ciudadController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public List<tblCiudad> Get(int idDpto)
        {
            clsOpeCiudad Od = new clsOpeCiudad();
            return Od.listarCiudadades(idDpto);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}