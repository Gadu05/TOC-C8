package io.github.gadu05.tocc8.usuarios.api.model;

import io.github.gadu05.tocc8.usuarios.api.dto.PessoaDTO;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.Setter;

import java.io.Serializable;

@Getter
@Setter
@Entity
@Table(name = "pessoa")
public class Pessoa implements Serializable {

    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "cpf", nullable = false, length = 15)
    private String cpf;

    @Column(name = "nome", length = 100)
    private String nome;

    @Column(name = "peso")
    private Double peso;

    public Pessoa() {}

    public Pessoa(String cpf, String nome, Double peso) {
        this.cpf = cpf;
        this.nome = nome;
        this.peso = peso;
    }

    public Pessoa(PessoaDTO dto) {
        this.cpf = dto.cpf();
        this.nome = dto.nome();
        this.peso = dto.peso();
    }

}