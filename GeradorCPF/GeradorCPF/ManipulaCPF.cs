using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCPF
{
    class ManipulaCPF
    {
        //Construtor que recebe a instânciação pra classe:
        public ManipulaCPF()
        {
        }

        //Método para gerar os CPF:
        public string GerarCpf()
        {
            //Instânciando um objeto a classe que irá gerar os CPF aleatórios:
            Random random = new Random();

            //Criando meu vetor que irá armazenar as 11 posições do CPF:
            int[] digitos = new int[11];

            //Declarando as variáveis que irão armazenar as somas:
            int soma = 0, soma2 = 0;

            //Algoritmo para validar os digitos do CPF:
            do
            {
                for (var i = 0; i < 8; i++)
                {
                    digitos[i] = random.Next(10);
                    soma += digitos[i] * (10 - i);
                    soma2 += digitos[i] * (11 - i);
                }
                soma += digitos[8] * 2;
                soma2 += digitos[8] * 3;
            } while (Repetidos(digitos));


            var resto = soma % 11;
            digitos[9] = resto < 2 ? 0 : 11 - resto;
            soma2 += digitos[9] * 2;
            resto = soma2 % 11;
            digitos[10] = resto < 2 ? 0 : 11 - resto;
            return string.Join("", digitos.Select(p => p.ToString()).ToArray());
        }

        public bool Repetidos(int[] digitos)
        {
            var val = digitos[0];
            return digitos.Take(9).All(x => x == val);
        }

    }
}
