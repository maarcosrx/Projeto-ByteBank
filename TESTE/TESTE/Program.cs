using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace BankForAll {

    public class Program {
        static void Menu() {
            Console.WriteLine(" ");
            Console.WriteLine("1 - Criar contar");
            Console.WriteLine("2 - Deletar conta");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Consultar Saldo de todas as contas");
            Console.WriteLine("5 - Entrar na conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void Main(string[] args) {

            Console.WriteLine("Olá, bem vindo ao Bank For All.\n");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<double> saldos = new List<double>();
            List<string> senhas = new List<string>();
            int escolha;

            do {
                Menu();
                escolha = int.Parse(Console.ReadLine());

                switch (escolha) {
                    case 0:
                        Console.WriteLine("Até mais!");
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Precisamos de  algumas informações.\nPreencha os dados solicitados:\n");
                        RegistroNovoUsuario(cpfs, senhas, titulares, saldos);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        DeletarUsuario(cpfs, senhas, titulares, saldos);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine();
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        Console.WriteLine();
                        ConsultaSaldo(saldos);
                        break;
                    case 5:
                        Console.WriteLine();
                        TelaDeLogin(cpfs, senhas, titulares, saldos);
                        //criar ideias para a função logar
                        break;

                }

            } while (escolha != 0);

        }

        static void RegistroNovoUsuario(List<string> cpfs, List<string> senhas, List<string> titulares, List<double> saldos) {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite uma senha: ");
            senhas.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Seu saldo: ");
            double valor = double.Parse(Console.ReadLine());
            saldos.Add(valor);
            Console.Clear();
        }

        static void DeletarUsuario(List<string> cpfs, List<string> senhas, List<string> titulares, List<double> saldos) {
            Console.Write("Digite o cpf do titular que deseja deletar: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(d => d == cpfParaDeletar);

            if (indexParaDeletar == -1) {
                Console.WriteLine("Não foi possível deletar este cpf");
                Console.WriteLine("Conta não encontrada. Confira o cpf digitado");
            } else {
                cpfs.Remove(cpfParaDeletar);
                titulares.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);
                Console.WriteLine("Conta deletada com sucesso!");
            }
        }
        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos) {
            for (int i = 0; i < cpfs.Count; i++) {
                NewMethod(cpfs, titulares, saldos, i);
            }


        }

        private static void NewMethod(List<string> cpfs, List<string> titulares, List<double> saldos, int i) {
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R$ {saldos[i]:F2}");
            Console.WriteLine("____________________________________________________________________________");
        }

        static void ConsultaSaldo(List<double> saldos) {
            Console.WriteLine($"A soma dos saldos é de: {saldos.Sum()}");
        }

        private static void TelaDeLogin(List<string> cpfs, List<string> senhas, List<string> titulares, List<double> saldos) {
            Console.Write("Para acessar sua conta, digite o cpf: ");
            string cpfParaLogin = Console.ReadLine();
            int indexParaLogar = cpfs.FindIndex(c => c == cpfParaLogin);
            Console.Write("Digite a senha: ");
            string conferirSenha = Console.ReadLine();
            int u = cpfs.IndexOf(cpfParaLogin);
            double saldo = saldos[indexParaLogar];
            if (senhas[indexParaLogar] == conferirSenha) {
                Console.WriteLine();

                Conta(cpfs, titulares, saldos, u, saldo);
            } else {
                Console.WriteLine("Senha incorreta.");
            }



            static void Conta(List<string> cpfs, List<string> titulares, List<double> saldos, int u, double saldo) {
                Console.Clear();
                MenuConta(saldo);
                int escolha = int.Parse(Console.ReadLine());
                do {

                    switch (escolha) {
                        case 1:
                            Console.WriteLine();
                            Pix(cpfs, saldos, u);
                            break;
                        case 2:
                            Console.WriteLine();
                            Saque(cpfs, saldos, u, saldo);
                            break;
                        case 3:
                            Console.WriteLine();
                            Deposito(cpfs, saldos, u);
                            break;
                        case 4:
                            Menu();
                            break;
                    }
                    Console.Clear();
                    MenuConta(saldo);
                    escolha = int.Parse(Console.ReadLine());

                } while (escolha != 4);



            }
            static void MenuConta(double saldo) {
                Console.WriteLine("1 - Pix");
                Console.WriteLine("2 - Saque");
                Console.WriteLine("3 - deposito");
                Console.WriteLine("4 -  Retornar a tela inicial\n");
                Console.WriteLine($"Seu saldo é: {saldo}\n"); // fazer atualização de saldos
                Console.Write("Digite a ação desejada: ");
            }

            static void Pix(List<string> cpfs, List<double> saldos, int u) {
                Console.Write("Digite o cpf do titular que deseja realizar a tranferência: ");
                string cpfPix = Console.ReadLine();
                Console.Write("Quanto deseja transferir? R$ ");
                double valorPix = double.Parse(Console.ReadLine());
                while (!cpfs.Contains(cpfPix)) {
                    Console.WriteLine("Usuário não encontrado, confira os números digitados");
                    cpfPix = Console.ReadLine();
                }
                int r = cpfs.IndexOf(cpfPix);
                saldos[u] -= valorPix;
                saldos[r] += valorPix;
                Console.WriteLine("Transferência concluída!");

            }
            static void Saque(List<string> cpfs, List<double> saldos, int u, double saldo) {
                Console.Write("O quando deseja sacar?\nR$ ");
                double saque = double.Parse(Console.ReadLine());
                saldos[u] -= saque;
                saldo -= saque;
            }
            static void Deposito(List<string> cpfs, List<double> saldos, int u) {
                Console.Write("O quanto deseja depositar?\nR$ ");
                double deposito = double.Parse(Console.ReadLine());
                saldos[u] += deposito;
            }



        }

    }


}