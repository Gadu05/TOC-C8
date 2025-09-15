<%-- 
    Document   : produtos
    Created on : 10 de set. de 2025, 16:28:41
    Author     : Gabriel Eduardo
--%>


<%@page import="java.util.ArrayList"%>
<%@page import="java.util.List"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.controller.DAOJPA"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.model.Produto"%>
<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        
        <%@include file="layout/header.jsp" %>
        
        <h3>Lista de Produtos</h3>
        <div class="produto-list" style="display: grid; grid-template-columns: repeat(4, 1fr); gap: 20px; margin-bottom: 30px;">
            
            <%
                
                try {
                    
                    DAOJPA dao;
                    List<Produto> lista;
                    
                    dao = new DAOJPA();
                    lista = dao.listarTodos();
                    
                    List<Produto> carrinho = (List<Produto>) session.getAttribute("carrinho");
                    
                    if (carrinho == null) {
                        carrinho = new ArrayList<>();
                    }
                    
                    String btnAdicionar = request.getParameter("btnAdicionarCarrinho");
                    if ("add".equals(btnAdicionar)) {
                        int codigoProduto = Integer.parseInt(request.getParameter("codigoProduto"));
                        
                        Produto produto;
                        produto = (Produto)dao.buscarPorCodigo(codigoProduto, Produto.class);
                        
                        carrinho.add(produto);
                        
                    }
                    
                    session.setAttribute("carrinho", carrinho);
                    
                    for (Produto produto : lista) {
                        
                        int quantidadeNoCarrinho = 0;
                        if (carrinho != null) {
                            for (Produto p : carrinho) {
                                if (produto.getCodigo() == p.getCodigo()) {
                                    quantidadeNoCarrinho++;
                                }
                            }
                        }
                        
                        int quantidadeDisponivel = produto.getQtde() - quantidadeNoCarrinho;

                    %>
                        <div style="border: 1px solid #ccc; padding: 15px; border-radius: 8px;">
                            <strong>Descrição:</strong> <%=produto.getDescricao() %> <br>
                            <strong>Preço:</strong> <%=produto.getPreco() %> <br>
                            <strong>Quantidade em estoque:</strong> <%=quantidadeDisponivel%> <br>
                            <form method="POST" action="">
                                <input type="hidden" name="codigoProduto" value="<%=produto.getCodigo() %>">
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
