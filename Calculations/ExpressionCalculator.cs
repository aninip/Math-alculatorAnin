using System;
using System.Collections.Generic;
using MathСalculatorAnin.Operators;

namespace MathCalculatorAnin.Calculations
{
    public class ExpressionCalculator
    {
        private readonly Dictionary<string, IOperator> operators;

        public ExpressionCalculator()
        {
            operators = new Dictionary<string, IOperator>
            {
                { "+", new AdditionOperator() },
                { "-", new SubtractionOperator() },
                { "*", new MultiplicationOperator() },
                { "/", new DivisionOperator() }
            };
        }

        /// <summary>
        /// Вычисляет значение математического выражения, представленное в виде списка токенов.
        /// Использует алгоритм "обратной польской записи" (RPN) для обработки выражения.
        /// </summary>
        /// <param name="tokens">Список строковых токенов, представляющих математическое выражение.</param>
        /// <returns>Результат вычисления выражения.</returns>
        /// <exception cref="ArgumentException">Вызывается, если список токенов пуст или равен null.</exception>
        /// <exception cref="FormatException">Вызывается, если выражение содержит ошибки.</exception>
        /// <exception cref="KeyNotFoundException">Вызывается, если найден неизвестный оператор или символ.</exception>
        public double Calculate(List<string> tokens)
        {
            if (tokens == null || tokens.Count == 0)
            {
                throw new ArgumentException("Выражение не может быть пустым.");
            }

            Stack<double> values = new Stack<double>();
            Stack<string> ops = new Stack<string>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    values.Push(number);
                }
                else if (token == "(")
                {
                    ops.Push(token);
                }
                else if (token == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        if (values.Count < 2)
                        {

                            throw new FormatException("Некорректное выражение: недостаточно значений для операции.");

                        }
                        values.Push(ApplyOperator(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    if (ops.Count == 0 || ops.Pop() != "(")
                    {

                        throw new FormatException("Некорректное выражение: отсутствует открывающая скобка.");

                    }
                }
                else if (operators.ContainsKey(token))
                {
                    while (ops.Count > 0 && operators.ContainsKey(ops.Peek()) &&
                           operators[ops.Peek()].Precedence >= operators[token].Precedence)
                    {
                        if (values.Count < 2)
                        {

                            throw new FormatException("Некорректное выражение: недостаточно значений для операции.");

                        }
                        values.Push(ApplyOperator(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Push(token);
                }
                else
                {
                    throw new KeyNotFoundException($"Неизвестный оператор или символ: {token}");
                }
            }

            while (ops.Count > 0)
            {
                if (values.Count < 2)
                {
                    throw new FormatException("Некорректное выражение: недостаточно значений для операции.");
                }
                values.Push(ApplyOperator(ops.Pop(), values.Pop(), values.Pop()));
            }

            if (values.Count != 1)

            {

                throw new FormatException("Некорректное выражение: лишние значения.");

            }

            return values.Pop();
        }

        private double ApplyOperator(string op, double right, double left)
        {
            if (operators.ContainsKey(op))
            {
                return operators[op].Calculate(left, right);
            }

            throw new KeyNotFoundException($"Оператор {op} не поддерживается.");
        }
    }
}
