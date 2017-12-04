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
    public class AsientoContableController : ApiController
    {
        // GET: api/Empleado
        public IHttpActionResult Get()
        {
            var list = new AsientoContable().SelectAsientoContables();

            return Ok(new { AsientoContable = list });



        }

        // GET: api/Empleado/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                AsientoContable asientoContable = new AsientoContable().SelectAsientoContable(id);

                return Ok(new { asientoContable });

            }
            catch (Exception e)
            {
                return Ok(new AsientoContable());
            }
        }

        // POST: api/Empleado
        public void Post([FromBody]AsientoContable value)
        {
            AsientoContable.InsertAsientoContable(value.Descripcion, value.ID_TipoInventario, value.CuentaContable, value.TipoMovimiento, value.FechaAsiento, value.MontoAsiento, value.Estado);
        }

        // PUT: api/Empleado/5
        public void Put([FromBody]AsientoContable value)
        {
            AsientoContable.UpdateAsientoContable(value.Id, value.Descripcion, value.ID_TipoInventario, value.CuentaContable, value.TipoMovimiento, value.FechaAsiento, value.MontoAsiento, value.Estado);
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
            AsientoContable.DeleteAsientoContable(id);
        } 

    }
}
