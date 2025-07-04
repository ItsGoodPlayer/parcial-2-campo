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
            this.btnAgregarQueso = new System.Windows.Forms.Button();
            this.btnAgregarCarne = new System.Windows.Forms.Button();
            this.btnAgregarTomate = new System.Windows.Forms.Button();
            this.btnAgregarPapas = new System.Windows.Forms.Button();
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
            // btnAgregarQueso
            // 
            this.btnAgregarQueso.BackColor = System.Drawing.Color.LightYellow;
            this.btnAgregarQueso.Location = new System.Drawing.Point(15, 95);
            this.btnAgregarQueso.Name = "btnAgregarQueso";
            this.btnAgregarQueso.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarQueso.TabIndex = 4;
            this.btnAgregarQueso.Text = "+ Queso $800";
            this.btnAgregarQueso.UseVisualStyleBackColor = false;
            this.btnAgregarQueso.Click += new System.EventHandler(this.btnAgregarQueso_Click);
            // 
            // btnAgregarCarne
            // 
            this.btnAgregarCarne.BackColor = System.Drawing.Color.LightCoral;
            this.btnAgregarCarne.Location = new System.Drawing.Point(125, 95);
            this.btnAgregarCarne.Name = "btnAgregarCarne";
            this.btnAgregarCarne.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarCarne.TabIndex = 5;
            this.btnAgregarCarne.Text = "+ Carne $2000";
            this.btnAgregarCarne.UseVisualStyleBackColor = false;
            this.btnAgregarCarne.Click += new System.EventHandler(this.btnAgregarCarne_Click);
            // 
            // btnAgregarTomate
            // 
            this.btnAgregarTomate.BackColor = System.Drawing.Color.LightGreen;
            this.btnAgregarTomate.Location = new System.Drawing.Point(15, 135);
            this.btnAgregarTomate.Name = "btnAgregarTomate";
            this.btnAgregarTomate.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarTomate.TabIndex = 6;
            this.btnAgregarTomate.Text = "+ Tomate $500";
            this.btnAgregarTomate.UseVisualStyleBackColor = false;
            this.btnAgregarTomate.Click += new System.EventHandler(this.btnAgregarTomate_Click);
            // 
            // btnAgregarPapas
            // 
            this.btnAgregarPapas.BackColor = System.Drawing.Color.LightSalmon;
            this.btnAgregarPapas.Location = new System.Drawing.Point(125, 135);
            this.btnAgregarPapas.Name = "btnAgregarPapas";
            this.btnAgregarPapas.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarPapas.TabIndex = 7;
            this.btnAgregarPapas.Text = "+ Papas $1000";
            this.btnAgregarPapas.UseVisualStyleBackColor = false;
            this.btnAgregarPapas.Click += new System.EventHandler(this.btnAgregarPapas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pedido Actual";
            // 
            // txtResumen
            // 
            this.txtResumen.Location = new System.Drawing.Point(15, 200);
            this.txtResumen.Multiline = true;
            this.txtResumen.Name = "txtResumen";
            this.txtResumen.ReadOnly = true;
            this.txtResumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumen.Size = new System.Drawing.Size(315, 100);
            this.txtResumen.TabIndex = 9;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(15, 310);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(79, 20);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total: $0";
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinalizarPedido.ForeColor = System.Drawing.Color.Black;
            this.btnFinalizarPedido.Location = new System.Drawing.Point(230, 305);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.Size = new System.Drawing.Size(100, 30);
            this.btnFinalizarPedido.TabIndex = 11;
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
            this.label4.TabIndex = 12;
            this.label4.Text = "Historial de Pedidos";
            // 
            // lstHistorial
            // 
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.Location = new System.Drawing.Point(353, 35);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(300, 134);
            this.lstHistorial.TabIndex = 13;
            this.lstHistorial.SelectedIndexChanged += new System.EventHandler(this.lstHistorial_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(350, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 14;
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
            this.txtResumenHistorial.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(690, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Pedidos Activos";
            // 
            // lstPedidosActivos
            // 
            this.lstPedidosActivos.FormattingEnabled = true;
            this.lstPedidosActivos.Location = new System.Drawing.Point(693, 35);
            this.lstPedidosActivos.Name = "lstPedidosActivos";
            this.lstPedidosActivos.Size = new System.Drawing.Size(280, 134);
            this.lstPedidosActivos.TabIndex = 17;
            this.lstPedidosActivos.SelectedIndexChanged += new System.EventHandler(this.lstPedidosActivos_SelectedIndexChanged);
            // 
            // btnEliminarPedido
            // 
            this.btnEliminarPedido.BackColor = System.Drawing.Color.Red;
            this.btnEliminarPedido.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPedido.Location = new System.Drawing.Point(693, 175);
            this.btnEliminarPedido.Name = "btnEliminarPedido";
            this.btnEliminarPedido.Size = new System.Drawing.Size(120, 25);
            this.btnEliminarPedido.TabIndex = 18;
            this.btnEliminarPedido.Text = "Eliminar Pedido";
            this.btnEliminarPedido.UseVisualStyleBackColor = false;
            this.btnEliminarPedido.Click += new System.EventHandler(this.btnEliminarPedido_Click);
            // 
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalGeneral.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalGeneral.Location = new System.Drawing.Point(693, 215);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(132, 20);
            this.lblTotalGeneral.TabIndex = 19;
            this.lblTotalGeneral.Text = "Total Gral.: $0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 375);
            this.Controls.Add(this.lblTotalGeneral);
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
            this.Controls.Add(this.btnAgregarPapas);
            this.Controls.Add(this.btnAgregarTomate);
            this.Controls.Add(this.btnAgregarCarne);
            this.Controls.Add(this.btnAgregarQueso);
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
        private System.Windows.Forms.Button btnAgregarQueso;
        private System.Windows.Forms.Button btnAgregarCarne;
        private System.Windows.Forms.Button btnAgregarTomate;
        private System.Windows.Forms.Button btnAgregarPapas;
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
        private System.Windows.Forms.Label lblTotalGeneral;
    }
}

