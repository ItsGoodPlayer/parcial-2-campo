using System.Collections.Generic;

namespace BE
{
    public abstract class PorcionDecorator : IPedidoComponent
    {
        protected IPedidoComponent componente;
        
        protected PorcionDecorator(IPedidoComponent componente)
        {
            this.componente = componente;
        }
        
        public virtual decimal CalcularPrecio()
        {
            return componente.CalcularPrecio();
        }
        
        public virtual string ObtenerDescripcion()
        {
            return componente.ObtenerDescripcion();
        }
        
        public virtual List<string> ObtenerIngredientes()
        {
            return new List<string>(componente.ObtenerIngredientes());
        }
        
        public virtual TipoCombo ObtenerTipoComboBase()
        {
            return componente.ObtenerTipoComboBase();
        }
    }
}