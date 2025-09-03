<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8" />
    <title> Primeiro Site PHP </title>
</head>

<body>
    <?php
    include("..\\controller\\ProdutoDAO.php");
    $dao = new ProdutoDAO();
    $obj = new Produto();

    $obj->setCodigo($_GET['txtCodigo']);
    $obj->setDescricao($_GET['txtDescricao']);
    $obj->setPreco($_GET['txtPreco']);
    $obj->setQtde($_GET['txtQuantidade']);
    $r = $dao->alterar($obj);

    if ($r > 0) {
        echo $obj->getDescricao() . " alterado com sucesso.";
    } else {
        echo "Nada foi salvo.";
    }
    ?>

    <button onclick="window.location.href='/TOC-C8/trabalho_2_php/view/estoque.php'">Voltar</button>

</body>

</html>