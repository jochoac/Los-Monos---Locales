namespace VistaLM
{
    partial class Detalle_EntPed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalle_EntPed));
            this.grid = new System.Windows.Forms.DataGridView();
            this.codigolbl = new System.Windows.Forms.Label();
            this.usuariolbl = new System.Windows.Forms.Label();
            this.fechalbl = new System.Windows.Forms.Label();
            this.locallbl = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.codtxt = new System.Windows.Forms.TextBox();
            this.usutxt = new System.Windows.Forms.TextBox();
            this.detalletxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 140);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(587, 359);
            this.grid.TabIndex = 0;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // codigolbl
            // 
            this.codigolbl.AutoSize = true;
            this.codigolbl.BackColor = System.Drawing.Color.Transparent;
            this.codigolbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigolbl.Location = new System.Drawing.Point(307, 25);
            this.codigolbl.Name = "codigolbl";
            this.codigolbl.Size = new System.Drawing.Size(77, 26);
            this.codigolbl.TabIndex = 1;
            this.codigolbl.Text = "Codigo:";
            // 
            // usuariolbl
            // 
            this.usuariolbl.AutoSize = true;
            this.usuariolbl.BackColor = System.Drawing.Color.Transparent;
            this.usuariolbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuariolbl.Location = new System.Drawing.Point(14, 24);
            this.usuariolbl.Name = "usuariolbl";
            this.usuariolbl.Size = new System.Drawing.Size(88, 26);
            this.usuariolbl.TabIndex = 2;
            this.usuariolbl.Text = "Usuario: ";
            // 
            // fechalbl
            // 
            this.fechalbl.AutoSize = true;
            this.fechalbl.BackColor = System.Drawing.Color.Transparent;
            this.fechalbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechalbl.Location = new System.Drawing.Point(311, 71);
            this.fechalbl.Name = "fechalbl";
            this.fechalbl.Size = new System.Drawing.Size(73, 26);
            this.fechalbl.TabIndex = 3;
            this.fechalbl.Text = "Fecha: ";
            // 
            // locallbl
            // 
            this.locallbl.AutoSize = true;
            this.locallbl.BackColor = System.Drawing.Color.Transparent;
            this.locallbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locallbl.Location = new System.Drawing.Point(35, 71);
            this.locallbl.Name = "locallbl";
            this.locallbl.Size = new System.Drawing.Size(67, 26);
            this.locallbl.TabIndex = 4;
            this.locallbl.Text = "Local: ";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(605, 436);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 63);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // codtxt
            // 
            this.codtxt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codtxt.Location = new System.Drawing.Point(382, 23);
            this.codtxt.Name = "codtxt";
            this.codtxt.ReadOnly = true;
            this.codtxt.Size = new System.Drawing.Size(179, 31);
            this.codtxt.TabIndex = 7;
            // 
            // usutxt
            // 
            this.usutxt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usutxt.Location = new System.Drawing.Point(96, 24);
            this.usutxt.Name = "usutxt";
            this.usutxt.ReadOnly = true;
            this.usutxt.Size = new System.Drawing.Size(169, 31);
            this.usutxt.TabIndex = 8;
            // 
            // detalletxt
            // 
            this.detalletxt.AutoSize = true;
            this.detalletxt.BackColor = System.Drawing.Color.Transparent;
            this.detalletxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalletxt.Location = new System.Drawing.Point(12, 112);
            this.detalletxt.Name = "detalletxt";
            this.detalletxt.Size = new System.Drawing.Size(350, 25);
            this.detalletxt.TabIndex = 9;
            this.detalletxt.Text = "*Doble clic en un ítem para eliminar";
            this.detalletxt.Click += new System.EventHandler(this.detalletxt_Click);
            // 
            // Detalle_EntPed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.detalletxt);
            this.Controls.Add(this.usutxt);
            this.Controls.Add(this.codtxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.locallbl);
            this.Controls.Add(this.fechalbl);
            this.Controls.Add(this.usuariolbl);
            this.Controls.Add(this.codigolbl);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detalle_EntPed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Detalle_EntPed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label codigolbl;
        public System.Windows.Forms.Label usuariolbl;
        public System.Windows.Forms.Label fechalbl;
        public System.Windows.Forms.Label locallbl;
        public System.Windows.Forms.TextBox codtxt;
        public System.Windows.Forms.TextBox usutxt;
        private System.Windows.Forms.Label detalletxt;
    }
}