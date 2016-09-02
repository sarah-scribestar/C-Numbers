using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* The aim is to convert a numerical digit into the corresponding English word */
namespace Numbers
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length == 0)
            {
                Console.WriteLine("Please enter a number between -999,999,999,999 to 999,999,999,999 to any number of decimal places");
            }
            ConvertNum cn = new ConvertNum();
            cn.Convert(input);
            Console.ReadKey();

        }

        //Console.WriteLine("Please enter a number between -999,999,999,999 to 999,999,999,999 to any number of decimal places");

    }
}