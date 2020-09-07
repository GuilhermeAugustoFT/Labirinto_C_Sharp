using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;

class Grafo
    {
    private string[,] matriz;
    private int qtdColunas, qtdLinhas;

    public string[,] Matriz { get => matriz; set => matriz = value; }
    public int QtdColunas { get => qtdColunas; set => qtdColunas = value; }
    public int QtdLinhas { get => qtdLinhas; set => qtdLinhas = value; }

    public Grafo(string nomeArquivo)
    {
        var arquivo = new StreamReader(nomeArquivo);
        qtdColunas = int.Parse(arquivo.ReadLine());
        qtdLinhas = int.Parse(arquivo.ReadLine());
        matriz = new string[qtdColunas, qtdLinhas];

        for(int linha=0; linha< qtdLinhas; linha++ )
        {
            string umaLinha= arquivo.ReadLine();
            int auxiliar=0;
            for(int coluna = 0; coluna<qtdColunas; coluna++)
            {
                matriz[coluna, linha] = umaLinha.Substring(auxiliar,1);
                auxiliar++;
            }

        }
    }

    public void Exibir(DataGridView dgv)
    {
        dgv.RowCount = 1;
        dgv.ColumnCount = 0;

        dgv.RowCount = qtdLinhas;
        dgv.ColumnCount = qtdColunas;

        for (int linha = 0; linha < qtdLinhas; linha++)
        {
            dgv.Rows[linha].HeaderCell.Value = linha.ToString();
            for (int coluna = 0; coluna < qtdColunas; coluna++)
            {
                dgv[coluna, linha].Value = matriz[coluna, linha];
                dgv.Columns[coluna].HeaderText = coluna.ToString();

                dgv.Columns[coluna].Width = 30;
            }
        }
    }

    public PilhaLista<PilhaLista<Movimento>> BuscarCaminho (DataGridView dgvGrafo, DataGridView dgvPilha)
    {
        int linhaAtual = 1,
            colunaAtual = 1;

        PilhaLista<Movimento> saida;
        Movimento movim = new Movimento();

        bool achouCaminho = false,
             naoTemSaida = false;

        string marca="*";

        var pilha = new PilhaLista<Movimento>();

        var caminhos = new PilhaLista<PilhaLista<Movimento>>();

        int[] lin = {-1,-1,0,1,1,1,0,-1};
        int[] col = {0,1,1,1,0,-1,-1,-1};
        int d=0;

      return ProcurarCaminho();

       

        void ExibirUmPasso()
        {
            dgvGrafo.CurrentCell = dgvGrafo[colunaAtual, linhaAtual];
            //pilha.Exibir(dgvPilha);
           // Thread.Sleep(500);
        }

        PilhaLista<PilhaLista<Movimento>> ProcurarCaminho()
        {
            while (!achouCaminho && !naoTemSaida)
            {

                for (; d < 8; d++)
                {


                    if (!(matriz[colunaAtual + col[d], linhaAtual + lin[d]]).Equals("#") &&
                        !(matriz[colunaAtual + col[d], linhaAtual + lin[d]]).Equals(marca))
                    {
                        matriz[colunaAtual, linhaAtual] = marca;
                        dgvGrafo[colunaAtual, linhaAtual].Value = marca;
                        dgvGrafo[colunaAtual, linhaAtual].Style.BackColor = Color.Black;
                        //Thread.Sleep(10);
                      //  Application.DoEvents();
                        int[] ori = { colunaAtual, linhaAtual };
                        colunaAtual += col[d];
                        linhaAtual += lin[d];
                        int[] des = { colunaAtual, linhaAtual };
                         movim = new Movimento(ori, des, d);
                        ExibirUmPasso();
                        pilha.Empilhar(movim);


                        
                        if (matriz[des[0], des[1]] == "S")
                        {
                            achouCaminho = true;
                            movim = new Movimento(des);
                            pilha.Empilhar(movim);
                        }
                        goto podeTerSaida;

                    }

                }
                podeTerSaida:
                naoTemSaida = (d > 7);


                if (naoTemSaida)
                {
                    if (!pilha.EstaVazia)
                    {
                        if (caminhos.Tamanho > 0)
                        {
                            dgvGrafo[colunaAtual, linhaAtual].Style.BackColor = Color.White;
                            movim = pilha.Desempilhar();
                            dgvGrafo[colunaAtual, linhaAtual].Value = matriz[colunaAtual, linhaAtual] = "";

                            colunaAtual = movim.Origem[0];
                            linhaAtual = movim.Origem[1];
                            d = movim.Direcao;
                            d++;
                            ExibirUmPasso();
                            naoTemSaida = false;
                        }
                        else
                        {
                            dgvGrafo[colunaAtual, linhaAtual].Style.BackColor = Color.White;
                            movim = pilha.Desempilhar();
                            dgvGrafo[colunaAtual, linhaAtual].Value = matriz[colunaAtual, linhaAtual] = "*";

                            colunaAtual = movim.Origem[0];
                            linhaAtual = movim.Origem[1];
                            d = movim.Direcao;
                            ExibirUmPasso();
                            naoTemSaida = false;
                        }
                    }
                    else
                    {
                        return caminhos;
                    }
                }
                else
                {
                    d = 0;
                }


            }
           
                  // desempilha a configuração atual da pilha
            // para a pilha da lista de parâmetros
                saida = new PilhaLista<Movimento>();
                movim = pilha.Desempilhar();
                saida.Empilhar(movim);

                PilhaLista<Movimento> clone = pilha.Clone();
                movim = pilha.Desempilhar();

                colunaAtual = movim.Origem[0];
                linhaAtual = movim.Origem[1];
                
                
                d = movim.Direcao;
                d++;
                movim = clone.Desempilhar();
                saida.Empilhar(movim);

                
               

                while (!clone.EstaVazia)
                {
                    movim = clone.Desempilhar();

                    saida.Empilhar(movim);
                }
                if(!caminhos.Existe(saida))
                    caminhos.Empilhar(saida);

                achouCaminho = false;
          
                ProcurarCaminho();
         
      
            return caminhos;
        }

    }
}

