/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gabrieleduardo.trabalho3.java.resources.model;

import jakarta.persistence.CacheRetrieveMode;
import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityManagerFactory;
import jakarta.persistence.Persistence;

public class Banco {

    public static EntityManagerFactory conexao = null;
    public EntityManager sessao;
    private final String nomeArqPersistence = "JPAPU";// nome da unidade de persistência

    public Banco() throws Exception {
        try {
            if ((conexao == null) || (!conexao.isOpen())) {
                conexao = Persistence.createEntityManagerFactory(nomeArqPersistence);
            }
            sessao = conexao.createEntityManager();
            sessao.setProperty("javax.persistence.cache.retrieveMode", CacheRetrieveMode.BYPASS); //sem cache local
        } catch (Exception ex) {
            throw new Exception("Erro de conexão: " + ex.getMessage());
        }
    }
}
