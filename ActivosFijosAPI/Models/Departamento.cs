using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosAPI.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Departamento> SelectDepartamentos()
        {
            Data.dsDepartamentosTableAdapters.DepartamentosTableAdapter adapter = new Data.dsDepartamentosTableAdapters.DepartamentosTableAdapter();
            Data.dsDepartamentos.DepartamentosDataTable dt = adapter.SelectDepartamentos();

            if (dt.Rows.Count <= 0)
                return new List<Departamento>();

            List<Departamento> listaDepartamentos = new List<Departamento>();

            foreach (Data.dsDepartamentos.DepartamentosRow data in dt)
            {
                var departamento = new Departamento();

                departamento.Id = data.ID_Departamento;
                departamento.Descripcion = data.Descripcion;
                departamento.Estado = data.Estado;

                listaDepartamentos.Add(departamento);
            }

            return listaDepartamentos;
        }

        public Departamento SelectDepartamento(int idDepartamento)
        {
            Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter adapter = new Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter();
            Data.dsDepartamentos.DepartamentoDataTable dt = adapter.SelectDepartamento(idDepartamento);

            if (dt.Rows.Count <= 0)
                return new Departamento();

            this.Id = dt.First().ID_Departamento;
            this.Descripcion = dt.First().Descripcion;
            this.Estado = dt.First().Estado;

            return this;
        }

        public static void InsertDepartamento(string descripcion, bool estado)
        {
            Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter adapter = new Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter();
            adapter.InsertDepartamento(descripcion, estado);
        }

        public static void UpdateDepartamento(int idDepartamento, string descripcion, bool estado)
        {
            Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter adapter = new Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter();
            adapter.UpdateDepartamento(idDepartamento, descripcion, estado);
        }

        public static void DeleteDepartamento(int idDepartamento)
        {
            Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter adapter = new Data.dsDepartamentosTableAdapters.DepartamentoTableAdapter();
            adapter.DeleteDepartamento(idDepartamento);
        }
    }
}