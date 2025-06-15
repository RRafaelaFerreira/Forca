//23015 e 24459
using JogoDaForca;

namespace JogoDaForca
{
    public partial class Form1 : Form
    {
        Dicionario d;
        private VetorDicionario vD;

        //sinaliza se o programa está no modo edição ou não(se sim, ativa botões específicos e "textBoxes")
        bool noModoEdicao = false;
        int indiceAtual = 0;

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
            if (vD.posicaoAtual > 0)
            {
                Dicionario atual = vD.dados[0];
                txtbPalavra.Text = atual.Palavra;
                txtbDica.Text = atual.Dica;
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (vD.posicaoAtual > 0 && vD.posicaoAtual - 1 >= 0)
            {
                vD.GetType().GetProperty("posicaoAtual").SetValue(vD, vD.posicaoAtual - 1);
                Dicionario atual = vD.dados[vD.posicaoAtual - 1];
                txtbPalavra.Text = atual.Palavra;
                txtbDica.Text = atual.Dica;
            }
        }


        private void btnAcancar_Click(object sender, EventArgs e)
        {
            if (indiceAtual < vD.posicaoAtual - 1)
            {
                indiceAtual++;
                Dicionario atual = vD.dados[indiceAtual];
                txtbPalavra.Text = atual.Palavra;
                txtbDica.Text = atual.Dica;
            }
            else
            {
                MessageBox.Show("Você já está no último item.");
            }
        }


        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (vD.posicaoAtual > 0)
            {
                indiceAtual = vD.posicaoAtual - 1;
                Dicionario atual = vD.dados[indiceAtual];
                txtbPalavra.Text = atual.Palavra;
                txtbDica.Text = atual.Dica;
            }
            else
            {
                MessageBox.Show("Nenhum item cadastrado ainda.");
            }
        }


        private void btnIncluir_Click(object sender, EventArgs e)
        {
            txtbPalavra.Text = "";
            txtbDica.Text = "";

            txtbPalavra.Enabled = true;
            txtbDica.Enabled = true;

            txtbPalavra.Focus();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (noModoEdicao)
            {
                int posicao = vD.posicaoAtual - 1; // cuidado: salvar na posição atual válida

                string novaDica = txtbDica.Text.Trim();

                if (posicao >= 0 && posicao < vD.posicaoAtual)
                {
                    vD.AlterarDica(posicao, novaDica);
                    MessageBox.Show("Dica alterada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Posição inválida!");
                }

                noModoEdicao = false;
                txtbDica.Enabled = false;
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
            DialogResult result = MessageBox.Show("Deseja excluir este item?", "Confirmação", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int posicao = vD.posicaoAtual - 1;
                vD.Excluir(posicao);

                txtbPalavra.Text = "";
                txtbDica.Text = "";

                MessageBox.Show("Item excluído.");
            }
        }

        private void txtbPalavra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
