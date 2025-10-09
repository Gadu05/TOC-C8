package io.github.gadu05.tocc8.usuarios.api.controller;

import io.github.gadu05.tocc8.usuarios.api.dto.PessoaDTO;
import io.github.gadu05.tocc8.usuarios.api.model.Pessoa;
import io.github.gadu05.tocc8.usuarios.api.service.PessoaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import java.net.URI;
import java.util.List;

@RestController
@RequestMapping("/api/pessoa")
class PessoaController {

    @Autowired
    private PessoaService service;

    @GetMapping()
    public ResponseEntity<List<PessoaDTO>> listar() {
        List<PessoaDTO> lista = service.listar();
        return ResponseEntity.ok(lista);
    }

    @GetMapping("/{cpf}")
    public ResponseEntity<PessoaDTO> buscar(@PathVariable String cpf) {
        Pessoa pessoa = service.buscarPessoaPorCpf(cpf);
        return ResponseEntity.ok(new PessoaDTO(pessoa));
    }

    @PostMapping()
    public ResponseEntity<PessoaDTO> salvar(@RequestBody PessoaDTO dto) {
        Pessoa pessoa = service.salvar(dto);
        URI location = URI.create("/api/pessoa/" + pessoa.getCpf());
        return ResponseEntity.created(location).body(new PessoaDTO(pessoa));
    }

    @PutMapping("/{cpf}")
    public ResponseEntity<PessoaDTO> alterar(@PathVariable String cpf, @RequestBody PessoaDTO dto) {
        Pessoa pessoa = service.alterar(cpf, dto);
        return ResponseEntity.ok(new PessoaDTO(pessoa));
    }

    @DeleteMapping("/{cpf}")
    public ResponseEntity<Void> remover(@PathVariable String cpf) {
        service.remover(cpf);
        return ResponseEntity.noContent().build();
    }



}
