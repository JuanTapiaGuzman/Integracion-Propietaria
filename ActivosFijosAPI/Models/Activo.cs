using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosAPI.Models
{
    public class Activo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int ID_Departamento { get; set; }
        public int ID_TipoActivo { get; set; }
        public string FechaRegistro { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal DepreciacionAcumulada { get; set; }

        public List<Activo> SelectActivos()
        {
            Data.dsActivosTableAdapters.ActivosTableAdapter adapter = new Data.dsActivosTableAdapters.ActivosTableAdapter();
            Data.dsActivos.ActivosDataTable dt = adapter.SelectActivos();

            if (dt.Rows.Count <= 0)
                return new List<Activo>();

            List<Activo> listaActivos = new List<Activo>();


            foreach (Data.dsActivos.ActivosRow data in dt)
            {
                var activo = new Activo
                {
                    Id = data.ID_Activo,
                    Descripcion = data.Descripcion,
                    ID_Departamento = data.ID_Departamento,
                    ID_TipoActivo = data.ID_TipoActivo,
                    FechaRegistro = data.FechaRegistro.ToLongDateString(),
                    ValorCompra = data.ValorCompra,
                    DepreciacionAcumulada = data.DepreciacionAcumulada
                };

                listaActivos.Add(activo);
            }

            return listaActivos;
        }

        public Activo SelectActivo(int idActivo)
        {
            Data.dsActivosTableAdapters.ActivoTableAdapter adapter = new Data.dsActivosTableAdapters.ActivoTableAdapter();
            Data.dsActivos.ActivoDataTable dt = adapter.SelectActivo(idActivo);

            if (dt.Rows.Count <= 0)
                return new Activo();

            this.Id = dt.First().ID_Activo;
            this.Descripcion = dt.First().Descripcion;
            this.ID_Departamento = dt.First().ID_Departamento;
            this.ID_TipoActivo = dt.First().ID_TipoActivo;
            this.FechaRegistro = dt.First().FechaRegistro.ToShortDateString();
            this.ValorCompra = dt.First().ValorCompra;
            this.DepreciacionAcumulada = dt.First().DepreciacionAcumulada;


            return this;
        }

        public Activo SelectActivoLatest()
        {
            Data.dsActivosTableAdapters.ActivoTableAdapter adapter = new Data.dsActivosTableAdapters.ActivoTableAdapter();
            Data.dsActivos.ActivoDataTable dt = adapter.SelectActivoLatest();

            if (dt.Rows.Count <= 0)
                return new Activo();

            this.Id = dt.First().ID_Activo;
            this.Descripcion = dt.First().Descripcion;
            this.ID_Departamento = dt.First().ID_Departamento;
            this.ID_TipoActivo = dt.First().ID_TipoActivo;
            this.FechaRegistro = dt.First().FechaRegistro.ToShortDateString();
            this.ValorCompra = dt.First().ValorCompra;
            this.DepreciacionAcumulada = dt.First().DepreciacionAcumulada;


            return this;
        }


        public static void InsertActivo(string Descripcion, int ID_Departamento, int ID_TipoActivo, string FechaRegistro, decimal ValorCompra, decimal DepreciacionAcumulada)
        {
            Data.dsActivosTableAdapters.ActivoTableAdapter adapter = new Data.dsActivosTableAdapters.ActivoTableAdapter();
            adapter.InsertActivo(Descripcion, ID_Departamento, ID_TipoActivo, Convert.ToDateTime(FechaRegistro), ValorCompra, DepreciacionAcumulada);
        }

        public static void UpdateActivo(int idActivo, string Descripcion, int ID_Departamento, int ID_TipoActivo, string FechaRegistro, decimal ValorCompra, decimal DepreciacionAcumulada)
        {
            Data.dsActivosTableAdapters.ActivoTableAdapter adapter = new Data.dsActivosTableAdapters.ActivoTableAdapter();
            adapter.UpdateActivo(idActivo, Descripcion, ID_Departamento, ID_TipoActivo, Convert.ToDateTime(FechaRegistro), ValorCompra, DepreciacionAcumulada);
        }

        public static void DeleteActivo(int idActivo)
        {
            Data.dsActivosTableAdapters.ActivoTableAdapter adapter = new Data.dsActivosTableAdapters.ActivoTableAdapter();
            adapter.DeleteActivo(idActivo);
        }
    }
}