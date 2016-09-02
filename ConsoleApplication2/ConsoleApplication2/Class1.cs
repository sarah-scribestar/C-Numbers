using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Wall
    {
        public Wall()
        {

        }

        public Wall(String m)
        {
            List<string> messages = new List<string>();
            messages.Add(m);
            Console.WriteLine(m + "- Added to wall");
        }

        //Console.WriteLine(message);

    }
}