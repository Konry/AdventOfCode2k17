using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day6 : DayInterface
    {
        string line;

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }

        public void initialize(string[] lines, Reader toLoadFor)
        {
            line = lines[0];
        }

        public void runTask1()
        {
            string[] split = line.Split('\t');
            int[] memoryBank = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                memoryBank[i] = Convert.ToInt32(split[i]);
            }

            HashSet<string> memoryMap = new HashSet<string>();

            bool inside = false;
            int toDistribute, index;
            int circle = 0;

            //Console.WriteLine(string.Join("", memoryBank));
            memoryMap.Add(string.Join("", memoryBank));

            while (!inside)
            {
                toDistribute = memoryBank.Max();
                index = memoryBank.ToList().IndexOf(toDistribute);            

                memoryBank[index] = 0;
                while (toDistribute != 0)
                {
                    index = (index + 1) % memoryBank.Length;
                    memoryBank[index]++;
                    toDistribute--;
                }
                circle++;

                if (!memoryMap.Contains(string.Join("", memoryBank))){

                    //Console.WriteLine("add to "+ string.Join("", memoryBank) );
                    memoryMap.Add(string.Join("", memoryBank));
                }
                else
                {
                    inside = true;
                    Console.WriteLine("end "+circle);
                }
            }
        }

        public void runTask2()
        {
            string[] split = line.Split('\t');
            int[] memoryBank = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                memoryBank[i] = Convert.ToInt32(split[i]);
            }

            HashSet<string> memoryMap = new HashSet<string>();

            bool inside = false;
            bool insideCircle = false;
            string memoryCircleBegin = "";
            int toDistribute, index;
            int circle = 0;
            
            memoryMap.Add(string.Join("", memoryBank));

            while (!insideCircle)
            {
                toDistribute = memoryBank.Max();
                index = memoryBank.ToList().IndexOf(toDistribute);

                memoryBank[index] = 0;
                while (toDistribute != 0)
                {
                    index = (index + 1) % memoryBank.Length;
                    memoryBank[index]++;
                    toDistribute--;
                }

                if (!memoryMap.Contains(string.Join("", memoryBank)))
                {
                    memoryMap.Add(string.Join("", memoryBank));
                }
                else
                {
                    inside = true;

                    if (memoryCircleBegin == "")
                    {
                        memoryCircleBegin = string.Join("", memoryBank);
                    }
                    else
                    {
                        if (string.Join("", memoryBank) == memoryCircleBegin)
                        {
                            Console.WriteLine("end " + circle);
                            insideCircle = true;
                        }
                    }
                    circle++;
                }
               
            }
        }

        public void runTestTask1()
        {
            initialize(new string[]{ "0\t2\t7\t0"}, Reader.BOTH);
            runTask1();
        }

        public void runTestTask2()
        {

            initialize(new string[] { "0\t2\t7\t0" }, Reader.BOTH);
            runTask2();
        }
    }
}
