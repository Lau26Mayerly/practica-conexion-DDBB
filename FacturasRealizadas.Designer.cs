namespace practica_conexion_DDBB
{
    partial class FacturasRealizadas
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
            this.DGVfacturas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVfacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVfacturas
            // 
            this.DGVfacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVfacturas.Location = new System.Drawing.Point(25, 113);
            this.DGVfacturas.Name = "DGVfacturas";
            this.DGVfacturas.Size = new System.Drawing.Size(737, 293);
            this.DGVfacturas.TabIndex = 0;
            this.DGVfacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVfacturas_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(288, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 60);
            this.label6.TabIndex = 27;
            this.label6.Text = "Facturas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wingdings 3", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 54);
            this.label2.TabIndex = 28;
            this.label2.Text = "b";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FacturasRealizadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DGVfacturas);
            this.Name = "FacturasRealizadas";
            this.Text = "FacturasRealizadas";
            this.Load += new System.EventHandler(this.FacturasRealizadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVfacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVfacturas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}