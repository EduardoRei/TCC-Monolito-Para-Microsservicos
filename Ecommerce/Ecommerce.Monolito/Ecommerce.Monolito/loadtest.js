import http from 'k6/http';
import { check, sleep } from 'k6';
import { Trend } from 'k6/metrics';

// Métricas personalizadas
const myTrend = new Trend('request_duration');

// Configuração do teste
export const options = {
    stages: [
        { duration: '1m', target: 20 },   // Aumenta para 20 usuários simultâneos
        { duration: '2m', target: 50 },   // Escala para 50 usuários simultâneos
        { duration: '1m', target: 100 },  // Escala para 100 usuários simultâneos
        { duration: '1m', target: 0 },    // Diminui para 0 usuários
    ],
};

const BASE_URL = 'https://localhost:44383/api'; // Alterar para sua URL de API

// Função principal
export default function () {
    const userId = Math.floor(Math.random() * 100);

    // 1. Criação de 100 usuários
    for (let i = 0; i < 100; i++) {
        const userPayload = JSON.stringify({
            nome: `Usuario-${Math.random().toString(36).substring(7)}`,
            email: `usuario${i}@teste.com`,
            endereco: `Endereco ${i}`,
            cpf: `000.000.000-${i.toString().padStart(2, '0')}`,
            senha: 'senha123',
            dataNascimento: new Date().toISOString(),
        });

        const headers = { 'Content-Type': 'application/json' };
        const userRes = http.post(`${BASE_URL}/Usuario`, userPayload, { headers });
        check(userRes, {
            'Usuário criado com sucesso': (res) => res.status === 201 || res.status === 400,
        });
    }

    // 2. Edição de 100 usuários
    for (let i = 0; i < 100; i++) {
        const userPayload = JSON.stringify({
            nome: `Usuario-Editado-${Math.random().toString(36).substring(7)}`,
            email: `usuario${i}@teste.com`,
            endereco: `Endereco Editado ${i}`,
            cpf: `000.000.000-${i.toString().padStart(2, '0')}`,
            senha: 'senha123',
            dataNascimento: new Date().toISOString(),
        });

        const headers = { 'Content-Type': 'application/json' };
        const userRes = http.put(`${BASE_URL}/Usuario/${i}`, userPayload, { headers });
        check(userRes, {
            'Usuário editado com sucesso': (res) => res.status === 200 || res.status === 400,
        });
    }

    // 3. Exclusão de 20 usuários
    for (let i = 0; i < 20; i++) {
        const deleteRes = http.del(`${BASE_URL}/Usuario/${i}`);
        check(deleteRes, {
            'Usuário excluído com sucesso': (res) => res.status === 204 || res.status === 404,
        });
    }

    // 4. Criação de pedidos com os 80 usuários restantes
    let pedidoRes;
    for (let i = 20; i < 100; i++) {
        const pedidoPayload = JSON.stringify({
            idUsuario: i,
            idCarrinho: Math.floor(Math.random() * 100),
            idStatusPagamento: 1,
            dataPedido: new Date().toISOString(),
            idStatusPedido: 1,
        });

        const headers = { 'Content-Type': 'application/json' };
        pedidoRes = http.post(`${BASE_URL}/Pedido`, pedidoPayload, { headers });
        check(pedidoRes, {
            'Pedido criado com sucesso': (res) => res.status === 201 || res.status === 400,
        });
    }

    // Registra a métrica de duração da requisição
    myTrend.add(pedidoRes.timings.duration);

    sleep(1); // Pausa entre as requisições
}
