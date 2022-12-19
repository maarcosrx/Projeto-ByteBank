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

        static void ListarUsuarios(List<string> cpfs, List<string> titulares, List<double> saldos) {
            for(int i = 0; i < cpfs.Count; i++) {
                Console.WriteLine($"CPF = {cpfs[i]} | Titulares = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
        }       

        //static void SubMenu() {
        //    Console.WriteLine("----------- Escolha uma opção abaixo ------------");
        //    Console.WriteLine($"Consultar seu saldo ---------------------------(1)"); //Funcionando
        //    Console.WriteLine($"Realizar saque --------------------------------(2)"); //Funcionando
        //    Console.WriteLine($"Realizar depósito -----------------------------(3)"); //Funcionando
        //    Console.WriteLine($"Transferências --------------------------------(4)"); //Funcionando
        //    Console.WriteLine($"Encerrar atendimento --------------------------(0)"); //Funcionando
        //    Console.WriteLine("---------------------------------------------------");
        //}


        public static void Main(string[] args) {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            //double saldo = 0.0;            
            //double deposito = 0.0;
            //double saque = 0.0;
            //double valorTranferencia = 0.0;

            int opcao;

            do {
                Menu();
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (opcao > 6) {
                    Console.WriteLine("Opção inválida.");
                    Console.WriteLine("");                    
                }
                switch (opcao){
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    case 1:
                        CadastroUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarUsuarios(cpfs, titulares, saldos);
                        break;
                   
                }
                
            } while (opcao != 0);

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