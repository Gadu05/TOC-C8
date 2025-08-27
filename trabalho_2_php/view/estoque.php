<?php
// --- Simulação de "banco de dados" em sessão ---
session_start();
if (!isset($_SESSION["produtos"])) {
    $_SESSION["produtos"] = [];
}

// --- Adicionar produto ---
if (isset($_POST["acao"]) && $_POST["acao"] === "adicionar") {
    $_SESSION["produtos"][] = [
        "id" => uniqid(),
        "descricao" => $_POST["descricao"],
        "preco" => (float) $_POST["preco"],
        "qtde" => (int) $_POST["qtde"]
    ];
}

// --- Remover produto ---
if (isset($_GET["remover"])) {
    $_SESSION["produtos"] = array_filter($_SESSION["produtos"], function ($p) {
        return $p["id"] !== $_GET["remover"];
    });
}

// --- Editar produto ---
if (isset($_POST["acao"]) && $_POST["acao"] === "editar") {
    foreach ($_SESSION["produtos"] as &$p) {
        if ($p["id"] === $_POST["id"]) {
            $p["descricao"] = $_POST["descricao"];
            $p["preco"] = (float) $_POST["preco"];
            $p["qtde"] = (int) $_POST["qtde"];
        }
    }
    unset($p);
}

// --- Buscar produto para edição ---
$produtoEditar = null;
if (isset($_GET["editar"])) {
    foreach ($_SESSION["produtos"] as $p) {
        if ($p["id"] === $_GET["editar"]) {
            $produtoEditar = $p;
        }
    }
}
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <title>CRUD PHP + Bootstrap</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>

    <?php require_once __DIR__ . "/layout/header.php"; ?>

    <div class="container py-5">

    <h1 class="mb-4">Mini CRUD de Produtos</h1>

    <!-- Formulário -->
    <div class="card mb-4">
        <div class="card-body">
            <form method="POST">
                <input type="hidden" name="acao" value="<?= $produtoEditar ? 'editar' : 'adicionar' ?>">
                <?php if ($produtoEditar): ?>
                    <input type="hidden" name="id" value="<?= $produtoEditar['id'] ?>">
                <?php endif; ?>

                <div class="mb-3">
                    <label class="form-label">Descrição</label>
                    <input type="text" name="descricao" class="form-control" 
                           value="<?= $produtoEditar['descricao'] ?? '' ?>" required>
                </div>
                <div class="mb-3">
                    <label class="form-label">Preço</label>
                    <input type="number" step="0.01" name="preco" class="form-control" 
                           value="<?= $produtoEditar['preco'] ?? '' ?>" required>
                </div>
                <div class="mb-3">
                    <label class="form-label">Quantidade</label>
                    <input type="number" name="qtde" class="form-control" 
                           value="<?= $produtoEditar['qtde'] ?? '' ?>" required>
                </div>

                <button type="submit" class="btn btn-success">
                    <?= $produtoEditar ? "Salvar Alterações" : "Adicionar Produto" ?>
                </button>
                <?php if ($produtoEditar): ?>
                    <a href="crud.php" class="btn btn-secondary">Cancelar</a>
                <?php endif; ?>
            </form>
        </div>
    </div>

    <!-- Listagem -->
    <table class="table table-striped table-bordered">
        <thead class="table-dark">
            <tr>
                <th>Descrição</th>
                <th>Preço (R$)</th>
                <th>Qtd</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <?php if (empty($_SESSION["produtos"])): ?>
                <tr><td colspan="4" class="text-center">Nenhum produto cadastrado</td></tr>
            <?php else: ?>
                <?php foreach ($_SESSION["produtos"] as $p): ?>
                    <tr>
                        <td><?= htmlspecialchars($p["descricao"]) ?></td>
                        <td><?= number_format($p["preco"], 2, ",", ".") ?></td>
                        <td><?= $p["qtde"] ?></td>
                        <td>
                            <a href="?editar=<?= $p['id'] ?>" class="btn btn-sm btn-primary">Editar</a>
                            <a href="?remover=<?= $p['id'] ?>" class="btn btn-sm btn-danger"
                               onclick="return confirm('Deseja remover este produto?')">Excluir</a>
                        </td>
                    </tr>
                <?php endforeach; ?>
            <?php endif; ?>
        </tbody>
    </table>

    </div>

</body>
</html>
