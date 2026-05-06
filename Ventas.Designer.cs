namespace practica_conexion_DDBB
{
    partial class Ventas
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
            this.btnFINALIZAR = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTCODIGO = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_NOMBRE_P = new System.Windows.Forms.MaskedTextBox();
            this.DGVventas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTCANTIDAD = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTCLIENTE = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TXTPRECIO_P = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TXTSTOCK = new System.Windows.Forms.MaskedTextBox();
            this.TXT_NIT_CLIENTE = new System.Windows.Forms.TextBox();
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.TXTCATEGORIA = new System.Windows.Forms.MaskedTextBox();
            this.BTNventasRecient = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVventas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFINALIZAR
            // 
            this.btnFINALIZAR.BackColor = System.Drawing.Color.YellowGreen;
            this.btnFINALIZAR.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFINALIZAR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFINALIZAR.Location = new System.Drawing.Point(729, 316);
            this.btnFINALIZAR.Name = "btnFINALIZAR";
            this.btnFINALIZAR.Size = new System.Drawing.Size(159, 61);
            this.btnFINALIZAR.TabIndex = 4;
            this.btnFINALIZAR.TabStop = false;
            this.btnFINALIZAR.Text = "Comprar";
            this.btnFINALIZAR.UseVisualStyleBackColor = false;
            this.btnFINALIZAR.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(131, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 42);
            this.button1.TabIndex = 23;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BTNAGREGAR_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Categoría";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Código";
            // 
            // TXTCODIGO
            // 
            this.TXTCODIGO.Location = new System.Drawing.Point(153, 249);
            this.TXTCODIGO.Name = "TXTCODIGO";
            this.TXTCODIGO.Size = new System.Drawing.Size(204, 20);
            this.TXTCODIGO.TabIndex = 18;
            this.TXTCODIGO.TextChanged += new System.EventHandler(this.TXTCODIGO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Busqueda";
            // 
            // TXT_NOMBRE_P
            // 
            this.TXT_NOMBRE_P.Location = new System.Drawing.Point(153, 276);
            this.TXT_NOMBRE_P.Name = "TXT_NOMBRE_P";
            this.TXT_NOMBRE_P.Size = new System.Drawing.Size(204, 20);
            this.TXT_NOMBRE_P.TabIndex = 15;
            this.TXT_NOMBRE_P.TextChanged += new System.EventHandler(this.TXT_NOMBRE_P_TextChanged);
            // 
            // DGVventas
            // 
            this.DGVventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVventas.Location = new System.Drawing.Point(497, 55);
            this.DGVventas.Name = "DGVventas";
            this.DGVventas.Size = new System.Drawing.Size(584, 252);
            this.DGVventas.TabIndex = 14;
            this.DGVventas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(361, -5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 60);
            this.label6.TabIndex = 26;
            this.label6.Text = "Ventas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Cantidad";
            // 
            // TXTCANTIDAD
            // 
            this.TXTCANTIDAD.Location = new System.Drawing.Point(153, 328);
            this.TXTCANTIDAD.Name = "TXTCANTIDAD";
            this.TXTCANTIDAD.Size = new System.Drawing.Size(204, 20);
            this.TXTCANTIDAD.TabIndex = 28;
            this.TXTCANTIDAD.Leave += new System.EventHandler(this.TXTCANTIDAD_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(97, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 26);
            this.label7.TabIndex = 29;
            this.label7.Text = "Cliente";
            // 
            // TXTCLIENTE
            // 
            this.TXTCLIENTE.Location = new System.Drawing.Point(153, 147);
            this.TXTCLIENTE.Name = "TXTCLIENTE";
            this.TXTCLIENTE.Size = new System.Drawing.Size(204, 20);
            this.TXTCLIENTE.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 26);
            this.label8.TabIndex = 31;
            this.label8.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 26);
            this.label9.TabIndex = 32;
            this.label9.Text = "Nit-CC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 23);
            this.label10.TabIndex = 35;
            this.label10.Text = "precio";
            // 
            // TXTPRECIO_P
            // 
            this.TXTPRECIO_P.Location = new System.Drawing.Point(153, 354);
            this.TXTPRECIO_P.Name = "TXTPRECIO_P";
            this.TXTPRECIO_P.Size = new System.Drawing.Size(204, 20);
            this.TXTPRECIO_P.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 374);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 23);
            this.label11.TabIndex = 37;
            this.label11.Text = "Existencias";
            // 
            // TXTSTOCK
            // 
            this.TXTSTOCK.Location = new System.Drawing.Point(153, 380);
            this.TXTSTOCK.Name = "TXTSTOCK";
            this.TXTSTOCK.Size = new System.Drawing.Size(204, 20);
            this.TXTSTOCK.TabIndex = 36;
            // 
            // TXT_NIT_CLIENTE
            // 
            this.TXT_NIT_CLIENTE.Location = new System.Drawing.Point(153, 121);
            this.TXT_NIT_CLIENTE.Name = "TXT_NIT_CLIENTE";
            this.TXT_NIT_CLIENTE.Size = new System.Drawing.Size(204, 20);
            this.TXT_NIT_CLIENTE.TabIndex = 38;
            this.TXT_NIT_CLIENTE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_NIT_CLIENTE_KeyDown);
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.Location = new System.Drawing.Point(371, 232);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(120, 95);
            this.listBoxProductos.TabIndex = 39;
            this.listBoxProductos.Click += new System.EventHandler(this.listBoxProductos_Click);
            this.listBoxProductos.SelectedIndexChanged += new System.EventHandler(this.listBoxProductos_SelectedIndexChanged);
            this.listBoxProductos.DoubleClick += new System.EventHandler(this.listBoxProductos_DoubleClick);
            // 
            // TXTCATEGORIA
            // 
            this.TXTCATEGORIA.Location = new System.Drawing.Point(153, 302);
            this.TXTCATEGORIA.Name = "TXTCATEGORIA";
            this.TXTCATEGORIA.Size = new System.Drawing.Size(204, 20);
            this.TXTCATEGORIA.TabIndex = 40;
            this.TXTCATEGORIA.TextChanged += new System.EventHandler(this.TXTCATEGORIA_TextChanged);
            // 
            // BTNventasRecient
            // 
            this.BTNventasRecient.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNventasRecient.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNventasRecient.Location = new System.Drawing.Point(729, 455);
            this.BTNventasRecient.Name = "BTNventasRecient";
            this.BTNventasRecient.Size = new System.Drawing.Size(159, 57);
            this.BTNventasRecient.TabIndex = 41;
            this.BTNventasRecient.Text = "Ventas recientes";
            this.BTNventasRecient.UseVisualStyleBackColor = false;
            this.BTNventasRecient.Click += new System.EventHandler(this.BTNventasRecient_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Wingdings 3", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label12.Location = new System.Drawing.Point(12, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 54);
            this.label12.TabIndex = 42;
            this.label12.Text = "b";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1093, 560);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BTNventasRecient);
            this.Controls.Add(this.TXTCATEGORIA);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.TXT_NIT_CLIENTE);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TXTSTOCK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TXTPRECIO_P);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TXTCLIENTE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXTCANTIDAD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTCODIGO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_NOMBRE_P);
            this.Controls.Add(this.DGVventas);
            this.Controls.Add(this.btnFINALIZAR);
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVventas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFINALIZAR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TXTCODIGO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox TXT_NOMBRE_P;
        private System.Windows.Forms.DataGridView DGVventas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TXTCANTIDAD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TXTCLIENTE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox TXTPRECIO_P;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox TXTSTOCK;
        private System.Windows.Forms.TextBox TXT_NIT_CLIENTE;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.MaskedTextBox TXTCATEGORIA;
        private System.Windows.Forms.Button BTNventasRecient;
        private System.Windows.Forms.Label label12;
    }
}