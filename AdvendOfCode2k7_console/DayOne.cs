using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class DayOne : DayInterface
    {
        string value = "";
        int[] intArray;

        public void initialize(string[] lines, Reader toLoadFor)
        {
            value = lines[0];

            intArray = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                int temp = Int32.Parse(value[i].ToString());
                intArray[i] = temp;
            }

        }

        public void runTask1()
        {

            int sum = 0;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (i < intArray.Length - 1 )
                {
                    if (intArray[i] == intArray[i + 1])
                    {
                        sum += intArray[i];
                    }
                }else
                {
                    if (intArray[i] == intArray[0])
                    {
                        sum += intArray[i];
                    }
                }

            }
            Console.WriteLine(sum);

        }

        public void runTask2()
        {
            int sum = 0;


            for (int i = 0; i < intArray.Length; i++)
            {

                int tmp = (i + (intArray.Length / 2)) % intArray.Length;
                Console.WriteLine(i + " " + tmp + " have values " + intArray[i] +  " = " + intArray[tmp]);
                if (intArray[i] == intArray[tmp])
                {
                    sum += intArray[i];
                }

            }
            Console.WriteLine(sum);
        }

        public void runTestTask1()
        {
            initialize(new string[]{ "1122" }, Reader.ONE);
            runTask1();
            initialize(new string[] { "1111" }, Reader.ONE);
            runTask1();
            initialize(new string[] { "1234" }, Reader.ONE);
            runTask1();
            initialize(new string[] { "91212129" }, Reader.ONE);
            runTask1();
        }

        public void runTestTask2()
        {

            initialize(new string[] { "1212" }, Reader.ONE);
            runTask2();
            initialize(new string[] { "1221" }, Reader.ONE);
            runTask2();
            initialize(new string[] { "123425" }, Reader.ONE);
            runTask2();
            initialize(new string[] { "123123" }, Reader.ONE);
            runTask2();
            initialize(new string[] { "12131415" }, Reader.ONE);
            runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
