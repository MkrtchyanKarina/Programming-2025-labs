using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Play
    {

        internal Play() 
        { 
        
        }
    }

    internal interface IReadData
    {
        string[] GetInputData();
    }

    internal class ConsoleReader : IReadData
    {
        internal string[] GetInputData() { 
            Console.WriteLine();
        }
    }
}
