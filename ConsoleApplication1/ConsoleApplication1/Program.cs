using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication2;

namespace ConsoleApplication1
{
    class Twitter
    {
        static void Main(string[] args)
        {

            String stuff;
            Console.WriteLine("Type some shit");
            stuff = Console.ReadLine();
            Wall wall1 = new Wall(stuff);
            while (stuff != "exit")
            {
                //Console.WriteLine("Output:" + stuff);
                stuff = Console.ReadLine();
            }
        }
    }
}
