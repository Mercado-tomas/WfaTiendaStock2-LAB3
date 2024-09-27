namespace WfaTiendaStock2_LAB3.Interfaces
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.buscarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPruebaDb = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.salirToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProductoToolStripMenuItem,
            this.modificarProductoToolStripMenuItem,
            this.eliminarProductoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.buscarProductoToolStripMenuItem,
            this.buscarPorCategoríaToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // agregarProductoToolStripMenuItem
            // 
            this.agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            this.agregarProductoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.agregarProductoToolStripMenuItem.Text = "Agregar Producto";
            this.agregarProductoToolStripMenuItem.Click += new System.EventHandler(this.agregarProductoToolStripMenuItem_Click);
            // 
            // modificarProductoToolStripMenuItem
            // 
            this.modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            this.modificarProductoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.modificarProductoToolStripMenuItem.Text = "Modificar Producto";
            this.modificarProductoToolStripMenuItem.Click += new System.EventHandler(this.modificarProductoToolStripMenuItem_Click);
            // 
            // eliminarProductoToolStripMenuItem
            // 
            this.eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            this.eliminarProductoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.eliminarProductoToolStripMenuItem.Text = "Eliminar Producto";
            this.eliminarProductoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProductoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
            // 
            // buscarProductoToolStripMenuItem
            // 
            this.buscarProductoToolStripMenuItem.Name = "buscarProductoToolStripMenuItem";
            this.buscarProductoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.buscarProductoToolStripMenuItem.Text = "Buscar Producto";
            this.buscarProductoToolStripMenuItem.Click += new System.EventHandler(this.buscarProductoToolStripMenuItem_Click);
            // 
            // buscarPorCategoríaToolStripMenuItem
            // 
            this.buscarPorCategoríaToolStripMenuItem.Name = "buscarPorCategoríaToolStripMenuItem";
            this.buscarPorCategoríaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.buscarPorCategoríaToolStripMenuItem.Text = "Buscar por Categoría";
            this.buscarPorCategoríaToolStripMenuItem.Click += new System.EventHandler(this.buscarPorCategoríaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.salirToolStripMenuItem1.Text = "Salir ";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // btnPruebaDb
            // 
            this.btnPruebaDb.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPruebaDb.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPruebaDb.Location = new System.Drawing.Point(942, 583);
            this.btnPruebaDb.Name = "btnPruebaDb";
            this.btnPruebaDb.Size = new System.Drawing.Size(139, 31);
            this.btnPruebaDb.TabIndex = 2;
            this.btnPruebaDb.Text = "Probar Conexión a BD";
            this.btnPruebaDb.UseVisualStyleBackColor = false;
            this.btnPruebaDb.Click += new System.EventHandler(this.btnPruebaDb_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WfaTiendaStock2_LAB3.Properties.Resources.Sistema_de_inventario;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1375, 700);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnPruebaDb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Sistema de Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem buscarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPruebaDb;
        private System.Windows.Forms.ToolStripMenuItem buscarPorCategoríaToolStripMenuItem;
    }
}