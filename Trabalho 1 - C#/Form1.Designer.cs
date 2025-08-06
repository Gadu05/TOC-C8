namespace Trabalho_1___C_
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.dtpDataValidadeProduto = new System.Windows.Forms.DateTimePicker();
            this.txtPrecoProduto = new System.Windows.Forms.TextBox();
            this.txtTaxaLucroProduto = new System.Windows.Forms.TextBox();
            this.lblCodigoProduto = new System.Windows.Forms.Label();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.lblDataValidadeProduto = new System.Windows.Forms.Label();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.lblTaxaLucroProduto = new System.Windows.Forms.Label();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnListarProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.btnGraficoProduto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.AccessibleName = "";
            this.txtCodigoProduto.Location = new System.Drawing.Point(23, 41);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoProduto.TabIndex = 0;
            this.txtCodigoProduto.Leave += new System.EventHandler(this.txtCodigoProduto_Leave);
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.AccessibleName = "";
            this.txtDescricaoProduto.Location = new System.Drawing.Point(23, 94);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtDescricaoProduto.TabIndex = 1;
            this.txtDescricaoProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescricaoProduto_KeyUp);
            // 
            // dtpDataValidadeProduto
            // 
            this.dtpDataValidadeProduto.AccessibleName = "";
            this.dtpDataValidadeProduto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataValidadeProduto.Location = new System.Drawing.Point(23, 145);
            this.dtpDataValidadeProduto.Name = "dtpDataValidadeProduto";
            this.dtpDataValidadeProduto.Size = new System.Drawing.Size(200, 20);
            this.dtpDataValidadeProduto.TabIndex = 2;
            // 
            // txtPrecoProduto
            // 
            this.txtPrecoProduto.AccessibleName = "";
            this.txtPrecoProduto.Location = new System.Drawing.Point(23, 192);
            this.txtPrecoProduto.Name = "txtPrecoProduto";
            this.txtPrecoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtPrecoProduto.TabIndex = 3;
            // 
            // txtTaxaLucroProduto
            // 
            this.txtTaxaLucroProduto.AccessibleName = "";
            this.txtTaxaLucroProduto.Location = new System.Drawing.Point(23, 245);
            this.txtTaxaLucroProduto.Name = "txtTaxaLucroProduto";
            this.txtTaxaLucroProduto.Size = new System.Drawing.Size(100, 20);
            this.txtTaxaLucroProduto.TabIndex = 4;
            // 
            // lblCodigoProduto
            // 
            this.lblCodigoProduto.AccessibleName = "";
            this.lblCodigoProduto.AutoSize = true;
            this.lblCodigoProduto.Location = new System.Drawing.Point(23, 22);
            this.lblCodigoProduto.Name = "lblCodigoProduto";
            this.lblCodigoProduto.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoProduto.TabIndex = 5;
            this.lblCodigoProduto.Text = "Código";
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AccessibleName = "";
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Location = new System.Drawing.Point(20, 78);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(55, 13);
            this.lblDescricaoProduto.TabIndex = 6;
            this.lblDescricaoProduto.Text = "Descrição";
            // 
            // lblDataValidadeProduto
            // 
            this.lblDataValidadeProduto.AccessibleName = "";
            this.lblDataValidadeProduto.AutoSize = true;
            this.lblDataValidadeProduto.Location = new System.Drawing.Point(23, 129);
            this.lblDataValidadeProduto.Name = "lblDataValidadeProduto";
            this.lblDataValidadeProduto.Size = new System.Drawing.Size(89, 13);
            this.lblDataValidadeProduto.TabIndex = 7;
            this.lblDataValidadeProduto.Text = "Data de Validade";
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.AccessibleName = "";
            this.lblPrecoProduto.AutoSize = true;
            this.lblPrecoProduto.Location = new System.Drawing.Point(23, 172);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(58, 13);
            this.lblPrecoProduto.TabIndex = 8;
            this.lblPrecoProduto.Text = "Preço (R$)";
            // 
            // lblTaxaLucroProduto
            // 
            this.lblTaxaLucroProduto.AccessibleName = "";
            this.lblTaxaLucroProduto.AutoSize = true;
            this.lblTaxaLucroProduto.Location = new System.Drawing.Point(23, 218);
            this.lblTaxaLucroProduto.Name = "lblTaxaLucroProduto";
            this.lblTaxaLucroProduto.Size = new System.Drawing.Size(76, 13);
            this.lblTaxaLucroProduto.TabIndex = 9;
            this.lblTaxaLucroProduto.Text = "Taxa de Lucro";
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.AccessibleName = "";
            this.btnAdicionarProduto.Location = new System.Drawing.Point(29, 276);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarProduto.TabIndex = 10;
            this.btnAdicionarProduto.Text = "ADICIONAR";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // btnListarProduto
            // 
            this.btnListarProduto.AccessibleName = "";
            this.btnListarProduto.Location = new System.Drawing.Point(137, 276);
            this.btnListarProduto.Name = "btnListarProduto";
            this.btnListarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnListarProduto.TabIndex = 11;
            this.btnListarProduto.Text = "LISTAR";
            this.btnListarProduto.UseVisualStyleBackColor = true;
            this.btnListarProduto.Click += new System.EventHandler(this.btnListarProduto_Click);
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.AccessibleName = "";
            this.btnEditarProduto.Location = new System.Drawing.Point(29, 326);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnEditarProduto.TabIndex = 12;
            this.btnEditarProduto.Text = "EDITAR";
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.AccessibleName = "";
            this.btnRemoverProduto.Location = new System.Drawing.Point(137, 326);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverProduto.TabIndex = 13;
            this.btnRemoverProduto.Text = "REMOVER";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AccessibleName = "";
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(300, 35);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(547, 356);
            this.dgvProdutos.TabIndex = 15;
            this.dgvProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);
            // 
            // btnGraficoProduto
            // 
            this.btnGraficoProduto.AccessibleName = "";
            this.btnGraficoProduto.Location = new System.Drawing.Point(83, 387);
            this.btnGraficoProduto.Name = "btnGraficoProduto";
            this.btnGraficoProduto.Size = new System.Drawing.Size(75, 23);
            this.btnGraficoProduto.TabIndex = 16;
            this.btnGraficoProduto.Text = "GRÁFICO";
            this.btnGraficoProduto.UseVisualStyleBackColor = true;
            this.btnGraficoProduto.Click += new System.EventHandler(this.btnGraficoProduto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 450);
            this.Controls.Add(this.btnGraficoProduto);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.btnEditarProduto);
            this.Controls.Add(this.btnListarProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.lblTaxaLucroProduto);
            this.Controls.Add(this.lblPrecoProduto);
            this.Controls.Add(this.lblDataValidadeProduto);
            this.Controls.Add(this.lblDescricaoProduto);
            this.Controls.Add(this.lblCodigoProduto);
            this.Controls.Add(this.txtTaxaLucroProduto);
            this.Controls.Add(this.txtPrecoProduto);
            this.Controls.Add(this.dtpDataValidadeProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.txtCodigoProduto);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.DateTimePicker dtpDataValidadeProduto;
        private System.Windows.Forms.TextBox txtPrecoProduto;
        private System.Windows.Forms.TextBox txtTaxaLucroProduto;
        private System.Windows.Forms.Label lblCodigoProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.Label lblDataValidadeProduto;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.Label lblTaxaLucroProduto;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnListarProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Button btnGraficoProduto;
    }
}

