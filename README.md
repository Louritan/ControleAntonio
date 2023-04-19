# ControleAntonio
Exercício de controle de gastos utilizando .NET 5.0:
Antônio controla os gastos mensais com sua conta de luz em uma planilha Excel. Para cada conta de luz cadastra-se: data em que a leitura do relógio de luz foi realizada, número da leitura (identificador único sem auto incremento), quantidade de Kw gasto no mês, valor a pagar pela conta, data do pagamento e média de consumo.

Crie um sistema para auxiliar Antônio nessa gestão, atenção para os critérios de aceite de negócio:

- O sistema deve solicitar que todas as informações da conta de luz sejam preenchidas;
- O sistema não deve permitir que sejam cadastradas mais que uma conta de luz para mesmos mês e ano;
- O sistema deve permitir que o Antônio consulte a conta de um mês e ano específico, caso não exista, deve informar ao usuário que não foi cadastrado;

Critérios de aceite técnico:

- O sistema deve contar com dados persistidos em banco de dados. O desenvolvedor deve modelar e criar o banco de dados;
- O sistema deve utilizar as três camadas aprendidas na aula: apresentação, domínio (negócio) e acesso a dados;
- O desenvolvedor deve respeitar a responsabilidade de cada camada colocando nela apenas ao que a compete;
- O sistema deve utilizar DAO's para acesso aos dados;
- O sistema deve utilizar o padrão Repository;
- O sistema deve utiliza o paradigma de orientação a objetos;
