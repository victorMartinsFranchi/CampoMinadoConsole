using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinadoConsole.Entities
{
    internal class Jogo
    {
        public static List<Mina> Minas { get; set; }
        public static List<Mina> MinasB { get; set; }
        public static int[,] MatrizTabela { get; set; }
        public static bool[,] b { get; set; }
        public static int contadorDePrimeiraJogada { get; set; }
        public static int ContadorFinal { get; set; }
        public static bool PrimeiraVez { get; set; }
        public static bool Derrota { get; set; }
        public static void IniciarOJogo()
        {
            b = new bool[15, 15];
            MatrizTabela = new int[9, 11];
            TabelaDoJogo.MatrizesZeradas();
            Minas = Mina.MinasLista();
            Tela.ImprimirTelaCompleta(Minas, Jogo.MatrizTabela);
            contadorDePrimeiraJogada = 1;
        }
        public static void Jogada()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Entre as Cordenadas (Ex: B-3) ou uma bandeira (Ex: Bandeira E,4): ");
                string numeros = Console.ReadLine();
                string[] nums = numeros.Split('-', ' ', ',');
                if (nums[0] == "Bandeira" | nums[0] == "bandeira")
                {
                    string letra = (nums[1]);
                    letra = letra.ToUpper();
                    int l = letra[0] - 64;
                    int c = int.Parse(nums[2]);
                    Posicao posi = new Posicao(l, c);
                    Alertas.ColocarBandeira(posi);
                    TabelaDoJogo.AddBandeiraMatriz(posi);
                }
                else
                {
                    string letra = (nums[0]);
                    letra = letra.ToUpper();
                    int l = letra[0] - 64;
                    int c = int.Parse(nums[1]);
                    Posicao posi = new Posicao(l, c);
                    AcertadorDeZeros(posi);
                    TabelaDoJogo.AddNaMatriz(posi);
                    Jogo.Derrota = DerrotaVerifica(l, c);
                }
                Tela.ImprimirTelaCompleta(Jogo.Minas, MatrizTabela);
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Tela.ImprimirTelaCompleta(Jogo.Minas, MatrizTabela);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você digitou valores que são fora dos esperados! Tente denovo" +
                    " seguindo os exemplos indicados.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(FormatException)
            {
                Console.Clear();
                Tela.ImprimirTelaCompleta(Jogo.Minas, MatrizTabela);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você digitou valores que são fora dos esperados! Tente denovo" +
                    " seguindo os exemplos indicados.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void AcertadorDeZeros(Posicao posi)
        {
            if (contadorDePrimeiraJogada == 1)
            {
                while (Alertas.NiveisDeAlerta(posi) != 0)
                {
                    IniciarOJogo();
                }
            }
            contadorDePrimeiraJogada++;
        }
        public static bool Vitoria()
        {
            int soma = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (MatrizTabela[i, j] < 10 | VerificarMinas(i, j))
                    {
                        soma++;
                    }
                }
            }
            if (soma == 80)
                return true;
            return false;
        }
        public static bool DerrotaVerifica(int i, int j)
        {
            if (VerificarMinas(i, j))
                return true;
            return false;
        }
        public static bool VerificarMinas(int i, int j)
        {
            foreach (Mina m in Minas)
            {
                if (m.PosicaoDaMina.Equals(new Posicao(i, j)))
                {
                    return true;
                }
            }
            return false;
        }
        public static void Jogar()
        {
            if (contadorDePrimeiraJogada == 0)
            {
                Jogo.PrimeiraVez = false;
                IniciarOJogo();
            }
            while (!Vitoria() & !Jogo.Derrota)
            {
                Jogada();
            }
            Tela.ImprimirTelaCompleta(Jogo.Minas, MatrizTabela);
            Console.WriteLine();
            if (Vitoria())
            {
                Console.WriteLine("Parabéns você ganhou !!!");
            }
            else
            {
                Console.WriteLine("BOOOM");
                Console.WriteLine("Você Perdeu :c !!!");
            }
            contadorDePrimeiraJogada = 0;
            Derrota = false;
            Console.Write("Quer jogar denovo?(Ex: s/n): ");
            string a = Console.ReadLine();
            if (a == "s" | a == "sim" | a == "Sim" | a == "S")
                Jogar();
            else if (a == "n" | a == "nao" | a == "Nao" | a == "N" | a == "Não" | a == "não")
                Environment.Exit(0);
        }
    }
}
