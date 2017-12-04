using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActivosFijosAPI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ActivosFijosAPI.Controllers
{
    public class ActivoController : ApiController
    {
        // GET: api/Empleado
        public IHttpActionResult Get()
        {
            var list = new Activo().SelectActivos();

            return Ok(new { activos = list });



        }

        // GET: api/Empleado/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Activo activo = new Activo().SelectActivo(id);

                return Ok(new { activo });

            }
            catch (Exception e)
            {
                return Ok(new Activo());
            }
        }

        // POST: api/Empleado
        public void Post([FromBody]Activo value)
        {
            Activo.InsertActivo(value.Descripcion, value.ID_Departamento, value.ID_TipoActivo, value.FechaRegistro, value.ValorCompra, value.DepreciacionAcumulada);
        }

        // PUT: api/Empleado/5
        public void Put([FromBody]Activo value)
        {
            Activo.UpdateActivo(value.Id, value.Descripcion, value.ID_Departamento, value.ID_TipoActivo, value.FechaRegistro, value.ValorCompra, value.DepreciacionAcumulada);
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
            Activo.DeleteActivo(id);
        }

    }
}
