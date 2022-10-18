using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mylibcs
{
    public class MyCalculator
    {
        /// <summary>
        /// Calculates the result of the operation.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int evaluateInfix(string expression)
        {
            char[] tokens = expression.ToCharArray();

            Stack<int> values = new Stack<int>();

            Stack<char> ops = new Stack<char>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == ' ')
                {
                    continue;
                }

                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sbuf = new StringBuilder();

                    while (i < tokens.Length &&
                            tokens[i] >= '0' &&
                                tokens[i] <= '9')
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    values.Push(int.Parse(sbuf.ToString()));

                    i--;
                }

                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(applyOp(ops.Pop(),
                                         values.Pop(),
                                        values.Pop()));
                    }
                    ops.Pop();
                }

                else if (tokens[i] == '+' ||
                         tokens[i] == '-' ||
                         tokens[i] == '*' ||
                         tokens[i] == '/')
                {

                    while (ops.Count > 0 &&
                             hasPrecedence(tokens[i],
                                         ops.Peek()))
                    {
                        values.Push(applyOp(ops.Pop(),
                                         values.Pop(),
                                       values.Pop()));
                    }

                    ops.Push(tokens[i]);
                }
            }

            while (ops.Count > 0)
            {
                values.Push(applyOp(ops.Pop(),
                                 values.Pop(),
                                values.Pop()));
            }

            return values.Pop();
        }

        public static bool hasPrecedence(char op1,
                                 char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') &&
                   (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int applyOp(char op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new
                        System.NotSupportedException(
                               "Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }

        /// <summary>
        /// Detects missing parentheses in expression
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static bool validateInfix(string exp)
        {
            int previous = 0;
            int previous1 = 0;
            string expEvaluated = string.Empty;
            int operatorOperand = 1;

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                if (c == ')')
                {
                }
                else
                if (c == '(')
                {
                    int j = exp.IndexOf(')', i);
                    if (j == -1)
                        return false;

                    string substring = exp.Substring(i + 1, j - i - 1);

                    while (getcharactercount(substring, '(') != getcharactercount(substring, ')'))
                    {
                        if (j < exp.Length - 1)
                            j = exp.IndexOf(')', j + 1);
                        else
                            break;

                        substring = exp.Substring(i + 1, j - i - 1);
                    }

                    i = j - 1;
                    if (validateInfix(substring) == true)
                    {
                        if (previous != 0 && previous1 != 0 && previous > previous1)
                        {
                            previous1 = operatorOperand;
                            operatorOperand++;
                            previous = 0;
                        }
                        else if (previous != 0 && previous1 != 0 && previous <= previous1)
                        {
                            return false;
                        }
                        else if (previous1 != 0)
                        {
                            return false;
                        }
                        else
                        {
                            previous1 = operatorOperand;
                            operatorOperand++;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    if (c == '+'             
                   || c == '-'
                   || c == '*'
                   || c == '/')
                {
                    if (previous != 0)
                    {
                        return false;
                    }
                    previous = operatorOperand;
                    operatorOperand++;
                }
                else
                {
                    if (previous != 0 && previous1 != 0 && previous > previous1)
                    {
                        previous1 = operatorOperand;
                        operatorOperand++;
                        previous = 0;
                    }
                    else if (previous != 0 && previous1 != 0 && previous <= previous1)
                    {
                        return false;
                    }
                    else if (previous1 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        previous1 = operatorOperand;
                        operatorOperand++;
                    }
                }
            }
            if (previous != 0)
                return false;
            return true;
        }

        /// <summary>
        /// This function will convert infix to postfix, and EvaluateInfix will process postfix evaluation. This function will be used in EvaluateInfix
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string InfixToPostfixConversion(string exp)
        {
            string result = "";

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                else if (c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ')')
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression";
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else 
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
        /// <summary>
        /// A helper function to return the precedence of a given operator...
        /// Higher returned value means higher priority
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        internal static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        /// <summary>
        /// To get the requested number of transactions
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="_c"></param>
        /// <returns></returns>
        public static int getcharactercount(string exp, char _c)
        {
            int count = 0;
            foreach (char c in exp)
            {
                if (c == _c)
                    count++;
            }
            return count;
        }
    }
}