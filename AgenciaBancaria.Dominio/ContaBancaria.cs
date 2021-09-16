using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;

            Cliente = cliente ?? throw new Exception("Favor informar o cliente");
        }
        public void AbrirConta(string senha)
        {
            SetaSenha(senha);
            {
                Situacao = SituacaoConta.Aberta;
                DataAbertura = DateTime.Now;
            }
        }

        public void SetaSenha(string senha)
        {
            senha = senha.ValidaStringEmBranco();

            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha invalida");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if(Senha != senha)
            {
                throw new Exception("Senha invalida.");
            }

            var saque = new Saque(valor, DateTime.Now, this);

            if (Saldo < saque.Valor)
            {
                throw new Exception("Saldo insuficiente");
            }
            Saldo -= saque.Valor;
        }

        public virtual string VerExtrato()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-- Extrato - Lançamentos --");

            foreach (var lancamento in Lancamentos)
            {
                sb.Append(lancamento.GetType().Name + "  -->   ");
                sb.Append(lancamento.Data.ToString("dd/MM/yyyy hh:mm:ss" + "   -->  "));

                if (lancamento is Saque)
                    sb.Append(" - ");
                
                if (lancamento is Deposito)
                    sb.Append(" + ");
                
                sb.Append("R$");
                sb.AppendLine(lancamento.Valor.ToString());
            }

            sb.AppendLine("Saldo final: R$ " + Saldo);
            return sb.ToString();
        }

        public string VerSaldo()
        {
            Console.WriteLine();
            return $"Saldo atual: R$ {Saldo.ToString("#####.00")}";

        }

        public void Depositar(decimal valor)
        {
            var deposito = new Deposito(valor, DateTime.Now, this);

            Saldo += deposito.Valor;
            Lancamentos.Add(deposito);
        }
        
        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }
        public List<Lancamento> Lancamentos { get; private set; }
    }
}
