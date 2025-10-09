import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, StyleSheet } from 'react-native';
import { listar } from '../services/pessoaService';

type PessoaDTO = {
    cpf: string;
    nome: string;
    peso: number;
};

export default function PessoaList() {
    const [pessoas, setPessoas] = useState<PessoaDTO[]>([]);

    useEffect(() => {
        async function fetchPessoas() {
            try {
                const data = await listar();
                setPessoas(data);
            } catch (error) {
                console.error('Erro ao carregar pessoas', error);
            }
        }
        fetchPessoas();
    }, []);

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Lista de Pessoas</Text>
            <FlatList
                data={pessoas}
                keyExtractor={(item: PessoaDTO) => item.cpf}
                renderItem={({ item }) => (
                    <View style={styles.item}>
                        <Text>{item.nome}</Text>
                        <Text>{item.peso}</Text>
                    </View>
                )}
            />
        </View>
    );
}

const styles = StyleSheet.create({
    container: { flex: 1, padding: 20 },
    title: { fontSize: 22, fontWeight: 'bold', marginBottom: 10 },
    item: { marginBottom: 10, padding: 10, backgroundColor: '#eee', borderRadius: 5 },
});
