<?php
class Produto {

    private $codigo;
    private $descricao;
    private $preco;
    private $qtde;

    public function getCodigo() {
        return $this->codigo;
    }

    public function setCodigo($codigo) {
        $this->codigo = $codigo;
    }

    public function getDescricao() {
        return $this->descricao;
    }

    public function setDescricao($descricao) {
        $this->descricao = $descricao;
    }

    public function getPreco() {
        return $this->preco;
    }

    public function setPreco($preco) {
        $this->preco = $preco;
    }

    public function getQtde() {
        return $this->qtde;
    }

    public function setQtde($qtde) {
        $this->qtde = $qtde;
    }

}
?>
