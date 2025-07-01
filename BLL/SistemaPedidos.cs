using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SistemaPedidos
    {
        private static SistemaPedidos _instancia;
        private PedidoDAL _pedidoDAL;
        private PorcionAdicionalDAL _porcionDAL;

        public PedidoBuilder PedidoActual { get; private set; }
        public List<Pedido> HistorialPedidos { get; private set; }

        private SistemaPedidos()
        {
            _pedidoDAL = new PedidoDAL();
            _porcionDAL = new PorcionAdicionalDAL();
            HistorialPedidos = new List<Pedido>();
            CargarHistorial();
        }

        public static SistemaPedidos ObtenerInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new SistemaPedidos();
            }
            return _instancia;
        }

        public void CrearNuevoPedido(TipoCombo tipoCombo)
        {
            PedidoActual = new PedidoBuilder(tipoCombo);
        }

        public void AgregarPorcionAdicional(TipoPorcion tipoPorcion)
        {
            if (PedidoActual == null) return;
            PedidoActual.AgregarPorcion(tipoPorcion);
        }

        public void QuitarPorcionAdicional(TipoPorcion tipoPorcion)
        {
            if (PedidoActual == null) return;
            
            var descripcion = PedidoActual.ObtenerDescripcionCompleta();
            var porcionTexto = "+ " + tipoPorcion.ToString();
            
            if (descripcion.Contains(porcionTexto))
            {
                CrearNuevoPedido(PedidoActual.ObtenerTipoComboBase());
                ReconstruirPedidoSinPorcion(descripcion, tipoPorcion);
            }
        }

        private void ReconstruirPedidoSinPorcion(string descripcionOriginal, TipoPorcion porcionAEliminar)
        {
            if (descripcionOriginal.Contains("+ Queso") && porcionAEliminar != TipoPorcion.Queso)
                PedidoActual.AgregarQueso();
            if (descripcionOriginal.Contains("+ Carne") && porcionAEliminar != TipoPorcion.Carne)
                PedidoActual.AgregarCarne();
            if (descripcionOriginal.Contains("+ Tomate") && porcionAEliminar != TipoPorcion.Tomate)
                PedidoActual.AgregarTomate();
            if (descripcionOriginal.Contains("+ Papas") && porcionAEliminar != TipoPorcion.Papas)
                PedidoActual.AgregarPapas();
        }

        public void FinalizarPedido()
        {
            if (PedidoActual == null) return;

            var pedidoParaGuardar = PedidoActual.ConvertirAPedido();
            pedidoParaGuardar.CalcularTotal();
            pedidoParaGuardar.Id = _pedidoDAL.GuardarPedido(pedidoParaGuardar);
            HistorialPedidos.Add(pedidoParaGuardar);
            PedidoActual = null;
        }

        public void CargarHistorial()
        {
            HistorialPedidos = _pedidoDAL.CargarPedidos();
        }

        public List<PorcionAdicional> ObtenerPorcionesDisponibles()
        {
            return _porcionDAL.CargarPorcionesAdicionales();
        }

        public bool EliminarPedido(int pedidoId)
        {
            bool eliminado = _pedidoDAL.EliminarPedido(pedidoId);
            if (eliminado)
            {
                var pedidoAEliminar = HistorialPedidos.FirstOrDefault(p => p.Id == pedidoId);
                if (pedidoAEliminar != null)
                {
                    HistorialPedidos.Remove(pedidoAEliminar);
                }
            }
            return eliminado;
        }

        public Pedido ObtenerPedidoPorId(int pedidoId)
        {
            return _pedidoDAL.ObtenerPedidoPorId(pedidoId);
        }

        public decimal ObtenerTotalPedidoActual()
        {
            return PedidoActual?.ObtenerPrecioTotal() ?? 0m;
        }

        public string ObtenerResumenPedidoActual()
        {
            if (PedidoActual == null) return "No hay pedido actual";
            
            var ingredientes = string.Join("\n  - ", PedidoActual.ObtenerIngredientes());
            return $"{PedidoActual.ObtenerDescripcionCompleta()}\n\nIngredientes:\n  - {ingredientes}\n\nTOTAL: ${PedidoActual.ObtenerPrecioTotal():N0}";
        }

        public bool TienePorcion(TipoPorcion tipoPorcion)
        {
            if (PedidoActual == null) return false;
            return PedidoActual.ObtenerDescripcionCompleta().Contains("+ " + tipoPorcion.ToString());
        }
    }
}