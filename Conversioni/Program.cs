using System;

namespace Conversioni
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] dp;
            bool[] b;
            // int Convert_Binario_To_Decimale(bool[] b)
            InserimentoB(out b, "1111111100");
            Console.WriteLine("Binario to Decimale: {0}", Convert_Binario_To_Decimale(b));
            // int Convert_Decimale_Puntato_To_Decimale(int[] dp)
            dp = new int[] { 10, 10, 10, 10 };
            Console.WriteLine("Decimale Punatato to Decimale: {0}", Convert_Decimale_Puntato_To_Decimale(dp));
            // int[] Convert_Binario_To_Decimale_Puntato(bool[] b)
            dp = Convert_Binario_To_Decimale_Puntato(b);
            Console.WriteLine("Binario to Decimale Puntato: {0}", string.Join(".", dp));
            // bool[] Convert_Decimale_Puntato_To_Binario(int[] dp)
            b = Convert_Decimale_Puntato_To_Binario(dp);
            Console.WriteLine("Decimale Puntato to Binario: {0}", string.Join("", b).Replace("True", "1").Replace("False", "0"));
            // int[] Convert_Numero_Decimale_To_Decimale_Puntato(uint numero)
            dp = Convert_Numero_Decimale_To_Decimale_Puntato(uint.MaxValue - 3);
            Console.WriteLine("Decimale to Decimale Puntato: {0}", string.Join(".", dp));
            // bool[] Convert_Numero_Decimale_To_Binario(uint numero)
            b = Convert_Numero_Decimale_To_Binario(uint.MaxValue - 3);
            Console.WriteLine("Decimale to Binario: {0}", string.Join("", b).Replace("True", "1").Replace("False", "0"));
            Console.ReadLine();
        }
        static void InserimentoB(out bool[] b, string bits)
        {
            b = new bool[32];
            int inizio = b.Length - bits.Length;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1')
                {
                    b[inizio + i] = true;
                }
            }
        }
        static int Convert_Binario_To_Decimale(bool[] b)
        {
            int intero = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i])
                {
                    intero += (int)Math.Pow(2, b.Length - i - 1);
                }
            }
            return intero;
        }
        static int Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            int intero = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                intero += dp[dp.Length - i - 1] * (int)Math.Pow(256, i);
            }
            return intero;
        }
        static int[] Convert_Binario_To_Decimale_Puntato(bool[] b)
        {
            int[] dp = new int[4];
            int intero;
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                intero = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (b[j + 8 * i])
                    {
                        intero += (int)Math.Pow(2, 7 - j);
                    }
                }
                dp[i] = intero;
            }
            return dp;
        }
        static bool[] Convert_Decimale_Puntato_To_Binario(int[] dp)
        {
            bool[] b = new bool[dp.Length * 8];
            byte numero;
            for (int i = 0; i < dp.Length; i++)
            {
                numero = (byte)dp[i];
                for (int j = 7; j >= 0 && numero > 0; j--)
                {
                    if (numero % 2 == 1)
                    {
                        b[j + i * 8] = true;
                    }
                    numero /= 2;
                }
            }
            return b;
        }
        static int[] Convert_Numero_Decimale_To_Decimale_Puntato(uint numero)
        {
            int[] dp = new int[4];
            for (int i = 0; i < dp.Length && numero > 0; i++)
            {
                dp[dp.Length - i - 1] = (int)(numero % 256);
                numero /= 256;
            }
            return dp;
        }
        static bool[] Convert_Numero_Decimale_To_Binario(uint numero)
        {
            bool[] b = new bool[32];
            for (int i = b.Length - 1; i >= 0 && numero > 0; i--)
            {
                if (numero % 2 == 1)
                {
                    b[i] = true;
                }
                numero /= 2;
            }
            return b;
        }
    }
}
