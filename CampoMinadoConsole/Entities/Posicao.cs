using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoConsole.Entities
{
    internal class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Posicao()
        {
        }
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public override bool Equals(Object o)
        {
            if (o is Posicao)
            {
                Posicao posi = (Posicao)o;
                if (this.Linha == posi.Linha && this.Coluna == posi.Coluna)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
