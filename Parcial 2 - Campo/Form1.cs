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
        private List<PorcionAdicional> porcionesDisponibles;

        public Form1()
        {
            InitializeComponent();
            InicializarSistema();
        }

        private void InicializarSistema()
        {
            sistema = SistemaPedidos.ObtenerInstancia();
            porcionesDisponibles = sistema.ObtenerPorcionesDisponibles();
            CargarCombos();
            CargarPorcionesAdicionales();
            CargarHistorial();
            ActualizarEstado();
        }

        private void CargarCombos()
        {
            cmbCombos.Items.Clear();
            cmbCombos.Items.Add(new ComboBasico());
            cmbCombos.Items.Add(new ComboFamiliar());
            cmbCombos.Items.Add(new ComboEspecial());
            cmbCombos.DisplayMember = "Nombre";
        }

        private void CargarPorcionesAdicionales()
        {
            chkPorciones.Items.Clear();
            foreach (var porcion in porcionesDisponibles)
            {
                chkPorciones.Items.Add(porcion, false);
            }
            chkPorciones.DisplayMember = "ToString";
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
            bool hayPedidoActual = sistema.PedidoActual != null;
            
            cmbCombos.Enabled = !hayPedidoActual;
            btnNuevoPedido.Enabled = !hayPedidoActual && cmbCombos.SelectedItem != null;
            chkPorciones.Enabled = hayPedidoActual;
            btnFinalizarPedido.Enabled = hayPedidoActual;

            if (hayPedidoActual)
            {
                ActualizarResumenPedido();
                ActualizarCheckboxesPorciones();
            }
            else
            {
                txtResumen.Text = "No hay pedido actual. Seleccione un combo y presione 'Nuevo Pedido'.";
                lblTotal.Text = "Total: $0";
                LimpiarCheckboxes();
            }
        }

        private void ActualizarResumenPedido()
        {
            if (sistema.PedidoActual != null)
            {
                txtResumen.Text = sistema.ObtenerResumenPedidoActual();
                lblTotal.Text = $"Total: ${sistema.ObtenerTotalPedidoActual():N0}";
            }
        }

        private void ActualizarCheckboxesPorciones()
        {
            if (sistema.PedidoActual == null) return;

            for (int i = 0; i < chkPorciones.Items.Count; i++)
            {
                var porcion = porcionesDisponibles[i];
                bool tieneEsta = sistema.TienePorcion(porcion.Tipo);
                chkPorciones.SetItemChecked(i, tieneEsta);
            }
        }

        private void LimpiarCheckboxes()
        {
            for (int i = 0; i < chkPorciones.Items.Count; i++)
            {
                chkPorciones.SetItemChecked(i, false);
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
                sistema.CrearNuevoPedido(comboSeleccionado.Tipo);
                ActualizarEstado();
            }
        }

        private void chkPorciones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (sistema.PedidoActual == null) return;

            var porcion = porcionesDisponibles[e.Index];
            
            BeginInvoke(new Action(() =>
            {
                if (e.NewValue == CheckState.Checked)
                {
                    sistema.AgregarPorcionAdicional(porcion.Tipo);
                }
                else
                {
                    sistema.QuitarPorcionAdicional(porcion.Tipo);
                }
                ActualizarResumenPedido();
            }));
        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (sistema.PedidoActual != null)
            {
                sistema.FinalizarPedido();
                CargarHistorial();
                LimpiarSelecciones();
                ActualizarEstado();
                MessageBox.Show("Pedido finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarSelecciones()
        {
            cmbCombos.SelectedIndex = -1;
            LimpiarCheckboxes();
        }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHistorial.SelectedItem is Pedido pedidoSeleccionado)
            {
                txtResumenHistorial.Text = pedidoSeleccionado.ObtenerResumen();
            }
        }
    }
}
