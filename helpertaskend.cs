using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp80
{
    class Helper
    {
       public  static void Print(object text,ConsoleColor color=ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            
        }
       public  static void PrintLine(object text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);

        }
    }
}
