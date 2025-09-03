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
    $carrinho = isset($_SESSION['carrinho']) ? $_SESSION['carrinho'] : [];

    $dao = new ProdutoDAO();
    $total = 0;

    if (!empty($carrinho)) {
        echo '<h3>Produtos no Carrinho</h3>';
        echo '<div class="produto-list" style="display: grid; grid-template-columns: repeat(4, 1fr); gap: 20px; margin-bottom: 30px;">';
        foreach ($carrinho as $codigoProduto => $quantidade) {
            $produto = $dao->buscarPorCodigo($codigoProduto);
            if ($produto) {
                echo '<div style="border: 1px solid #ccc; padding: 15px; border-radius: 8px;">';
                echo '<strong>Descrição:</strong> ' . $produto["descricao"] . '<br>';
                echo '<strong>Preço:</strong> R$ ' . $produto["preco"] . '<br>';
                echo '<strong>Quantidade:</strong> ' . $quantidade . '<br>';
                $subtotal = $produto["preco"] * $quantidade;
                echo '<strong>Subtotal:</strong> R$ ' . number_format($subtotal, 2, ',', '.') . '<br>';
                echo '</div>';
                $total += $subtotal;
            }
        }
        echo '</div>';
        echo '<h4>Total do Carrinho: R$ ' . number_format($total, 2, ',', '.') . '</h4>';
    } else {
        echo '<p>O carrinho está vazio.</p>';
    }


    echo '<form method="post" action="">
        <button type="submit" >Comprar</button>
    </form>';

    echo '<form method="post" action="">
        <button type="submit" name="limpar_carrinho">Limpar Carrinho</button>
    </form>';

    if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['limpar_carrinho'])) {
        $_SESSION['carrinho'] = [];
        header("Location: " . $_SERVER['PHP_SELF']);
        exit;
    }


    ?>

</body>
</html>