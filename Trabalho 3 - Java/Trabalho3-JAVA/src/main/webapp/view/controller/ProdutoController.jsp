<%-- 
    Document   : ProdutoController
    Created on : 15 de set. de 2025, 15:39:40
    Author     : Gabriel Eduardo
--%>

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
        String botao;
        try {
            botao = request.getParameter("btnFormProduto").trim().toLowerCase();
            switch (botao) {
                case "gravar":
                    request.getRequestDispatcher("..//produto//Gravar.jsp").forward(request, response);
                    break;
                //case "listar":
                //    request.getRequestDispatcher("..//view//Listar.jsp").forward(request, response);
                //    break;
                case "alterar":
                    request.getRequestDispatcher("..//produto//Alterar.jsp").forward(request, response);
                    break;
                case "remover":
                    request.getRequestDispatcher("..//produto//Remover.jsp").forward(request, response);
                    break;
            }
            out.println("<h1>Evento :" + botao + " não tratado!</h1>");
          
        }
        catch (Exception ex) {
           out.println("<h1>Erro: " + ex.getMessage() + "</h1>");
        }           
 
        %>
    </body>
</html>
