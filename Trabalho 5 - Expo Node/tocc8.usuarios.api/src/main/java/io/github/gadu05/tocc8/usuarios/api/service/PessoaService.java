package io.github.gadu05.tocc8.usuarios.api.service;

import io.github.gadu05.tocc8.usuarios.api.dto.PessoaDTO;
import io.github.gadu05.tocc8.usuarios.api.model.Pessoa;
import io.github.gadu05.tocc8.usuarios.api.repository.PessoaRepository;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class PessoaService {

    @Autowired
    private PessoaRepository repository;

    public List<PessoaDTO> listar() {
        List<Pessoa> pessoas = repository.findAll();
        return pessoas.stream()
                .map(PessoaDTO::new)
                .collect(Collectors.toList());
    }

    public Pessoa buscarPessoaPorCpf(String cpf) {
        return repository.findById(cpf)
                .orElseThrow(() ->
                        new RuntimeException(("Pessoa não encontrada com cpf: " + cpf)));
    }

    @Transactional
    public Pessoa salvar(PessoaDTO dto) {
        Pessoa pessoa = new Pessoa(dto);
        return repository.save(pessoa);
    }

    @Transactional
    public Pessoa alterar(String cpf, PessoaDTO dto) {
        Pessoa pessoa = buscarPessoaPorCpf(cpf);
        pessoa.setNome(dto.nome());
        pessoa.setCpf(dto.cpf());
        return repository.save(pessoa);
    }

    @Transactional
    public void remover(String cpf) {
        Pessoa pessoa = buscarPessoaPorCpf(cpf);
        repository.delete(pessoa);
    }

}
