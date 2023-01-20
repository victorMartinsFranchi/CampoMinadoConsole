using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoConsole.Entities
{
    internal static class TabelaDoJogo
    {
        public static void VerificadorParaNaoRepetir(Posicao posi)
        {
            Jogo.b.SetValue(true, posi.Linha, posi.Coluna);
        }
        public static void MatrizesZeradas()
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Jogo.MatrizTabela.SetValue(10, i, j);
                }
            }
        }
        public static void AddNaMatriz(Posicao posi)
        {
            Jogo.MatrizTabela.SetValue(Alertas.NiveisDeAlerta(posi), posi.Linha, posi.Coluna);
            TabelaDoJogo.VerificadorParaNaoRepetir(posi);
            //direita
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Coluna < 10 &&
                Jogo.b[posi.Linha, posi.Coluna + 1] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha, posi.Coluna + 1));
            }
            //esquerda
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Coluna > 1 &&
                Jogo.b[posi.Linha, posi.Coluna - 1] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha, posi.Coluna - 1));
            }
            //cima
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Linha > 1 &&
                Jogo.b[posi.Linha - 1, posi.Coluna] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha - 1, posi.Coluna));
            }
            //baixo
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Linha < 8 &&
                Jogo.b[posi.Linha + 1, posi.Coluna] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha + 1, posi.Coluna));
            }
            //cima esquerda
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Linha > 1 && posi.Coluna > 1 &&
                Jogo.b[posi.Linha - 1, posi.Coluna - 1] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha - 1, posi.Coluna - 1));
            }
            //cima direita
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Linha > 1 && posi.Coluna < 10 &&
                Jogo.b[posi.Linha - 1, posi.Coluna + 1] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha - 1, posi.Coluna + 1));
            }
            //baixo esquerda
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Linha < 8 && posi.Coluna > 1 &&
                Jogo.b[posi.Linha + 1, posi.Coluna - 1] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha + 1, posi.Coluna - 1));
            }
            //baixo direita
            if (Alertas.NiveisDeAlerta(posi) == 0 && posi.Linha < 8 && posi.Coluna < 10 &&
                Jogo.b[posi.Linha + 1, posi.Coluna + 1] == false)
            {
                TabelaDoJogo.AddNaMatriz(new Posicao(posi.Linha + 1, posi.Coluna + 1));
            }
        }
        public static void AddBandeiraMatriz(Posicao posi)
        {
            Jogo.MatrizTabela.SetValue(Alertas.ColocarBandeira(posi), posi.Linha, posi.Coluna);
        }
    }
}
