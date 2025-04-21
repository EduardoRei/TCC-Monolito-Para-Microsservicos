param (
    [int]$repeatCount = 30  # Numero de execucoes (padrao = 1)
)

# Configuracoes
$scriptPath = "insert-path-here"
$k6Script = ".\MonolitoStressTest.js"

# Nome real do container Docker
$containerMonolito = "ecommerce-monolito-1"
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
    Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"DELETE FROM ECommerceDB.dbo.Pagamento;`""
    Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"DELETE FROM ECommerceDB.dbo.ProdutoPedido;`""
    Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"DELETE FROM ECommerceDB.dbo.Pedido;`""

    # Rebuild dos índices
    Write-Host "Reorganizando índices..."

    $rebuildQueries = @(
        "ALTER INDEX ALL ON ECommerceDB.dbo.Pagamento REBUILD;",
        "ALTER INDEX ALL ON ECommerceDB.dbo.ProdutoPedido REBUILD;",
        "ALTER INDEX ALL ON ECommerceDB.dbo.Pedido REBUILD;"
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
        "SELECT TOP 1 * FROM ECommerceDB.dbo.Pagamento;",
        "SELECT TOP 1 * FROM ECommerceDB.dbo.ProdutoPedido;",
        "SELECT TOP 1 * FROM ECommerceDB.dbo.Pedido;"
        )

        foreach ($query in $warmUpQueries) {
            Invoke-Expression "sqlcmd -S $sqlServer,$sqlPort -d $sqlDatabase -U $sqlUser -P $sqlPassword -Q `"$query`""
        }

        Write-Host "Banco aquecido com queries iniciais."
    }

    # Reinicia o container a cada 5 execuções
    if (($i % 5) -eq 0) {
        Write-Host "`nReiniciando container para limpar cache do monolito (execução $i)..."
        docker restart $containerMonolito
        Start-Sleep -Seconds 10
    }
}

Write-Host "`n Todas as execuções foram finalizadas com sucesso."