using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosAPI.Models
{
    public class AsientoContable
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string ID_TipoInventario { get; set; }
        public string CuentaContable { get; set; }
        public string TipoMovimiento { get; set; }
        public string FechaAsiento { get; set; }
        public decimal MontoAsiento { get; set; }
        public bool Estado { get; set; }

        public List<AsientoContable> SelectAsientoContables()
        {
            Data.dsAsientoContableTableAdapters.AsientoContablesTableAdapter adapter = new Data.dsAsientoContableTableAdapters.AsientoContablesTableAdapter();
            Data.dsAsientoContable.AsientoContablesDataTable dt = adapter.SelectAsientoContables();

            if (dt.Rows.Count <= 0)
                return new List<AsientoContable>();

            List<AsientoContable> listaAsientoContables = new List<AsientoContable>();


            foreach (Data.dsAsientoContable.AsientoContablesRow data in dt)
            {
                var asientoContable = new AsientoContable
                {
                    Id = data.ID_AsientoContable,
                    Descripcion = data.Descripcion,
                    ID_TipoInventario = data.ID_TipoInventario,
                    CuentaContable = data.CuentaContable,
                    TipoMovimiento = data.TipoMovimiento,
                    FechaAsiento = data.FechaAsiento.ToLongDateString(),
                    MontoAsiento = data.MontoAsiento,
                    Estado = data.Estado
                };

                listaAsientoContables.Add(asientoContable);
            }

            return listaAsientoContables;
        }

        public AsientoContable SelectAsientoContable(int idAsientoContable)
        {
            Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter adapter = new Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter();
            Data.dsAsientoContable.AsientoContableDataTable dt = adapter.SelectAsientoContable(idAsientoContable);

            if (dt.Rows.Count <= 0)
                return new AsientoContable();

            this.Id = dt.First().ID_AsientoContable;
            this.Descripcion = dt.First().Descripcion;
            this.ID_TipoInventario = dt.First().ID_TipoInventario;
            this.CuentaContable = dt.First().CuentaContable;
            this.TipoMovimiento = dt.First().TipoMovimiento;
            this.FechaAsiento = dt.First().FechaAsiento.ToShortDateString();
            this.MontoAsiento = dt.First().MontoAsiento;
            this.Estado = dt.First().Estado;


            return this;
        }

        public static void InsertAsientoContable(string Descripcion, string ID_TipoInventario, string CuentaContable, string TipoMovimiento, string FechaAsiento, decimal MontoAsiento, bool Estado)
        {
            Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter adapter = new Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter();
            adapter.InsertAsientoContable(Descripcion, ID_TipoInventario, CuentaContable, TipoMovimiento, Convert.ToDateTime(FechaAsiento), MontoAsiento, Estado);
        }

        public static void UpdateAsientoContable(int idAsientoContable, string Descripcion, string ID_TipoInventario, string CuentaContable, string TipoMovimiento, string FechaAsiento, decimal MontoAsiento, bool Estado)
        {
            Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter adapter = new Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter();
            adapter.UpdateAsientoContable(idAsientoContable, Descripcion, ID_TipoInventario, CuentaContable, TipoMovimiento, Convert.ToDateTime(FechaAsiento), MontoAsiento, Estado);
        }

        public static void DeleteAsientoContable(int idAsientoContable)
        {
            Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter adapter = new Data.dsAsientoContableTableAdapters.AsientoContableTableAdapter();
            adapter.DeleteAsientoContable(idAsientoContable);
        }
    }
}