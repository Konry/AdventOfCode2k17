using System;
using System.Collections;
using System.Collections.Generic;

namespace AdvendOfCode2k7_console
{
    class Day8 : DayInterface
    {

        class Item
        {
            public string name;
            public int value = 0;

            public Item(string name)
            {
                this.name = name;
            }
        }

        class Incoming
        {
            public string name;
            public string operation;
            public int value;
            public string namecondition;
            public string operationCondition;
            public int valueCondition;

            Incoming(string name, string operation, int value, string namecondition, string operationCondition, int valueCondition)
            {
                this.name = name;
                this.operation = operation;
                this.value = value;
                this.namecondition = namecondition;
                this.operationCondition = operationCondition;
                this.valueCondition = valueCondition;
            }

            public static Incoming FillIncoming(string s)
            {
                string[] split = s.Split(' ');
                return new Incoming(split[0], split[1], Convert.ToInt32(split[2]), split[4], split[5], Convert.ToInt32(split[6]));
            }
        }


        class ItemList : List<Item>
        {
            public int IndexOf(string name)
            {
                return IndexOf(name, true);
            }

            public int IndexOf(string name, bool silent)
            {
                //Console.WriteLine("look for " + name + " " + this.Count);
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].name == name)
                    {
                        return i;
                    }
                }
                if (!silent)
                    Console.WriteLine("index < 0 " + name);
                return -1;
            }
        }

        HashSet<string> hs = new HashSet<string>();

        List<Incoming> incomingList = new List<Incoming>();
        ItemList currentRegisters = new ItemList();

        public void initialize(string[] lines, Reader toLoadFor)
        {
            int counter = 0;
            currentRegisters = new ItemList();
            incomingList = new List<Incoming>();
            foreach (string s in lines)
            {
                if (s.Contains("ixp"))
                {
                    counter++;
                }
                Incoming ic = Incoming.FillIncoming(s);
                incomingList.Add(ic);
                bool name1 = false;
                bool name2 = false;

                if (currentRegisters.IndexOf(ic.name) >= 0)
                {
                    name1 = true;
                }
                if (currentRegisters.IndexOf(ic.namecondition) >= 0)
                {
                    name2 = true;
                }
                if (!name1)
                {
                    currentRegisters.Add(new Item(ic.name));
                }
                if (!name2 && ic.name != ic.namecondition)
                {
                    currentRegisters.Add(new Item(ic.namecondition));
                }
            }
            //Console.WriteLine(counter);
            
        }

        public void runTask1()
        {

            for (int i = 0; i < incomingList.Count; i++)
            {

                int index = currentRegisters.IndexOf(incomingList[i].name);

                //Console.WriteLine(index + " " + incomingList[i].name);
                if (index >= 0)
                {
                    int index2 = currentRegisters.IndexOf(incomingList[i].namecondition);
                    bool cond = false;
                    if (index2 >= 0)
                    {
                        //Console.WriteLine(index + " ind2 " + index2);
                        switch (incomingList[i].operationCondition)
                        {
                            case "<=":
                                if (currentRegisters[index2].value <= incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case "<":
                                if (currentRegisters[index2].value < incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case "==":
                                if (currentRegisters[index2].value == incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case "!=":
                                if (currentRegisters[index2].value != incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case ">=":
                                if (currentRegisters[index2].value >= incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case ">":
                                if (currentRegisters[index2].value > incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            default:
                                Console.WriteLine("error ####################################\n\n\n################################\n\n\n");
                                break;
                        }

                    }

                    //Console.WriteLine("condition " + cond + " " +incomingList[i].name + " ");

                    if (cond)
                    {
                        if (incomingList[i].operation == "inc")
                        {
                            currentRegisters[index].value += incomingList[i].value;
                        }
                        else if (incomingList[i].operation == "dec")
                        {
                            currentRegisters[index].value -= incomingList[i].value;
                        }
                    }
                }
            }

            int max = Int32.MinValue;
            foreach (Item i in currentRegisters)
            {
                if (i.value > max)
                {
                    max = i.value;
                }
            }

            Console.WriteLine(max);
        }

        public void runTask2()
        {
            int max = Int32.MinValue;

            foreach (Incoming ic in incomingList)
            {
                if (currentRegisters.IndexOf(ic.name) < 0)
                {
                    currentRegisters.Add(new Item(ic.name));
                }
                if (currentRegisters.IndexOf(ic.namecondition) < 0)
                {
                    currentRegisters.Add(new Item(ic.namecondition));
                }
            }

            for (int i = 0; i < incomingList.Count; i++)
            {

                int index = currentRegisters.IndexOf(incomingList[i].name, false);

                //Console.WriteLine(index + " " + incomingList[i].name);
                if (index >= 0)
                {
                    int index2 = currentRegisters.IndexOf(incomingList[i].namecondition, false);
                    bool cond = false;
                    if (index2 >= 0)
                    {
                        //Console.WriteLine(index + " ind2 " + index2);
                        switch (incomingList[i].operationCondition)
                        {
                            case "<=":
                                if (currentRegisters[index2].value <= incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case "<":
                                if (currentRegisters[index2].value < incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case "==":
                                if (currentRegisters[index2].value == incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case "!=":
                                if (currentRegisters[index2].value != incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case ">=":
                                if (currentRegisters[index2].value >= incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            case ">":
                                if (currentRegisters[index2].value > incomingList[i].valueCondition)
                                {
                                    cond = true;
                                }
                                break;
                            default:
                                Console.WriteLine("error ####################################\n\n\n################################\n\n\n");
                                break;
                        }

                    }else
                    {
                        Console.WriteLine("error ####################################\n\n\n################################\n\n\n");

                    }

                    //Console.WriteLine("condition " + cond + " " + incomingList[i].name + " ");

                    if (cond)
                    {
                        if (incomingList[i].operation == "inc")
                        {
                            currentRegisters[index].value += incomingList[i].value;
                        }
                        else
                        {
                            currentRegisters[index].value -= incomingList[i].value;
                        }
                    }
                    if (currentRegisters[index].value > max)
                    {
                        max = currentRegisters[index].value;
                    }
                }
            }
            /* 5326 wrong */
            /* 4254 */
            Console.WriteLine(max);
        }

        public void runTestTask1()
        {
            Console.WriteLine("test1:");
            runTask1();
        }

        public void runTestTask2()
        {
            Console.WriteLine("test2:");
            runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
