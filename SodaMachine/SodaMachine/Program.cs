using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            UI UIInstance = new SodaMachine.UI();
            UIInstance.StartMachine();
        }
    }
}
