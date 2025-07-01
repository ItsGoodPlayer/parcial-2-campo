using System.Collections.Generic;

namespace BE
{
    public class CarneDecorator : PorcionDecorator
    {
        private const decimal PRECIO_CARNE = 2000m;
        
        public CarneDecorator(IPedidoComponent componente) : base(componente)
        {
        }
        
        public override decimal CalcularPrecio()
        {
            return componente.CalcularPrecio() + PRECIO_CARNE;
        }
        
        public override string ObtenerDescripcion()
        {
            return componente.ObtenerDescripcion() + " + Carne";
        }
        
        public override List<string> ObtenerIngredientes()
        {
            var ingredientes = base.ObtenerIngredientes();
            ingredientes.Add("Carne extra");
            return ingredientes;
        }
    }
}