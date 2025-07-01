using System;
using System.Collections.Generic;
using System.Linq;

namespace BE
{
    public class Pedido
    {
        public int Id { get; set; }
        public Combo Combo { get; set; }
        public List<PorcionAdicional> PorcionesAdicionales { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public Pedido()
        {
            PorcionesAdicionales = new List<PorcionAdicional>();
            Fecha = DateTime.Now;
        }

        public decimal CalcularTotal()
        {
            decimal totalPorciones = PorcionesAdicionales.Sum(p => p.CalcularSubtotal());
            Total = Combo.CalcularPrecio() + totalPorciones;
            return Total;
        }

        public string ObtenerResumen()
        {
            string resumen = $"Pedido #{Id} - {Fecha:dd/MM/yyyy HH:mm}\n";
            resumen += $"Combo: {Combo.ObtenerDetalle()}\n";
            
            if (PorcionesAdicionales.Any())
            {
                resumen += "Porciones adicionales:\n";
                foreach (var porcion in PorcionesAdicionales)
                {
                    resumen += $"  - {porcion}\n";
                }
            }
            
            resumen += $"TOTAL: ${Total:N0}";
            return resumen;
        }

        public override string ToString()
        {
            return $"Pedido #{Id} - {Fecha:dd/MM/yyyy} - {Combo.Nombre} - ${Total:N0}";
        }
    }
}