using System;
using ControleAntonio.Domain;
using ControleAntonio.Infra.Data;
using System.Collections.Generic;

namespace ControleAntonio.ConsoleApp
{
    class Program
    {
        private static ContaDeLuzRepository contaRepository = new ContaDeLuzRepository();

        static void Main(string[] args)
        {
            var opcao = string.Empty;

            do
            {
                Console.Clear();
                System.Console.WriteLine("============= MENU =============");
                System.Console.WriteLine("1 > Cadastrar conta");
                System.Console.WriteLine("2 > Buscar contas");
                System.Console.WriteLine("3 > Buscar conta por número da leitura");
                System.Console.WriteLine("4 > Buscar conta por data");
                System.Console.WriteLine("5 > Atualizar conta");
                System.Console.WriteLine("6 > Deletar conta");
                System.Console.WriteLine("7 > Deletar todas as contas");
                System.Console.WriteLine("8 > Sair");
                System.Console.WriteLine("================================");
                Console.Write("> ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarConta();
                        break;
                    case "2":
                        BuscarContas();
                        break;
                    case "3":
                        BuscarContaPorNumero();
                        break;
                    case "4":
                        BuscarContaPorData();
                        break;
                    case "5":
                        AtualizarConta();
                        break;
                    case "6":
                        DeletarConta();
                        break;
                    case "7":
                        DeletarTodos();
                        break;
                    case "8":
                        Console.Clear();
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida.");
                        PressioneContinuar();
                        break;
                }
            } while (opcao != "8");
        }

        private static void CadastrarConta()
        {
            Console.Clear();

            System.Console.WriteLine("======== CADASTRAR CONTA =======");

            System.Console.WriteLine("Digite o número da leitura:");
            var numeroLeitura = Convert.ToInt64(Console.ReadLine());

            var existe = contaRepository.VerificarSeExisteContaNumero(numeroLeitura);

            if (existe)
            {
                System.Console.WriteLine("Esse número da leitura já existe.");
                PressioneContinuar();
                return;
            }

            System.Console.WriteLine("Digite a data da leitura (AAAA-MM-DD):");
            var dataLeitura = Convert.ToDateTime(Console.ReadLine());

            existe = contaRepository.VerificarSeExisteContaData(dataLeitura.Month, dataLeitura.Year);

            if (existe)
            {
                System.Console.WriteLine("Essa data da leitura já existe.");
                PressioneContinuar();
                return;
            }

            System.Console.WriteLine("Digite a data de pagamento (AAAA-MM-DD):");
            var dataPagamento = Convert.ToDateTime(Console.ReadLine());

            System.Console.WriteLine("Digite a quantidade de KW gasto no mês:");
            var kwGastoMes = Convert.ToDouble(Console.ReadLine());

            System.Console.WriteLine("Digite o valor:");
            var valor = Convert.ToDouble(Console.ReadLine());

            System.Console.WriteLine("Digite a média de consumo:");
            var mediaConsumo = Convert.ToDouble(Console.ReadLine());

            var conta = new ContaDeLuz(numeroLeitura, dataLeitura, dataPagamento, kwGastoMes, valor, mediaConsumo);
            contaRepository.CadastrarConta(conta);

            System.Console.WriteLine("Conta cadastrada com sucesso!");
            
            PressioneContinuar();
        }

        private static void BuscarContas()
        {
            Console.Clear();

            System.Console.WriteLine("====== CONTAS CADASTRADAS ======");

            var listaContas = new List<ContaDeLuz>();

            listaContas = contaRepository.BuscarTodos();

            foreach (var conta in listaContas)
            {
                System.Console.WriteLine(conta);
            }

            PressioneContinuar();
        }

        private static void BuscarContaPorNumero()
        {
            Console.Clear();

            System.Console.WriteLine("========= BUSCAR CONTA =========");

            System.Console.WriteLine("Digite o número da leitura:");
            var numeroLeitura = Convert.ToInt64(Console.ReadLine());

            var conta = contaRepository.BuscarContaNumero(numeroLeitura);

            if (conta == null)
            {
                System.Console.WriteLine("Conta não existe.");
            }
            else
            {
                System.Console.WriteLine(conta);
            }

            PressioneContinuar();
        }

        private static void BuscarContaPorData()
        {
            Console.Clear();

            System.Console.WriteLine("========= BUSCAR CONTA =========");

            System.Console.WriteLine("Digite o mês da leitura:");
            var mes = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Digite o ano da leitura:");
            var ano = Convert.ToInt32(Console.ReadLine());

            var conta = contaRepository.BuscarContaData(mes, ano);

            if (conta == null)
            {
                System.Console.WriteLine("Conta não existe.");
            }
            else
            {
                System.Console.WriteLine(conta);
            }

            PressioneContinuar();
        }

        private static void AtualizarConta()
        {
            Console.Clear();

            System.Console.WriteLine("======== ATUALIZAR CONTA =======");

            System.Console.WriteLine("Digite o número da leitura:");
            var numeroLeitura = Convert.ToInt64(Console.ReadLine());

            var existe = contaRepository.VerificarSeExisteContaNumero(numeroLeitura);

            if (!existe)
            {
                System.Console.WriteLine("Conta não existe.");
                PressioneContinuar();
                return;
            }

            System.Console.WriteLine("Digite a data da leitura (AAAA-MM-DD):");
            var dataLeitura = Convert.ToDateTime(Console.ReadLine());

            System.Console.WriteLine("Digite a data de pagamento (AAAA-MM-DD):");
            var dataPagamento = Convert.ToDateTime(Console.ReadLine());

            System.Console.WriteLine("Digite a quantidade de KW gasto no mês:");
            var kwGastoMes = Convert.ToDouble(Console.ReadLine());

            System.Console.WriteLine("Digite o valor:");
            var valor = Convert.ToDouble(Console.ReadLine());

            System.Console.WriteLine("Digite a média de consumo:");
            var mediaConsumo = Convert.ToDouble(Console.ReadLine());

            var conta = new ContaDeLuz(numeroLeitura, dataLeitura, dataPagamento, kwGastoMes, valor, mediaConsumo);
            contaRepository.AtualizarConta(conta);

            System.Console.WriteLine("Conta atualizada com sucesso!");

            PressioneContinuar();
        }

        private static void DeletarConta()
        {
            Console.Clear();

            System.Console.WriteLine("======== DELETAR CONTA =========");

            bool deletado = false;

            var listaContas = new List<ContaDeLuz>();

            System.Console.WriteLine("Digite o número da leitura:");
            var numeroLeitura = Convert.ToInt64(Console.ReadLine());

            listaContas = contaRepository.BuscarTodos();

            foreach (var conta in listaContas)
            {
                if (conta.NumeroLeitura == numeroLeitura)
                {
                    contaRepository.DeletarConta(conta);
                    deletado = true;
                    break;
                }
            }

            System.Console.WriteLine(deletado ? "Conta deletada!" : "Conta não encontrada");
            PressioneContinuar();
        }

        private static void DeletarTodos()
        {
            Console.Clear();

            contaRepository.DeletarTodos();

            System.Console.WriteLine("Contas deletadas!");

            PressioneContinuar();
        }

        private static void PressioneContinuar()
        {
            System.Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
