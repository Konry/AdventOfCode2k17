using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    class Day7 : DayInterface
    {
        class item
        {
            public int weight = 0;
            public string name = "";
            public string parent = "";
            public string[] subitems;
            public int[] sumSubitems;

            public item(string name, int weight, string[] subitems)
            {
                this.name = name;
                this.weight = weight;
                this.subitems = subitems;
                sumSubitems = new int[100000];
            }

            public static item fill(string s)
            {
                string[] nameNWeight;
                string[] temp;
                string[] subitemlist = null;
                if (s.Contains("->"))
                {
                    temp = s.Replace(" ","").Split('>');
                    subitemlist = temp[1].Split(',');
                }else
                {
                    temp = new string[1];
                    temp[0] = s.Replace(" ", "");
                }
                int weight;
                string name;

                nameNWeight = temp[0].Split('(');
                name = nameNWeight[0];
                //Console.WriteLine(nameNWeight[1].Substring(0, nameNWeight[1].IndexOf(")")));
                
                weight = Convert.ToInt32(nameNWeight[1].Substring(0, nameNWeight[1].IndexOf(")")));

                return new item(name, weight, subitemlist);

            }
        }

        item[] itemList;

        public void initialize(string[] lines, Reader toLoadFor)
        {
            itemList = new item[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                itemList[i] = item.fill(lines[i]);
            }

            foreach (item i in itemList)
            {
                if (i.subitems != null)
                {
                    foreach (string s in i.subitems)
                    {
                        foreach (item x in itemList)
                        {
                            if (x.name == s)
                            {
                                x.parent = i.name;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void runTask1()
        {
            int count = 0;
            foreach (item x in itemList)
            {
                if (x.parent == "")
                {
                    Console.WriteLine(x.name + " count " + ++count);
                }
            }
        }

        public void runTask2()
        {
            string root = "";
            foreach (item x in itemList)
            {
                if (x.parent == "")
                {
                    root = x.name;
                    foreach(string s in x.subitems)
                    {
                        foreach(item i in itemList)
                        {
                            if(i.name == s)
                            {
                                Console.WriteLine("Check for root " + root + " " + s);
                                Console.WriteLine(sumSubtreee(i));
                            }
                        }
                    }
                }
            }

            foreach (item x in itemList)
            {
                if (x.parent != "")
                {
                    bool same = true;

                    int value = 0;
                    if(x.subitems != null)
                        for (int i = 0; i < x.subitems.Length; i++)
                        {
                            if (i == 0)
                            {
                                value = x.sumSubitems[i];
                            }
                            else
                            {
                                if (value != x.sumSubitems[i])
                                {
                                    same = false;
                                    //Console.WriteLine(x.name + " " + value + " sum is " + x.sumSubitems[i]);
                                    break;
                                }
                            }
                        }
                }
            }
        }

        HashSet<string> done2 = new HashSet<string>();
        HashSet<string> done = new HashSet<string>();
        private int sumSubtreee(item item)
        {
            int sum = 0;
            if (item.subitems != null)
            {
                foreach (string s in item.subitems)
                {
                    foreach (item i in itemList)
                    {
                        if(i.name == s)
                        {
                            sum += sumSubtreee(i);
                            //Console.WriteLine(i.name + " " + i.weight + " sum is " );
                        }
                    }
                }
            }
            sum += item.weight;
            return sum;
        }

        private int sumSubtree(string s)
        {
            int sum = 0;
            for (int i = 0; i < itemList.Length; i++)
            {
                if(itemList[i].name == s)
                {
                    //if (!done2.Contains(i.name))
                    //{
                    //    done2.Add(i.name);
                    //Console.WriteLine("check " + s);
                    if (itemList[i].subitems != null)
                    {
                        foreach (string subitem in itemList[i].subitems)
                        {
                            //Console.WriteLine("Check subitem " + subitem + " of item " + s + " sum ");
                            for (int j = 0; j < itemList.Length; j++)
                            {
                                if (itemList[j].name == subitem)
                                {
                                    itemList[i].sumSubitems[j] = sumSubtree(itemList[j].name);
                                    sum += sumSubtree(itemList[j].name);
                                    //Console.WriteLine("Check subsubitem " + itemList[j].name + " of item " + s + " sum " + sum);
                                }
                            }
                                    //        if (!done.Contains(subitem))
                                    //        {
                                    //            done.Add(subitem);
                                    //sum += ;
                                    //            Console.WriteLine("sum of tree "+i+" " + subitem + " : " + sumSubtree(s));
                                    //        }
                                }
                    }

                    sum += itemList[i].weight;
                    //Console.WriteLine("weight of item " + itemList[i].name + " is " + itemList[i].weight + " sum " + sum);
                }
                //}
            }
            /* 9 wrong */
            /* inwmb wrong */
            /* 145260 wrong */
            /* 53037 wrong */
            return sum;
        }

        public void runTestTask1()
        {
            runTask1();
        }

        public void runTestTask2()
        {
            runTask2();
        }

        public void initialize(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
