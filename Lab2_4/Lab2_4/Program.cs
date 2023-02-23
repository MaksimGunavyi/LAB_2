using System;
using System.Collections.Generic;

namespace DelegateLambda
{
    class Program
    {
        delegate int StringLengthDelegate(string s);

        static void Main(string[] args)
        {
            List<string> strings = new List<string>()
            {
                "Hello",
                "World",
            };

            // Создание делегата с помощью лямбда-выражения
            StringLengthDelegate stringLength = s => s.Length;

            // Использование делегата для обработки списка строк
            foreach (string s in strings)
            {
                int length = stringLength(s);
                Console.WriteLine(s + " - " + length);
            }

            Console.ReadLine();
        }
    }
}