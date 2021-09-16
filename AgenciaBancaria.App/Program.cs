using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
                        
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        opcaoContaCorrente();
                        break;
                    case "2":
                        opcaoContaPoupanca();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine();

        }

        #region Opção pela conta corrente
        public static void opcaoContaCorrente()
        {
                try
                {
                    Endereco endereco = new Endereco("Rua Avinda Rua", "34567832", "Recife", "PE");
                    Cliente cliente = new Cliente("Jean", "5432134", "098765", endereco);
                    ContaCorrente conta = new ContaCorrente(cliente, 200);

                    Console.WriteLine("Conta: " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                    string senha = "abc12345678";
                    conta.AbrirConta(senha);

                    Console.WriteLine("Conta: " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                    decimal valorsaque;
                    Console.WriteLine("Digite o valor do saque R$: ");
                    valorsaque = decimal.Parse(Console.ReadLine());
                    conta.Sacar(valorsaque, senha);
                    Console.WriteLine(conta.VerSaldo());

            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            #endregion

        }
        #region Opção pela Conta Poupanca
        public static void opcaoContaPoupanca()
        {
            try
            {
                Endereco endereco = new Endereco("Rua Avinda Rua", "34567832", "Recife", "PE");
                Cliente cliente = new Cliente("Jean", "5432134", "098765", endereco);
                ContaPoupanca conta = new ContaPoupanca(cliente);

                Console.WriteLine("Conta: " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                string senha = "abc12345678";
                conta.AbrirConta(senha);

                Console.WriteLine("Conta: " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                decimal valorsaque;
                Console.WriteLine("Digite o valor do saque R$: ");
                valorsaque = decimal.Parse(Console.ReadLine());
                conta.Sacar(valorsaque, senha);
                Console.WriteLine(conta.VerSaldo());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

        }

        #region Obter a Opção Usuário
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Olá! Seja Bem Vindo!!!");
            Console.WriteLine();
            Console.WriteLine("Digite a opção desejada:");

            Console.WriteLine("1- Conta Corrente");
            Console.WriteLine("2- Conta Poupança");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        #endregion
    }
}
