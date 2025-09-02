<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Estoque</title>
    <link rel="stylesheet" href="/TOC-C8/trabalho_2_php/view/public/css/style.css">
</head>
<body>
    <?php require_once __DIR__ . "/layout/header.php"; ?>

    <div class="form-container">

    <form action="../controller/Controlador.php" method="GET">
        <h2>Estoque de Produtos</h2>
        <label for="txtCodigo">Código:</label>
        <input type="text" id="txtCodigo" name="txtCodigo" required><br><br>

        <label for="txtNome">Nome:</label>
        <input type="text" id="txtNome" name="txtNome" required><br><br>

        <label for="txtDescricao">Descrição:</label>
        <input type="text" id="txtDescricao" name="txtDescricao" required><br><br>

        <label for="txtPreco">Preço:</label>
        <input type="number" step="0.01" id="txtPreco" name="txtPreco" required><br><br>

        <div class="button-group">
        <button type="submit" name="btnFormProduto" value="gravar">Gravar</button>
        <button type="submit" name="btnFormProduto" value="listar">Listar</button>
        <button type="submit" name="btnFormProduto" value="remover">Remover</button>
        <button type="submit" name="btnFormProduto" value="alterar">Alterar</button>
        </div>
    </form>

    </div>

    <?php
    require_once __DIR__ . "../../controller/ProdutoDAO.php";

    $produtoDAO = new ProdutoDAO();
    $produtos = $produtoDAO->listar();
    echo ("Produtos retornados: " . print_r($produtos, true));

    if (!empty($produtos)) {
        echo '<div class="produto-list">';
        echo '<h3>Lista de Produtos</h3>';
        echo '<table>';
        echo '<tr><th>Código</th><th>Nome</th><th>Descrição</th><th>Preço</th><th>Ações</th></tr>';
        foreach ($produtos as $produto) {
            echo '<tr>';
            echo '<td>' . htmlspecialchars($produto['codigo']) . '</td>';
            echo '<td>' . htmlspecialchars($produto['nome']) . '</td>';
            echo '<td>' . htmlspecialchars($produto['descricao']) . '</td>';
            echo '<td>' . htmlspecialchars(number_format($produto['preco'], 2)) . '</td>';
            echo '<td>
                <form method="GET" action="">
                    <input type="hidden" name="editCodigo" value="' . htmlspecialchars($produto['codigo']) . '">
                    <button type="submit" name="btnEditProduto" value="editar">Editar</button>
                </form>
            </td>';
            echo '</tr>';
        }
        echo '</table>';
        echo '</div>';
    }

    // Carregar dados do produto para edição
    if (isset($_GET['btnEditProduto']) && $_GET['btnEditProduto'] === 'editar' && isset($_GET['editCodigo'])) {
        $codigo = $_GET['editCodigo'];
        $produto = $produtoDAO->buscarPorCodigo($codigo);
        if ($produto) {
            echo "<script>
                document.getElementById('txtCodigo').value = '" . addslashes($produto['codigo']) . "';
                document.getElementById('txtNome').value = '" . addslashes($produto['nome']) . "';
                document.getElementById('txtDescricao').value = '" . addslashes($produto['descricao']) . "';
                document.getElementById('txtPreco').value = '" . addslashes($produto['preco']) . "';
            </script>";
        }
    }
    ?>

    <!-- Conteúdo dos produtos será adicionado aqui -->
</body>
</html>