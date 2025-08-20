namespace Trabalho_1___C_
{
    partial class FormGraficoProduto
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graProdutos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.graProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // graProdutos
            // 
            chartArea1.Name = "ChartArea1";
            this.graProdutos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graProdutos.Legends.Add(legend1);
            this.graProdutos.Location = new System.Drawing.Point(12, 9);
            this.graProdutos.Name = "graProdutos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graProdutos.Series.Add(series1);
            this.graProdutos.Size = new System.Drawing.Size(768, 523);
            this.graProdutos.TabIndex = 0;
            this.graProdutos.Text = "chart1";
            // 
            // FormGraficoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 544);
            this.Controls.Add(this.graProdutos);
            this.Name = "FormGraficoProduto";
            this.Text = "Gráfico";
            this.Load += new System.EventHandler(this.FormGraficoProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graProdutos;
    }
}