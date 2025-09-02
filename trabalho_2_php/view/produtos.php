<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Produtos</title>
</head>
<body>
    <?php require_once __DIR__ . "/layout/header.php"; ?>

    <form action="../controller/Controlador.php" method="GET">
        <h2>Produtos</h2>
        <label for="txtCodigo">Código:</label>
        <input type="text" id="txtCodigo" name="txtCodigo" required><br><br>

        <label for="txtNome">Nome:</label>
        <input type="text" id="txtNome" name="txtNome" required><br><br>

        <label for="txtDescricao">Descrição:</label>
        <input type="text" id="txtDescricao" name="txtDescricao" required><br><br>

        <label for="txtPreco">Preço:</label>
        <input type="number" step="0.01" id="txtPreco" name="txtPreco" required><br><br>

        <button type="submit" name="btnFormProduto" value="gravar">Gravar</button>
        <button type="submit" name="btnFormProduto" value="listar">Listar</button>
        <button type="submit" name="btnFormProduto" value="remover">Remover</button>
        <button type="submit" name="btnFormProduto" value="alterar">Alterar</button>
    </form>

    <!-- Conteúdo dos produtos será adicionado aqui -->
</body>
</html>