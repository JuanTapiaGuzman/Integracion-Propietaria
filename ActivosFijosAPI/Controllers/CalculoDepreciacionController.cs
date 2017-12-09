using ActivosFijosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivosFijosAPI.Controllers
{
    public class CalculoDepreciacionController : ApiController
    {
        // GET: api/Empleado/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                CalculoDepreciacion asientoContable = new CalculoDepreciacion();
                asientoContable = asientoContable.SelectCalculoDepreciacion(id);

                return Ok(new { asientoContable });
            }
            catch (Exception e)
            {
                return Ok(new AsientoContable());
            }
        }
    }
}
