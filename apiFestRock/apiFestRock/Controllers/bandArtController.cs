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
    public class bandArtController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get(int dato, int comando)
        {
            clsOpeBandaArt opeBA = new clsOpeBandaArt();
            switch (comando)
            {
                case 1: //Llenar combo de los artistas por banda
                    return opeBA.listarArtistasXBand(dato);
                default: //Consultar el nombre del instrumento de un artista
                    return opeBA.consultaInstArtBand(dato);
            }
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