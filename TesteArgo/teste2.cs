using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArgo
{
    public class teste2
    {
        public List<int> CriarLista(int quantidade)
        {
            return new int[quantidade].ToList();

        }

        public List<int> OrdenarLista(params int[] valores)
        {
            return valores.OrderBy(x => x).ToList();
        }
    }
}
