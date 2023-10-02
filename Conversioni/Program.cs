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
            int intero = 0;
            for (int i = 0; i < b.Length; i++)
            {
                intero += Convert.ToInt32(b[31 - i]) * (int)Math.Pow(2, i);
            }
            return intero;
        }
        static int Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            int intero = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                intero += dp[3 - i] * (int)Math.Pow(256, i);
            }
            return intero;
        }
    }
}
