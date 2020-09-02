using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public class FilaVaziaException : Exception
  {
    // chama o método da classe ancestral (classe base) de Exception
    public FilaVaziaException(String erro) : base(erro)
    { }
  }


