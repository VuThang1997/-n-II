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

        public void appNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
        }

        public void appOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "X Files (*.x)|*.x|All Files (*.*)|*.*";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
            }
        }

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

    }
}
