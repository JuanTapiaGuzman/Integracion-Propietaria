using ActivosFijosAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivosFijosAPI.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET: api/Departamento
        public IHttpActionResult Get()
        {
            var list = new Departamento().SelectDepartamentos();

            return Ok(new { departamentos = list });
        }

        // GET: api/Departamento/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Departamento departamento = new Departamento().SelectDepartamento(id);

                return Ok(new { departamento });
            }
            catch (Exception e)
            {
                return Ok( new Departamento() );
            }
        }

        // POST: api/Departamento
        public void Post([FromBody]Departamento value)
        {
            Departamento.InsertDepartamento(value.Descripcion, value.Estado);
        }

        // PUT: api/Departamento/5
        public void Put([FromBody]Departamento value)
        {
            Departamento.UpdateDepartamento(value.Id, value.Descripcion, value.Estado);
        }

        // DELETE: api/Departamento/5
        public void Delete(int id)
        {
            Departamento.DeleteDepartamento(id);
        }
    }
}
