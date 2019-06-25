using System;
using System.Collections.Generic;
using System.IO;

namespace CheckBracingInTextAlgorithm
{
    class Program
    {
        /// <summary>
        /// quotes could be difficult to manage, because of interference with special symbols and triple quotes
        /// it would be easier just to count them and check for reminder
        /// symbols.Add('<', '>');  // not always closed in code because of conditions like x < y
        /// 
        /// Demo algorithm created by Serge Klokov in 2019
        /// 
        /// based on:
        /// https://stackoverflow.com/questions/37041515/program-to-balance-the-braces
        /// https://codereview.stackexchange.com/questions/67602/check-for-balanced-parentheses
        /// https://codereview.stackexchange.com/questions/187591/stacks-balanced-brackets-hacker-rank
        /// https://rextester.com/discussion/FFL87374/Stacks-Balanced-Brackets-
        /// https://www.geeksforgeeks.org/expression-contains-redundant-bracket-not/
        /// </summary>
        /// <returns>Dictionary of char pairs</returns>
        private static Dictionary<char, char> InitializePairSymbols()
        {

            var pairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };

            return pairs;
        }

        /// <summary>
        /// Check pairing of parentesis in the text  
        /// </summary>
        /// <returns>true if pairing is correct</returns>
        private static bool IsParenthesesBracingCorrect()  
        {
            Dictionary<char, char> pairs = InitializePairSymbols();

            try
            {
                var s = new Stack<char>(); // stacked history

                //var fileName = "Test Files/Test.cs.txt";
                //var fileName = "Test Files/Test.bad.cs.txt";
                //var fileName = "Test Files/Test2.js";
                //var fileName = "Test Files/Test2.bad.js";
                //var fileName = "Test Files/Test3.html";
                //var fileName = "Test Files/Test3.bad.html";
                var fileName = "Test Files/Test4.txt";
                //var fileName = "Test Files/Test4.bad.txt";

                using (var sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (var c in line)
                        {
                            foreach (var p in pairs)
                            {
                                if (c == p.Key)               // check open bracket
                                {
                                    s.Push(p.Key);  // add opening bracket
                                }
                                else if (c == p.Value)        //check closing bracket
                                {
                                    if (s.Count == 0 || p.Key != s.Peek()) 
                                        return false;

                                     s.Pop();  // remove closing bracket
                                }
                            }
                        }

                        //Console.WriteLine(line); //to check if reading file correct
                    }
                }

               
                if (s.Count == 0)
                {
                    return true;
                }
                else
                {
                    Console.Write("Left in stack: ");

                    for (int i = 0; i < s.Count; i++)
                        Console.Write(s.Pop());

                    Console.WriteLine();

                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            if (IsParenthesesBracingCorrect())
                Console.WriteLine("Bracing is correct.");
            else
                Console.WriteLine("Bracing is incorrect.");

            Console.WriteLine();
            Console.WriteLine("Done. Please press any key to exit..");
            Console.ReadKey();
        }
    }
}
