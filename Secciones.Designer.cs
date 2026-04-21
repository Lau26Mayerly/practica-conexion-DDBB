namespace practica_conexion_DDBB
{
    partial class Secciones
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
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.YellowGreen;
            this.btnVentas.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVentas.Location = new System.Drawing.Point(224, 169);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(159, 61);
            this.btnVentas.TabIndex = 0;
            this.btnVentas.TabStop = false;
            this.btnVentas.Text = "VENTAS";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInventario.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInventario.Location = new System.Drawing.Point(224, 263);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(159, 61);
            this.btnInventario.TabIndex = 1;
            this.btnInventario.TabStop = false;
            this.btnInventario.Text = "INVENTARIO";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.YellowGreen;
            this.btnClientes.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClientes.Location = new System.Drawing.Point(462, 263);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(159, 61);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.TabStop = false;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.YellowGreen;
            this.btnUsuarios.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUsuarios.Location = new System.Drawing.Point(462, 169);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(159, 61);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.TabStop = false;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(236, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 49);
            this.label1.TabIndex = 4;
            this.label1.Text = "¡Ingresa a tu area!";
            // 
            // Secciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnVentas);
            this.ForeColor = System.Drawing.Color.CadetBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Secciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Label label1;
    }
}