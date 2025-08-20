using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_1___C_ {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e) {

            TOCC8Entities contexto;
            produto obj;

            try {

                obj = new produto();
                obj.descricao = this.txtDescricaoProduto.Text;
                obj.datavalidade = this.dtpDataValidadeProduto.Value;
                obj.preco = Convert.ToDouble(this.txtPrecoProduto.Text);
                obj.taxalucro = Convert.ToDouble(this.txtTaxaLucroProduto.Text);

                verficarDados(obj);

                contexto = new TOCC8Entities();
                contexto.produto.Add(obj);
                contexto.SaveChanges();
                MessageBox.Show("Salvo com sucesso.");
                btnListarProduto.PerformClick();
                limparFormulario();

            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao gravar: " + ex.Message);
            }

        }

        private void btnListarProduto_Click(object sender, EventArgs e) {

            TOCC8Entities contexto;

            try {

                contexto = new TOCC8Entities();
                var lista = from p
                            in contexto.produto
                            orderby p.codigo
                            select new {
                                p.codigo,
                                p.descricao,
                                p.datavalidade,
                                precoFinal = p.preco * (100 + p.taxalucro) / 100,
                                prazoValidade = DbFunctions.DiffDays(DateTime.Now, p.datavalidade)
                            };

                this.dgvProdutos.Columns.Clear();
                this.dgvProdutos.DataSource = lista.ToList();
                renomearColunas();

            }
            catch (Exception){
                throw;
            }

        }


        private void limparFormulario() {

            this.txtCodigoProduto.Text = "";
            this.txtDescricaoProduto.Text = "";
            this.dtpDataValidadeProduto.Value = DateTime.Now;
            this.txtPrecoProduto.Text = "";
            this.txtTaxaLucroProduto.Text = "";

        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {

            TOCC8Entities contexto;
            produto obj;

            try {

                int linha = this.dgvProdutos.SelectedCells[0].RowIndex;
                int codigo = Convert.ToInt32(this.dgvProdutos.Rows[linha].Cells["codigo"].Value);

                contexto = new TOCC8Entities();
                obj = contexto.produto.First(c => c.codigo == codigo);

                this.txtCodigoProduto.Text = obj.codigo.ToString();
                this.txtDescricaoProduto.Text = obj.descricao;
                this.dtpDataValidadeProduto.Value = obj.datavalidade.Value;
                this.txtPrecoProduto.Text = obj.preco.ToString();
                this.txtTaxaLucroProduto.Text = obj.taxalucro.ToString();

            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnEditarProduto_Click(object sender, EventArgs e) {

            TOCC8Entities contexto;
            produto obj;

            try {

                int codigo = Convert.ToInt32(txtCodigoProduto.Text);
                contexto = new TOCC8Entities();
                obj = contexto.produto.First(c => c.codigo == codigo);

                if (obj != null) {

                    obj.descricao = this.txtDescricaoProduto.Text;
                    obj.datavalidade = this.dtpDataValidadeProduto.Value;
                    obj.preco = Convert.ToDouble(this.txtPrecoProduto.Text);
                    obj.taxalucro = Convert.ToDouble(this.txtTaxaLucroProduto.Text);

                    verficarDados(obj);

                    contexto.SaveChanges();

                }

                MessageBox.Show("Alterado com sucesso.");
                this.btnListarProduto.PerformClick();
                limparFormulario();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRemoverProduto_Click(object sender, EventArgs e) {

            TOCC8Entities contexto;
            produto obj;

            try {

                int codigo = Convert.ToInt32(txtCodigoProduto.Text);
                contexto = new TOCC8Entities();
                obj = contexto.produto.First(c => c.codigo == codigo);

                if (obj != null) {

                    contexto.produto.Remove(obj);
                    contexto.SaveChanges();

                }

                MessageBox.Show("Removido com sucesso.");
                this.btnListarProduto.PerformClick();
                limparFormulario();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtDescricaoProduto_KeyUp(object sender, KeyEventArgs e) {

            TOCC8Entities contexto;

            try
            {

                contexto = new TOCC8Entities();
                var lista = from p
                            in contexto.produto
                            where p.descricao.ToLower().Contains(txtDescricaoProduto.Text.ToLower())
                            orderby p.codigo
                            select new {
                                p.codigo,
                                p.descricao,
                                p.datavalidade,
                                precoFinal = p.preco * (100 + p.taxalucro) / 100,
                                prazoValidade = DbFunctions.DiffDays(DateTime.Now, p.datavalidade)
                            };

                this.dgvProdutos.Columns.Clear();
                this.dgvProdutos.DataSource = lista.ToList();
                renomearColunas();

            }
            catch (Exception){
                throw;
            }

        }

        private void txtCodigoProduto_Leave(object sender, EventArgs e) {

            TOCC8Entities contexto;
            produto obj;

            try {

                if (txtCodigoProduto.Text.Trim().Length > 0) {

                    int codigo = Convert.ToInt32(txtCodigoProduto.Text);
                    contexto = new TOCC8Entities();
                    obj = contexto.produto.First(c => c.codigo == codigo);

                    if (obj != null) {
                        txtDescricaoProduto.Text = obj.descricao;
                        dtpDataValidadeProduto.Value = obj.datavalidade.Value;
                        txtPrecoProduto.Text = obj.preco.ToString();
                        txtTaxaLucroProduto.Text = obj.taxalucro.ToString();
                    }
                    else {
                        limparFormulario();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void renomearColunas() {

            dgvProdutos.Columns["codigo"].HeaderText = "Código";
            dgvProdutos.Columns["descricao"].HeaderText = "Descrição";
            dgvProdutos.Columns["datavalidade"].HeaderText = "Data de Validade";
            dgvProdutos.Columns["precoFinal"].HeaderText = "Preço Final (R$)";
            dgvProdutos.Columns["prazoValidade"].HeaderText = "Prazo de Validade (em dias)";

        }

        private void btnGraficoProduto_Click(object sender, EventArgs e) {

            try {

                FormGraficoProduto form = new FormGraficoProduto();
                form.ShowDialog();

            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao abrir gráfico: " + ex.Message);
            }

        }

        private void verficarDados(produto produto) { 
        
            if (produto.descricao.Trim().Length == 0) {
                throw new Exception("Descrição é obrigatória.");
            }

            if (produto.preco != null && produto.preco < 0) {
                throw new Exception("Preço não pode ser negativo.");
            }

            if (produto.taxalucro != null && produto.taxalucro < 0) {
                throw new Exception("Taxa de lucro não pode ser negativa.");
            }

            if (produto.datavalidade != null && produto.datavalidade < DateTime.Now) {
                throw new Exception("Data de validade não pode ser menor que a data atual.");
            }

        }

    }

}
