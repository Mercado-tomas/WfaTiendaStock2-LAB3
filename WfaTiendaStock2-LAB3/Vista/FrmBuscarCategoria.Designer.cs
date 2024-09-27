namespace WfaTiendaStock2_LAB3.Interfaces
{
    partial class FrmBuscarCategoria
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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Computadoras");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Accesorios");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Periféricos");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Categoría ", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "Computadoras";
            treeNode5.Text = "Computadoras";
            treeNode6.Name = "Accesorios";
            treeNode6.Text = "Accesorios";
            treeNode7.Name = "Perifericos";
            treeNode7.Text = "Periféricos";
            treeNode8.Name = "Categoria";
            treeNode8.Text = "Categoría ";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(154, 268);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(180, 12);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(608, 268);
            this.dgvProductos.TabIndex = 3;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(642, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmBuscarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmBuscarCategoria";
            this.Text = "Buscar por Categoría ";
            this.Load += new System.EventHandler(this.FrmBuscarCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button button1;
    }
}