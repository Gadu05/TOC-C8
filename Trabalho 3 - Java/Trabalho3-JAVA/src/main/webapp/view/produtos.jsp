<%-- 
    Document   : produtos
    Created on : 10 de set. de 2025, 16:28:41
    Author     : Gabriel Eduardo
--%>

<%@page import="java.util.HashMap"%>
<%@page import="java.util.Map"%>
<%@page import="java.sql.ResultSet"%>
<%@page import="java.util.ArrayList"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.controller.ProdutoDAO"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.model.Produto"%>
<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        
        <h3>Lista de Produtos</h3>
        <div class="produto-list" style="display: grid; grid-template-columns: repeat(4, 1fr); gap: 20px; margin-bottom: 30px;">
            
            <%
                
                try {
                    
                    ProdutoDAO dao;
                    ResultSet produtos;
                    
                    dao = new ProdutoDAO();
                    produtos = dao.listar();
                    
                    Map<Integer, Integer> carrinho = (Map<Integer, Integer>) session.getAttribute("carrinho");
                    
                    if (carrinho == null) {
                        carrinho = new HashMap<>();
                    }
                    
                    String btnAdicionar = request.getParameter("btnAdicionarCarrinho");
                    if ("add".equals(btnAdicionar)) {
                        int codigoProduto = Integer.parseInt(request.getParameter("codigoProduto"));
                        int quantidade = Integer.parseInt(request.getParameter("quantidadeCarrinho"));
                        carrinho.put(codigoProduto, carrinho.getOrDefault(codigoProduto, 0) + quantidade);
                    }
                    
                    session.setAttribute("carrinho", carrinho);
                    
                    while (produtos != null && produtos.next()) {
                        
                        int quantidadeNoCarrinho = 0;
                        if (carrinho != null && carrinho.containsKey(produtos.getInt(1)))
                            quantidadeNoCarrinho = carrinho.get(produtos.getInt(1));
                        int quantidadeDisponivel = produtos.getInt(4) - quantidadeNoCarrinho;

                    %>
                        <div style="border: 1px solid #ccc; padding: 15px; border-radius: 8px;">
                            <strong>Descrição:</strong> <%=produtos.getString(2)%> <br>
                            <strong>Preço:</strong> <%=produtos.getDouble(3)%> <br>
                            <strong>Quantidade em estoque:</strong> <%=quantidadeDisponivel%> <br>
                            <form method="POST" action="">
                                <input type="hidden" name="codigoProduto" value="<%=produtos.getInt(1)%>">
                                <input type="number" name="quantidadeCarrinho" value="1" min="1" max="<%=quantidadeDisponivel%>" required>
                                <button type="submit" name="btnAdicionarCarrinho" value="add">Adicionar ao Carrinho</button>
                            </form>
                        </div>
                    <%
                    }
                }
                catch (Exception e) { %>
                    <h1> Erro: <%=e.getMessage()%> </h1>
                <%
                }
                %>
            
            
        </div>

    </body>
</html>
