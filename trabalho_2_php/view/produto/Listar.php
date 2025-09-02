<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title> Primeiro Site PHP </title>
    </head>
    <body>

        <?php

        include("..\\..\\controller\\ProdutoDAO.php");
        $dao = new ProdutoDAO();

        $tabela = $dao->listar();
        if ($tabela) {
            echo " <h1> Lista de Clientes </h1><br/>";
            while ($linha = pg_fetch_array($tabela)) {
                echo "Codigo: $linha[0] Nome: $linha[1] Idade: $linha[2] <br/>";
            }
        } else {
            echo "Tabela Vazia";
        }

        ?>

    </body>
</html>    