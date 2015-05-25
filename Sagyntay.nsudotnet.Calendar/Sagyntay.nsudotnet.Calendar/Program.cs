using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sagyntay.nsudotnet.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime Dt;

            Console.Write("Введите дату:");
            if (DateTime.TryParse(Console.ReadLine(), out Dt))
            {
                DayOfWeek[] DW = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, 
                                   DayOfWeek.Friday,DayOfWeek.Saturday,DayOfWeek.Sunday };

                Console.WriteLine("\n Пн Вт Ср Чт Пт Сб Вс");
                Console.WriteLine(" --------------------");
                int nD = DateTime.DaysInMonth(Dt.Year, Dt.Month);
                DateTime mD = new DateTime(Dt.Year, Dt.Month, 1);
                int nW, wD = 0;
                for (nW = 0; mD.DayOfWeek != DW[nW]; nW++) Console.Write("   ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 1; i <= nD; i++)
                {
                    Console.Write(" ");
                    if (nW > 4) Console.ForegroundColor = ConsoleColor.Red;
                    else wD++;
                    if (mD == Dt) Console.BackgroundColor = ConsoleColor.Blue;
                    if (mD == DateTime.Today) Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0,2}", mD.Day);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    mD = mD.AddDays(1);
                    if (++nW % 7 == 0)
                    {
                        nW = 0;
                        Console.WriteLine();
                    }
                }
                if (nW != 0) Console.WriteLine();
                Console.WriteLine("\nРабочих дней:{0}", wD);
            }
            else Console.WriteLine("Формат или дата не верны!");
            Console.ReadKey(true);
        }
    }
}
