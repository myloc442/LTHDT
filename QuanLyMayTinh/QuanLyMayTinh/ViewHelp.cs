using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class ViewHelp
    {
        public static void WriteLine(string mess, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            Console.ResetColor();
        }
        public static void Write(string mess, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(mess);
            Console.ResetColor();
        }
    }
}
