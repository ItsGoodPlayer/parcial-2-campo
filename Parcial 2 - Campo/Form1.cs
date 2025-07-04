using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace Parcial_2___Campo
{
    public partial class Form1 : Form
    {
        private SistemaPedidos sistema;

        public Form1()
        {
            InitializeComponent();
            InicializarSistema();
        }

        private void InicializarSistema()
        {
            sistema = SistemaPedidos.ObtenerInstancia();
            CargarCombos();
            CargarHistorial();
            ActualizarEstado();
        }

        private void CargarCombos()
        {
            cmbCombos.Items.Clear();
            foreach (var combo in sistema.ObtenerCombosDisponibles())
            {
                cmbCombos.Items.Add(combo);
            }
            cmbCombos.DisplayMember = "Nombre";
        }


        private void CargarHistorial()
        {
            lstHistorial.Items.Clear();
            foreach (var pedido in sistema.HistorialPedidos)
            {
                lstHistorial.Items.Add(pedido);
            }
            lstHistorial.DisplayMember = "ToString";
        }

        private void ActualizarEstado()
        {
            bool hayPedidoSeleccionado = sistema.PedidoSeleccionado != null;
            bool hayPedidosActivos = sistema.ObtenerCantidadPedidosActivos() > 0;
            int cantidadPedidos = sistema.ObtenerCantidadPedidosActivos();
            
            cmbCombos.Enabled = true;
            btnNuevoPedido.Enabled = cmbCombos.SelectedItem != null;
            
            // Habilitar botones de porciones solo si hay pedido seleccionado
            btnAgregarQueso.Enabled = hayPedidoSeleccionado;
            btnAgregarCarne.Enabled = hayPedidoSeleccionado;
            btnAgregarTomate.Enabled = hayPedidoSeleccionado;
            btnAgregarPapas.Enabled = hayPedidoSeleccionado;
            
            // Botón inteligente que se adapta al contexto
            btnFinalizarPedido.Enabled = hayPedidosActivos;
            if (cantidadPedidos > 1)
            {
                btnFinalizarPedido.Text = $"Finalizar Todos ({cantidadPedidos})";
            }
            else if (cantidadPedidos == 1)
            {
                btnFinalizarPedido.Text = "Finalizar";
            }
            else
            {
                btnFinalizarPedido.Text = "Finalizar";
            }

            if (hayPedidoSeleccionado)
            {
                ActualizarResumenPedido();
            }
            else
            {
                txtResumen.Text = hayPedidosActivos ? "Seleccione un pedido de la lista para editarlo." : "No hay pedidos activos. Seleccione un combo y presione 'Nuevo Pedido'.";
                lblTotal.Text = "Total: $0";
            }
            
            ActualizarListaPedidosActivos();
        }

        private void ActualizarResumenPedido()
        {
            if (sistema.PedidoSeleccionado != null)
            {
                txtResumen.Text = sistema.ObtenerResumenPedidoActual();
                lblTotal.Text = $"Total: ${sistema.ObtenerTotalPedidoActual():N0}";
            }
        }


        private void cmbCombos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            if (cmbCombos.SelectedItem is Combo comboSeleccionado)
            {
                sistema.CrearNuevoPedido(comboSeleccionado);
                ActualizarEstado();
            }
        }


        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            int cantidadPedidos = sistema.ObtenerCantidadPedidosActivos();
            if (cantidadPedidos == 0) return;
            
            string mensaje;
            if (cantidadPedidos > 1)
            {
                var totalTodos = sistema.ObtenerTotalTodosPedidos();
                mensaje = $"¿Confirma finalizar todos los {cantidadPedidos} pedidos?\nTotal: ${totalTodos:N0}";
            }
            else
            {
                mensaje = "¿Confirma finalizar este pedido?";
            }
            
            var resultado = MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (cantidadPedidos > 1)
                {
                    sistema.FinalizarTodosPedidos();
                }
                else
                {
                    sistema.FinalizarPedido();
                }
                
                CargarHistorial();
                LimpiarSelecciones();
                ActualizarEstado();
                
                string mensajeExito = cantidadPedidos > 1 
                    ? "Todos los pedidos finalizados correctamente." 
                    : "Pedido finalizado correctamente.";
                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarSelecciones()
        {
            cmbCombos.SelectedIndex = -1;
        }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHistorial.SelectedItem is Pedido pedidoSeleccionado)
            {
                // Recrear la estructura de decorators para mostrar descripción completa
                var pedidoReconstruido = sistema.ReconstruirPedidoDesdeBaseDatos(pedidoSeleccionado);
                string descripcionCompleta = pedidoReconstruido.ObtenerDescripcion();
                
                // Mostrar tanto la descripción con decorators como el resumen original
                txtResumenHistorial.Text = $"Descripción completa:\n{descripcionCompleta}\n\n{pedidoSeleccionado.ObtenerResumen()}";
            }
        }

        private void ActualizarListaPedidosActivos()
        {
            lstPedidosActivos.Items.Clear();
            
            for (int i = 0; i < sistema.ObtenerCantidadPedidosActivos(); i++)
            {
                var resumen = sistema.ObtenerResumenPedido(i);
                lstPedidosActivos.Items.Add($"#{i + 1}: {resumen}");
            }
            
            lblTotalGeneral.Text = $"Total Gral.: ${sistema.ObtenerTotalTodosPedidos():N0}";
            
            bool hayPedidos = sistema.ObtenerCantidadPedidosActivos() > 0;
            btnEliminarPedido.Enabled = hayPedidos && lstPedidosActivos.SelectedIndex >= 0;
        }


        private void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            if (lstPedidosActivos.SelectedIndex >= 0)
            {
                var resultado = MessageBox.Show("¿Está seguro de eliminar este pedido?", 
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    sistema.EliminarPedidoActivo(lstPedidosActivos.SelectedIndex);
                    ActualizarEstado();
                }
            }
        }

        private void lstPedidosActivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPedidosActivos.SelectedIndex >= 0)
            {
                sistema.SeleccionarPedido(lstPedidosActivos.SelectedIndex);
                ActualizarEstado();
            }
            
            btnEliminarPedido.Enabled = lstPedidosActivos.SelectedIndex >= 0;
        }

        private void btnAgregarQueso_Click(object sender, EventArgs e)
        {
            if (sistema.PedidoSeleccionado != null)
            {
                sistema.AgregarPorcionAdicional(TipoPorcion.Queso);
                ActualizarResumenPedido();
                ActualizarListaPedidosActivos();
            }
        }

        private void btnAgregarCarne_Click(object sender, EventArgs e)
        {
            if (sistema.PedidoSeleccionado != null)
            {
                sistema.AgregarPorcionAdicional(TipoPorcion.Carne);
                ActualizarResumenPedido();
                ActualizarListaPedidosActivos();
            }
        }

        private void btnAgregarTomate_Click(object sender, EventArgs e)
        {
            if (sistema.PedidoSeleccionado != null)
            {
                sistema.AgregarPorcionAdicional(TipoPorcion.Tomate);
                ActualizarResumenPedido();
                ActualizarListaPedidosActivos();
            }
        }

        private void btnAgregarPapas_Click(object sender, EventArgs e)
        {
            if (sistema.PedidoSeleccionado != null)
            {
                sistema.AgregarPorcionAdicional(TipoPorcion.Papas);
                ActualizarResumenPedido();
                ActualizarListaPedidosActivos();
            }
        }
    }
}
