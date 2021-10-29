using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {

            //IsBalanced("{ int a = new int[ ] ( ( ) ) }");

            Evaluate("5 3 11 + -");
            Evaluate("2 2 +"); //4

        }



        public static bool IsBalanced(string s)
        {
            if(s.ToString().Length == 1)
            {
                return false;
            }

            
            Stack<char> stack = new Stack<char>();

            foreach( char c in s)
            {
                // If opening symbol, then push onto stack
                if ( c == '{' || c=='<' || c=='[' || c=='(' )
                {
                    stack.Push(c);
                }

                // If closing symbol, then see if it matches the top
                else if (c == '}' || c == '>' || c == ']' || c == ')')
                {
                    if( Matches(stack.Peek(), c) )
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }

                // If any other character, then continue/ignore it.
                else
                {
                    //continue;
                }
            }

            // If stack is empty, return true
            // else return false

            if( stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static bool Matches(char open, char close)
        {
            // do the matching
            switch (open)
            {
                case '{':
                    if (close == '}')
                    {
                        return true;
                    }
                    return false;
                case '<':
                    if (close == '>')
                    {
                        return true;
                    }
                    return false;
                case '[':
                    if (close == ']')
                    {
                        return true;
                    }
                    return false;
                case '(':
                    if (close == ')')
                    {
                        return true;
                    }
                    return false;
                default:
                    // Do Something
                    return false;
            }
        }

        // Evaluate("5 3 11 + -")	// returns -9
        // 2.4 3.8 / 2.321 +
        
        public static double? Evaluate(string s)
        {

            Stack<double> stack = new Stack<double>();

            string[] tokens = s.Split();
            string operators = "+-*/^";

            foreach (string t in tokens)
            {
                if (!operators.Contains(t))
                {
                    double d = double.Parse(t);
                    stack.Push(d);
                }
                else
                {
                    double top = stack.Pop();
                    double below = stack.Pop();
                    if (t == "+")
                    {
                        stack.Push(below + top);
                    }
                    if (t == "-")
                    {
                        stack.Push(below - top);
                    }
                    if (t == "*")
                    {
                        stack.Push(below * top);
                    }
                    if (t == "/")
                    {
                        stack.Push(below / top);
                    }
                }

            }

            // parse into tokens (strings)
            // foreach token
                // If token is an integer
                // Push on stack
                // If token is an operator
                    // Pop twice and save both values
                    // (if you can't pop twice, then return null)
                    // Perform operation on 2 values (in the correct order)
                    // Push the result on to stack


            if ( stack.Count != 1)
            {
                return null;
            }

            return stack.Pop();
        }



    }
}
