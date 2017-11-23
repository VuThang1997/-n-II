using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test6
{
    public partial class CustomCommands
    {
        //Bold Command
        public static RoutedCommand Bold = new RoutedCommand("Bold", typeof(CustomCommands),
                                            new InputGestureCollection()
                                            {
                                                new KeyGesture(Key.B, ModifierKeys.Control)
                                            });

        //Italic Command
        public static RoutedCommand Italic = new RoutedCommand("Italic", typeof(CustomCommands),
                                            new InputGestureCollection()
                                            {
                                                new KeyGesture(Key.I, ModifierKeys.Control)
                                            });

        //Underline Command
        public static RoutedCommand Underline = new RoutedCommand("Underline", typeof(CustomCommands),
                                            new InputGestureCollection()
                                            {
                                                new KeyGesture(Key.U, ModifierKeys.Control)
                                            });
        //Strikethrough Command
        public static RoutedCommand Strike = new RoutedCommand("Strikethrough", typeof(CustomCommands));

        //SpeechSynthesizer Command
        public static RoutedCommand Speech = new RoutedCommand("SpeechSynthesizer", typeof(CustomCommands));

        //DateTime Command
        public static RoutedCommand Date = new RoutedCommand("Date/Time", typeof(CustomCommands));
    }
}
