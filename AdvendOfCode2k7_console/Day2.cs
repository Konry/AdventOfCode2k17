using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day2 : DayInterface
    {
        string[] lines;

        public void initialize(string[] lines, Reader toLoadFor)
        {
            this.lines = lines;
        }

        public void runTask2()
        {
            int[] arr = new int[lines.Length];
            int sum = 0;

            foreach (string l in lines)
            {
                string[] tmp = l.Split('\t');
                int[] lineArray = new int[tmp.Length];
                int min = Int32.MaxValue;
                int max = Int32.MinValue;

                for (int i = 0; i < tmp.Length; i++)
                {
                    try
                    {
                        int temp = Int32.Parse(tmp[i]);

                        lineArray[i] = temp;
                    }
                    catch (FormatException e) { }
                }
                Console.WriteLine("Hallo");
                for (int i = 0; i < lineArray.Length; i++)
                {
                    for (int j = 0; j < lineArray.Length; j++)
                    {
                        if(i != j)
                        {
                            try
                            {
                                float x1 = lineArray[i];
                                float x2 = lineArray[j];
                                double number = x1 / x2 * 10;

                                if (number % 10 == 0)
                                {
                                    sum += Convert.ToInt32(x1 / x2);
                                    Console.WriteLine(lineArray[i] + " " + lineArray[j] + " " + number % 10 + " " + Convert.ToInt32(x1 / x2));

                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("error " + e.Message);
                            }

                        }
                    } 
                }

            }


            Console.WriteLine("sum " +sum);
        }

        public void runTask1()
        {
            int[] arr = new int[lines.Length];
            int sum = 0;

            foreach (string l in lines)
            {
                string[] tmp = l.Split('\t');
                int[] lineArray = new int[tmp.Length];
                int min = Int32.MaxValue;
                int max = Int32.MinValue;

                for (int i = 0; i < tmp.Length; i++)
                {
                    try
                    {
                        int temp = Int32.Parse(tmp[i]);
                        if (min > temp)
                        {
                            min = temp;
                        }
                        if (max < temp)
                        {
                            max = temp;
                        }
                    }
                    catch (FormatException e) { }
                }
                Console.WriteLine("#" + (max - min) + "#");
                sum += max - min;
            }


            Console.WriteLine("sum " + sum);
        }

        public void runTestTask1()
        {
            initialize(new string[] { "5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8" }, Reader.ONE);
            runTask1();
        }

        public void runTestTask2()
        {

            initialize(new string[] { "5\t9\t2\t8", "9\t4\t7\t3", "3\t8\t6\t5" }, Reader.ONE);
            runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
