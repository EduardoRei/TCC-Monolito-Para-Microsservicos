import http from 'k6/http';
import { check, sleep } from 'k6';
import { Counter } from 'k6/metrics';
import { randomIntBetween } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';

// Contadores GET
export const totalGetRequests = new Counter('total_get_requests');
export const successfulGetRequests = new Counter('successful_get_requests');

// Contadores POST
export const totalPostRequests = new Counter('total_post_requests');
export const successfulPostRequests = new Counter('successful_post_requests');

export const options = {
    stages: [
        { duration: '1m', target: 50 },
        { duration: '1m', target: 100 },
        { duration: '1m', target: 125 },
        { duration: '1m', target: 100 },
        { duration: '1m', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<2000'],
        http_req_failed: ['rate<0.3'],
    },
};

function generateOrderPayload() {
    const items = [{
        idProduto: 1,
        quantidadeProduto: 2
    }, {
        idProduto: 22,
        quantidadeProduto: 3
    }];

    return JSON.stringify({
        idUsuario: randomIntBetween(1, 20),
        formaPagamento: randomIntBetween(0, 3),
        createProdutoPedido: items
    });
}

export default function () {
    const requestParams = {
        headers: { 'Content-Type': 'application/json' },
        timeout: '60s'
    };

    // GET /api/Produto
    totalGetRequests.add(1);
    const getResponse = http.get('http://localhost:5000/api/Produto', requestParams);
    const getCheck = check(getResponse, {
        'GET /api/Produto status is 2xx': (r) => r.status >= 200 && r.status < 300,
    });
    if (getCheck) {
        successfulGetRequests.add(1);
    }

    // POST /api/Pedido
    totalPostRequests.add(1);
    const postPayload = generateOrderPayload();
    const postResponse = http.post('http://localhost:5000/api/Pedido', postPayload, requestParams);
    const postCheck = check(postResponse, {
        'POST /api/Pedido status is 2xx': (r) => r.status >= 200 && r.status < 300,
    });
    if (postCheck) {
        successfulPostRequests.add(1);
    }
    
    //sleep(1);
    sleep(randomIntBetween(0, 2));
}

// 📊 Relatório personalizado no final
export function handleSummary(data) {
    const successGET = data.metrics.successful_get_requests?.values?.count || 0;
    const totalGET = data.metrics.total_get_requests?.values?.count || 0;
    const successPOST = data.metrics.successful_post_requests?.values?.count || 0;
    const totalPOST = data.metrics.total_post_requests?.values?.count || 0;

    console.log('\n\n===== RESUMO DE SUCESSO POR ENDPOINT =====');
    console.log(`GET /api/Produto: ${successGET}/${totalGET} successful`);
    console.log(`POST /api/Pedido: ${successPOST}/${totalPOST} successful`);
    console.log('==========================================\n');

    const date = new Date().toISOString().replace(/[:.]/g, '-');
    return {
        [`${date}-report.html`]: generateHTMLSummary(data),
    };
}

// Gera relatório .html (exige xk6-reporter)
import { htmlReport as generateHTMLSummary } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js';