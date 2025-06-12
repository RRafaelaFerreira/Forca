using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    public class VetorDicionario
    {
        private Dicionario[] Dados;
        private int posicaoAtual;

        public VetorDicionario(int capacidade)
        {
            Dados = new Dicionario[capacidade];
            posicaoAtual = 0;
        }

        public void Adicionar(Dicionario item)
        {
            if (posicaoAtual < Dados.Length)
            {
                Dados[posicaoAtual] = item;
                posicaoAtual++;
            }
        }

        public void Listar()
        {
            for (int i = 0; i < posicaoAtual; i++)
            {
                Console.WriteLine(Dados[i].ToString());
            }
        }

    }
}
