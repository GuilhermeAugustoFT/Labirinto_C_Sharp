using System;
using System.Windows.Forms;
using System.Threading;


class PilhaLista<Dado> : ListaSimples<Dado>, IStack<Dado>, IComparable<PilhaLista<Dado>>
                         where Dado : IComparable<Dado>
{
    public Dado Desempilhar()

    {
        if (EstaVazia)
            throw new PilhaVaziaException("pilha vazia!");

        Dado valor = base.Primeiro.Info;

        NoLista<Dado> pri = base.Primeiro;
        NoLista<Dado> ant = null;
        base.RemoverNo(ref pri, ref ant);
        return valor;
    }

    public void Empilhar(Dado elemento)
    {
        base.InserirAntesDoInicio
              (
                new NoLista<Dado>(elemento, null)
              );
    }

    new public bool EstaVazia
    {
        get => base.EstaVazia;
    }

    public Dado OTopo()
    {
        if (EstaVazia)
            throw new PilhaVaziaException("pilha vazia!");

        return base.Primeiro.Info;
    }

    public int Tamanho { get => base.QuantosNos; }


    public void Exibir(DataGridView dgv)
    {

        //  for (int j = 0; j < Tamanho; j++)
        //   {
        //      dgv[j, dgv.RowCount-1].Value = " ";
        //  }


        var auxiliar = new PilhaLista<Dado>();
        string[] linha = new string[Tamanho];
        int i = Tamanho - 1;
        while (!this.EstaVazia)
        {
            linha[i--] = this.OTopo().ToString();
            // Thread.Sleep(3000);
            Application.DoEvents();
            auxiliar.Empilhar(this.Desempilhar());

        }
        dgv.Rows.Add(linha);
        while (!auxiliar.EstaVazia)
            this.Empilhar(auxiliar.Desempilhar());
    }

    public int CompareTo(PilhaLista<Dado> pilha)
    {
        return 0;
    }

    public bool Equals(Object obj)
    {
        if (obj == null)
            return false;
        if (obj == this)
            return true;
        if (!obj.GetType().Equals(this.GetType()))
            return false;

        PilhaLista<Dado> pilha = (PilhaLista<Dado>)obj;

        if (this.Tamanho != pilha.Tamanho)
            return false;

        PilhaLista<Dado> estaPilha = (PilhaLista<Dado>)this.Clone();
        while (!estaPilha.EstaVazia)
        {
            if (!estaPilha.Desempilhar().Equals(pilha.Desempilhar()))
                return false;
        }
        return true;
    }

    public bool Existe(Dado dado)
    {
        if (dado == null)
            return false;
        if (EstaVazia)
            return false;
        if (OTopo().Equals(dado))
            return true;


        PilhaLista<Dado> estaPilha = (PilhaLista<Dado>)this.Clone();


        while (!estaPilha.EstaVazia)
        {
            if (estaPilha.Desempilhar().Equals(dado))
                return true;
        }

        return false;
    }
    public Object Clone()
    {
        PilhaLista<Dado> clone = new PilhaLista<Dado>();

        NoLista<Dado> dado = new NoLista<Dado>(Primeiro.Info, Primeiro.Prox);
        while (dado.Prox != null)
        {
            clone.Empilhar(dado.Info);
            dado = dado.Prox;

        }
        return clone;

    }
}

