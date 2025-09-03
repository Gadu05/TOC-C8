<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Produtos</title>
</head>
<body>
    <?php require_once __DIR__ . "/layout/header.php"; ?>

    <?php
    include("../controller/ProdutoDAO.php");

    session_start();

    $dao = new ProdutoDAO();
    $tabela = $dao->listar();

    if ($tabela) {
        echo '<h3>Lista de Produtos</h3>';
        echo '<div class="produto-list" style="display: grid; grid-template-columns: repeat(4, 1fr); gap: 20px; margin-bottom: 30px;">';
        while ($linha = pg_fetch_array($tabela)) {
            echo '<div style="border: 1px solid #ccc; padding: 15px; border-radius: 8px;">';
            echo '<strong>Descrição:</strong> ' . $linha[1] . '<br>';
            echo '<strong>Preço:</strong> R$ ' . $linha[2] . '<br>';
            $quantidadeNoCarrinho = isset($_SESSION['carrinho'][$linha[0]]) ? $_SESSION['carrinho'][$linha[0]] : 0;
            $quantidadeDisponivel = $linha[3] - $quantidadeNoCarrinho;
            echo '<strong>Quantidade em estoque:</strong> ' . $quantidadeDisponivel . '<br>';
            echo '<form method="GET" action="">
                    <input type="hidden" name="codigoProduto" value="' . $linha[0] . '">
                    <input type="number" name="quantidadeCarrinho" value="1" min="1" max="' . $quantidadeDisponivel . '" required>
                    <button type="submit" name="btnAdicionarCarrinho" value="add">Adicionar ao Carrinho</button>
                </form>';
            echo '</div>';
        }
        echo '</div>';
    }
    

    if (isset($_GET['btnAdicionarCarrinho']) && isset($_GET['codigoProduto']) && isset($_GET['quantidadeCarrinho'])) {
        $codigoProduto = $_GET['codigoProduto'];
        $quantidadeAdicionar = intval($_GET['quantidadeCarrinho']);

        $produtoAtual = $dao->buscarPorCodigo($codigoProduto);

        if ($produtoAtual) {
            $estoque = intval($produtoAtual["qtde"]);

            if (!isset($_SESSION['carrinho'])) {
                $_SESSION['carrinho'] = [];
            }

            $quantidadeNoCarrinho = isset($_SESSION['carrinho'][$codigoProduto]) ? $_SESSION['carrinho'][$codigoProduto] : 0;
            $novaQuantidade = $quantidadeNoCarrinho + $quantidadeAdicionar;

            if ($novaQuantidade <= $estoque) {
                $_SESSION['carrinho'][$codigoProduto] = $novaQuantidade;
                echo '<div style="color:green;">Produto adicionado ao carrinho!</div>';
                header("Location: " . $_SERVER['PHP_SELF']);
            } else {
                echo '<div style="color:red;">Quantidade excede o estoque disponível!</div>';
            }
        }
    }
    
    ?>

</body>
</html>