using System.Collections.Generic;

namespace BE
{
    public class TomateDecorator : PorcionDecorator
    {
        private const decimal PRECIO_TOMATE = 500m;
        
        public TomateDecorator(IPedidoComponent componente) : base(componente)
        {
        }
        
        public override decimal CalcularPrecio()
        {
            return componente.CalcularPrecio() + PRECIO_TOMATE;
        }
        
        public override string ObtenerDescripcion()
        {
            return componente.ObtenerDescripcion() + " + Tomate";
        }
        
        public override List<string> ObtenerIngredientes()
        {
            var ingredientes = base.ObtenerIngredientes();
            ingredientes.Add("Tomate");
            return ingredientes;
        }
        
        protected override TipoPorcion GetTipoPorcion()
        {
            return TipoPorcion.Tomate;
        }
        
        protected override decimal GetPrecio()
        {
            return PRECIO_TOMATE;
        }
    }
}