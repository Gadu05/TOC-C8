<%-- 
    Document   : estoque
    Created on : 15 de set. de 2025, 13:11:06
    Author     : Gabriel Eduardo
--%>

<%@page import="com.gabrieleduardo.trabalho3.java.resources.model.Produto"%>
<%@page import="java.util.List"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.controller.DAOJPA"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        
        <%@include file="layout/header.jsp" %>

        <div>

            <form action="controller/ProdutoController.jsp" method="POST">
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

        <%
        
        DAOJPA dao;
        List<Object> lista;
        
        dao = new DAOJPA();
        lista = dao.listarTodos(Produto.class);

        if (lista != null) {
            %>
            <div class="produto-list">
                <h3>Lista de Produtos</h3>
                <table>
                    <tr><th>Código</th><th>Descrição</th><th>Preço</th><th>Quantidade</th><th>Ações</th></tr>
            <%
            
            for (Object obj : lista) {
                Produto produto = (Produto)obj;
                %>
                <tr>
                    <td><%= produto.getCodigo() %></td>
                    <td><%= produto.getDescricao() %></td>
                    <td><%= produto.getPreco() %> </td>
                    <td><%= produto.getQtde() %></td>
                    <td>
                        <form method="POST" action="">
                            <input type="hidden" name="editCodigo" value="<%= produto.getCodigo() %>">
                            <button type="submit" name="btnEditProduto" value="editar">Editar/Remover</button>
                        </form>
                    </td>
                </tr>
                <%
            }
            %>
                </table>
            </div>
            <%
        }

        String btnEditProduto = request.getParameter("btnEditProduto");
        String editCodigo = request.getParameter("editCodigo");

        if (btnEditProduto != null && btnEditProduto.equals("editar") && editCodigo != null) {
            
            Produto produto;
            produto = (Produto)dao.buscarPorCodigo(editCodigo, Produto.class);

            if (produto != null) {
                %>
                <script>
                    document.getElementById('txtCodigo').value = '<%=produto.getCodigo()%>';
                    document.getElementById('txtDescricao').value = '<%=produto.getDescricao()%>';
                    document.getElementById('txtPreco').value = '<%=produto.getPreco()%>';
                    document.getElementById('txtQuantidade').value = '<%=produto.getQtde()%>';
                </script>
                <%
            }
        }      
        %>
        
    </body>
</html>
