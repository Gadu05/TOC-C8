package io.github.gadu05.tocc8.usuarios.api.repository;

import io.github.gadu05.tocc8.usuarios.api.model.Pessoa;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PessoaRepository extends JpaRepository<Pessoa, String> {}
