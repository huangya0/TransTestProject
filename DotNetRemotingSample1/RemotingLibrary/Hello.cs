using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingLibrary
{
    public class Hello : System.MarshalByRefObject
    {
        public Hello()
        {
            Console.WriteLine("constructor called");
        }

        ~Hello()
        {
            Console.WriteLine("destructor called");
        }

        public string Greeting(string name)
        {
            Console.WriteLine("greeting called");
            return "hello," + name;

        }
    }

}
