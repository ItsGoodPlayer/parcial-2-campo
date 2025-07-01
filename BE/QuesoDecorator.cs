using System.Collections.Generic;

namespace BE
{
    public class QuesoDecorator : PorcionDecorator
    {
        private const decimal PRECIO_QUESO = 800m;
        
        public QuesoDecorator(IPedidoComponent componente) : base(componente)
        {
        }
        
        public override decimal CalcularPrecio()
        {
            return componente.CalcularPrecio() + PRECIO_QUESO;
        }
        
        public override string ObtenerDescripcion()
        {
            return componente.ObtenerDescripcion() + " + Queso";
        }
        
        public override List<string> ObtenerIngredientes()
        {
            var ingredientes = base.ObtenerIngredientes();
            ingredientes.Add("Queso extra");
            return ingredientes;
        }
    }
}