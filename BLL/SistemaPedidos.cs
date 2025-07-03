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
        private ComboDAL _comboDAL;

        public List<PedidoBuilder> PedidosActivos { get; private set; }
        public PedidoBuilder PedidoSeleccionado { get; private set; }
        public List<Pedido> HistorialPedidos { get; private set; }

        private SistemaPedidos()
        {
            _pedidoDAL = new PedidoDAL();
            _porcionDAL = new PorcionAdicionalDAL();
            _comboDAL = new ComboDAL();
            PedidosActivos = new List<PedidoBuilder>();
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

        public void CrearNuevoPedido(Combo combo)
        {
            var nuevoPedido = new PedidoBuilder(combo);
            PedidosActivos.Add(nuevoPedido);
            PedidoSeleccionado = nuevoPedido;
        }

        public void AgregarPorcionAdicional(TipoPorcion tipoPorcion)
        {
            if (PedidoSeleccionado == null) return;
            PedidoSeleccionado.AgregarPorcion(tipoPorcion);
        }

        public void QuitarPorcionAdicional(TipoPorcion tipoPorcion)
        {
            if (PedidoSeleccionado == null) return;
            
            var descripcion = PedidoSeleccionado.ObtenerDescripcionCompleta();
            var porcionTexto = "+ " + tipoPorcion.ToString();
            
            if (descripcion.Contains(porcionTexto))
            {
                var comboActual = ObtenerComboPorTipo(PedidoSeleccionado.ObtenerTipoComboBase());
                var indicePedido = PedidosActivos.IndexOf(PedidoSeleccionado);
                PedidosActivos[indicePedido] = new PedidoBuilder(comboActual);
                PedidoSeleccionado = PedidosActivos[indicePedido];
                ReconstruirPedidoSinPorcion(descripcion, tipoPorcion);
            }
        }

        private void ReconstruirPedidoSinPorcion(string descripcionOriginal, TipoPorcion porcionAEliminar)
        {
            if (descripcionOriginal.Contains("+ Queso") && porcionAEliminar != TipoPorcion.Queso)
                PedidoSeleccionado.AgregarQueso();
            if (descripcionOriginal.Contains("+ Carne") && porcionAEliminar != TipoPorcion.Carne)
                PedidoSeleccionado.AgregarCarne();
            if (descripcionOriginal.Contains("+ Tomate") && porcionAEliminar != TipoPorcion.Tomate)
                PedidoSeleccionado.AgregarTomate();
            if (descripcionOriginal.Contains("+ Papas") && porcionAEliminar != TipoPorcion.Papas)
                PedidoSeleccionado.AgregarPapas();
        }

        public void FinalizarPedido()
        {
            if (PedidoSeleccionado == null) return;

            var pedidoParaGuardar = PedidoSeleccionado.ConvertirAPedido();
            pedidoParaGuardar.CalcularTotal();
            pedidoParaGuardar.Id = _pedidoDAL.GuardarPedido(pedidoParaGuardar);
            HistorialPedidos.Add(pedidoParaGuardar);
            
            PedidosActivos.Remove(PedidoSeleccionado);
            PedidoSeleccionado = PedidosActivos.FirstOrDefault();
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
            return PedidoSeleccionado?.ObtenerPrecioTotal() ?? 0m;
        }

        public string ObtenerResumenPedidoActual()
        {
            if (PedidoSeleccionado == null) return "No hay pedido actual";
            
            var ingredientes = string.Join("\n  - ", PedidoSeleccionado.ObtenerIngredientes());
            return $"{PedidoSeleccionado.ObtenerDescripcionCompleta()}\n\nIngredientes:\n  - {ingredientes}\n\nTOTAL: ${PedidoSeleccionado.ObtenerPrecioTotal():N0}";
        }

        public bool TienePorcion(TipoPorcion tipoPorcion)
        {
            if (PedidoSeleccionado == null) return false;
            return PedidoSeleccionado.ObtenerDescripcionCompleta().Contains("+ " + tipoPorcion.ToString());
        }

        public List<Combo> ObtenerCombosDisponibles()
        {
            return _comboDAL.CargarCombos();
        }

        public Combo ObtenerComboPorTipo(TipoCombo tipo)
        {
            return _comboDAL.ObtenerComboPorTipo(tipo);
        }

        public void SeleccionarPedido(int indice)
        {
            if (indice >= 0 && indice < PedidosActivos.Count)
            {
                PedidoSeleccionado = PedidosActivos[indice];
            }
        }

        public void EliminarPedidoActivo(int indice)
        {
            if (indice >= 0 && indice < PedidosActivos.Count)
            {
                var pedidoAEliminar = PedidosActivos[indice];
                PedidosActivos.RemoveAt(indice);
                
                if (PedidoSeleccionado == pedidoAEliminar)
                {
                    PedidoSeleccionado = PedidosActivos.FirstOrDefault();
                }
            }
        }

        public void FinalizarTodosPedidos()
        {
            var pedidosParaGuardar = new List<Pedido>();
            
            foreach (var pedidoBuilder in PedidosActivos.ToList())
            {
                var pedidoParaGuardar = pedidoBuilder.ConvertirAPedido();
                pedidoParaGuardar.CalcularTotal();
                pedidoParaGuardar.Id = _pedidoDAL.GuardarPedido(pedidoParaGuardar);
                pedidosParaGuardar.Add(pedidoParaGuardar);
            }
            
            HistorialPedidos.AddRange(pedidosParaGuardar);
            PedidosActivos.Clear();
            PedidoSeleccionado = null;
        }

        public int ObtenerCantidadPedidosActivos()
        {
            return PedidosActivos.Count;
        }

        public string ObtenerResumenPedido(int indice)
        {
            if (indice >= 0 && indice < PedidosActivos.Count)
            {
                var pedido = PedidosActivos[indice];
                return $"{pedido.ObtenerDescripcionCompleta()} - ${pedido.ObtenerPrecioTotal():N0}";
            }
            return string.Empty;
        }

        public decimal ObtenerTotalTodosPedidos()
        {
            return PedidosActivos.Sum(p => p.ObtenerPrecioTotal());
        }
    }
}