using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apLabirinto
{

    public partial class Form1 : System.Windows.Forms.Form
    {

        PilhaLista<PilhaLista<MovimentoTemp>> pilha;
        GrafoBacktracking oGrafo;
        GrafoTemp umGrafo;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                umGrafo = new GrafoTemp(dlgAbrir.FileName);
                umGrafo.Exibir(dgvLabirinto);
            }
            
        }

        private void btnEncontrarCaminhos_Click(object sender, EventArgs e)
        {

            pilha = umGrafo.BuscarCaminho(dgvLabirinto,dgvCaminhos);
            umGrafo.Exibir(dgvLabirinto);
            dgvCaminhos.RowCount = 1;
            dgvCaminhos.ColumnCount = 40;
            while (!pilha.EstaVazia)
            {
                
                pilha.Desempilhar().Exibir(dgvCaminhos);
            }
            MessageBox.Show((dgvCaminhos.RowCount - 1).ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvCaminhos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void limparDgv(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Rows.Clear();
        }

        private void dgvCaminhos_SelectionChanged(object sender, EventArgs e)
        {
            limparDgv(dgvLabirinto);
            umGrafo = new GrafoTemp(dlgAbrir.FileName);
            umGrafo.Exibir(dgvLabirinto);

            int linhaAtual = dgvCaminhos.CurrentRow.Index;
            bool acabou = false;
            char marca = ',';
            string[] coords;
            string valores;

            for (int i = 0; !acabou; i++)
            {

                if (dgvCaminhos[i, linhaAtual].Value == null)
                {
                    acabou = true;
                    break;
                }

                valores = dgvCaminhos[i, linhaAtual].Value.ToString();
                coords = valores.Split(marca);

                dgvLabirinto[int.Parse(coords[0]), int.Parse(coords[1])].Style.BackColor = Color.Black;
                Thread.Sleep(10);
                Application.DoEvents();

            }
        }
    }
   } 
       

