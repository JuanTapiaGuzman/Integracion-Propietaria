using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijosAPI.Models
{
    public class CalculoDepreciacion
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }
        public decimal IdActivo { get; set; }
        public DateTime FechaProceso { get; set; }
        public Decimal MontoDepreciado { get; set; }
        public string CuentaCompra { get; set; }
        public string CuentaDepreciacion { get; set; }
        public bool Estado { get; set; }

        public CalculoDepreciacion SelectCalculoDepreciacion(int IdActivo = 1)
        {
            Data.dsCalculoDepreciacionTableAdapters.CalcularDepreciacionTableAdapter adapter = new Data.dsCalculoDepreciacionTableAdapters.CalcularDepreciacionTableAdapter();
            Data.dsCalculoDepreciacion.CalcularDepreciacionDataTable dt = adapter.CalcularDepreciacion(IdActivo);

            if (dt.Rows.Count <= 0)
                return new CalculoDepreciacion();

            this.Id = dt.First().ID_CalculoDepreciacion;
            this.Ano = dt.First().AnoProceso;
            this.Mes = dt.First().MesProceso;
            this.IdActivo = dt.First().ID_Activo;
            this.FechaProceso = dt.First().FechaProceso;
            this.MontoDepreciado = dt.First().MontoDepreciado;
            this.CuentaCompra = dt.First().CuentaContableCompra;
            this.CuentaDepreciacion = dt.First().CuentaContableDepreciacion;
            this.Estado = dt.First().Estado;

            return this;
        }
    }
}