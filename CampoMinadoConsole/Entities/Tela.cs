using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoConsole.Entities
{
    internal static class Tela
    {
        public static void ResetCorEFormatacao()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }
        public static void AuxImprimir(List<Mina> Minas, int[,] matrizTabela, int i, int j)
        {
            if (matrizTabela[i, j] == 8)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 12)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("B");
                Console.ForegroundColor = ConsoleColor.Black;
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 9)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.Black;
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 7)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 6)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 5)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 4)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 3)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 2)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else if (matrizTabela[i, j] == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(matrizTabela[i, j]);
                ResetCorEFormatacao();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("?");
                ResetCorEFormatacao();
            }
        }
        public static void ImprimirTelaCompleta(List<Mina> Minas, int[,] matrizTabela)
        {
            Console.Clear();
            for (int i = 1; i < 9; i++)
            {
                char x = (char)(i + 64);
                Console.Write(x + "  ");
                Console.ForegroundColor = ConsoleColor.Black;
                for (int j = 1; j < 11; j++)
                {
                    Tela.AuxImprimir(Minas, matrizTabela, i, j);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("x");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.WriteLine("   1  2  3  4  5  6  7  8  9  10");
        }
    }
}
