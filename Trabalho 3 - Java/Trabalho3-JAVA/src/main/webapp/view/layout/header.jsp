<%-- 
    Document   : header.jsp
    Created on : 15 de set. de 2025, 13:15:49
    Author     : Gabriel Eduardo
--%>

<!DOCTYPE html>
<html lang="pt-br">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
    </head>
    <body class="header-body">
        <header>
            <div class="button-list">
                <a href="${pageContext.request.contextPath}/">
                    <button type="button">Início</button>
                </a>
                <a href="${pageContext.request.contextPath}/view/produtos.jsp">
                    <button type="button">Produtos</button>
                </a>
                <a href="${pageContext.request.contextPath}/view/estoque.jsp">
                    <button type="button">Gerenciar Estoque</button>
                </a>
                <a href="${pageContext.request.contextPath}/view/carrinho.jsp">
                    <button type="button">Carrinho</button>
                </a>
            </div>
        </header>
    </body>
</html>
