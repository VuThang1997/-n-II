using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test6
{
    public static class CustomCommands
    {
        static RoutedUICommand exit = new RoutedUICommand("Exit the application", "Exit", typeof(CustomCommands));

        public static RoutedUICommand Exit { get { return exit; } }
    }
}
