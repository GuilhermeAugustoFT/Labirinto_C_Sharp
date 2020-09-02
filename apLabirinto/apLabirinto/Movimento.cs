using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Movimento : IComparable<Movimento>
    {
		private int origem, destino;  // onde estou, para onde vou
		public Movimento(int or, int dest)
		{
			origem = or;
			destino = dest;
		}
		public int Origem
		{
			get => origem;
			set => origem = value;
		}
		public int Destino
		{
			get => destino;
			set => destino = value;
		}
		public override String ToString()
		{
			return origem +" "+destino;
		}

    
    public int CompareTo(Movimento outro)   // para compatibilizar com ListaSimples e NoLista
		{
			return 0;
		}
	}

