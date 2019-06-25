using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

/// <summary>
/// This is modified version for hackerrank website
/// </summary>
class Solution
{

    // Complete the isBalanced function below.
    static string isBalanced(string s)
    {

        var pairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };

        var stack = new Stack<char>(); // stacked history

        foreach (var c in s)
        {
            foreach (var p in pairs)
            {
                if (c == p.Key)               // check open bracket
                {
                    stack.Push(p.Key);  // add opening bracket
                }
                else if (c == p.Value)        //check closing bracket
                {
                    if (stack.Count == 0 || p.Key != stack.Peek())
                        return "NO";

                    stack.Pop();  // remove closing bracket
                }
            }
        }

        if (stack.Count == 0)
        {
            return "YES";
        }
        else
        {
            return "NO";
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
