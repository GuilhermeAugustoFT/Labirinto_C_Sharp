using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;

class GrafoTemp
    {
    private string[,] matriz;
    private int qtdColunas, qtdLinhas;

    public string[,] Matriz { get => matriz; set => matriz = value; }
    public int QtdColunas { get => qtdColunas; set => qtdColunas = value; }
    public int QtdLinhas { get => qtdLinhas; set => qtdLinhas = value; }

    public GrafoTemp(string nomeArquivo)
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

    public PilhaLista<PilhaLista<MovimentoTemp>> BuscarCaminho (DataGridView dgvGrafo, DataGridView dgvPilha)
    {
        int linhaAtual = 1,
            colunaAtual = 1;

        PilhaLista<MovimentoTemp> saida;
        MovimentoTemp movim = new MovimentoTemp();

        bool achouCaminho = false,
             naoTemSaida = false;

        string marca="*";

        var pilha = new PilhaLista<MovimentoTemp>();

        var caminhos = new PilhaLista<PilhaLista<MovimentoTemp>>();

        int[] lin = {-1,-1,0,1,1,1,0,-1};
        int[] col = {0,1,1,1,0,-1,-1,-1};
        int d=0;

      return ProcurarCaminho();

       

        void ExibirUmPasso()
        {
            dgvGrafo.CurrentCell = dgvGrafo[colunaAtual, linhaAtual];
            //pilha.Exibir(dgvPilha);
          //  Thread.Sleep(500);
          // MessageBox.Show(colunaAtual.ToString(), linhaAtual.ToString());
        }

        PilhaLista<PilhaLista<MovimentoTemp>> ProcurarCaminho()
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
                        Thread.Sleep(10);
                        Application.DoEvents();
                        int[] ori = { colunaAtual, linhaAtual };
                        colunaAtual += col[d];
                        linhaAtual += lin[d];
                        int[] des = { colunaAtual, linhaAtual };
                         movim = new MovimentoTemp(ori, des, d);
                        ExibirUmPasso();
                        pilha.Empilhar(movim);


                        
                        if (matriz[des[0], des[1]] == "S")
                        {
                            achouCaminho = true;

                        }
                        break;

                    }

                }
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
            if (achouCaminho)
            {       // desempilha a configuração atual da pilha
                    // para a pilha da lista de parâmetros
                PilhaLista<MovimentoTemp> clone = (PilhaLista<MovimentoTemp>) pilha.Clone();
                movim = pilha.Desempilhar();
                saida = new PilhaLista<MovimentoTemp>();

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
               // if(!caminhos.Existe(saida))
                    caminhos.Empilhar(saida);

                achouCaminho = false;
               // MessageBox.Show("gg ez");
                ProcurarCaminho();
            }
        //    MessageBox.Show("gg ez");
            return caminhos;
        }

    }




   /* public PilhaLista<Movimento> BuscarCaminho(int linhaOrigem,int colunaOrigem,DataGridView dgvGrafo, DataGridView dgvPilha)
    {
        int linhaAtual=linhaOrigem,
            colunaAtual=colunaOrigem;
        bool achouCaminho = false,
             naoTemSaida = false;

        var pilha = new PilhaLista<Movimento>();


        while (!achouCaminho && !naoTemSaida)
        {
            naoTemSaida = (linhaAtual == linhaOrigem && colunaAtual == colunaOrigem && pilha.EstaVazia);
            if (!naoTemSaida)
            {
                while ((saidaAtual < qtasCidades) && !achouCaminho)
                {
                    // se não há saída pela cidade testada, verifica a próxima
                    if (matriz[cidadeAtual, saidaAtual] == 0)
                        saidaAtual++;
                    else
                        // se já passou pela cidade testada, verifica se a próxima
                        // cidade permite saída 
                        if (passou[saidaAtual])
                        saidaAtual++;
                    else
                        // se chegou na cidade desejada, empilha o local
                        // e termina o processo de procura de caminho
                        if (saidaAtual == destino)
                    {
                        Movimento movim = new Movimento(cidadeAtual, saidaAtual);
                        pilha.Empilhar(movim);
                        achouCaminho = true;

                    //    lsb.Items.Add($"Saiu de {cidadeAtual} para {saidaAtual}");
                        ExibirUmPasso();
                    }
                    else
                    {
                      //  lsb.Items.Add($"Saiu de {cidadeAtual} para {saidaAtual}");
                        ExibirUmPasso();

                        Movimento movim = new Movimento(cidadeAtual, saidaAtual);
                        pilha.Empilhar(movim);
                        passou[cidadeAtual] = true;
                        cidadeAtual = saidaAtual;   // muda para a nova cidade 
                        saidaAtual = 0;            // reinicia busca de saídas da nova cidade a partir da primeira cidade
                    }
                }
            }
            if (!achouCaminho)
                if (!pilha.EstaVazia)
                {
                    var movim = pilha.Desempilhar();
                    saidaAtual = movim.Destino;
                    cidadeAtual = movim.Origem;

                    lsb.Items.Add($"Voltando de {saidaAtual} para {cidadeAtual}");
                    ExibirUmPasso();

                    saidaAtual++;
                }
        }
        var saida = new PilhaLista<Movimento>();
        if (achouCaminho)
        {       // desempilha a configuração atual da pilha
                // para a pilha da lista de parâmetros
            while (!pilha.EstaVazia)
            {
                Movimento movim = pilha.Desempilhar();
                saida.Empilhar(movim);
            }
        }

        return saida;

        void ExibirUmPasso()
        {
            dgvGrafo.CurrentCell = dgvGrafo[saidaAtual, cidadeAtual];
            pilha.Exibir(dgvPilha);
            Thread.Sleep(1000);
        }
   
    }*/
}

