# Aspnetcore Healthchecks and Metrics

Api  usando AspnetCore  contendo healthchecks e métricas usando [Prometheus](https://prometheus.io/) e [Grafana](https://grafana.com/)

#HealthChecks

- [X] Saúde da própria api.
- [X] Consumo de memória da aplicação.
- [X] Saúde de chamada a serviço externo.
- [X] Saúde de conexão a banco de dados Sql Server.

#Métricas

- [X] Métricas utilizando o pacote [prometheus-net.AspnetCore](https://github.com/prometheus-net)
- [X] Obtenção de dados de healthchecks usando o pacote [prometheus-net.AspnetCore.HealthChecks](https://github.com/prometheus-net/prometheus-net)


#Criação da imagem da aplicação

- [x] Ter uma conta no [docker Hub](https://hub.docker.com/)

> A aplicação deve conter um arquivo  *_dockerfile_* contendo os passos de build e release.
Deve-se também efetuar a criação da imagem no docker usando os seguintes comandos:

*Efetuar o login:*

```
docker login
````
*Criar a imagem:*

```
docker image build -t user_dockerhub/nome-sua-api:tag .
```
```
docker image build -t jhonDoe/my-api:v1 .
```
*Enviar para o docker Registry :*

```
docker push nome_imagem
````

**O nome da imagem criada deve ser inserida no docker-compose logo após a sua subida para o docker registry.


Após a criação da imagem , fazer o envio para o dockerhub

```
docker image build -t jhonDoe/my-api:v1 .
```

#Execução da aplicação

> A estrutura da aplicação contém um arquivo chamado _docker-compose.yml_ que contém as estruturas que devem ser criadas com containers.

> Para Executar o arquivo basta usar o seguinte comando na raiz da aplicação:

```
docker-compose up -d
```

> Para fazer acesso a aplicação basta acessar o endereço:

```

```

> Para fazer acesso ao Prometheus basta acessar o endereço:

```
http://localhost:9090
```

> Para fazer acesso ao Grafana basta acessar o endereço:

```
http://localhost:3000
```

#Configurar Prometheus como Data Source no Grafana

> É necessário efetuar a configuração do Prometheus dentro do Grafana. Efetuar o login com o _user_ **_admin_** e _senha_ **_P@ssw0rd_**

> Ir na aba configuration  Data Sources e escolha o data source do Prometheus. No campo url colocar a http://prometheus:9090 e clicar em *"Save & test"* . Dando tudo certo, O Grafana irá mostrar a mensagem *Data source is working* .

#Criar a dashboard para mostrar as métricas

> Para efetuar a criação da dashboard das métricas é necessário ir na opção *Create -> Import* . Para importar o dashboard usada, vamos inserir a numeração *_10427_* para buscar do site do grafana e clicar em *Load*




