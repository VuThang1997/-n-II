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
        //Strikethrough Command
        public static RoutedCommand Strike = new RoutedCommand("Strikethrough", typeof(CustomCommands));

        //SpeechSynthesizer Command
        public static RoutedCommand Speech = new RoutedCommand("SpeechSynthesizer", typeof(CustomCommands));

        //DateTime Command
        public static RoutedCommand Date = new RoutedCommand("Date/Time", typeof(CustomCommands));

        //ClearFormat Command
        public static RoutedCommand Clear = new RoutedCommand("Clear Formatting", typeof(CustomCommands));
    }
}
