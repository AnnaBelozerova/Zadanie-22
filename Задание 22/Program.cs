using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0,200);
            }
           

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,5}", array[i]);
            }
            Console.WriteLine();           


            Task task1 = new Task(() => Sum(array));
            task1.Start();
            task1.Wait();

            
            Task task2 = task1.ContinueWith(
                t => 
                {
                    int max = array[0];
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (array[i] > max)
                            max = array[i];
                    }
                    Console.WriteLine("Максимальное число: {0}", max);
                });
            task2.Wait();



            Console.WriteLine("Метод Main закончил работу.");
            Console.ReadKey();
        }
        static void Sum(int[] array )
        {
            
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("Сумма чисел равна: {0}", sum);
            
        }
              

    }
}
