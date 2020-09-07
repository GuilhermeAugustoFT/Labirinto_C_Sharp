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

        PilhaLista<PilhaLista<Movimento>> pilha;
        Grafo umGrafo;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
        
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                limparDgv(dgvCaminhos);
                umGrafo = new Grafo(dlgAbrir.FileName);
                umGrafo.Exibir(dgvLabirinto);
            }
            
        }

        private void btnEncontrarCaminhos_Click(object sender, EventArgs e)
        {

            pilha = umGrafo.BuscarCaminho(dgvLabirinto,dgvCaminhos);
            umGrafo.Exibir(dgvLabirinto);
            dgvCaminhos.RowCount = 1;
            dgvCaminhos.ColumnCount = 50;
            while (!pilha.EstaVazia)
            {
                pilha.Desempilhar().Exibir(dgvCaminhos);
            }
            MessageBox.Show((dgvCaminhos.RowCount - 1).ToString() + " Caminhos encontrados!","Total de caminhos");

            
        }

        private void limparDgv(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Rows.Clear();
        }



        private void dgvCaminhos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            umGrafo = new Grafo(dlgAbrir.FileName);
            umGrafo.Exibir(dgvLabirinto);

            int linhaAtual = dgvCaminhos.CurrentRow.Index;
            bool acabou = false;
            char marca = ',';
            string[] coords;
            string valores;

            de:
            for (int i = 0; !acabou; i++)
            {

                if (dgvCaminhos[i, linhaAtual].Value == null)
                {
                    acabou = true;
                    goto de;

                }

                valores = dgvCaminhos[i, linhaAtual].Value.ToString();
                coords = valores.Split(marca);

                dgvLabirinto[int.Parse(coords[0]), int.Parse(coords[1])].Style.BackColor = Color.Black;
                //Thread.Sleep(10);
                // Application.DoEvents();

            }
        }
    }
   } 
       

