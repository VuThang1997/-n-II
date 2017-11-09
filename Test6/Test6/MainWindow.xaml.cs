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
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Cac chuc nang trong ApplicationMenu
        public void appNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
        }

        public void appOpen_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "text files (*.txt)|*.txt|All Files (*.*)|*.*";

            /* cach lam cho OpenFileDialog cua Microsoft.Win32
            Nullable<bool> result = openFile.ShowDialog();
            if (result == true)
            {
                TextRange content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                FileStream fStream = new FileStream(openFile.FileName, FileMode.OpenOrCreate);
                content.Load(fStream, System.Windows.DataFormats.Text);
                fStream.Close();

                this.Title = openFile.FileName;
            }*/

            /*
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFile.FileName;
                //FileStream file = new FileStream(fileName, FileMode.Open);
               
                
                    string content = File.ReadAllText(openFile.FileName);
                    richTextBox1.Document.Blocks.Clear();
                    richTextBox1.Document.Blocks.Add(new Paragraph(new Run(content)));
                
                //file.Close();
            }    */

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream s = File.Open(openFile.FileName, FileMode.Open);
                StreamReader sRead = new StreamReader(s);

                string content = sRead.ReadToEnd();
                richTextBox1.Document.Blocks.Clear();
                richTextBox1.Document.Blocks.Add(new Paragraph(new Run(content)));

                sRead.Close();
                s.Close();

                this.Title = openFile.FileName;
            }
            
        }

        public void saveAsFunc()
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

        public void appSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.Title))
            {
                saveAsFunc();
            }
            else
            {
                Stream s = File.Open(this.Title, FileMode.OpenOrCreate);
                StreamWriter sWrite = new StreamWriter(s);

                string content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                sWrite.Write(content);
                sWrite.Close();
                s.Close();
            }
        }

        public void appSaveAs_Click(object sender, EventArgs e)
        {
            saveAsFunc();
        }

        public void appExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    
        //Cac chuc nang trong QuickAccessToolbar
        public void saveButton1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.Title))
            {
                saveAsFunc();
            }
            else
            {
                Stream s = File.Open(this.Title, FileMode.OpenOrCreate);
                StreamWriter sWrite = new StreamWriter(s);

                string content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                sWrite.Write(content);
                sWrite.Close();
                s.Close();
            }
        }

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

        public void cutButton_Click (object sender, EventArgs e)
        {
            richTextBox1.Cut();
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

                cutButton.IsEnabled = true;
                copyButton.IsEnabled = true;
                selectAllButton.IsEnabled = true;

                boldButton.IsEnabled = true;
                italicButton.IsEnabled = true;
                underlineButton.IsEnabled = true;
                spikeButton.IsEnabled = true;
                deleteButton.IsEnabled = true;

                speechObject.IsEnabled = true;
            }
            else
            {
                undoButton1.IsEnabled = false;
                undoButton2.IsEnabled = false;

                cutButton.IsEnabled = false;
                copyButton.IsEnabled = false;
                selectAllButton.IsEnabled = false;

                boldButton.IsEnabled = false;
                italicButton.IsEnabled = false;
                underlineButton.IsEnabled = false;
                spikeButton.IsEnabled = false;
                deleteButton.IsEnabled = false;

                speechObject.IsEnabled = false;
            }
        }

       
    }
}
