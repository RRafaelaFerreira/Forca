using JogoDaForca;

namespace JogoDaForca
{
    public partial class Form1 : Form
    {
        Dicionario d;
        private VetorDicionario vD;

        //sinaliza se o programa está no modo edição ou não(se sim, ativa botões específicos e "textBoxes")
        bool noModoEdicao = false;
        public Form1()
        {
            InitializeComponent();

            vD = new VetorDicionario(100);
            

            //inicia o textBox de palavra e dica como desativados
            txtbPalavra.Enabled = false;
            txtbDica.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            /*posicaoAtual=0 e exibe dados[0] nos campos txtbPalavra e txtbDica*/
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            /*PosicaoAtual-- (se > 0) e atualiza os campos*/
        }

        private void btnAcancar_Click(object sender, EventArgs e)
        {
            /*PosicaoAtual++ (se < último) e atualiza os campos*/
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            /*	PosicaoAtual = total - 1 e exibe o último item*/
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            /*Limpa os TextBox para que se inclua algo*/
            txtbPalavra.Text = " ";
            txtbPalavra.Text = " ";

            txtbPalavra.Enabled = true;
            txtbDica.Enabled = true;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            /*Quando for pressionado o botão [Salvar], verificar se está em
            Modo de Edição e, se estiver, substituir pelo novo valor a dica armazenada na posição
            PosicaoAtual do vetor dados interno de VetorDicionario.*/
            int position = vD.posicaoAtual;
            string conteudo = txtbDica.Text.Trim();

            if (noModoEdicao == true) {
                if (position >= 0 && position < vD.posicaoAtual) {
                    /*vD.dados[position] = novaDica;*/
                }

                MessageBox.Show("Dica salva!");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            noModoEdicao = true;
            txtbDica.Enabled = true;
            txtbDica.Focus();//coloca o cursor no txtbDica
            /*Ao pressionar [Alterar], colocar o programa em Modo de Edição. Colocar o cursor em edDica e
            permitir que o usuário mude a dica.*/
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /*Confirma com o usuário e remove dados[PosicaoAtual] do vetor*/
        }
    }
}
