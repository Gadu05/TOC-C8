<?php
include("..\\model\\Banco.php");
include("..\\model\\Produto.php");

class ProdutoDAO
{

    public function gravar($obj)
    {

        $banco = new Banco();
        $query = "INSERT INTO produto(descricao, preco, qtde) VALUES ($1, $2, $3)";

        $resultado = pg_query_params(
            $banco->conexao,
            $query,
            [$obj->getDescricao(), $obj->getPreco(), $obj->getQtde()]
        );

        $rows = pg_affected_rows($resultado);
        pg_close($banco->conexao);
        return $rows;

    }

    public function listar()
    {

        $banco = new Banco();
        $query = "SELECT * FROM produto ORDER BY descricao";

        $tabela = pg_query(
            $banco->conexao,
            $query
        );

        pg_close($banco->conexao);
        return $tabela;

    }

    public function remover($obj)
    {

        $banco = new Banco();
        $query = "DELETE FROM produto WHERE codigo = $1";

        $resultado = pg_query_params(
            $banco->conexao,
            $query,
            [$obj->getCodigo()]
        );

        $rows = pg_affected_rows($resultado);
        pg_close($banco->conexao);
        return $rows;

    }

    public function alterar($obj)
    {

        $banco = new Banco();
        $query = "UPDATE produto SET descricao = $1, preco = $2, qtde = $3 WHERE codigo = $4";

        $resultado = pg_query_params(
            $banco->conexao,
            $query,
            [$obj->getDescricao(), $obj->getPreco(), $obj->getQtde(), $obj->getCodigo()]
        );

        $rows = pg_affected_rows($resultado);
        pg_close($banco->conexao);
        return $rows;

    }
}
