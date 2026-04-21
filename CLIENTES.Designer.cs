namespace practica_conexion_DDBB
{
    partial class CLIENTES
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
            this.BTNMODIF = new System.Windows.Forms.Button();
            this.BTNELIMINAR = new System.Windows.Forms.Button();
            this.BTNCREAR = new System.Windows.Forms.Button();
            this.BTNBUSCAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(290, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 49);
            this.label1.TabIndex = 5;
            this.label1.Text = "Clientes";
            // 
            // BTNMODIF
            // 
            this.BTNMODIF.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNMODIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNMODIF.Location = new System.Drawing.Point(226, 171);
            this.BTNMODIF.Name = "BTNMODIF";
            this.BTNMODIF.Size = new System.Drawing.Size(136, 54);
            this.BTNMODIF.TabIndex = 16;
            this.BTNMODIF.Text = "Modificar";
            this.BTNMODIF.UseVisualStyleBackColor = false;
            this.BTNMODIF.Click += new System.EventHandler(this.button3_Click);
            // 
            // BTNELIMINAR
            // 
            this.BTNELIMINAR.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNELIMINAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNELIMINAR.Location = new System.Drawing.Point(379, 171);
            this.BTNELIMINAR.Name = "BTNELIMINAR";
            this.BTNELIMINAR.Size = new System.Drawing.Size(136, 54);
            this.BTNELIMINAR.TabIndex = 15;
            this.BTNELIMINAR.Text = "Eliminar";
            this.BTNELIMINAR.UseVisualStyleBackColor = false;
            // 
            // BTNCREAR
            // 
            this.BTNCREAR.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNCREAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCREAR.Location = new System.Drawing.Point(379, 93);
            this.BTNCREAR.Name = "BTNCREAR";
            this.BTNCREAR.Size = new System.Drawing.Size(136, 54);
            this.BTNCREAR.TabIndex = 14;
            this.BTNCREAR.Text = "Crear nuevo";
            this.BTNCREAR.UseVisualStyleBackColor = false;
            this.BTNCREAR.Click += new System.EventHandler(this.BTNCREAR_Click);
            // 
            // BTNBUSCAR
            // 
            this.BTNBUSCAR.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNBUSCAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBUSCAR.Location = new System.Drawing.Point(226, 93);
            this.BTNBUSCAR.Name = "BTNBUSCAR";
            this.BTNBUSCAR.Size = new System.Drawing.Size(136, 54);
            this.BTNBUSCAR.TabIndex = 17;
            this.BTNBUSCAR.Text = "Buscar ";
            this.BTNBUSCAR.UseVisualStyleBackColor = false;
            this.BTNBUSCAR.Click += new System.EventHandler(this.BTNBUSCAR_Click);
            // 
            // CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTNBUSCAR);
            this.Controls.Add(this.BTNMODIF);
            this.Controls.Add(this.BTNELIMINAR);
            this.Controls.Add(this.BTNCREAR);
            this.Controls.Add(this.label1);
            this.Name = "CLIENTES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLIENTES";
            this.Load += new System.EventHandler(this.CLIENTES_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNMODIF;
        private System.Windows.Forms.Button BTNELIMINAR;
        private System.Windows.Forms.Button BTNCREAR;
        private System.Windows.Forms.Button BTNBUSCAR;
    }
}