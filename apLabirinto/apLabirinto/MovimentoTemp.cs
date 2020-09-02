using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class MovimentoTemp : IComparable<MovimentoTemp>
{
        private int[] origem, destino;
    private int direcao;

        public MovimentoTemp(int[]ori,int[]des,int dir)
        {
        origem = new int[2];
        destino = new int[2];

            Direcao = dir;
            Origem[0] = ori[0];
            Destino[0]= des[0]; 
            Origem[1] = ori[1];
            Destino[1] = des[1];
        }  
    public MovimentoTemp()
    {

    }
        public int[] Origem { get => origem; set => origem = value; }
        public int[] Destino { get => destino; set => destino = value; }
        public int Direcao { get => direcao; set => direcao = value; }

    public override String ToString()
        {
            return Origem[0] + ", " + Origem[1];
        }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (obj == this)
            return true;

        if (!this.GetType().Equals(obj.GetType()))
            return false;

        MovimentoTemp outro = (MovimentoTemp)obj;

        if (this.direcao != outro.direcao)
            return false;

        for (int i = 0; i < 2; i++)
        {
            if (this.origem[i] != outro.origem[i] || this.destino[i] != outro.destino[i])
                return false;
        }
            return true;
    }

    public int CompareTo(MovimentoTemp outro)   // para compatibilizar com ListaSimples e NoLista
        {
            return 0;
        }
    }

