# Instruções de Configuração e Implantação do Aplicativo ASP.NET Core em ECS Fargate na AWS

Este documento fornece instruções passo a passo para configurar e implantar um aplicativo ASP.NET Core em um ECS Fargate na AWS, utilizando um pipeline de CI/CD completo.

## Pré-requisitos

- Conta da AWS
- Git instalado localmente
- Docker instalado localmente
- Conhecimento básico de Docker e AWS

## Configuração do Projeto

1. Clone o repositório do aplicativo ASP.NET Core para o seu ambiente local.

2. Certifique-se de que o aplicativo tenha uma estrutura compatível com Docker e um arquivo `Dockerfile` configurado corretamente.

## Configuração da AWS

### 1. Configuração do Cluster ECS Fargate

- Crie um cluster ECS Fargate na AWS.


### 2. Configuração do Load Balancer

- Configure um load balancer na AWS para rotear o tráfego para os contêineres ECS Fargate.

### 3 Configuração do Pipeline de CI/CD

- Configure um pipeline de CI/CD na AWS usando AWS CodePipeline, AWS CodeBuild e AWS CodeDeploy para automatizar a construção e implantação do aplicativo em ECS Fargate. 
OBS: o build precisa ser realizado no CI/CD da AWS e não no dockerfile atual.

- Configure regras de implantação automática no AWS CodeDeploy para aumentar ou diminuir o número de tarefas ECS Fargate com base na carga de tráfego.

- Configure métricas de monitoramento e alertas no Amazon CloudWatch para monitorar o desempenho do aplicativo e do cluster ECS Fargate.

## Execução do Projeto

1. Inicie o pipeline de CI/CD para construir e implantar o aplicativo ASP.NET Core no ECS Fargate.

2. Após a conclusão bem-sucedida do pipeline, seu aplicativo estará implantado e pronto para uso.

## PROEJTO UpperStack

