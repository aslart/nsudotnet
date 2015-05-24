using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sagyntay.nsudotnet.NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name, Answer;
            int Num, nTry = 0, n = 0;
            Random Rdm = new Random();
            TimeSpan t1, t2;
            int[] Steps = new int[1000];
            string[] Remark = { "думать пора!", "луга попутал?", "мда, сегодня не в ударе", "ай малаца!" };

            Console.Write("Введите имя:");
            Name = Console.ReadLine();
            Num = Rdm.Next(101);
            //Console.WriteLine("Число:{0} потом уберу", Num);
            t1 = DateTime.Now.TimeOfDay;
            do
            {
                do
                {
                    Console.Write("{0}) Введите число 0<=n<=100:", nTry + 1);
                    Answer = Console.ReadLine().ToLower();
                } while (Answer != "q" && (!int.TryParse(Answer, out n) || n < 0 || n > 100));
                if (Answer != "q")
                {
                    if (n < Num) Console.Write("Меньше ");
                    else
                        if (n > Num) Console.Write("Больше ");
                        else Console.Write("Точно!");
                    if (n == Num || (nTry + 1) % 4 != 0) Console.WriteLine();
                    else
                    {
                        string str = string.Format(",{0},{1}", Name, Remark[Rdm.Next(Remark.Length)]);
                        Console.WriteLine(str);
                    }
                    Steps[nTry++] = n;
                }
                else Console.WriteLine("Извините");
            } while (Answer != "q" && n != Num);
            t2 = DateTime.Now.TimeOfDay;
            Console.WriteLine("\nВремя игры: {0}\nИстория игры:", (t2 - t1).ToString().Substring(0, 8));
            for (int i = 0; i < nTry; i++)
                Console.WriteLine("{0}) {1} {2}", i + 1, Steps[i],
                    (Steps[i] < Num) ? "Меньше" : (Steps[i] > Num) ? "Больше" : "Финиш");

            Console.ReadKey(true);
        }
    }
}
