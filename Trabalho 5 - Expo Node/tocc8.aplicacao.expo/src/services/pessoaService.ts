import api from '../api/api';

export async function listar() {
    const response = await api.get('/api/pessoa');
    return response.data;
}

export async function salvar(pessoa: { cpf: string; nome: string; email: string }) {
    const response = await api.post('/api/pessoa', pessoa);
    return response.data;
}
