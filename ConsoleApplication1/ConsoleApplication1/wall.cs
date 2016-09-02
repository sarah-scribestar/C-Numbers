using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Wall
    {
        public List<string> messages;

        public Wall()
        {

        }

        public Wall(String m)
        {
            messages = new List<string>();
            messages.Add(m);
            Console.WriteLine(m + "HIIIII");
        }

        //Console.WriteLine(message);

    }
}
