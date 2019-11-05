using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;

namespace FileMonitor.Infrasctructure.Operations.Css
{
    /// <summary>
    /// css brackets balance checker
    /// </summary>
    public class CssBracketsBalanceChecker : IOperation
    {
        public string OperationName { get; set; }

        public CssBracketsBalanceChecker(string operationName)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                throw new ArgumentNullException("The observer must be assigned a name.");
            }

            OperationName = operationName;
        }

        public void Run(Document document, out object result)
        {
            Console.WriteLine("css brackets balanser run");

            var text = File.ReadAllText(document.FullPath);

            result = false;

            var bracketsPair = new Dictionary<char, char>()
            {
                {'{','}' }
            };

            Stack<char> brackets = new Stack<char>();

            foreach (var c in text)
            {
                if (bracketsPair.Keys.Contains(c))
                {
                    brackets.Push(c);
                }
                else
                {
                    if (bracketsPair.Values.Contains(c))
                    {
                        if (c == bracketsPair[brackets.First()])
                        {
                            brackets.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            result = brackets.Count == 0 ? true : false;

            Console.WriteLine($"css brackets is balanced = {result}");
        }
    }
}
