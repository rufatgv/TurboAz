using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turboaz
{[Serializable]
    internal class Methods
    {
       static internal int ReadInteger(string caption)
        {  
            l1:
            Console.Write(caption);

            if (int.TryParse(Console.ReadLine(), out int value)) 
            {
                return value;
            }
            goto l1;
        }

        static internal string ReadString(string caption)
        {
        l1:
            Console.Write(caption);

              string value=  Console.ReadLine();
            if (string.IsNullOrEmpty(value))
            goto l1;
            return value;
        }
        internal static double ReadDouble(string caption )
        {
        l1:
            Console.Write(caption);

            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }
            goto l1;
        }
    }
}
