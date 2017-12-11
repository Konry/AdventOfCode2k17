using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day10 : DayInterface
    {
        int[] input;
        int[] inputChar;
        //LinkedList<int> valuelist;
        int listLength = 256;
        int[] resultArray;

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }

        public void initialize(string[] lines, Reader toLoadFor)
        {
            Console.WriteLine(toLoadFor);
            if (toLoadFor == Reader.BOTH)
            {
                Console.WriteLine("reader both");
                this.listLength = 5;
            }
            else
            {
                Console.WriteLine("reader One");
                this.listLength = 256;
            }

            string[] split = lines[0].Split(',');
            input = new int[split.Length];
            for (int i = 0; i< split.Length; i++)
            {
                input[i] = Convert.ToInt32(split[i]);
            }

            //valuelist = new LinkedList<int>();
            resultArray = new int[listLength];
            for (int i = 0; i < listLength; i++)
            {
                //valuelist.AddLast(i);
                resultArray[i] = i;
            }
            Console.WriteLine("#################  " + listLength);

            char[] charArray = lines[0].ToCharArray();
            inputChar = new int[charArray.Length + 5];
            for (int i = 0; i < charArray.Length; i++)
            {
                inputChar[i] = Convert.ToInt32(charArray[i]);
                //Console.WriteLine(inputChar[i] + "  " +charArray[i]);
            }

            new int[] { 17, 31, 73, 47, 23}.CopyTo(inputChar, charArray.Length);

            //foreach (int i in inputChar)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
        }

        public void runTask1()
        {
            int index = 0;
            int toIndex = 0;

            int skipSize = -1;


            using (StreamWriter file = new StreamWriter("export.csv"))
            {
                    foreach (int inp in input)
                    {
                        if (inp != 0)
                        {
                            //Console.WriteLine("input " + inp);
                            LinkedList<int> llReverse = new LinkedList<int>();
                            LinkedList<int> listSinceIndex = new LinkedList<int>();

                            LinkedList<int> newList = new LinkedList<int>();


                            //LinkedList<int> ll = new LinkedList<int>();

                            toIndex = (index + inp) % listLength;

                            /* if toIndex > index then in same size */
                            /* else the index goes over the edge */

                            bool reverseComplete = false;

                            int ind = index % listLength;
                            while (!reverseComplete)
                            {
                                llReverse.AddFirst(resultArray[ind]);
                                ind = (++ind) % listLength;

                                //Console.WriteLine("check " + ind + " listLength " + listLength + " toIndex " + toIndex);
                                if (ind == toIndex)
                                {
                                    reverseComplete = true;
                                }
                            }

                            file.WriteLine("invered from " + index + " to " + toIndex);
                            file.WriteLine("Revert Array");

                            foreach (int i in resultArray)
                            {
                                file.Write(i + ",");
                            }
                            file.WriteLine();

                            int startIndex = index;
                            int endIndex = (index + llReverse.Count) % listLength;

                            file.WriteLine("Start Array");

                            foreach (int i in resultArray)
                            {
                                file.Write(i + ",");
                            }
                            file.WriteLine();

                            /* case A : start in range , end in range */

                            int j = 0;
                            if (endIndex > startIndex)
                            {
                                for (int i = startIndex; i < endIndex; i++)
                                {
                                    resultArray[i] = llReverse.ElementAt(j);
                                    j++;
                                }
                            }
                            else
                            {
                                /* case Start in range , ende before start */

                                for (int i = startIndex; i < listLength; i++)
                                {
                                    resultArray[i] = llReverse.ElementAt(j);
                                    j++;
                                }
                                for (int i = 0; i < endIndex; i++)
                                {
                                    resultArray[i] = llReverse.ElementAt(j);
                                    j++;
                                }
                            }

                            file.WriteLine("Result Array");

                            foreach (int i in resultArray)
                            {
                                file.Write(i + ",");
                            }
                            file.WriteLine();
                            file.WriteLine();
                            file.WriteLine();


                        }
                            skipSize++;
                            //Console.WriteLine("old index  " + index + " skip " + skipSize + " inp " +inp + "," + valuelist.Count+" add " + (skipSize + inp));
                            index = (index + skipSize + inp) % resultArray.Length;

                        //Console.WriteLine("new index  " + index + " skip " + skipSize + " inp " + inp+ "," +valuelist.Count) 


                        //var name = Console.ReadLine();

                    }
                }
            //Console.WriteLine("new row");
            //foreach (int i in resultArray)
            //{
            //    Console.Write(i + " - ");
            //}
            //Console.WriteLine();
            ///*14042 too low*/
            //int indexxx = (index + 1) % listLength;
            //Console.WriteLine(index);

            Console.WriteLine(resultArray[0] + " " + resultArray[1] + " " + resultArray[0] * resultArray[1]);
        }

        public void runTask2()
        {
            Console.WriteLine("run task2");
            int index = 0;
            int toIndex = 0;

            int skipSize = -1;


            using (StreamWriter file = new StreamWriter("export.csv"))
            {
                for (int repeater = 0; repeater < 64; repeater++)
                {
                    foreach (int inp in inputChar)
                    {
                        if (inp != 0)
                        {
                            //Console.WriteLine("input " + inp);
                            LinkedList<int> llReverse = new LinkedList<int>();
                            LinkedList<int> listSinceIndex = new LinkedList<int>();

                            LinkedList<int> newList = new LinkedList<int>();


                            //LinkedList<int> ll = new LinkedList<int>();

                            toIndex = (index + inp) % listLength;

                            /* if toIndex > index then in same size */
                            /* else the index goes over the edge */

                            bool reverseComplete = false;

                            int ind = index % listLength;
                            while (!reverseComplete)
                            {
                                llReverse.AddFirst(resultArray[ind]);
                                ind = (++ind) % listLength;

                                //Console.WriteLine("check " + ind + " listLength " + listLength + " toIndex " + toIndex);
                                if (ind == toIndex)
                                {
                                    reverseComplete = true;
                                }
                            }

                            file.WriteLine("invered from " + index + " to " + toIndex);
                            file.WriteLine("Revert Array");

                            foreach (int i in resultArray)
                            {
                                file.Write(i + ",");
                            }
                            file.WriteLine();

                            int startIndex = index;
                            int endIndex = (index + llReverse.Count) % listLength;

                            file.WriteLine("Start Array");

                            foreach (int i in resultArray)
                            {
                                file.Write(i + ",");
                            }
                            file.WriteLine();

                            /* case A : start in range , end in range */

                            int j = 0;
                            if (endIndex > startIndex)
                            {
                                for (int i = startIndex; i < endIndex; i++)
                                {
                                    resultArray[i] = llReverse.ElementAt(j);
                                    j++;
                                }
                            }
                            else
                            {
                                /* case Start in range , ende before start */

                                for (int i = startIndex; i < listLength; i++)
                                {
                                    resultArray[i] = llReverse.ElementAt(j);
                                    j++;
                                }
                                for (int i = 0; i < endIndex; i++)
                                {
                                    resultArray[i] = llReverse.ElementAt(j);
                                    j++;
                                }
                            }

                            file.WriteLine("Result Array");

                            foreach (int i in resultArray)
                            {
                                file.Write(i + ",");
                            }
                            file.WriteLine();
                            file.WriteLine();
                            file.WriteLine();


                        }
                        if (repeater == 63)
                        {
                            skipSize++;
                            //Console.WriteLine("old index  " + index + " skip " + skipSize + " inp " +inp + "," + valuelist.Count+" add " + (skipSize + inp));
                            index = (index + skipSize + inp) % resultArray.Length;
                        }

                        //Console.WriteLine("new index  " + index + " skip " + skipSize + " inp " + inp+ "," +valuelist.Count) 


                        //var name = Console.ReadLine();

                    }
                    Console.WriteLine("new row");
                    foreach (int i in resultArray)
                    {
                        Console.Write(i + " - ");
                    }
                    Console.WriteLine();
                }
            }
            //Console.WriteLine("new row");
            //foreach (int i in resultArray)
            //{
            //    Console.Write(i + " - ");
            //}
            //Console.WriteLine();
            ///*14042 too low*/
            //int indexxx = (index + 1) % listLength;
            //Console.WriteLine(index);

            Console.WriteLine(resultArray[0] + " " + resultArray[1] + " " + resultArray[0] * resultArray[1]);

        }

        public void runTestTask1()
        {
            this.listLength = 5;
            //initialize(new string[] { "3,4,1,5" }, Reader.BOTH);
            runTask1();
        }

        //public string getHashString(int[] arr)
        //{
        //    for(int i = 0; i < 16; i++)
        //    {
                
        //        for (int j = 0; j < 16; j++)
        //        {

        //        }
        //    }
        //}

        public void runTestTask2()
        {

            //this.listLength = 5;
            runTask2();
            //int[] a = new int[] { 1,2,3};
            //Console.WriteLine(getHashString(a));
        }
    }
}
 