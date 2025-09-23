
import Banco from "../model/Banco.js";

class ProdutoDAO {

    async gravar(produto) {
        try {
            Banco.init();
            await Banco.conexao
                .query("INSERT INTO produto (descricao, preco, qtde) VALUES ($1, $2, $3) RETURNING *", [produto.descricao, produto.preco, produto.qtde])
                .then(resposta => {
                    this.codigo = resposta.rows[0].codigo;
                    return (resposta.rows[0].codigo);
                })
                .catch(erro => {
                    console.log("Erro ao gravar: " + erro);
                    return 0;
                });
            Banco.conexao.end();
        }
        catch (erro) {
            console.log("Erro: " + erro);
            return 0;
        }
    }

    async listar() {
        try {
            Banco.init();
            const resposta = await Banco.conexao
                .query("SELECT * FROM produto ORDER BY codigo")
                .catch(erro => {
                    console.log("Erro ao listar: " + erro);
                    return null;
                });
            Banco.conexao.end();
            return resposta.rows;
        }
        catch (erro) {
            console.log("Erro: " + erro);
            return null;
        }
    }

    async alterar(produto) {
        try {
            Banco.init();
            await Banco.conexao
                .query("UPDATE produto SET descricao=$1, preco=$2, qtde=$3 WHERE codigo=$4", [produto.descricao, produto.preco, produto.qtde, produto.codigo])
                .then(resposta => {
                    return (resposta.rowCount);
                })
                .catch(erro => {
                    console.log("Erro ao alterar: " + erro);
                    return 0;
                });
            Banco.conexao.end();
        }
        catch (erro) {
            console.log("Erro: " + erro);
            return 0;
        }
    }

    async excluir(codigo) {
        try {
            Banco.init();
            await Banco.conexao
                .query("DELETE FROM produto WHERE codigo=$1", [codigo])
                .then(resposta => {
                    return (resposta.rowCount);
                })
                .catch(erro => {
                    console.log("Erro ao excluir: " + erro);
                    return 0;
                });
            Banco.conexao.end();
        }
        catch (erro) {
            console.log("Erro: " + erro);
            return 0;
        }
    }

}

export default ProdutoDAO;