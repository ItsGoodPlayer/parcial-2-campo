using System;
using System.Collections.Generic;

namespace BE
{
    public abstract class Combo : IPedidoComponent
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public TipoCombo Tipo { get; set; }

        public virtual decimal CalcularPrecio()
        {
            return Precio;
        }

        public virtual string ObtenerDetalle()
        {
            return $"{Nombre} - ${Precio:N0} - {Descripcion}";
        }

        public override string ToString()
        {
            return $"{Nombre} (${Precio:N0})";
        }

        // Implementación de IPedidoComponent
        public string ObtenerDescripcion()
        {
            return Nombre;
        }

        public TipoCombo ObtenerTipoComboBase()
        {
            return Tipo;
        }

        public List<PorcionAdicional> ExtraerPorcionesRecursivamente()
        {
            // Caso base: el combo no tiene porciones adicionales
            return new List<PorcionAdicional>();
        }

        // Método abstracto que cada combo específico debe implementar
        public abstract List<string> ObtenerIngredientes();
    }
}