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
    public class EmpleadoController : ApiController
    {
        // GET: api/Empleado
        public IHttpActionResult Get()
        {
            var list = new Empleado().SelectEmpleados();

            return Ok(new { empleados = list });



        }

        // GET: api/Empleado/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Empleado empleado = new Empleado().SelectEmpleado(id);

                return Ok(new { empleado });

            }
            catch (Exception e)
            {
                return Ok(new Empleado());
            }
        }

        // POST: api/Empleado
        public void Post([FromBody]Empleado value)
        {
            Empleado.InsertEmpleado(value.Nombre, value.Cedula, value.ID_Departamento, value.TipoPersona, value.FechaIngreso, value.Estado);
        }

        // PUT: api/Empleado/5
        public void Put([FromBody]Empleado value)
        {
            Empleado.UpdateEmpleado(value.Id, value.Nombre, value.Cedula, value.ID_Departamento, value.TipoPersona, value.FechaIngreso, value.Estado);
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
            Empleado.DeleteEmpleado(id);
        }
    }
}