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
        public static string pathFile = null;  //bien global luu tru duong dan file
        public MainWindow()
        {
            InitializeComponent();
        }

        
        //New Command
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //xoa sach tat ca moi thu tren richTextBox1
            richTextBox1.Document.Blocks.Clear();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //cho phep chuc nang New duoc su dung bat ki luc nao
            e.CanExecute = true;
        }
        
        //Open Command
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
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

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //cho phep chuc nang Open duoc su dung bat ki luc nao
            e.CanExecute = true;
        }

        //Close Command
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //cho phep chuc nang Close duoc su dung bat ki luc nao
            e.CanExecute = true;
        }

        //saveAs Func, su dung cho SaveAsCommand va SaveCommand
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

        //Save Command
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
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

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //cho phep chuc nang Save duoc su dung bat ki luc nao
            e.CanExecute = true;
        }

        //SaveAs Command
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveAsFunc();
        }

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //cho phep chuc nang Save duoc su dung bat ki luc nao
            e.CanExecute = true;
        }

        //Bold Command
        private void BoldCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //thay doi thuoc tinh FontWeight cua doan text duoc chon thanh Bold
            richTextBox1.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);           
        }

        private void BoldCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null) && (richTextBox1.Selection.IsEmpty == false);
        }

        //Italic Command
        private void ItalicCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // thay doi thuoc tinh FontStyles cua doan text duoc chon thanh Italic
            richTextBox1.Selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);
        }

        private void ItalicCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null) && (richTextBox1.Selection.IsEmpty == false);
        }

        //Underline Command
        private void UnderlineCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // thay doi thuoc tinh TextDecorations cua doan text duoc chon thanh Underline
            richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }

        private void UnderlineCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null) && (richTextBox1.Selection.IsEmpty == false);
        }

        //Strikethrough Command
        private void StrikeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // thay doi thuoc tinh TextDecorations cua doan text duoc chon thanh Strikethrough
            richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
        }

        private void StrikeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null) && (richTextBox1.Selection.IsEmpty == false);
        }

        //SpeechSynthesizer Command
        private void SpeechCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();

            //lay noi dung ghi tren richTextBox1
            string content = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
            synth.Speak(content);
        }

        private void SpeechCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null);
        }

        //DateTime Command
        private void DateCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox1.Document.Blocks.Add(new Paragraph(new Run(" " + DateTime.Now)));
        }

        private void DateCommand_CanExecute (object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
