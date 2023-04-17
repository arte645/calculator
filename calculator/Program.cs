using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace calculator
{
    interface IMath
    {
        void AdditionMethod(int num1, int num2);

        void SubstractionMethod(int num1, int num2);

        void MultiplicationMethod(int num1, int num2);

        void DivideMethod(int num1, int num2);

    }

    class Calculator:IMath
    {
        public delegate void Addition(int num1, int num2);
        public delegate void Subtraction(int num1, int num2);
        public delegate void Multiplication(int num1, int num2);
        public delegate void Divide(int num1, int num2);

        public void AdditionMethod(int num1, int num2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{num1}+{num2}={num1 + num2}");
        }

        public void SubstractionMethod(int num1, int num2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{num1}-{num2}={num1 - num2}");
        }

        public void MultiplicationMethod(int num1, int num2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{num1}*{num2}={num1 * num2}");
        }

        public void DivideMethod(int num1, int num2)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{num1}/{num2}={num1 / num2}");
        }
    }

    internal class Program
    {
        static int Move(int i, int n, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                i =  (n + i - 1) % n;
            }
            else if(key.Key==ConsoleKey.DownArrow)
            {
                i = (n - (n - i - 1)) % n;
            }
            return i;
        }

        static void Main(string[] args)
        {
            Calculator calculator= new Calculator();

            Calculator.Addition sum = calculator.AdditionMethod;
            Calculator.Subtraction minus = calculator.SubstractionMethod;
            Calculator.Multiplication multi = calculator.MultiplicationMethod;
            Calculator.Divide div = calculator.DivideMethod;


            int i = 0;
            int n = 5;
            while (true)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine("Выберите шо вам надо сделать да");
                Console.WriteLine("Сложить");
                Console.WriteLine("Отнять");
                Console.WriteLine("Умножит");
                Console.WriteLine("Паделит на целом(ну норм же без дабла)");
                Console.WriteLine("Вихад");

                Console.SetCursorPosition(40, i+1);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    switch (i)
                    {
                        case 0:
                            int num1 = int.Parse(Console.ReadLine());
                            int num2 = int.Parse(Console.ReadLine());
                            sum(num1,num2);
                            break;
                        case 1:
                            num1 = int.Parse(Console.ReadLine());
                            num2 = int.Parse(Console.ReadLine());
                            minus(num1,num2);
                            break;
                        case 2:
                            num1 = int.Parse(Console.ReadLine());
                            num2 = int.Parse(Console.ReadLine());
                            multi(num1, num2);
                            break;
                        case 3:
                            num1 = int.Parse(Console.ReadLine());
                            num2 = int.Parse(Console.ReadLine());
                            div(num1,num2);
                            break;
                        default:
                            return;
                    }
                    Console.WriteLine("Ну ВрОдЕ НиЧё ТаК");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else i = Move(i, n, key);

            }

        }
    }
}
