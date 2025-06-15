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
        int indiceAtual = 0; 

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

        public void Excluir(int posicao)
        {
            if (posicao >= 0 && posicao < PosicaoAtual)
            {
                for (int i = posicao; i < PosicaoAtual - 1; i++)
                {
                    Dados[i] = Dados[i + 1];
                }
                Dados[PosicaoAtual - 1] = null;
                PosicaoAtual--;
            }
        }


        public void AlterarDica(int posicao, string novaDica)
        {
            if (posicao >= 0 && posicao < PosicaoAtual)
            {
                Dados[posicao].Dica = novaDica;
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
