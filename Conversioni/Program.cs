using System;
using System.Data.Common;

namespace Conversioni
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool[] b = new bool[32];
            int[] dp;
            uint decimale;
            InserimentoB(b);
            Console.WriteLine("Il numero intero è {0}", Convert_Binario_To_Decimale(b));
            Console.WriteLine("Il numero decimale puntato è: {0}", string.Join(".", Convert_Binario_To_Decimale_Puntato(b)));
            InserimentoDP(out dp);
            Console.WriteLine("Il numero intero è {0}", Convert_Decimale_Puntato_To_Decimale(dp));
            b = Convert_Decimale_Puntato_To_Binario(dp);
            Console.WriteLine("Il numero decimale puntato è: {0}", string.Join(".", Convert_Binario_To_Decimale_Puntato(b)));
            decimale = uint.MaxValue - 1;
            dp = Convert_Numero_Decimale_To_Decimale_Puntato(decimale);
            Console.WriteLine("Il numero decimale puntato è: {0}", string.Join(".", dp));
            Console.ReadLine();
        }
        static void InserimentoB(bool[] b)
        {
            string temp;
            int j = 0;
            Console.Write("Inserisci la serie di bit (Massimo 4 byte): ");
            temp = Console.ReadLine();
            for (int i = 32 - temp.Length; i < 32; i++)
            {
                if (temp[j] == '1')
                {
                    b[i] = true;
                }
                j++;
            }
        }
        static void InserimentoDP(out int[] dp)
        {
            string temp;
            dp = new int[4];
            Console.Write("Inserisci numero decimale puntato: ");
            temp = Console.ReadLine();
            string[] split = temp.Split('.');
            for (int i = 0; i < split.Length; i++)
            {
                dp[i] = Convert.ToInt32(split[i]);
            }
        }
        static int Convert_Binario_To_Decimale(bool[] b)
        {
            int intero = 0, len = b.Length - 1;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i])
                {
                    intero += (int)Math.Pow(2, len - i);
                }
            }
            return intero;
        }
        static int Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            int intero = 0, len = dp.Length - 1;
            for (int i = 0; i < dp.Length; i++)
            {
                intero += dp[len - i] * (int)Math.Pow(256, i);
            }
            return intero;
        }
        static int[] Convert_Binario_To_Decimale_Puntato(bool[] b)
        {
            int[] dp = new int[4];
            int intero, next;
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                intero = 0;
                next = (i + 1) * 8;
                for (int j = i * 8; j < next; j++)
                {
                    if (b[j])
                    {
                        intero += (int)Math.Pow(2, next - j - 1);
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
    }
}
