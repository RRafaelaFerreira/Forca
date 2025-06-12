using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    public class VetorDicionario
    {
        private Dicionario[] Dados { get; set; }
        private int PosicaoAtual { get; set; }

        public int posicaoAtual => PosicaoAtual;
        public Dicionario[] dados => Dados;


        public VetorDicionario(int capacidade)
        {
            Dados = new Dicionario[capacidade];
            PosicaoAtual = 0;
        }

        public void Adicionar(Dicionario item)
        {
            if (posicaoAtual < Dados.Length)
            {
                Dados[posicaoAtual] = item;
                PosicaoAtual++;
            }
        }

        /*public void AlterarDica(int posicao, string dica)
        {
            if (posicao >= 0 && posicao < posicaoAtual)
            {
                dados[posicao].Dica = dica;
            }
        }*/   //NÃO SEI O QUE ESTÁ ERRADO!

           
        public void Listar()
        {
            for (int i = 0; i < posicaoAtual; i++)
            {
                Console.WriteLine(Dados[i].ToString());
            }
        }

    }
}
