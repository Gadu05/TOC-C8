package io.github.gadu05.tocc8.usuarios.api.dto;

import io.github.gadu05.tocc8.usuarios.api.model.Pessoa;

public record PessoaDTO(String cpf, String nome, double peso) {

    public PessoaDTO(Pessoa pessoa) {
        this(pessoa.getCpf(), pessoa.getNome(), pessoa.getPeso());
    }

}
