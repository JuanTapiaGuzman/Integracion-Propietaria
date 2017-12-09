using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosAPI.Models
{
    public class TipoActivo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CuentaContableCompra { get; set; }
        public string CuentaContableDepreciacion { get; set; }
        public bool Estado { get; set; }


        public List<TipoActivo> SelectTipoActivos()
        {
            Data.dsTipoActivosTableAdapters.TipoActivosTableAdapter adapter = new Data.dsTipoActivosTableAdapters.TipoActivosTableAdapter();
            Data.dsTipoActivos.TipoActivosDataTable dt = adapter.SelectTipoActivos();

            if (dt.Rows.Count <= 0)
                return new List<TipoActivo>();

            List<TipoActivo> listaTipoActivos = new List<TipoActivo>();


            foreach (Data.dsTipoActivos.TipoActivosRow data in dt)
            {
                var tipoActivo = new TipoActivo
                {
                    Id = data.ID_TipoActivo,
                    Descripcion = data.Descripcion,
                    CuentaContableCompra = data.CuentaContableCompra,
                    CuentaContableDepreciacion = data.CuentaContableDepreciacion,
                    Estado = data.Estado
                };

                listaTipoActivos.Add(tipoActivo);
            }

            return listaTipoActivos;
        }

        public TipoActivo SelectTipoActivo(int idTipoActivo)
        {
            Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter adapter = new Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter();
            Data.dsTipoActivos.TipoActivoDataTable dt = adapter.SelectTipoActivo(idTipoActivo);

            if (dt.Rows.Count <= 0)
                return new TipoActivo();

            this.Id = dt.First().ID_TipoActivo;
            this.Descripcion = dt.First().Descripcion;
            this.CuentaContableCompra = dt.First().CuentaContableCompra;
            this.CuentaContableDepreciacion = dt.First().CuentaContableDepreciacion;
            this.Estado = dt.First().Estado;


            return this;
        }


        public TipoActivo SelectTipoActivoLatest()
        {
            Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter adapter = new Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter();
            Data.dsTipoActivos.TipoActivoDataTable dt = adapter.SelectTipoActivoLatest();

            if (dt.Rows.Count <= 0)
                return new TipoActivo();

            this.Id = dt.First().ID_TipoActivo;
            this.Descripcion = dt.First().Descripcion;
            this.CuentaContableCompra = dt.First().CuentaContableCompra;
            this.CuentaContableDepreciacion = dt.First().CuentaContableDepreciacion;
            this.Estado = dt.First().Estado;


            return this;
        }

        public static void InsertTipoActivo(string Descripcion, string CuentaContableCompra, string CuentaContableDepreciacion, bool Estado)
        {
            Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter adapter = new Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter();
            adapter.InsertTipoActivo(Descripcion, CuentaContableCompra, CuentaContableDepreciacion, Estado);
        }

        public static void UpdateTipoActivo(int idTipoActivo, string Descripcion, string CuentaContableCompra, string CuentaContableDepreciacion, bool Estado)
        {
            Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter adapter = new Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter();
            adapter.UpdateTipoActivo(idTipoActivo, Descripcion, CuentaContableCompra, CuentaContableDepreciacion, Estado);
        }

        public static void DeleteTipoActivo(int idTipoActivo)
        {
            Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter adapter = new Data.dsTipoActivosTableAdapters.TipoActivoTableAdapter();
            adapter.DeleteTipoActivo(idTipoActivo);
        }


    }
}