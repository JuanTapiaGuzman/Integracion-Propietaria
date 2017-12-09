using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosAPI.Models
{
    public class Empleado
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public int ID_Departamento { get; set; }
        public string TipoPersona { get; set; }
        public string FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Empleado> SelectEmpleados()
        {
            Data.dsEmpleadosTableAdapters.EmpleadosTableAdapter adapter = new Data.dsEmpleadosTableAdapters.EmpleadosTableAdapter();
            Data.dsEmpleados.EmpleadosDataTable dt = adapter.SelectEmpleados();

            if (dt.Rows.Count <= 0)
                return new List<Empleado>();

            List<Empleado> listaEmpleados = new List<Empleado>();


            foreach (Data.dsEmpleados.EmpleadosRow data in dt)
            {
                var empleado = new Empleado
                {
                    Id = data.ID_Empleado,
                    Nombre = data.Nombre,
                    Cedula = data.Cedula,
                    ID_Departamento = data.ID_Departamento,
                    TipoPersona = data.TipoPersona,
                    FechaIngreso = data.FechaIngreso.ToShortDateString(),
                    Estado = data.Estado
                };

                listaEmpleados.Add(empleado);
            }

            return listaEmpleados;
        }

        public Empleado SelectEmpleado(int idEmpleado)
        {
            Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter adapter = new Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter();
            Data.dsEmpleados.EmpleadoDataTable dt = adapter.SelectEmpleado(idEmpleado);

            if (dt.Rows.Count <= 0)
                return new Empleado();

            this.Id = dt.First().ID_Empleado;
            this.Nombre = dt.First().Nombre;
            this.Cedula = dt.First().Cedula;
            this.ID_Departamento = dt.First().ID_Departamento;
            this.TipoPersona = dt.First().TipoPersona;
            this.FechaIngreso = dt.First().FechaIngreso.ToShortDateString();
            this.Estado = dt.First().Estado;


            return this;
        }

        public Empleado SelectEmpleadoLatest()
        {
            Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter adapter = new Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter();
            Data.dsEmpleados.EmpleadoDataTable dt = adapter.SelectEmpleadoLatest();

            if (dt.Rows.Count <= 0)
                return new Empleado();

            this.Id = dt.First().ID_Empleado;
            this.Nombre = dt.First().Nombre;
            this.Cedula = dt.First().Cedula;
            this.ID_Departamento = dt.First().ID_Departamento;
            this.TipoPersona = dt.First().TipoPersona;
            this.FechaIngreso = dt.First().FechaIngreso.ToShortDateString();
            this.Estado = dt.First().Estado;


            return this;
        }

        public static void InsertEmpleado(string Nombre, string Cedula, int ID_Empleado, string TipoPersona, string FechaIngreso, bool estado)
        {
            Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter adapter = new Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter();
            adapter.InsertEmpleado(Nombre, Cedula, ID_Empleado, TipoPersona, Convert.ToDateTime(FechaIngreso), estado);
        }

        public static void UpdateEmpleado(int idEmpleado, string Nombre, string Cedula, int ID_Empleado, string TipoPersona, string FechaIngreso, bool estado)
        {
            Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter adapter = new Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter();
            adapter.UpdateEmpleado(idEmpleado, Nombre, Cedula, TipoPersona, Convert.ToDateTime(FechaIngreso), estado);
        }

        public static void DeleteEmpleado(int idEmpleado)
        {
            Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter adapter = new Data.dsEmpleadosTableAdapters.EmpleadoTableAdapter();
            adapter.DeleteEmpleado(idEmpleado);
        }

    }

}