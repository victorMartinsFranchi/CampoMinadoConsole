namespace CampoMinadoConsole.Entities
{
    internal static class Alertas
    {
        public static int NiveisDeAlerta(Posicao posi)
        {
            int perigo = 0;
            foreach (Mina m in Jogo.Minas)
            {
                if (posi.Equals(m.PosicaoDaMina))
                {
                    return 9;
                }
                //direita
                if (new Posicao(posi.Linha, (posi.Coluna + 1)).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //esquerda
                if (new Posicao(posi.Linha, (posi.Coluna - 1)).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //cima
                if (new Posicao((posi.Linha - 1), posi.Coluna).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //baixo
                if (new Posicao((posi.Linha + 1), posi.Coluna).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //cima esquerda
                if (new Posicao((posi.Linha - 1), (posi.Coluna - 1)).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //cima direita
                if (new Posicao((posi.Linha - 1), (posi.Coluna + 1)).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //baixo esquerda
                if (new Posicao((posi.Linha + 1), (posi.Coluna - 1)).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
                //baixo direita 
                if (new Posicao((posi.Linha + 1), (posi.Coluna + 1)).Equals(m.PosicaoDaMina))
                {
                    perigo++;
                }
            }
            return perigo;
        }
        public static int ColocarBandeira(Posicao posi)
        {
            int perigo = 12;
            return perigo;
        }
    }
}
