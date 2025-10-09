
class Produto {

    #codigo;
    #descricao;
    #preco;
    #qtde;

    produto() {
        this.#codigo = 0;
        this.#descricao = "";
        this.#preco = 0.0;
        this.#qtde = 0;
    }

    get codigo() {
        return this.#codigo;
    }

    set codigo(codigo) {
        this.#codigo = codigo;
    }

    get descricao() {
        return this.#descricao;
    }

    set descricao(descricao) {
        this.#descricao = descricao;
    }

    get preco() {
        return this.#preco;
    }

    set preco(preco) {
        this.#preco = preco;
    }

    get qtde() {
        return this.#qtde;
    }

    set qtde(qtde) {
        this.#qtde = qtde;
    }

}

export default Produto;