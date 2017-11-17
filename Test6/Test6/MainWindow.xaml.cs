using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Test6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MyApplicationCommands
    {
        public static RoutedUICommand ExitApp = new RoutedUICommand("Exit the application", "ExitApp", typeof(MyApplicationCommands));
    }

    public partial class MainWindow : RibbonWindow
    {
        public static string pathFile = null;  //bien global luu tru duong dan file
        public MainWindow()
        {
            InitializeComponent();
        }
       
        //Cac chuc nang trong ApplicationMenu
        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "text files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream stream = File.Open(openFile.FileName, FileMode.Open);
                StreamReader sRead = new StreamReader(stream);

                string content = sRead.ReadToEnd();
                richTextBox1.Document.Blocks.Clear();
                richTextBox1.Document.Blocks.Add(new Paragraph(new Run(content)));

                sRead.Close();
                stream.Close();

                //chuyen ten window sang ten file; pathFile nhan duong dan truc tiep den file
                this.Title = openFile.SafeFileName;
                pathFile = openFile.FileName;
            }
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
        }

        private void saveAsFunc()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream s = File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate);
                StreamWriter sWrite = new StreamWriter(s);

                string content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                sWrite.Write(content);
                sWrite.Close();
                s.Close();
            }
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!File.Exists(pathFile))
            {
                saveAsFunc();
            }
            else
            {
                Stream s = File.Open(pathFile, FileMode.OpenOrCreate);
                StreamWriter sWrite = new StreamWriter(s);

                string content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                sWrite.Write(content);
                sWrite.Close();
                s.Close();
            }
        }

        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveAsFunc();
        }
    
        //Cac chuc nang trong QuickAccessToolbar

        public void undoButton1_Click (object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoButton1.IsEnabled = false;
            undoButton2.IsEnabled = false;
            redoButton1.IsEnabled = true;
            redoButton2.IsEnabled = true;
        }

        public void redoButton1_Click (object sender, EventArgs e)
        {
            //redo 1 muc
            richTextBox1.Redo();
            undoButton1.IsEnabled = true;
            undoButton2.IsEnabled = true;
            redoButton1.IsEnabled = false;
            redoButton2.IsEnabled = false;
        } 

        //Cac chuc nang trong RibbonTab GENERAL

        //Group ClipBoard
        public void pasteButton_Click (object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
       

        public void copyButton_Click (object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        //Group Edit
        public void undoButton2_Click (object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoButton1.IsEnabled = false;
            undoButton2.IsEnabled = false;
            redoButton1.IsEnabled = true;
            redoButton2.IsEnabled = true;
        }

        public void redoButton2_Click (object sender, EventArgs e)
        {
            //redo 1 muc
            richTextBox1.Redo();
            undoButton1.IsEnabled = true;
            undoButton2.IsEnabled = true;
            redoButton1.IsEnabled = false;
            redoButton2.IsEnabled = false;
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox1.SelectAll();
        }

        //Group Font
        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            //thay doi thuoc tinh FontWeight cua doan text duoc chon thanh Bold
            richTextBox1.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            // thay doi thuoc tinh FontWeight cua doan text duoc chon thanh Italic
            richTextBox1.Selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            // thay doi thuoc tinh TextDecorations cua doan text duoc chon thanh Underline
            richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }

        private void strikeButton_Click(object sender, RoutedEventArgs e)
        {
            // thay doi thuoc tinh TextDecorations cua doan text duoc chon thanh Strikethrough
            richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
        }

        //Cac chuc nang trong RibbonTab ADVANCED
        public void speechObject_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer(); 
            synth.SetOutputToDefaultAudioDevice();

            //lay noi dung ghi tren richTextBox1
            string content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
            synth.Speak(content);
        }

        public void dateTime_Click (object sender, EventArgs e)
        {
            richTextBox1.Document.Blocks.Add(new Paragraph(new Run(" " + DateTime.Now)));
        }

        //xu ly su kien TextChanged trong richTextBox1
        private void richTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
            
            if (range.Text.Length > 0)
            {
                undoButton1.IsEnabled = true;
                undoButton2.IsEnabled = true;

                
                copyButton.IsEnabled = true;
                selectAllButton.IsEnabled = true;

                boldButton.IsEnabled = true;
                italicButton.IsEnabled = true;
                underlineButton.IsEnabled = true;
                strikeButton.IsEnabled = true;
                deleteButton.IsEnabled = true;

                speechObject.IsEnabled = true;
            }
            else
            {
                undoButton1.IsEnabled = false;
                undoButton2.IsEnabled = false;
                
                copyButton.IsEnabled = false;
                selectAllButton.IsEnabled = false;

                boldButton.IsEnabled = false;
                italicButton.IsEnabled = false;
                underlineButton.IsEnabled = false;
                strikeButton.IsEnabled = false;
                deleteButton.IsEnabled = false;

                speechObject.IsEnabled = false;
            }
        }

        
    }
}
