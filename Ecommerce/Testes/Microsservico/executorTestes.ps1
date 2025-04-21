param (
    [int]$repeatCount = 10  # Numero de execucoes (padrao = 1)
)

# Configuracoes
$scriptPath = "insert-path-here"
$k6Script = ".\MicrosservicoStressTest.js"

# Nome real do container Docker
$containerPedido1 = "ecommerce-pedido-api-1"
$containerPedido2 = "ecommerce-pedido-api-1-1"
$containerPedido3 = "ecommerce-pedido-api-2-1"
$containerProduto1 = "ecommerce-produto-api-1"
$containerProduto2 = "ecommerce-produto-api-1-1"
$containerUsuario1 = "ecommerce-usuario-api-1"
$containerPagamento1 = "ecommerce-pagamento-api-1"
$containerRabbitMQConsumer = "ecommerce-rabbitmq-consumer-1"
$containerRabbitMQ = "rabbitmq" # Nome do container SQL Server (em container Docker)
$containerSQL = "sqlserver" # Nome do container SQL Server (em container Docker)

# SQL Server (em container Docker)
$sqlServer = "localhost"
$sqlPort = 1433
$sqlDatabase = "master"
$sqlUser = "sa"
$sqlPassword = "YourPassword123!"

## Muda para o diretorio do teste
Set-Location $scriptPath

# Loop de execucoes
for ($i = 1; $i -le $repeatCount; $i++) {
    Write-Host "`n[$i/$repeatCount] Iniciando teste de estresse..."

    # Executa o k6 como processo separado, sem redirecionamento
    Start-Process -FilePath "cmd.exe" `
    -ArgumentList "/c start /high k6 run `"$k6Script`"" `
    -NoNewWindow `
    -Wait

    Write-Host "Teste $i finalizado. Limpando banco de dados..."

    # Execução dos deletes em ordem controlada
    #Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"DELETE FROM PagamentoDB.dbo.Pagamento;`""
    Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"DELETE FROM PedidoDB.dbo.ProdutoPedido;`""
    Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"DELETE FROM PedidoDB.dbo.Pedido;`""

    # Rebuild dos índices
    Write-Host "Reorganizando índices..."

    $rebuildQueries = @(
        "ALTER INDEX ALL ON PedidoDB.dbo.ProdutoPedido REBUILD;",
        "ALTER INDEX ALL ON PedidoDB.dbo.Pedido REBUILD;"
    )

    foreach ($query in $rebuildQueries) {
        Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"$query`""
    }

    Write-Host "Banco limpo e índices atualizados com sucesso!"

    if (($i % 10) -eq 0) {
        Write-Host "`nReiniciando container SQL para limpar cache (execução $i)..."
        docker restart $containerSQL
        Start-Sleep -Seconds 10

        $warmUpQueries = @(
        "SELECT TOP 1 * FROM PagamentoDB.dbo.Pagamento;",
        "SELECT TOP 1 * FROM PedidoDB.dbo.ProdutoPedido;",
        "SELECT TOP 1 * FROM PedidoDB.dbo.Pedido;"
        )

        foreach ($query in $warmUpQueries) {
            Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"$query`""
        }

        Write-Host "Banco aquecido com queries iniciais."

        docker restart $containerRabbitMQ
        start-sleep -Seconds 10

        docker restart $containerRabbitMQConsumer
        start-sleep -Seconds 10
    }

    if (($i % 5) -eq 0) {
        Write-Host "`nReiniciando containers para limpar cache (execução $i)..."
    
        $containers = @(
            $containerPedido1,
            $containerPedido2,
            $containerPedido3,
            $containerProduto1,
            $containerProduto2,
            $containerUsuario1,
            $containerPagamento1
        )
    
        foreach ($container in $containers) {
            Write-Host "Reiniciando container: $container"
            docker restart $container | Out-Null
        }
    
        Start-Sleep -Seconds 10
    }
    
}

Write-Host "`n Todas as execuções foram finalizadas com sucesso."