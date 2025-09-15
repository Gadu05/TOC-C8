/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gabrieleduardo.trabalho3.java.resources.controller;

import java.util.List;
import com.gabrieleduardo.trabalho3.java.resources.model.Banco;
import com.gabrieleduardo.trabalho3.java.resources.model.Produto;

/**
 *
 * @author Gabriel Eduardo
 */
public class DAOJPA {

    public void gravar(Object obj) throws Exception {
        Banco banco;
        try {
            banco = new Banco();
            banco.sessao.getTransaction().begin();
            banco.sessao.persist(obj);
            banco.sessao.getTransaction().commit();
            banco.sessao.close();
        } catch (Exception ex) {
            throw new Exception("Erro ao gravar: " + ex.getMessage());
        }
    }

    public void alterar(Object obj) throws Exception {
        Banco banco;
        try {
            banco = new Banco();
            banco.sessao.getTransaction().begin();
            banco.sessao.merge(obj);
            banco.sessao.getTransaction().commit();
            banco.sessao.close();
       } catch (Exception ex) {
            throw new Exception("Erro ao alterar: " + ex.getMessage());
        } 
    }

    public void remover( int id) throws Exception {
        Banco banco;
        Object obj;
        try {
            banco = new Banco();
            banco.sessao.getTransaction().begin();
            obj = banco.sessao.find(Produto.class, id);
            if (obj != null) {
                banco.sessao.remove(obj);
            }
            banco.sessao.getTransaction().commit();
            banco.sessao.close();
        } catch (Exception ex) {
            throw new Exception("Erro ao remover: " + ex.getMessage());
        } 
    }
    
    public Object buscarPorCodigo(final int codigo, Class classe) throws Exception {
        Banco banco;
        Object obj;
        try {
            banco = new Banco();
            obj = banco.sessao.find(classe, codigo);
            banco.conexao.close();
            return obj;
        }
        catch (Exception ex) {
            throw new Exception("Erro buscar por codigo: " + ex.getMessage());
        }
    }
    
    public Object buscarPorCodigo(String codigo, Class classe) throws Exception {
        Banco banco;
        Object obj;
        try {
            
            final int cod = Integer.parseInt(codigo);
            
            banco = new Banco();
            obj = banco.sessao.find(classe, cod);
            banco.conexao.close();
            return obj;
            
        }
        catch (Exception ex) {
            throw new Exception("Erro buscar por codigo: " + ex.getMessage());
        }
    }

    /*
    public Object getById(final int id) throws Exception {
        Banco banco;
        Object obj;
        try {
            banco = new Banco();
            obj = banco.sessao.find(Produto.class, id);
            banco.sessao.close();
            return obj;
        } catch (Exception ex) {
            throw new Exception("Erro ao getById: " + ex.getMessage());
        } finally {

        }

    }
    */
    
    public List<Object> listarTodos(Class classe) throws Exception {
        Banco banco;
        List<Object> lista;
        try {
            banco = new Banco();
            lista = banco.sessao.createNamedQuery(classe.getSimpleName() + ".findAll", classe).getResultList();
            banco.conexao.close();
            return lista;
        }
        catch (Exception ex) {
            throw new Exception("Erro ao Listar Todos " + classe.getSimpleName() + ": " + ex.getLocalizedMessage());
        }
    }

    public List<Produto> listarTodos() throws Exception {
        Banco banco;
        List<Produto> lista;
        try {
            banco = new Banco();
            lista = banco.sessao.createNamedQuery("Produto.findAll", Produto.class).getResultList();
            banco.sessao.close();
            return lista;
        } catch (Exception ex) {
            throw new Exception("Erro ao listarTodos: " + ex.getMessage());
        }
    }

}
