<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title> Primeiro Site PHP </title>
    </head>
    <body>
        <?php
        include("..\\..\\controller\\ProdutoDAO.php");

        //cria ou captura a sessao
        session_start();
        //$_SESSION['codigo'] -> pega o campo codigo da sessao.
        if(isset($_SESSION['codigo'])) { //isset -> verifica se recebeu algo
            $dao = new ProdutoDAO();
            $obj = new Produto();
            $obj->setCodigo($_SESSION['codigo']);
            $obj->setDescricao($_SESSION['descricao']);
            $obj->setPreco($_SESSION['preco']);
            $obj->setQtde($_SESSION['qtde']);
            $r = $dao->alterar($obj);
        
            if($r>0){
                echo $obj->getDescricao()." alterado com sucesso."; 
            }
            else{
                echo "Nada foi alterado."; 
            }
        }
        else
            echo 'Dados não foram recebidos.';

        session_destroy(); //apaga tudo da sessão    
        ?>
    </body>
</html>    