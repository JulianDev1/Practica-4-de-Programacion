using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiFestRock.Models;
using apiFestRock.Clases;
using System.Web.Http.Cors;

namespace apiFestRock.Controllers
{
    [EnableCors(origins: "http://localhost:51700", headers: "*", methods: "*")]
    public class artistaController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable Get(int dato,  int comando)
        {
            clsOpeArtista opeArt = new clsOpeArtista();
            switch (comando)
            {
                case 1: // Vamos a llenar la tabla con los datos de todos los artistas
                    return opeArt.listarArtistas();
                default: // Vamos a consultar el artista
                    return opeArt.artistaXCod( dato );
            }
        }

        // POST api/<controller>
        //Boton Agregar
        public string Post([FromBody] tblArtista datIn)
        {
            clsOpeArtista oOpeX=new clsOpeArtista();
            oOpeX.tblArt = datIn;
            return oOpeX.Agregar();
        }

        // PUT api/<controller>/5
        // Boton< Modificar
        public string Put([FromBody] tblArtista datIn)
        {
            clsOpeArtista oOpeX = new clsOpeArtista();
            //Pasar los parámetros del estudiante
            oOpeX.tblArt = datIn;
            return oOpeX.Modificar();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}