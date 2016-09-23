using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numbers;

/* The aim is to convert a numerical digit into the corresponding English word */
namespace Numbers
{
    public class NumbersProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            string input = Console.ReadLine();
            if (input.Length == 0)
            {
                Console.WriteLine("Please enter a number between -999,999,999,999 to 999,999,999,999");
            }
            ConvertNum cn = new ConvertNum();
            string output = cn.Convert(input);
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}