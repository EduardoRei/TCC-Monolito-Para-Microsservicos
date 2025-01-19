import http from 'k6/http';
import { check, sleep } from 'k6';
import { Trend } from 'k6/metrics';

// Métricas personalizadas
const myTrend = new Trend('request_duration');

// Configuração do teste
export const options = {
    stages: [
        { duration: '30s', target: 10 },   // Aumenta para 10 usuários simultâneos
        { duration: '1m', target: 50 },    // Escala para 50 usuários simultâneos
        { duration: '30s', target: 0 },    // Diminui para 0 usuários
    ],
};

const BASE_URL = 'https://localhost:7224/api'; // Alterar para sua URL de API

// Função principal
export default function () {
    const carrinhoId = Math.floor(Math.random() * 100);

    // 1. Testa a criação de Produto
    const produtoPayload = JSON.stringify({
        idCategoria: Math.floor(Math.random() * 10) + 1,
        nome: `Produto-${Math.random().toString(36).substring(7)}`,
        quantidadeEstoque: Math.floor(Math.random() * 100),
        precoUnitario: (Math.random() * 100).toFixed(2),
    });

    const headers = { 'Content-Type': 'application/json' };
    const produtoRes = http.post(`${BASE_URL}/Produto`, produtoPayload, { headers });
    check(produtoRes, {
        'Produto criado com sucesso': (res) => res.status === 201 || res.status === 400,
    });

    // 2. Testa o endpoint de Carrinho
    const carrinhoRes = http.get(`${BASE_URL}/Carrinho/${carrinhoId}`);
    check(carrinhoRes, {
        'Carrinho carregado com sucesso': (res) => res.status === 200 || res.status === 404,
    });

    // 3. Simula a criação de um novo Pedido
    const pedidoPayload = JSON.stringify({
        idUsuario: Math.floor(Math.random() * 10),
        idCarrinho: carrinhoId,
        idStatusPagamento: 1,
        dataPedido: new Date().toISOString(),
        idStatusPedido: 1,
    });

    const pedidoRes = http.post(`${BASE_URL}/Pedido`, pedidoPayload, { headers });
    check(pedidoRes, {
        'Pedido criado com sucesso': (res) => res.status === 201 || res.status === 400,
    });

    // 4. Simula a atualização de um Pagamento
    const pagamentoPayload = JSON.stringify({
        id: Math.floor(Math.random() * 100),
        idUsuario: Math.floor(Math.random() * 10),
        idCarrinho: carrinhoId,
        idTipoPagamento: 1,
        idStatusPagamento: 2,
        valorCarrinho: (Math.random() * 100).toFixed(2),
        data: new Date().toISOString(),
    });

    const pagamentoRes = http.put(`${BASE_URL}/Pagamento`, pagamentoPayload, { headers });
    check(pagamentoRes, {
        'Pagamento atualizado com sucesso': (res) => res.status === 204 || res.status === 400,
    });

    // 5. Simula a exclusão de um Pedido
    const deleteRes = http.del(`${BASE_URL}/Pedido/${Math.floor(Math.random() * 100)}`);
    check(deleteRes, {
        'Pedido excluído com sucesso': (res) => res.status === 204 || res.status === 404,
    });

    // Registra a métrica de duração da requisição
    myTrend.add(produtoRes.timings.duration);

    sleep(1); // Pausa entre as requisições
}
