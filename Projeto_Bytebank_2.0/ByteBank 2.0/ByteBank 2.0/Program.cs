namespace ByteBank_2 {
    public class Program {
        static void Menu() {
            Console.WriteLine();
            Console.WriteLine("1 - Criar contar");
            Console.WriteLine("2 - Deletar conta");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Consultar Saldo de todas as contas");
            Console.WriteLine("5 - Entrar na conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            Console.WriteLine();
        }

        static void Main(string[] args) {
            Console.WriteLine("--- Bem vindo ao ByteBank ---");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();
            int opcao;

            do {
                Menu();
                opcao = int.Parse(Console.ReadLine());           

                switch (opcao) {
                    case 0:
                        Console.WriteLine("Encerrando o programa\n" +
                                          "Obrigado por usar!");
                        break;

                    case 1:
                        CadastrarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarContas(cpfs, titulares, saldos);
                        break;                        
                    case 4:
                        SaldoAcumulado(saldos);
                        break;
                    case 5:
                        Login(cpfs, titulares, senhas, saldos);
                        break;
                }
            } while (opcao != 0);

        }

        static void CadastrarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("Digite o CPF a ser cadastrado: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite uma senha: ");
            senhas.Add(Console.ReadLine());
            Console.Write("Digite o nome do titular: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Seu saldo: ");
            int valor = int.Parse(Console.ReadLine());
            saldos.Add(valor);
            Console.Clear();
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("insira o CPF: ");
            string cpfDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfDeletar);

            if(indexParaDeletar == -1) {
                Console.WriteLine("Não foi possível deletar essa conta");
                Console.WriteLine("MOTIVO: Conta inexistente");    
            }

            cpfs.Remove(cpfDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso.");            
        }

        static void ListarContas(List<string> cpfs, List<string> titulares, List<double> saldos) {
            for(int i = 0; i < cpfs.Count; i++) {
                Console.WriteLine($"CPF: {cpfs[i]} | Titulares: {titulares[i]} | Saldo: R$ {saldos[i]:F2}");
            }            
        }

        static void SaldoAcumulado(List<double> saldos) {
            Console.WriteLine($"O saldo total armazenado no banco é de R${saldos.Sum()}");            
        }

        static void Login(List<string> cpfs, List<string> titulares,List<string> senha, List<double> saldos) {
            Console.Write("Faça login para continuar...\n"+
                          "Digite o CPF: ");
            string cpfLogin = Console.ReadLine();
            int indexLogin = cpfs.FindIndex(c => c == cpfLogin);
            Console.Write("Digite a senha: ");
            string senhaLogin = Console.ReadLine();
            int x = cpfs.IndexOf(cpfLogin);
            double saldo = saldos[indexLogin];

            if (senha[indexLogin] == senhaLogin) {
                Console.WriteLine();
                Conta(cpfs, titulares, senha, saldos, x, saldo);
            } else {
                Console.WriteLine("CPF ou senha incorreta");
            }

            static void Conta(List<string> cpfs, List<string> titulares, List<string> senha, List<double> saldos, int x, double saldo) {

                int opcao;
                do {
                    Console.Clear();
                    MenuConta(cpfs, saldos, x);
                    opcao = int.Parse(Console.ReadLine());

                    switch(opcao) {
                        case 1:
                            Transferencia(cpfs, saldos, x);
                            break;
                        case 2:
                            Deposito(cpfs, saldos, x);
                            break;
                        case 3:
                            Saque(cpfs, saldos, x);
                            break;
                        case 4:
                            Console.WriteLine("Saindo da sua conta.....");
                            Console.WriteLine("Logout realizado com sucesso! Aperte qualquer tecla....");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();

                } while (opcao != 4);
            }

            static void MenuConta(List<string> cpfs, List<double> saldos, int x ) {
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
                Console.WriteLine("Escolha uma das opções abaixo: ");
                Console.WriteLine("Transferência ------------- (1)");
                Console.WriteLine("Deposito ------------------ (2)");
                Console.WriteLine("Saque --------------------- (3)");
                Console.WriteLine("Realizar Logout ----------- (4)");
                Console.WriteLine();
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Saldo R${saldos[x]}");
            }
            
            static void Transferencia(List<string> cpfs, List<double> saldos, int x) {
                Console.Write("Digite o CPF do titular que receberá a transferência: ");
                string cpfTransferencia = Console.ReadLine();
                Console.Write("Qual valor da transferência? R$ ");
                double valorTransferencia = double.Parse(Console.ReadLine());
                while (!cpfs.Contains(cpfTransferencia)) {
                    Console.WriteLine("Usuário não encontrado, confira os números digitados");
                    cpfTransferencia = Console.ReadLine();
                }
                int z = cpfs.IndexOf(cpfTransferencia);
                saldos[x] -= valorTransferencia;
                saldos[z] += valorTransferencia;
                Console.WriteLine("Transferência concluída");
                Console.WriteLine($"Saldo atual R$ {saldos[x]}");
                Console.WriteLine("Aperte qualquer tecla para voltar...");
                Console.ReadKey();                
            }

            static void Saque(List<string> cpfs, List<double> saldos, int x) {
                Console.Write("Qual valor do saque?\nR$ ");
                double saque = double.Parse(Console.ReadLine());
                saldos[x] -= saque;
                Console.WriteLine($"Saque efetuado com sucesso\n"+$"Saldo atual R$ {saldos[x]}");
                Console.WriteLine("Aperte qualquer tecla para voltar...");
                Console.ReadKey();
            }

            static void Deposito(List<string> cpfs, List<double> saldos, int x) {
                Console.Write("O quanto deseja depositar?\nR$ ");
                double deposito = double.Parse(Console.ReadLine());
                saldos[x] += deposito;
                Console.WriteLine($"Depósito efetuado com sucesso\n"+$"Saldo atual R$ {saldos[x]}");
                Console.WriteLine("Aperte qualquer tecla para voltar...");
                Console.ReadKey();
            }
        }
    }
}