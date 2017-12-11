using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Program
    {
        static void Main(string[] args)
        {

            DayInterface di = new Day11();

            di.initialize(new string[] { "3,4,1,5" }, Reader.BOTH);
            di.runTestTask1();

            di.initialize(FileReader.readFile("input/day11_1.txt"), Reader.ONE);
            di.runTask1();

            //di.initialize(new string[] { "3,4,1,5" }, Reader.BOTH);
            //di.runTestTask2();

            //di.initialize(FileReader.readFile("input/day8_1.txt"), Reader.ONE);
            //di.runTask2();

            Console.Write("Willst du beenden? ");
            Console.Out.Flush();
            var name = Console.ReadLine();

        }

        public class Node
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public Node Parent { get; set; }
            public string[] ChildNames { get; set; }
            public List<Node> Children { get; } = new List<Node>();

            public int TotalWeight()
            {
                return Weight + Children.Sum(c => c.TotalWeight());
            }
        }

        static bool IsBalanced(List<Node> nodes)
        {
            foreach (var node in nodes.Where(n => n.Children.Count > 1))
            {
                var min = node.Children.Min(c => c.TotalWeight());
                var max = node.Children.Max(c => c.TotalWeight());
                var diff = max - min;
                if (diff != 0) return false;
            }
            return true;
        }
    }
}
