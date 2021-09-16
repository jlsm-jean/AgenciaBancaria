using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public static class Validacoes
    {
        public static string ValidaStringEmBranco(this string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? throw new Exception("Propriedade deve ser preenchida. ") : texto;
        }
    }
}
