using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day3 : DayInterface
    {
        int input = 0;
        public void initialize(string[] lines, Reader toLoadFor)
        {
            input = Int32.Parse(lines[0]);
        }

        public void runTask1()
        {
            /* calc ring */
            /* first 3x3, 5x5, 7x7 */
            int ringIndex = 1;
            int ringMaxValue = 1;
            while (ringMaxValue < input)
            {
                ringIndex += 2;
                ringMaxValue = ringIndex * ringIndex;
                /*
                Console.WriteLine("ringIndex "+ ringIndex);
                Console.WriteLine("ringMaxValue "+ ringMaxValue);
                Console.WriteLine("input "+ input);*/
            }
            Console.WriteLine("ringIndex " + ringIndex);

            /*calc position */
            int positionX = 0;
            int positionY = 0;
            int number = 0;
            if (ringIndex > 1)
            {
                positionX = (ringIndex - 1) / 2;
                positionY = -(ringIndex - 1) / 2 + 1;
                number = (ringIndex - 2) * (ringIndex - 2) + 1;
                int counter = 0;
                int corner = 0;
                while (number < input)
                {
                    //Console.WriteLine("check " + number + " counter " + counter + " posx " + positionX + " posy " + positionY + " c "+corner);
                    if (positionY < (ringIndex - 1) / 2 && corner == 0)
                    {
                        positionY++;

                        if (positionY >= (ringIndex - 1) / 2)
                        {
                            corner = 1;
                        }
                    }
                    else if (positionX > -(ringIndex - 1) / 2 && corner == 1)
                    {
                        positionX--;
                        if (positionX <= -(ringIndex - 1) / 2)
                        {
                            corner = 2;
                        }
                    }
                    else if (positionY > -(ringIndex - 1) / 2 && corner == 2)
                    {
                        positionY--;
                        if (positionY <= -(ringIndex - 1) / 2)
                        {
                            corner = 3;
                        }
                    }
                    else if (positionX < (ringIndex - 1) / 2 && corner == 3)
                    {
                        positionX++;
                        if (positionY >= (ringIndex - 1) / 2)
                        {
                            corner = 4;
                        }
                    }

                    counter++;
                    number++;
                }
                Console.WriteLine(number + " posx " + positionX + " posy " + positionY + " manhatten " + (Math.Abs(positionX) + Math.Abs(positionY)));
            }

        }

        public void runTask2()
        {
            int[][] matrix = new int[101][];
            for (int i = 0; i < 101; i++)
            {
                matrix[i] = new int[101];
                foreach (int j in matrix[i])
                {
                    matrix[i][j] = 0;
                }
            }


            int indexX = 0;
            int indexY = 0;
            int positionX = 50;
            int positionY = 50;
            int corner = 4;
            int number = 1;
            int innerCircle = 0;
            int tempNumberMax = 0;
            int ringIndex = 1;

            while (number < input)
            {

                tempNumberMax = ringIndex * ringIndex;
                indexX = positionX - 50;
                indexY = positionY - 50;

                if (positionX == 50 && positionY == 50)
                {
                    Console.WriteLine(positionX + " == " + positionY);
                    matrix[50][50] = 1;
                }
                else
                {
                    matrix[positionX][positionY] = LookInMatrix(matrix, positionX, positionY);
                }

                Console.WriteLine("val In Matrix: " + LookInMatrix(matrix, positionX, positionY) + " pos x" + indexX + " posy " + indexY);
                number = LookInMatrix(matrix, positionX, positionY);
                //var name = Console.ReadLine();

                if (number >= tempNumberMax)
                {
                    Console.WriteLine("inc Ring index ");
                    //ringIndex += 2;
                }

                if (indexY < (ringIndex - 1) / 2 && corner == 0)
                {
                    positionY++;
                    indexX = positionX - 50;
                    indexY = positionY - 50;
                    //Console.WriteLine("increment Y " + positionX + " - " + positionY + " # " + corner + " checkYS " + ((ringIndex - 1) / 2 + 50));

                    if (indexY >= (ringIndex - 1) / 2)
                    {
                        corner = 1;
                    }
                }
                else if (indexX > -(ringIndex - 1) / 2 && corner == 1)
                {
                    positionX--;
                    indexX = positionX - 50;
                    indexY = positionY - 50;
                    //Console.WriteLine("decrement X " + positionX + " - " + positionY + " # " + corner + " checkX " + (-(ringIndex - 1) / 2 + 50));
                    if (indexX <= -((ringIndex - 1) / 2))
                    {
                        corner = 2;
                    }
                }
                else if (indexY > -(ringIndex - 1) / 2 && corner == 2)
                {
                    positionY--;
                    indexX = positionX - 50;
                    indexY = positionY - 50;
                    //Console.WriteLine("decrement Y " + positionX + " - " + positionY + " # " + corner + " checkY " + (-(ringIndex - 1) / 2 + 50));
                    if (indexY <= -((ringIndex - 1) / 2))
                    {
                        corner = 3;
                    }
                }
                else if (indexX < (ringIndex - 1) / 2 && corner == 3)
                {
                    positionX++;
                    indexX = positionX - 50;
                    indexY = positionY - 50;
                    //Console.WriteLine("increment X " + positionX + " - " + positionY + " # " + corner + " checkX " + ((ringIndex - 1) / 2 + 50));
                    if (indexX >= (ringIndex - 1) / 2)
                    {
                        corner = 4;
                    }
                }
                else if (corner == 4)
                {
                    ringIndex += 2;
                    positionX++;
                    corner = 0;
                }
                else
                {
                    //Console.WriteLine("ringIndex " + ringIndex + " check index " + indexY + "  to " + (ringIndex - 1) + " corner " + corner);
                }


            }
        }

        private int LookInMatrix(int[][] matrix, int positionX, int positionY)
        {
            Console.WriteLine(positionX + " " + positionY);
            return matrix[positionX - 1][positionY - 1] +
                matrix[positionX - 1][positionY] +
                matrix[positionX - 1][positionY + 1] +
                matrix[positionX][positionY - 1] +
                matrix[positionX][positionY + 1] +
                matrix[positionX + 1][positionY - 1] +
                matrix[positionX + 1][positionY] +
                matrix[positionX + 1][positionY + 1];
        }

        public void runTestTask1()
        {
            Console.WriteLine("Test1");
            initialize(new string[] { "1" }, Reader.ONE);
            runTask1();
            initialize(new string[] { "12" }, Reader.ONE);
            runTask1();
            initialize(new string[] { "23" }, Reader.ONE);
            runTask1();
            initialize(new string[] { "1024" }, Reader.ONE);
            runTask1();
        }

        public void runTestTask2()
        {
            Console.WriteLine("Test2");
            initialize(new string[] { "1" }, Reader.ONE);
            runTask2();
            initialize(new string[] { "2" }, Reader.ONE);
            runTask2();
            //initialize(new string[] { "23" }, Reader.ONE);
            //runTask2();
            //initialize(new string[] { "1024" }, Reader.ONE);
            //runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
