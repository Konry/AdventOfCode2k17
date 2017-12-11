using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day11 : DayInterface
    {
        string[] directions;
        string complete;
        public void initialize(string[] lines, Reader toLoadFor)
        {
            this.directions = lines[0].Split(',');
            this.complete = lines[0];
        }

        public void runTask1()
        {
            int posx = 0, posy = 0, posz = 0;
            
            int distance = 0;
            int max = Int32.MinValue;
            foreach (string dir in directions)
            {
                switch (dir)
                {
                    case "n":
                        posy++;
                        posz--;
                        break;
                    case "s":
                        posy--;
                        posz++;
                        break;
                    case "nw":
                        posy++;
                        posx--;
                        break;
                    case "sw":
                        posz++;
                        posx--;
                        break;
                    case "se":
                        posx++;
                        posy--;
                        break;
                    case "ne":
                        posx++;
                        posz--;
                        break;
                }
                Console.WriteLine("posx " + posx + " posy " + posy + " posz " + posz);
                distance = CalcDistance(posx, posy, posz);

                if (distance > max)
                {
                    max = distance;
                }
            }

            Console.WriteLine("END: " + distance + " maxdistance " + max);
            /* 1789 */
            /* 715*/
            var name = Console.ReadLine();
        }

        private int CalcDistance(int posx, int posy, int posz)
        {
            return (Math.Abs(posx) + Math.Abs(posy) + Math.Abs(posz)) / 2;
        }

        public void runTask2()
        {
            throw new NotImplementedException();
        }

        public void runTestTask1()
        {
            initialize(new string[] { "ne,ne,ne" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "ne,ne,sw,sw" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "ne,ne,s,s" }, Reader.BOTH);
            runTask1();
            initialize(new string[] { "se,sw,se,sw,sw" }, Reader.BOTH);
            runTask1();
        }

        public void runTestTask2()
        {
            throw new NotImplementedException();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
