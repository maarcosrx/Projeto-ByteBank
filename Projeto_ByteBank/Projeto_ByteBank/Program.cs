using System.Diagnostics;

namespace ByteBank {
    public class Program {


        static void Menu() {
            Console.WriteLine("----------- Escolha uma opção abaixo ------------");
            Console.WriteLine($"Consultar seu saldo ---------------------------(1)"); //Funcionando
            Console.WriteLine($"Realizar saque --------------------------------(2)"); //Funcionando
            Console.WriteLine($"Realizar depósito ------------------------------(3)"); //Funcionando
            Console.WriteLine($"Transferências --------------------------------(4)"); //Funcionando
            Console.WriteLine($"Encerrar atendimento --------------------------(0)"); //Funcionando
        }

        public static void Main(string[] args) {
            double saldo = 0.0;            
            double deposito = 0.0;
            double saque = 0.0;
            double valorTranferencia = 0.0;
            int opcao;

            Console.WriteLine(" --------- BEM VINDO AO BYTE BANK! --------------");
            Console.WriteLine("");
            Console.WriteLine("Antes de começar, por favor digite seus dados:");
            Console.Write($"Nome: ");
            string nome = Console.ReadLine();
            Console.Write($"CPF: ");
            var cpf = (Console.ReadLine());

            do {                
                Menu();
                opcao = int.Parse(Console.ReadLine()); 
                if(opcao > 4) {
                    Console.WriteLine("Opção inválida.");
                    Console.WriteLine(" ");
                }
                switch (opcao) {
                    case 1:
                        Console.WriteLine($"Seu saldo é {saldo:f2}");
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.Write($"Digite o valor do saque: ");
                        Console.WriteLine("");
                        saque = double.Parse(Console.ReadLine());
                        if (saque > saldo) {
                            Console.WriteLine("ERRO: Saldo indisponível.");
                            Console.WriteLine("");
                        } else {
                            Console.WriteLine($"Valor sacado {saque:f2}");
                            Console.WriteLine("");
                            saldo -= saque;
                            Console.WriteLine($"Seu saldo atual é {saldo:f2}");
                            Console.WriteLine("");
                        }                        
                        break;
                    case 3:
                        Console.Write("Valor a depositar: ");
                        deposito = double.Parse(Console.ReadLine());
                        if (deposito <= 0) {
                            Console.WriteLine("ERRO: Valor incorreto.");
                            Console.WriteLine("");
                        } else {
                            saldo += deposito; 
                            Console.WriteLine($"Saldo Atual: {saldo:f2}");
                            Console.WriteLine("");
                        }
                        break;
                    case 4:
                        Console.Write("Digite o número da conta: ");
                        int conta = int.Parse(Console.ReadLine());                        
                        Console.Write($"Digite o dígito: {conta}-");
                        int digito = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Conta para transferência: {conta}-{digito}");
                        Console.Write("Valor: ");
                        valorTranferencia = double.Parse(Console.ReadLine());

                        if(valorTranferencia > saldo){
                            Console.WriteLine("Saldo indisponivel");
                            Console.WriteLine("");
                        } else {
                            saldo -= valorTranferencia;
                            Console.WriteLine("Tranfereência Realizada");
                            Console.WriteLine($"Conta: {conta}-{digito}");
                            Console.WriteLine($"Valor: {valorTranferencia}");
                            Console.WriteLine("");
                        }
                        break;
                }
            } while (opcao != 0);

        }
    }
}