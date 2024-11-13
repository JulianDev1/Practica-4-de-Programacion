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
    public class eventoController : ApiController
    {
        // GET api/<controller>
        public List<tblEvento> Get()
        {
            clsOpeEvento oX = new clsOpeEvento();
            return oX.listarEvento();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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