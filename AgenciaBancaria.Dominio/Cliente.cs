using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, string rg, Endereco endereco)
        {
            /*if (string.IsNullOrWhiteSpace(nome))
            {
            throw new Exception("Propriedade deve estar preenchida. ");
            }                                                Ou
            Nome = string.IsNullOrWhiteSpace(nome) ? throw new Exception("Propriedade deve ser preenchida. ") : nome;*/

            Nome = nome.ValidaStringEmBranco();
            CPF = cpf.ValidaStringEmBranco();
            RG = rg.ValidaStringEmBranco();
            Endereco = endereco ?? throw new Exception("Endereço deve ser informando.");
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public Endereco Endereco { get; private set; }

        
    }
}
