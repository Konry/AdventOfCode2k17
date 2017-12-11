using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day4 : DayInterface
    {
        string[] list = null;
        public void initialize(string[] lines, Reader toLoadFor)
        {
            list = lines;
        }

        public void runTask1()
        {
            int correct = 0;

            foreach(string set in list){
                string[] split = set.Split(' ');

                HashSet<string> found = new HashSet<string>();
                Boolean alreadyContains = false;
                foreach (string tmp in split)
                {
                    if (!found.Contains(tmp))
                    {
                        found.Add(tmp);
                    }
                    else
                    {
                        alreadyContains = true;
                    }
                }
                if (!alreadyContains)
                {
                    correct++;
                }
            }
            Console.WriteLine(correct);
        }

        public void runTask2()
        {
            int correct = 0;

            foreach (string set in list)
            {
                string[] split = set.Split(' ');

                HashSet<string> found = new HashSet<string>();
                HashSet<string> foundSorted = new HashSet<string>();
                Boolean alreadyContains = false;
                foreach (string tmp in split)
                {
                    if (!found.Contains(tmp) && !found.Contains(Reverse(tmp)) && !foundSorted.Contains(String.Concat(tmp.OrderBy(c => c))))
                    {
                        found.Add(tmp);
                        foundSorted.Add(String.Concat(tmp.OrderBy(c => c)));
                    }
                    else
                    {
                        alreadyContains = true;
                    }
                }
                if (!alreadyContains)
                {
                    correct++;
                }
            }
            /* 448 too high */
            /* 425 too high */
            Console.WriteLine(correct);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public void runTestTask1()
        {
            initialize(new string[] { "aa bb cc dd ee", "aa bb cc dd aa", "aa bb cc dd aaa" }, Reader.BOTH);
            runTask1();
        }

        public void runTestTask2()
        {
            initialize(new string[] { "abcde xyz ecdab" }, Reader.BOTH);
            runTask2();
            //initialize(new string[] { "abcde fghij", "abcde xyz ecdab", "a ab abc abd abf abj", "iiii oiii ooii oooi oooo", "oiii ioii iioi iiio" }, Reader.BOTH);
            //runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
