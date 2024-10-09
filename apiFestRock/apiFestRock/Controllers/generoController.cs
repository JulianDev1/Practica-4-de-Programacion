using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;
using apiFestRock.Clases;
using apiFestRock.Models;


namespace apiFestRock.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class generoController : ApiController
    {

        // GET api/<controller>
        public List<tblGenero> Get()
        {
            clsOpeGenero oX = new clsOpeGenero();
            return oX.listarGenero();
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