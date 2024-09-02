using System;
using System.Collections.Generic;
using MathCalculatorAnin.Calculations;
using MathCalculatorAnin.Parsers;

namespace MathСalculatorAnin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ExpressionCalculator();
            var parser = new ExpressionParser();
            Console.WriteLine("Добро пожаловать в калькулятор! Введите математическое выражение или 'exit' для выхода.");

            while (true)
            {
                try
                {
                    Console.Write("\nВведите выражение: ");
                    string input = Console.ReadLine();

                    if (input?.Trim().ToLower() == "exit")
                    {
                        Console.WriteLine("Завершение программы...");
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Выражение не может быть пустым. Попробуйте снова.");
                        continue;
                    }

                    List<string> tokens = parser.Tokenize(input);
                    double result = calculator.Calculate(tokens);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
