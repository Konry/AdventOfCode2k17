using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day9 : DayInterface
    {
        string[] lines;

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }

        public void initialize(string[] lines, Reader toLoadFor)
        {
            this.lines = lines;
        }

        public void runTask1()
        {
            string input = lines[0];

            char[] charArr = input.ToCharArray();
            while (charArr.Contains('!'))
            {
                for (int i = 0; i < charArr.Length; i++)
                {
                    if (charArr[i] == '!')
                    {
                        charArr[i] = ' ';
                        if ( i + 1 < charArr.Length)
                        {
                            charArr[i + 1] = ' ';
                        }
                    }
                }
            }
            int garbageCount = 0;

            input = new string(charArr);
            input = input.Replace(" ", "");
            charArr = input.ToCharArray();

            while (charArr.Contains('>'))
            {
                int indexUp = -1;

                for (int i = 0; i < charArr.Length; i++)
                {
                    if (charArr[i] == '<' && indexUp < 0)
                    {
                        indexUp = i;
                    }

                    if(charArr[i] == '>')
                    {
                        garbageCount += i - indexUp - 1;
                        //Console.WriteLine("delete between " + indexUp + " " + i);
                        for (int j = indexUp; j <= i; j++)
                        {
                            charArr[j] = ' ';
                        }
                        indexUp = -1;
                    }
                }
            }

            
            input = new string(charArr);
            input = input.Replace(" ", "");

            int count = 0;
            int score = 1;
            int result = 0;
            foreach(char c in input.ToCharArray())
            {
                if (c == '{')
                {
                    result += score;
                    count++;
                    score++;
                }
                if (c == '}')
                {
                    score--;
                }
            }
            /* 1290 */
            Console.WriteLine(input + " " +count + "  " + result + " garbage " + garbageCount);
        }

        public void runTask2()
        {
            throw new NotImplementedException();
        }

        public void runTestTask1()
        {
            initialize(new string[] { "{}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{{}}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{},{}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{{},{},{{}}}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{<{},{},{{}}>}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{<a>,<a>,<a>,<a>}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{<a>},{<a>},{<a>},{<a>}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{<!>},{<!>},{<!>},{<a>}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{<ab>},{<ab>},{<ab>},{<ab>}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{<!!>},{<!!>},{<!!>},{<!!>}}" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "{{<a!>},{<a!>},{<a!>},{<ab>}}" }, Reader.BOTH);
            runTask1();
        }

        public void runTestTask2()
        {
            initialize(new string[] { "<>" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "<random characters>" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "<<<<>" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "<{!>}>" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "<!!>" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "<!!!>>" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "<{o\"i!a,<{i<a>" }, Reader.BOTH);
            runTask1();
        }
    }
}
