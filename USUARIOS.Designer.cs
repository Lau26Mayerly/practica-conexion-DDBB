namespace practica_conexion_DDBB
{
    partial class USUARIOS
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
            this.DGVuser = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID_USER = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.MaskedTextBox();
            this.txtRol = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVuser)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVuser
            // 
            this.DGVuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVuser.Location = new System.Drawing.Point(78, 145);
            this.DGVuser.Name = "DGVuser";
            this.DGVuser.Size = new System.Drawing.Size(1022, 309);
            this.DGVuser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
            this.label1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(738, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(181, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Código";
            // 
            // txtID_USER
            // 
            this.txtID_USER.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_USER.Location = new System.Drawing.Point(186, 96);
            this.txtID_USER.Margin = new System.Windows.Forms.Padding(6);
            this.txtID_USER.Name = "txtID_USER";
            this.txtID_USER.Size = new System.Drawing.Size(272, 33);
            this.txtID_USER.TabIndex = 12;
            this.txtID_USER.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtID_USER_MaskInputRejected);
            this.txtID_USER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_USER_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Busqueda";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(466, 96);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 33);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // txtRol
            // 
            this.txtRol.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRol.Location = new System.Drawing.Point(743, 96);
            this.txtRol.Margin = new System.Windows.Forms.Padding(6);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(240, 33);
            this.txtRol.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(416, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 60);
            this.label6.TabIndex = 16;
            this.label6.Text = "USUARIOS";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.YellowGreen;
            this.button3.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(800, 477);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 50);
            this.button3.TabIndex = 19;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.YellowGreen;
            this.button2.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(500, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 50);
            this.button2.TabIndex = 18;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(240, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 50);
            this.button1.TabIndex = 17;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // USUARIOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1153, 683);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID_USER);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVuser);
            this.Name = "USUARIOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USUARIOS";
            this.Load += new System.EventHandler(this.USUARIOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVuser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtID_USER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtNombre;
        private System.Windows.Forms.MaskedTextBox txtRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}