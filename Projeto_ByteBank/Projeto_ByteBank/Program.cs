using System.Diagnostics;

namespace ByteBank {
    public class Program {

        static void Menu() {
            Console.WriteLine("----------- Escolha uma opção abaixo ------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.WriteLine("");
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("");

        }
        static void CadastroUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {

            Console.Write("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite uma senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);

        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("Digite o CPF: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1) {
                Console.WriteLine("Não foi possível deletar essa conta");
                Console.WriteLine("MOTIVO: Titular não encotrado");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso.");
        }


        static void ListarUsuarios(List<string> cpfs, List<string> titulares, List<double> saldos) {
            for (int i = 0; i < cpfs.Count; i++) {
                Console.WriteLine($"CPF = {cpfs[i]} | Titulares = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos) {
            Console.Write("Digite o CPF: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpfs => cpfs == cpfParaApresentar);

            if (indexParaApresentar == -1) {
                Console.WriteLine("Não foi possível apresentar essa conta");
                Console.WriteLine("MOTIVO: Conta não encontrada");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos) {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static void SaldoAcumulado(List<double> saldos) {
            Console.WriteLine($"O saldo do total banco é: {saldos.Sum()}");

        }

        static void SubMenu() {
            Console.WriteLine("----------- Escolha uma opção abaixo ------------");            
            Console.WriteLine($"Realizar saque --------------------------------(1)"); //Funcionando
            Console.WriteLine($"Realizar depósito -----------------------------(2)"); //Funcionando
            Console.WriteLine($"Transferências --------------------------------(3)"); //Funcionando            
            Console.WriteLine($"Encerrar atendimento --------------------------(4)"); //Funcionando
            Console.WriteLine("---------------------------------------------------");
        }

        static void Login(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("Faça Login para continuar...\n"+
                          "Digite o CPF do titular: ");
            string cpfLogin = Console.ReadLine();
            int indexCpfLogin = cpfs.FindIndex(c => c == cpfLogin);
            Console.Write("Digite a senha: ");
            string senhaLogin = Console.ReadLine();
            int x = cpfs.IndexOf(cpfLogin);
            double saldo = saldos[indexCpfLogin];
            if (senhas[indexCpfLogin] == senhaLogin) {
                Console.WriteLine();
                ManipularConta(cpfs, titulares, saldos, x, saldo);
            } else {
                Console.WriteLine("CPF ou senha incorreto.");
            }
        }

        static void ManipularConta(List<string> cpfs, List<string> titulares, List<double> saldos, int x, double saldo) {
            Console.Clear();
            SubMenu();
            int opcao = int.Parse(Console.ReadLine());
            do {
                switch (opcao) {
                    case 1:
                        Console.WriteLine();
                        Saque(cpfs, saldos, x, saldo);
                        break;
                    case 2:
                        Console.WriteLine();
                        Deposito(cpfs, saldos, x);
                        break; 
                    case 3:
                        Console.WriteLine();
                        Transferir(cpfs, saldos, x);
                        break;
                }


            } while (opcao != 4);
        }

        static void Saque(List<string> cpfs, List<double> saldos, int x, double saldo) {
            Console.Write("Qual valor do saque? ");
            double saque = double.Parse(Console.ReadLine());
            if(saque < saldo)
            saldos[x] -= saque;
            saldo-= saque; 
        }

        static void Deposito(List<string> cpfs, List<double> saldos, int x) {
            Console.Write("Qual valor deseja depositar? ");
            double deposito = double.Parse(Console.ReadLine());
            saldos[x] -= deposito;
        }

        static void Transferir(List<string> cpfs, List<double> saldos, int x) {
            Console.Write("Qual valor deseja transferir? ");
            double transferencia = double.Parse(Console.ReadLine());
            saldos[x] -= transferencia;
        }


        public static void Main(string[] args) {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            double saldo = 0.0;
            double deposito = 0.0;
            double saque = 0.0;
            double valorTranferencia = 0.0;

            int opcaoPrincipal;

            do {
                Menu();
                opcaoPrincipal = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (opcaoPrincipal > 6) {
                    Console.WriteLine("Opção inválida.");
                    Console.WriteLine("");
                }
                switch (opcaoPrincipal) {
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    case 1:
                        CadastroUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarUsuarios(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        SaldoAcumulado(saldos);
                        break;
                    case 6:
                        Login(cpfs, titulares, senhas, saldos);
                        break;

                }

            } while (opcaoPrincipal != 0);









            //do {                
            //    Menu();
            //    opcao = int.Parse(Console.ReadLine()); 
            //    if(opcao > 4) {
            //        Console.WriteLine("Opção inválida.");
            //        Console.WriteLine(" ");
            //    }
            //    switch (opcao) {
            //        case 1:
            //            Console.WriteLine($"Seu saldo é {saldo:f2}");
            //            Console.WriteLine("");
            //            break;
            //        case 2:
            //            Console.Write($"Digite o valor do saque: ");
            //            Console.WriteLine("");
            //            saque = double.Parse(Console.ReadLine());
            //            if (saque > saldo) {
            //                Console.WriteLine("ERRO: Saldo indisponível.");
            //                Console.WriteLine("");
            //            } else {
            //                Console.WriteLine($"Valor sacado {saque:f2}");
            //                Console.WriteLine("");
            //                saldo -= saque;
            //                Console.WriteLine($"Seu saldo atual é {saldo:f2}");
            //                Console.WriteLine("");
            //            }                        
            //            break;
            //        case 3:
            //            Console.Write("Valor a depositar: ");
            //            deposito = double.Parse(Console.ReadLine());
            //            if (deposito <= 0) {
            //                Console.WriteLine("ERRO: Valor incorreto.");
            //                Console.WriteLine("");
            //            } else {
            //                saldo += deposito; 
            //                Console.WriteLine($"Saldo Atual: {saldo:f2}");
            //                Console.WriteLine("");
            //            }
            //            break;
            //        case 4:
            //            Console.Write("Digite o número da conta: ");
            //            int conta = int.Parse(Console.ReadLine());                        
            //            Console.Write($"Digite o dígito: {conta}-");
            //            int digito = int.Parse(Console.ReadLine());
            //            Console.WriteLine($"Conta para transferência: {conta}-{digito}");
            //            Console.Write("Valor: ");
            //            valorTranferencia = double.Parse(Console.ReadLine());

            //            if(valorTranferencia > saldo){
            //                Console.WriteLine("Saldo indisponivel");
            //                Console.WriteLine("");
            //            } else {
            //                saldo -= valorTranferencia;
            //                Console.WriteLine("Tranfereência Realizada");
            //                Console.WriteLine($"Conta: {conta}-{digito}");
            //                Console.WriteLine($"Valor: {valorTranferencia}");
            //                Console.WriteLine("");
            //            }
            //            break;
            //    }
            //} while (opcao != 0);

        }
    }
}