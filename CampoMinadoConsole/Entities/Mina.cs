using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoConsole.Entities
{
    internal class Mina
    {
        public Posicao PosicaoDaMina { get; set; }
        public static Random RandNum = new Random();
        public Mina(Posicao posicaoDaMina)
        {
            PosicaoDaMina = posicaoDaMina;
        }
        public static bool VerificadorDasMina(List<Mina> LocaisDasMina, Posicao PosiVerifica)
        {
            foreach (Mina m in LocaisDasMina)
            {
                if (PosiVerifica.Equals(m.PosicaoDaMina))
                    return false;
            }
            return true;
        }
        public static List<Mina> MinasLista()
        {
            List<Mina> LocaisMinasFacil = new List<Mina>();
            Posicao PosiVerifica;
            bool checagem = true;
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    PosiVerifica = new Posicao(RandNum.Next(1, 9), RandNum.Next(1, 11));
                    checagem = Mina.VerificadorDasMina(LocaisMinasFacil, PosiVerifica);
                } while (checagem != true);
                LocaisMinasFacil.Add(new Mina(PosiVerifica));
            }
            return LocaisMinasFacil;
        }
    }
}
