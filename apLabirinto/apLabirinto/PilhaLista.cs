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

        var auxiliar = new PilhaLista<Dado>();
        string[] linha = new string[Tamanho];
        int i = 0;
        if (dgv.ColumnCount < Tamanho)
            dgv.ColumnCount = Tamanho+1;

        while (!this.EstaVazia)
        {
         
            linha[i++] = this.OTopo().ToString();
            
            // Thread.Sleep(3000);
         //   Application.DoEvents();
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

    public override bool Equals(Object obj)
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

        PilhaLista<Dado> estaPilha = this.Clone();
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


        PilhaLista<Dado> estaPilha = this.Clone();


        while (!estaPilha.EstaVazia)
        {
            if (estaPilha.Desempilhar().Equals(dado))
                return true;
        }

        return false;
    }

    public PilhaLista<Dado> Clone()
    {
        return (PilhaLista<Dado>)this.MemberwiseClone();
    }

    public PilhaLista()
    {

    }


    public override int GetHashCode()
    {
        int hash = 0;
        PilhaLista<Dado> estaPilha = this.Clone();
        while (!estaPilha.EstaVazia)
        {
            hash += estaPilha.Desempilhar().GetHashCode();
        }
        hash += estaPilha.Tamanho.GetHashCode();
        if (hash < 0)
            hash = -hash;
        return hash;

    }


    public override string ToString()
    {
        string toString=" ";

        PilhaLista<Dado> estaPilha = this.Clone();
        while (!estaPilha.EstaVazia)
        {
            toString = toString +" " + estaPilha.Desempilhar().ToString();
        }

        return base.ToString();
    }

}

