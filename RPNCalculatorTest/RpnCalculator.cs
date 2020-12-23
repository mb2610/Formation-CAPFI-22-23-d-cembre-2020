using System;
using System.Collections.Generic;

namespace RPNCalculatorTest
{
    public class RpnCalculator
    {
        private readonly Dictionary<string, Func<int, int, int>> _operators =
            new Dictionary<string, Func<int, int, int>>
            {
                ["+"] = (a, b) => a + b,
                ["-"] = (a, b) => a - b,
                ["/"] = (a, b) => a / b,
                ["*"] = (a, b) => a * b
            };


        public string Evaluate(string expression)
        {
            if (!ContainsOperator(expression))
                return expression;

            var operands = new Stack<int>();

            foreach (var token in expression.Split(' '))
                if (_operators.ContainsKey(token))
                {
                    var operand1 = operands.Pop();
                    var operand2 = operands.Pop();
                    operands.Push(_operators[token](operand2, operand1));
                }
                else
                {
                    operands.Push(int.Parse(token));
                }

            return operands.Pop().ToString();
        }

        private bool ContainsOperator(string expression)
        {
            foreach (var (key, _) in _operators)
                if (expression.Contains(key))
                    return true;
            return false;
        }
    }
}