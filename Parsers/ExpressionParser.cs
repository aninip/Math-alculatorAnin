using System.Collections.Generic;

namespace MathCalculatorAnin.Parsers
{
    public class ExpressionParser
    {
        public List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var currentToken = string.Empty;
            bool lastCharWasOperator = false;

            expression = expression.Replace('.', ',');

            foreach (var ch in expression)
            {
                if (char.IsDigit(ch) || ch == ',')
                {
                    currentToken += ch;
                    lastCharWasOperator = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }

                    if (ch != ' ')
                    {
                        if (ch == '-' && (tokens.Count == 0 || lastCharWasOperator))
                        {
                            currentToken += ch;
                        }
                        else
                        {
                            tokens.Add(ch.ToString());
                        }
                        lastCharWasOperator = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }
    }
}
