# Hotel e Estacionamento

Este projeto é uma aplicação de console que gerencia reservas de hotel e estacionamento de veículos. Ele permite cadastrar hóspedes, suítes, veículos e calcular valores de diárias e estacionamento.

## Estrutura do Projeto

### Hotel

- **Models/Reserve.cs**
  - `CreatePerson()`: Cria uma nova pessoa solicitando o nome e sobrenome.
  - `RegisterHosting()`: Registra a quantidade de diárias.
  - `CalculateDailyRate()`: Calcula o valor da diária com base na quantidade de dias reservados.
  - `AddSuite()`: Adiciona uma nova suíte solicitando nome, capacidade e valor da diária.
  - `GetNumberOfGuests()`: Exibe o número de hóspedes na suíte.
  - `AddGuest()`: Adiciona um novo hóspede à suíte, se houver capacidade.

### Estacionamento

- **Models/VehicleParking.cs**
  - `LoadMenu()`: Exibe o menu de opções para o estacionamento.
  - `Register()`: Registra um novo veículo solicitando a placa.
  - `List()`: Lista todos os veículos estacionados.
  - `Unregister()`: Remove um veículo do estacionamento solicitando a placa e o tempo de permanência.

## Como Executar

1. Clone o repositório para sua máquina local.
2. Abra o projeto no Visual Studio.
3. Compile e execute o projeto.
4. Siga as instruções exibidas no console para interagir com o sistema.

## Funcionalidades

### Hotel

- **Cadastrar Hóspede**: Permite cadastrar um novo hóspede.
- **Registrar Diárias**: Permite registrar a quantidade de diárias.
- **Calcular Valor da Diária**: Calcula o valor total da estadia com base nas diárias.
- **Adicionar Suíte**: Permite adicionar uma nova suíte ao sistema.
- **Exibir Número de Hóspedes**: Exibe o número de hóspedes na suíte.
- **Adicionar Hóspede à Suíte**: Adiciona um hóspede à suíte, se houver capacidade.

### Estacionamento

- **Cadastrar Veículo**: Permite cadastrar um novo veículo.
- **Listar Veículos**: Lista todos os veículos estacionados.
- **Remover Veículo**: Remove um veículo do estacionamento e calcula o valor a ser pago.

## Contribuição

Sinta-se à vontade para contribuir com o projeto. Para isso, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma nova branch: `git checkout -b minha-nova-funcionalidade`.
3. Faça suas alterações e commit: `git commit -m 'Adiciona nova funcionalidade'`.
4. Envie para o repositório original: `git push origin minha-nova-funcionalidade`.
5. Crie um pull request.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
