using System;

namespace Conversioni
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool[] b = new bool[32];
            int[] dp;
            InserimentoB(b);
            Console.WriteLine("Il numero intero è {0}", Convert_Binario_To_Decimale(b));
            Console.WriteLine("Il numero decimale puntato è: {0}", string.Join(".", Convert_Binario_To_Decimale_Puntato(b)));
            InserimentoDP(out dp);
            Console.WriteLine("Il numero intero è {0}", Convert_Decimale_Puntato_To_Decimale(dp));
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
            int intero, j = 0, next;
            for (int i = 0; i < dp.Length; i++)
            {
                intero = 0;
                next = 8 * (i + 1);
                for (; j < next; j++)
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
    }
}
