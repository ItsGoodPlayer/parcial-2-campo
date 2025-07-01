using System.Collections.Generic;

namespace BE
{
    public class PapasDecorator : PorcionDecorator
    {
        private const decimal PRECIO_PAPAS = 1000m;
        
        public PapasDecorator(IPedidoComponent componente) : base(componente)
        {
        }
        
        public override decimal CalcularPrecio()
        {
            return componente.CalcularPrecio() + PRECIO_PAPAS;
        }
        
        public override string ObtenerDescripcion()
        {
            return componente.ObtenerDescripcion() + " + Papas";
        }
        
        public override List<string> ObtenerIngredientes()
        {
            var ingredientes = base.ObtenerIngredientes();
            ingredientes.Add("Papas extra");
            return ingredientes;
        }
    }
}