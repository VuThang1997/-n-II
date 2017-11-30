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
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<Double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            richTextBox1.Document.PageWidth = 1000;
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

        //Strikethrough Command
        private void StrikeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //lay ra bo gia tri TextDecoration cua doan text duoc chon
            TextDecorationCollection decs = (TextDecorationCollection)richTextBox1.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

            if (decs.Contains(TextDecorations.Strikethrough[0]) == true) 
            {
                //neu doan text duoc chon da duoc gach giua thi xoa thiet lap nay
                TextDecorationCollection noStrike = new TextDecorationCollection(decs);
                noStrike.Remove(TextDecorations.Strikethrough[0]);

                richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, noStrike);
                
            }
            //else if ((decs.Contains(TextDecorations.Strikethrough[0]) == false) || (richTextBox1.Selection.GetPropertyValue(Inline.TextDecorationsProperty) == DependencyProperty.UnsetValue))
            else
            {
                //neu doan text duoc chon chua duoc gach giua thi thuc hien chuc nang
                TextDecorationCollection addStrike = new TextDecorationCollection(decs);
                addStrike.Add(TextDecorations.Strikethrough[0]);

                richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, addStrike);
            }
        }

        private void StrikeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null) && (richTextBox1.Selection.IsEmpty == false);
        }

        //Clear Formatting Command
        private void ClearCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox1 != null) && (richTextBox1.Selection.IsEmpty == false);
        }

        private void ClearCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //xoa cac thiet lap TextDecorations
            richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);

            //xoa thiet lap chu dam
            richTextBox1.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);

            //xoa thiet lap chu nghieng
            richTextBox1.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
        }

        //FontSize SelectionChanged
        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null)
            {
                richTextBox1.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
            }
        }

        //FontFamily_SelectionChanged
        private void cmbFontFamily_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                richTextBox1.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
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

        //richTextBox1 SelectionChanged
        private void richTextBox1_SelectionChanged (object sender, RoutedEventArgs e)
        {
            object temp;

            //dieu khien trang thai cua boldButton
            temp = richTextBox1.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            //dieu khien trang thai cua italicdButton
            temp = richTextBox1.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italicButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            //dieu khien trang thai cua underlineButton
            temp = richTextBox1.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            //hien thi FontFamily cua doan duoc chon
            temp = richTextBox1.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            //hien thi FontSize cua doan duoc chon
            temp = richTextBox1.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.SelectedItem = temp;
        }
    }
}
