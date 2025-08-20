using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trabalho_1___C_ {

    public partial class FormGraficoProduto : Form {

        public FormGraficoProduto() {

            InitializeComponent();
            carregarGrafico();

        }

        public void carregarGrafico()
        {
            TOCC8Entities contexto;
            double valor = 0;

            try
            {
                contexto = new TOCC8Entities();
                var lista = from p
                            in contexto.produto
                            orderby p.codigo
                            select new
                            {
                                p.descricao,
                                lucro = p.preco + (p.preco * p.taxalucro / 100),
                                prazoValidade = DbFunctions.DiffDays(DateTime.Now, p.datavalidade)
                            };

                graProdutos.ChartAreas[0].AxisX.Title = " Descrições ";
                graProdutos.ChartAreas[0].AxisY.Title = " Valor ";
                graProdutos.Titles.Add(" Lista de produtos ");

                graProdutos.Series[0].Name = "Lucro";
                graProdutos.Series[0].IsVisibleInLegend = true;

                graProdutos.Series.Add(new Series());
                graProdutos.Series[1].Name = "Validade (em dias)";
                graProdutos.Series[1].ChartType = SeriesChartType.Column;
                graProdutos.Series[1].IsVisibleInLegend = true;

                graProdutos.Series[0].Points.Clear();
                graProdutos.Series[1].Points.Clear();

                graProdutos.Series[0].IsValueShownAsLabel = true;
                graProdutos.Series[1].IsValueShownAsLabel = true;



                foreach (var obj in lista) {

                    if (obj.lucro == null) {
                        valor = 0;
                    }
                    else {
                        valor = Convert.ToDouble(obj.lucro);
                    }
                    graProdutos.Series[0].Points.AddXY((string)obj.descricao, valor);

                    if (obj.prazoValidade == null) {
                        valor = 0;
                    }
                    else {
                        valor = Convert.ToDouble(obj.prazoValidade);
                    }
                    graProdutos.Series[1].Points.AddXY((string)obj.descricao, valor);

                }

            }
            catch (Exception) {
                throw;
            }
        }

        private void FormGraficoProduto_Load(object sender, EventArgs e)
        {

        }


    }
}
