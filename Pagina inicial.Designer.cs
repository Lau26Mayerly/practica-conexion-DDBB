namespace practica_conexion_DDBB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ENCRIPTAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(677, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIENVENIDO A INSTAR_LC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "INGRESA AQUI";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(474, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 31);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(474, 291);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(157, 31);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "USUARIO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(366, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "CLAVE";
            // 
            // ENCRIPTAR
            // 
            this.ENCRIPTAR.BackColor = System.Drawing.Color.YellowGreen;
            this.ENCRIPTAR.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENCRIPTAR.Location = new System.Drawing.Point(441, 356);
            this.ENCRIPTAR.Name = "ENCRIPTAR";
            this.ENCRIPTAR.Size = new System.Drawing.Size(135, 38);
            this.ENCRIPTAR.TabIndex = 6;
            this.ENCRIPTAR.Text = "CONECTAR";
            this.ENCRIPTAR.UseVisualStyleBackColor = false;
            this.ENCRIPTAR.Click += new System.EventHandler(this.ENCRIPTAR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(994, 523);
            this.Controls.Add(this.ENCRIPTAR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ENCRIPTAR;
    }
}

