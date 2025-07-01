namespace BE
{
    public class PorcionAdicional
    {
        public int Id { get; set; }
        public TipoPorcion Tipo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public PorcionAdicional()
        {
            Cantidad = 1;
        }

        public PorcionAdicional(TipoPorcion tipo, decimal precio) : this()
        {
            Tipo = tipo;
            Precio = precio;
        }

        public decimal CalcularSubtotal()
        {
            return Precio * Cantidad;
        }

        public override string ToString()
        {
            string cantidadTexto = Cantidad > 1 ? $" x{Cantidad}" : "";
            return $"{Tipo}{cantidadTexto} (${CalcularSubtotal():N0})";
        }
    }
}