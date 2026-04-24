namespace practica_conexion_DDBB
{
    partial class REGISTRAR_CLIENTE
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
            this.BTNGUARDAR = new System.Windows.Forms.Button();
            this.CMB_Tipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_CC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_Nombre = new System.Windows.Forms.TextBox();
            this.TXT_Tel = new System.Windows.Forms.TextBox();
            this.txt_Dir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTNGUARDAR
            // 
            this.BTNGUARDAR.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNGUARDAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNGUARDAR.Location = new System.Drawing.Point(321, 346);
            this.BTNGUARDAR.Name = "BTNGUARDAR";
            this.BTNGUARDAR.Size = new System.Drawing.Size(128, 43);
            this.BTNGUARDAR.TabIndex = 19;
            this.BTNGUARDAR.Text = "Guardar Cambios";
            this.BTNGUARDAR.UseVisualStyleBackColor = false;
            this.BTNGUARDAR.Click += new System.EventHandler(this.BTNGUARDAR_Click);
            // 
            // CMB_Tipo
            // 
            this.CMB_Tipo.FormattingEnabled = true;
            this.CMB_Tipo.Items.AddRange(new object[] {
            "Persona Juridica",
            "Persona Natural"});
            this.CMB_Tipo.Location = new System.Drawing.Point(321, 133);
            this.CMB_Tipo.Name = "CMB_Tipo";
            this.CMB_Tipo.Size = new System.Drawing.Size(180, 21);
            this.CMB_Tipo.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tipo de cliente";
            // 
            // TXT_CC
            // 
            this.TXT_CC.Location = new System.Drawing.Point(321, 172);
            this.TXT_CC.Name = "TXT_CC";
            this.TXT_CC.Size = new System.Drawing.Size(180, 20);
            this.TXT_CC.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "NIT - CC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nombre";
            // 
            // TXT_Nombre
            // 
            this.TXT_Nombre.Location = new System.Drawing.Point(321, 213);
            this.TXT_Nombre.Name = "TXT_Nombre";
            this.TXT_Nombre.Size = new System.Drawing.Size(180, 20);
            this.TXT_Nombre.TabIndex = 25;
            // 
            // TXT_Tel
            // 
            this.TXT_Tel.Location = new System.Drawing.Point(321, 292);
            this.TXT_Tel.Name = "TXT_Tel";
            this.TXT_Tel.Size = new System.Drawing.Size(180, 20);
            this.TXT_Tel.TabIndex = 27;
            // 
            // txt_Dir
            // 
            this.txt_Dir.Location = new System.Drawing.Point(321, 251);
            this.txt_Dir.Name = "txt_Dir";
            this.txt_Dir.Size = new System.Drawing.Size(180, 20);
            this.txt_Dir.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Dirección";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(274, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 30);
            this.label6.TabIndex = 30;
            this.label6.Text = "Cliente Nuevo";
            // 
            // REGISTRAR_CLIENTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXT_Tel);
            this.Controls.Add(this.txt_Dir);
            this.Controls.Add(this.TXT_Nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXT_CC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMB_Tipo);
            this.Controls.Add(this.BTNGUARDAR);
            this.Name = "REGISTRAR_CLIENTE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRAR_CLIENTE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNGUARDAR;
        private System.Windows.Forms.ComboBox CMB_Tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_CC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_Nombre;
        private System.Windows.Forms.TextBox TXT_Tel;
        private System.Windows.Forms.TextBox txt_Dir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}