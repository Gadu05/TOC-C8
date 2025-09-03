<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title> Primeiro Site PHP </title>
    </head>
    <body>
        <?php
        include("..\\controller\\ProdutoDAO.php");
        $dao = new ProdutoDAO();
        $obj = new Produto();

        $obj->setCodigo($_GET['txtCodigo']);

        echo $obj->getCodigo();
        
        $r = $dao->remover($obj);
        
        if($r>0){
            echo $obj->getDescricao()." removido com sucesso."; 
        }
        else{
            echo "Nada foi removido."; 
        }
        ?>

        <button onclick="window.location.href='/trabalho_2_php/view/estoque.php'">Voltar</button>

    </body>
</html>    