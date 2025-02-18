# 📦 API de Produção 
![badge](https://img.shields.io/endpoint?url=https://gist.githubusercontent.com/victoromc/bd5447fccccec9b660124c91b3d27ae3/raw/pedidos-code-coverage.json)

## Objetivos

Este repositório contém a API de produção, desenvolvida utilizando .NET 8. O processo de build, publicação e deployment funciona via workflow no GitHub Actions.

## Requisitos

Para rodar o sistema localmente, você precisará de:

- Uma IDE compatível, como IntelliJ IDEA, Eclipse, ou VS Code, para baixar e abrir o repositório.
- [Docker](https://docs.docker.com/engine/install/), [Kubernetes](https://kubernetes.io/docs/setup/), e AWS-CLI instalados para a execução da infraestrutura.

## Como Executar o Projeto Localmente

- Restaurar Dependências:
  
```sh
dotnet restore src/Pedidos.Api/Pedidos.Api.csproj
```

- Compilar o projeto:

```sh
dotnet build src/Pedidos.Api/Pedidos.Api.csproj -c Release --no-restore
```

- Executar testes:

```sh
dotnet test Pedidos.sln -c Release --no-build --no-restore
```

- Executar API localemte:

```sh
dotnet run --project src/Pedidos.Api/Pedidos.Api.csproj
```


## Execução com Docker

- Build da Imagem:

```sh
docker build -t pedidos-api .
```

- Execute o container:

```sh
docker run -p 5000:5000 pedidos-api
```


## Deploy local no Cluster EKS

- Configurar Profile da AWS editando o arquivo `.aws/config`:

```sh
[profile_name]
access_key = ""
secret_key = ""
region = us-east-1
output = json
```

```sh
- Atualizar o `kubeconfig`para acesso ao Cluster:

aws eks update-kubeconfig --region (region-name) --name (cluster-name) --profile (name);
```

- Aplicar os manifestos:

```sh
kubectl apply -f iac/kubernetes/
```

- Verificar status dos pods em execução:

```sh
kubectl get pods -n fast-order
```


## Workflows

---

### - 1.Build and Push Docker Images

- O workflow é acionado manualmente via `workflow_dispatch`.

- Realiza o checkout do repositório.

- Configura o .NET 8 no ambiente.

- Restaura dependências e compila o projeto.

- Publica o projeto .NET para a pasta app/publish.

- Faz login no Docker Hub utilizando credenciais armazenadas como secrets.

- Garante a existência da pasta certs.

- Constrói a imagem Docker com duas tags:

`latest`

`SHA do commit atual`

- Faz o push das imagens para o Docker Hub.


### - 2.Coverage Report

- Acionado automaticamente ao realizar push nas branches `main` e `feat/badge`.

- Faz checkout do repositório.

- Configura o .NET 8 no ambiente.

- Restaura dependências e compila o projeto.

- Executa os testes unitários com cobertura de código.

- Gera um badge de cobertura de código e atualiza um `Gist`.

- Instala a ferramenta `ReportGenerator`.

- Gera relatórios de cobertura em formato `HTML` e `Badges`.

- Faz upload do relatório como um artefato do `GitHub Actions`.


### - 3. Deploy To AWS EKS Cluster

- O workflow é acionado manualmente via `workflow_dispatch`.

- Faz checkout do código-fonte.

- Instala o `kubectl`.

- Instala a `AWS CLI`.

- Configura as credenciais da AWS.

- Atualiza o `kubeconfig` para acessar o cluster EKS.

- Verifica a configuração do `kubectl` e os nodes do cluster.

- Aplica os manifests Kubernetes armazenados na pasta `iac/kubernetes/`.

- Aguarda a conclusão do rollout do `deployment pedidos-dep` no `namespace fast-order`.    


## Estrutura dos diretórios

```sh
/
├── src/
│   ├── Producao.Api/               # Projeto principal da API
│   │   ├── Producao.Api.csproj     # Arquivo de projeto do .NET
│   ├── Producao.Tests/             # Testes unitários
│
├── iac/
│   ├── kubernetes/                 # Manifests do Kubernetes para deployment
│   │   ├── namespace.yaml
│   │   ├── deployment.yaml
│   │   ├── service.yaml
│   │   ├── outros arquivos de configuração
│
├── .github/workflows/              # Workflows do GitHub Actions
│   ├── build-and-push.yml          # Workflow de build e push do Docker
│   ├── coverage-report.yml         # Workflow de testes e cobertura
│   ├── deploy-eks.yml              # Workflow de deploy no EKS

```sh
