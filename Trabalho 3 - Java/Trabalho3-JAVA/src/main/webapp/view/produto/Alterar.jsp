<%-- 
    Document   : Alterar.jsp
    Created on : 15 de set. de 2025, 15:12:34
    Author     : Gabriel Eduardo
--%>

<%@page import="com.gabrieleduardo.trabalho3.java.resources.controller.DAOJPA"%>
<%@page import="com.gabrieleduardo.trabalho3.java.resources.model.Produto"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        
        <%

        request.setCharacterEncoding("UTF-8");

        try {
            Produto produto;
            DAOJPA dao;
            
            
            produto = new Produto();
            produto.setCodigo(request.getParameter("txtCodigo"));
            produto.setDescricao(request.getParameter("txtDescricao"));
            produto.setPreco(request.getParameter("txtPreco"));
            produto.setQtde(request.getParameter("txtQuantidade"));
            
            
            dao = new DAOJPA();
            dao.alterar(produto);
            
            %>
            <script>
                alert("Salvo com sucesso!");
                window.location.href = "<%=request.getContextPath()%>/view/estoque.jsp";
            </script>
                <%

        }
        catch (Exception ex) {
            out.println("<h1>Erro ao alterar " + ex.getMessage() + "</h1>");
        }

        %>
        
    </body>
</html>
