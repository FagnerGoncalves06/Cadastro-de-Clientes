using System.Linq;
using System.Text.RegularExpressions;

namespace ProjetoSOLID.Application.Utils
{
    public static class ValidadorCPF
    {
        // Retorna true se o CPF tem 11 dígitos e se dígitos verificadores estão corretos.
        public static bool Validar(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            var somenteNumeros = Regex.Replace(cpf, @"\D", "");

            if (somenteNumeros.Length != 11) return false;

            var repetido = Enumerable.Range(0, 10).Select(i => new string(char.Parse(i.ToString()), 11));
            if (repetido.Any(r => r == somenteNumeros)) return false;

            // Função para calcular dígito verificador
            int CalculaDigito(string num, int pesoInicio)
            {
                int soma = 0;
                for (int i = 0; i < num.Length; i++)
                    soma += (num[i] - '0') * (pesoInicio - i);
                int resto = soma % 11;
                return (resto < 2) ? 0 : 11 - resto;
            }

            var base9 = somenteNumeros.Substring(0, 9);
            var digito1 = CalculaDigito(base9, 10);
            var digito2 = CalculaDigito(base9 + digito1.ToString(), 11);

            return somenteNumeros[9] - '0' == digito1 && somenteNumeros[10] - '0' == digito2;
        }
    }
}
