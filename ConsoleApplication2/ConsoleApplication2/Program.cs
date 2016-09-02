using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            String stuff;
            Console.WriteLine("Add to wall");
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