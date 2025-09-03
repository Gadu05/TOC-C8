<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Estoque</title>
    <link rel="stylesheet" href="/trabalho_2_php/view/public/css/style.css">
</head>
<body>
    <?php require_once __DIR__ . "/layout/header.php"; ?>

    <div>

    <form action="../controller/Controlador.php" method="GET">
        <h2>Estoque de Produtos</h2>
        <label for="txtCodigo">Código:</label>
        <input type="text" id="txtCodigo" name="txtCodigo"><br>

        <label for="txtDescricao">Descrição:</label>
        <input type="text" id="txtDescricao" name="txtDescricao" required><br>

        <label for="txtPreco">Preço:</label>
        <input type="number" step="0.01" id="txtPreco" name="txtPreco" required><br>

        <label for="txtQuantidade">Quantidade:</label>
        <input type="number" id="txtQuantidade" name="txtQuantidade" required><br>

        <div class="button-group">
        <button type="submit" name="btnFormProduto" value="gravar">Gravar</button>
        <!-- <button type="submit" name="btnFormProduto" value="listar">Listar</button> -->
        <button type="submit" name="btnFormProduto" value="alterar">Alterar</button>
        <button type="submit" name="btnFormProduto" value="remover">Remover</button>
        </div>
    </form>

    </div>

    <?php
    include("../controller/ProdutoDAO.php");

    $dao = new ProdutoDAO();
    $tabela = $dao->listar();

    if ($tabela) {
        echo '<div class="produto-list">';
        echo '<h3>Lista de Produtos</h3>';
        echo '<table>';
        echo '<tr><th>Código</th><th>Descrição</th><th>Preço</th><th>Quantidade</th><th>Ações</th></tr>';
        while ($linha = pg_fetch_array($tabela)) {
            echo '<tr>';
            echo '<td>' . $linha[0] . '</td>';
            echo '<td>' . $linha[1] . '</td>';
            echo '<td>' . $linha[2] . '</td>';
            echo '<td>' . $linha[3] . '</td>';
            echo '<td>
                <form method="GET" action="">
                    <input type="hidden" name="editCodigo" value="' . $linha[0] . '">
                    <button type="submit" name="btnEditProduto" value="editar">Editar</button>
                </form>
            </td>';
            echo '</tr>';
        }
        echo '</table>';
        echo '</div>';
    }

    if (isset($_GET['btnEditProduto']) && $_GET['btnEditProduto'] === 'editar' && isset($_GET['editCodigo'])) {
        $codigo = $_GET['editCodigo'];
        $produto = $dao->buscarPorCodigo($codigo);
        if ($produto) {
            echo "<script>
                document.getElementById('txtCodigo').value = '" . addslashes($produto['codigo']) . "';
                document.getElementById('txtDescricao').value = '" . addslashes($produto['descricao']) . "';
                document.getElementById('txtPreco').value = '" . addslashes($produto['preco']) . "';
                document.getElementById('txtQuantidade').value = '" . addslashes($produto['qtde']) . "';
            </script>";
        }
    }
    ?>

</body>
</html>