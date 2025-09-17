<%-- 
    Document   : Remover.jsp
    Created on : 15 de set. de 2025, 15:12:42
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
            
            dao = new DAOJPA();
            dao.remover(produto.getCodigo());
            
            %>
            <script>
                alert("Produto removido com sucesso!");
                window.location.href = "<%=request.getContextPath()%>/view/estoque.jsp";
            </script>
                <%

        }
        catch (Exception ex) {
            out.println("<h1>Erro ao remover " + ex.getMessage() + "</h1>");
        }

        %>
    </body>
</html>
