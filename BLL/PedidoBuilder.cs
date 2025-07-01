using BE;
using System.Collections.Generic;

namespace BLL
{
    public class PedidoBuilder
    {
        private IPedidoComponent _pedidoComponent;

        public PedidoBuilder(TipoCombo tipoCombo)
        {
            _pedidoComponent = BE.ComboFactory.CrearCombo(tipoCombo);
        }

        public PedidoBuilder AgregarQueso()
        {
            _pedidoComponent = new QuesoDecorator(_pedidoComponent);
            return this;
        }

        public PedidoBuilder AgregarCarne()
        {
            _pedidoComponent = new CarneDecorator(_pedidoComponent);
            return this;
        }

        public PedidoBuilder AgregarTomate()
        {
            _pedidoComponent = new TomateDecorator(_pedidoComponent);
            return this;
        }

        public PedidoBuilder AgregarPapas()
        {
            _pedidoComponent = new PapasDecorator(_pedidoComponent);
            return this;
        }

        public PedidoBuilder AgregarPorcion(TipoPorcion tipoPorcion)
        {
            switch (tipoPorcion)
            {
                case TipoPorcion.Queso:
                    return AgregarQueso();
                case TipoPorcion.Carne:
                    return AgregarCarne();
                case TipoPorcion.Tomate:
                    return AgregarTomate();
                case TipoPorcion.Papas:
                    return AgregarPapas();
                default:
                    return this;
            }
        }

        public IPedidoComponent Construir()
        {
            return _pedidoComponent;
        }

        public decimal ObtenerPrecioTotal()
        {
            return _pedidoComponent.CalcularPrecio();
        }

        public string ObtenerDescripcionCompleta()
        {
            return _pedidoComponent.ObtenerDescripcion();
        }

        public List<string> ObtenerIngredientes()
        {
            return _pedidoComponent.ObtenerIngredientes();
        }

        public TipoCombo ObtenerTipoComboBase()
        {
            return _pedidoComponent.ObtenerTipoComboBase();
        }

        public Pedido ConvertirAPedido()
        {
            var combo = BE.ComboFactory.CrearCombo(_pedidoComponent.ObtenerTipoComboBase());
            
            var pedido = new Pedido
            {
                Combo = combo
            };

            var descripcionCompleta = _pedidoComponent.ObtenerDescripcion();
            var descripcionBase = combo.Nombre;

            if (descripcionCompleta.Contains("+ Queso"))
            {
                pedido.PorcionesAdicionales.Add(new PorcionAdicional(TipoPorcion.Queso, 800m));
            }
            if (descripcionCompleta.Contains("+ Carne"))
            {
                pedido.PorcionesAdicionales.Add(new PorcionAdicional(TipoPorcion.Carne, 2000m));
            }
            if (descripcionCompleta.Contains("+ Tomate"))
            {
                pedido.PorcionesAdicionales.Add(new PorcionAdicional(TipoPorcion.Tomate, 500m));
            }
            if (descripcionCompleta.Contains("+ Papas"))
            {
                pedido.PorcionesAdicionales.Add(new PorcionAdicional(TipoPorcion.Papas, 1000m));
            }

            pedido.Total = _pedidoComponent.CalcularPrecio();
            return pedido;
        }
    }
}