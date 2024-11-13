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
    public class bandaController : ApiController
    {
        // GET api/<controller>
        public List<tblBanda> Get()
        {
            clsOpeBanda oX = new clsOpeBanda();
            return oX.listarBanda();
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