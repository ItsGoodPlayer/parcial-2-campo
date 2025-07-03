namespace Parcial_2___Campo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCombos = new System.Windows.Forms.ComboBox();
            this.btnNuevoPedido = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPorciones = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResumen = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFinalizarPedido = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResumenHistorial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstPedidosActivos = new System.Windows.Forms.ListBox();
            this.btnEliminarPedido = new System.Windows.Forms.Button();
            this.btnFinalizarTodos = new System.Windows.Forms.Button();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar Combo";
            // 
            // cmbCombos
            // 
            this.cmbCombos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCombos.FormattingEnabled = true;
            this.cmbCombos.Location = new System.Drawing.Point(15, 35);
            this.cmbCombos.Name = "cmbCombos";
            this.cmbCombos.Size = new System.Drawing.Size(200, 21);
            this.cmbCombos.TabIndex = 1;
            this.cmbCombos.SelectedIndexChanged += new System.EventHandler(this.cmbCombos_SelectedIndexChanged);
            // 
            // btnNuevoPedido
            // 
            this.btnNuevoPedido.BackColor = System.Drawing.Color.Green;
            this.btnNuevoPedido.ForeColor = System.Drawing.Color.White;
            this.btnNuevoPedido.Location = new System.Drawing.Point(230, 35);
            this.btnNuevoPedido.Name = "btnNuevoPedido";
            this.btnNuevoPedido.Size = new System.Drawing.Size(100, 25);
            this.btnNuevoPedido.TabIndex = 2;
            this.btnNuevoPedido.Text = "Nuevo Pedido";
            this.btnNuevoPedido.UseVisualStyleBackColor = false;
            this.btnNuevoPedido.Click += new System.EventHandler(this.btnNuevoPedido_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Porciones Adicionales";
            // 
            // chkPorciones
            // 
            this.chkPorciones.FormattingEnabled = true;
            this.chkPorciones.Location = new System.Drawing.Point(15, 95);
            this.chkPorciones.Name = "chkPorciones";
            this.chkPorciones.Size = new System.Drawing.Size(200, 79);
            this.chkPorciones.TabIndex = 4;
            this.chkPorciones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkPorciones_ItemCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pedido Actual";
            // 
            // txtResumen
            // 
            this.txtResumen.Location = new System.Drawing.Point(15, 215);
            this.txtResumen.Multiline = true;
            this.txtResumen.Name = "txtResumen";
            this.txtResumen.ReadOnly = true;
            this.txtResumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumen.Size = new System.Drawing.Size(315, 100);
            this.txtResumen.TabIndex = 6;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(15, 325);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(79, 20);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total: $0";
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinalizarPedido.ForeColor = System.Drawing.Color.Black;
            this.btnFinalizarPedido.Location = new System.Drawing.Point(230, 320);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.Size = new System.Drawing.Size(100, 30);
            this.btnFinalizarPedido.TabIndex = 8;
            this.btnFinalizarPedido.Text = "Finalizar Pedido";
            this.btnFinalizarPedido.UseVisualStyleBackColor = false;
            this.btnFinalizarPedido.Click += new System.EventHandler(this.btnFinalizarPedido_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(350, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Historial de Pedidos";
            // 
            // lstHistorial
            // 
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.Location = new System.Drawing.Point(353, 35);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(300, 134);
            this.lstHistorial.TabIndex = 10;
            this.lstHistorial.SelectedIndexChanged += new System.EventHandler(this.lstHistorial_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(350, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Detalle del Pedido";
            // 
            // txtResumenHistorial
            // 
            this.txtResumenHistorial.Location = new System.Drawing.Point(353, 215);
            this.txtResumenHistorial.Multiline = true;
            this.txtResumenHistorial.Name = "txtResumenHistorial";
            this.txtResumenHistorial.ReadOnly = true;
            this.txtResumenHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumenHistorial.Size = new System.Drawing.Size(300, 135);
            this.txtResumenHistorial.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(690, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pedidos Activos";
            // 
            // lstPedidosActivos
            // 
            this.lstPedidosActivos.FormattingEnabled = true;
            this.lstPedidosActivos.Location = new System.Drawing.Point(693, 35);
            this.lstPedidosActivos.Name = "lstPedidosActivos";
            this.lstPedidosActivos.Size = new System.Drawing.Size(280, 134);
            this.lstPedidosActivos.TabIndex = 14;
            this.lstPedidosActivos.SelectedIndexChanged += new System.EventHandler(this.lstPedidosActivos_SelectedIndexChanged);
            // 
            // btnEliminarPedido
            // 
            this.btnEliminarPedido.BackColor = System.Drawing.Color.Red;
            this.btnEliminarPedido.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPedido.Location = new System.Drawing.Point(693, 175);
            this.btnEliminarPedido.Name = "btnEliminarPedido";
            this.btnEliminarPedido.Size = new System.Drawing.Size(120, 25);
            this.btnEliminarPedido.TabIndex = 15;
            this.btnEliminarPedido.Text = "Eliminar Pedido";
            this.btnEliminarPedido.UseVisualStyleBackColor = false;
            this.btnEliminarPedido.Click += new System.EventHandler(this.btnEliminarPedido_Click);
            // 
            // btnFinalizarTodos
            // 
            this.btnFinalizarTodos.BackColor = System.Drawing.Color.Orange;
            this.btnFinalizarTodos.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarTodos.Location = new System.Drawing.Point(853, 175);
            this.btnFinalizarTodos.Name = "btnFinalizarTodos";
            this.btnFinalizarTodos.Size = new System.Drawing.Size(120, 25);
            this.btnFinalizarTodos.TabIndex = 16;
            this.btnFinalizarTodos.Text = "Finalizar Todos";
            this.btnFinalizarTodos.UseVisualStyleBackColor = false;
            this.btnFinalizarTodos.Click += new System.EventHandler(this.btnFinalizarTodos_Click);
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalGeneral.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalGeneral.Location = new System.Drawing.Point(693, 215);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(132, 20);
            this.lblTotalGeneral.TabIndex = 17;
            this.lblTotalGeneral.Text = "Total Gral.: $0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 375);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.btnFinalizarTodos);
            this.Controls.Add(this.btnEliminarPedido);
            this.Controls.Add(this.lstPedidosActivos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResumenHistorial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHistorial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFinalizarPedido);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtResumen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkPorciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevoPedido);
            this.Controls.Add(this.cmbCombos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Pedidos - Restaurante";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCombos;
        private System.Windows.Forms.Button btnNuevoPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkPorciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResumen;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFinalizarPedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstHistorial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResumenHistorial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstPedidosActivos;
        private System.Windows.Forms.Button btnEliminarPedido;
        private System.Windows.Forms.Button btnFinalizarTodos;
        private System.Windows.Forms.Label lblTotalGeneral;
    }
}

