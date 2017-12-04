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
    public class TipoActivoController : ApiController
    {
        // GET: api/Empleado
        public IHttpActionResult Get()
        {
            var list = new TipoActivo().SelectTipoActivos();

            return Ok(new { tipoActivos = list });



        }

        // GET: api/Empleado/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                TipoActivo tipoActivo = new TipoActivo().SelectTipoActivo(id);

                return Ok(new { tipoActivo });

            }
            catch (Exception e)
            {
                return Ok(new TipoActivo());
            }
        }

        // POST: api/Empleado
        public void Post([FromBody]TipoActivo value)
        {
            TipoActivo.InsertTipoActivo(value.Descripcion, value.CuentaContableCompra, value.CuentaContableDepreciacion, value.Estado);
        }

        // PUT: api/Empleado/5
        public void Put([FromBody]TipoActivo value)
        {
            TipoActivo.UpdateTipoActivo(value.Id, value.Descripcion, value.CuentaContableCompra, value.CuentaContableDepreciacion, value.Estado);
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
            TipoActivo.DeleteTipoActivo(id);
        }
    }
}
