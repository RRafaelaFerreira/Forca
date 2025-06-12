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
    public class Dicionario
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

        public void LeUmaLinha(string linha){// lê uma linha e armazena a dica e a palavra em suas respectivas variáveis
            if (linha.Length >= 16)
            {
                Palavra = linha.Substring(0, 15).Trim();
                Dica = linha.Substring(16).Trim();
            }
            else
            {
                throw new ArgumentException("Linha inválida!");
            }
        }

        public string LinhaLida() { //método que retorna a palavra e a dica armazenada.
            return "Palavra: " + Palavra + "Dica: " + Dica;//deve ser chamado após o LeUmaLinha para retornar o resultado...
        }

        public void IniciaFalse() {
            for (int i = 0; i < Acertou.Length; i++)
            {
                Acertou[i] = false;//faz com que sempre inicialize o vetor com os campos FALSE
            }
        }

        public bool EstaNaPalavra(string letraDigitada){
            char letra = letraDigitada[0]; // Pega a primeira letra da string
            bool encontrou = false;

            for (int i = 0; i < Palavra.Length; i++){
                if (Palavra[i] == letra){
                    Acertou[i] = true; // atualiza a posição da letra encontrada para true
                    encontrou = true;
                }
            }

            return encontrou; 
        }

        public string MostrarAcertos(){//retorna os acertos
            string resultado = "";

            for (int i = 0; i < Palavra.Length; i++){
                if (Acertou[i])
                    resultado += Palavra[i];
                else
                    resultado += "_";
            }

            return resultado;
        }

    }
}
