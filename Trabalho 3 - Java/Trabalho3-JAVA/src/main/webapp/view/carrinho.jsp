<%-- 
    Document   : carrinho
    Created on : 15 de set. de 2025, 16:08:26
    Author     : Gabriel Eduardo
--%>

<%@page import="com.gabrieleduardo.trabalho3.java.resources.controller.DAOJPA"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.model.Produto"%>
<%@page import="java.util.List"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        
        <%@include file="layout/header.jsp" %>
        
        <h3> CARRINHO </h3>
        
        <%
            
        try {
            
            DAOJPA dao;
            List<Produto> carrinho;
            double totalCarrinho = 0;

            carrinho = (List<Produto>) session.getAttribute("carrinho");
            dao = new DAOJPA();

            String btnRemoverCarrinho = request.getParameter("btnRemoverCarrinho");
            if ("remove".equals(btnRemoverCarrinho)) {
                String codigoCarrinho = request.getParameter("codigoCarrinho");
                carrinho.remove(Integer.parseInt(codigoCarrinho));
            }

            String btnLimparCarrinho = request.getParameter("limpar_carrinho");
            if ("limpar".equals(btnLimparCarrinho)) {
                carrinho.clear();
                carrinho = null;
            }

            if (carrinho != null) {
                %>
                <h3>Produtos no Carrinho</h3>
                <div class="produto-list" style="display: grid; grid-template-columns: repeat(4, 1fr); gap: 20px; margin-bottom: 30px;">
                <%
                int idCarrinho = 0;
                for (Produto produto : carrinho) {
                    %>
                    <div style="border: 1px solid #ccc; padding: 15px; border-radius: 8px;">
                        <strong>Descrição:</strong> <%= produto.getDescricao() %> <br>
                        <strong>Preço:</strong> R$ <%= produto.getPreco() %> <br>
                        <form method="post" action="">
                           <input type="hidden" name="codigoCarrinho" value="<%= idCarrinho++ %>">
                           <button type="submit" name="btnRemoverCarrinho" value="remove">REMOVER</button>
                        </form>
                    </div>
                    <%
                    totalCarrinho += produto.getPreco();
                }
                %>
                </div>
                <h4>Total do Carrinho: R$ <%= totalCarrinho %> </h4>
                <%
            }
            else {
                %>
                <p>O carrinho está vazio.</p>
                <%
            }
        }
        catch (Exception ex) {
            %>
            <h3>Erro ao carregar o carrinho: <%= ex.getMessage() %> </h3>
            <%
        }
        %>
        
        <form method="post" action="">
            <button type="submit" >Comprar</button>
        </form>

        <form method="post" action="">
            <button type="submit" name="limpar_carrinho" value="limpar">Limpar Carrinho</button>
        </form>

    </body>
</html>
