//23015 e 24459
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace JogoDaForca
{
    internal class Dicionario
    {
        //private const int TAMANHO_PALAVRA = 15;
        //private const int TAMANHO_DICA = 16;
        
        private string Palavra { get; set; }
        private string Dica{ get; set; }
        private bool[] Acertou { get; set; } //sempre iniciará com false

        public Dicionario(string Palavra, string Dica, bool[] Acertou) { 
            this.Palavra = Palavra; 
            this.Dica = Dica; 
            this.Acertou = Acertou;
        }

        public void LeUmaLinha() {//Método que lê uma linha e armazena a dica e a palavra em suas respectivas variáveis
            using (StreamReader lerLinha = new StreamReader(Palavra)) {
                string linha = lerLinha.ReadLine();//lê a linha

                string palavra = linha.Substring(0, 15);//pega a palavra e a armazena
                Palavra = palavra.Trim();

                string dica = linha.Substring(16);
                Dica = dica.Trim(); 
            }
        }

        public string LinhaLida() { //método que retorna a palavra e a dica armazenada.
            LeUmaLinha();
            return "Palavra: " + Palavra + "Dica: " + Dica;
        }


        public void IniciaFalse() {
            for (int i = 0; i < Acertou.Length; i++)
            {
                Acertou[i] = false;//faz com que sempre inicialize o vetor com os campos FALSE
            }
        }

        public bool EstaNaPalavra(string letra){
            //se a letra está na paalvra
                //Atualiza no vetor os lugares que estão false e que a letra está lá(ex: posição 1---5--8)fica true, false, false, false, true, false, false, true
                //retorna true
            //retorna false se a letra não estiver.
        }

        public string Acertou() { 
            //retorna o vetor Acertou atualizado pelo EstaNaPalavra()
        }
        

    }
}
