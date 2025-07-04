using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PedidoBuilder
    {
        private IPedidoComponent _pedidoComponent;
        private Combo _comboBase;

        public PedidoBuilder(Combo combo)
        {
            _comboBase = combo;
            _pedidoComponent = (IPedidoComponent)combo;
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
            var pedido = new Pedido
            {
                Combo = _comboBase,
                // Convertir múltiples decorators individuales a cantidades agregadas
                PorcionesAdicionales = AgregarCantidadesDePorciones(_pedidoComponent.ExtraerPorcionesRecursivamente())
            };

            pedido.Total = _pedidoComponent.CalcularPrecio();
            return pedido;
        }

        private List<PorcionAdicional> AgregarCantidadesDePorciones(List<PorcionAdicional> porcionesIndividuales)
        {
            // Agrupar porciones del mismo tipo y sumar cantidades
            var grupos = porcionesIndividuales
                .GroupBy(p => p.Tipo)
                .Select(g => new PorcionAdicional(g.Key, g.First().Precio)
                {
                    Cantidad = g.Sum(p => p.Cantidad)
                })
                .ToList();
            
            return grupos;
        }
    }
}