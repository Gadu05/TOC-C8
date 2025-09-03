<?php
$botao = strtolower(trim($_GET["btnFormProduto"]));

switch ($botao) {
    case 'gravar':
        header("Location: ..\\view\Gravar.php?txtDescricao=" . $_GET["txtDescricao"] . "&txtPreco=" . $_GET["txtPreco"] . "&txtQuantidade=" . $_GET["txtQuantidade"]);
        break;
    case 'listar':
        header("Location: ..\\view\Listar.php");
        break;
    case 'remover':
        header("Location: ..\\view\Remover.php?txtCodigo=" . $_GET["txtCodigo"]);
        break;
    case 'alterar':
        header("Location: ..\\view\Alterar.php?txtCodigo=" . $_GET["txtCodigo"] . "&txtDescricao=" . $_GET["txtDescricao"] . "&txtPreco=" . $_GET["txtPreco"] . "&txtQuantidade=" . $_GET["txtQuantidade"]);
        //passar campos via sessão
        /*
        session_start(); //inicia a sessão e viabiliza a $_SESSION
        $_SESSION['codigo'] = $_GET['txtCodigo'];
        $_SESSION['descricao'] = $_GET['txtDescricao'];
        $_SESSION['preco'] = $_GET['txtPreco'];
        $_SESSION['qtde'] = $_GET['txtQuantidade'];
        header("Location: ..\\view\Alterar.php");
        */
        break;
}
