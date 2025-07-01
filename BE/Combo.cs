using System;

namespace BE
{
    public abstract class Combo
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
    }
}