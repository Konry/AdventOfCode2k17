using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day5 : DayInterface
    {
        string[] value;
        int[] arr;

        public void initialize(string[] lines, Reader toLoadFor)
        {
            value = lines;
            arr = new int[value.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                //Console.WriteLine(value[i]);
                arr[i] = Convert.ToInt32(value[i]);
            }
        }

        public void runTask1()
        {
            int index = 0;
            int steps = 0;
            while(index < arr.Length)
            {
                int tmp = index;
                index += arr[index];
                arr[tmp]++;
                steps++;
                //Console.WriteLine("sit at " + index + " after "+ steps);
            }
            Console.WriteLine(steps);

        }

        public void runTask2()
        {
            int index = 0;
            int steps = 0;
            while (index < arr.Length)
            {
                int tmp = index;
                index += arr[index];
                if (arr[tmp] >= 3)
                {
                    arr[tmp]--;
                }
                else
                {
                    arr[tmp]++;
                }
                steps++;
                //Console.WriteLine("sit at " + index + " after "+ steps);
            }
            Console.WriteLine(steps);
        }

        public void runTestTask1()
        {

            initialize(new string[] { "0","3","0", "1","-3"}, Reader.BOTH);
            runTask1();
        }

        public void runTestTask2()
        {

            initialize(new string[] { "0", "3", "0", "1", "-3" }, Reader.BOTH);
            runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
