using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Xoa man hinh cua app
            richTextBox1.Text = "";
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
                //Path de xac dinh ten va vi tri cua file 
                //Lua chon PlainText: 1 doan text(co bao gom dau cach) thay the Object Linking hoac doi tuong OLE (?)

                this.Text = open.FileName;      //Chuyen ten form thanh ten file duoc mo
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "text files (*.txt)|*.txt|All Files (*.*)|*.*";
            //doan mo ta cua phan loai file, cac loai file mau duoc phan cach boi dau "|"
            if (save.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                this.Text = save.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dong moi thao tac trong cac luong va cac cua so cua ung dung
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            //Di chuyen cac doan duoc chon vao Clipboard (1 dang vung nho dem)
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            //Sao chep cac doan duoc chon vao Clipboard
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            //Thay the cac doan duoc chon trong phan text bang noi dung trong Clipboard (neu co)
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
            //Dao nguoc thay doi cuoi cung trong phan text
            //Khong hoat dong voi truong hop Keypress va TextChanged
            //cho phep dao nguoc hieu ung voi Redo
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
            //Lap lai thay doi cuoi cung da duoc dao nguoc truoc do
            //Cho phep dao nguoc hieu ung voi Undo
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.Font = richTextBox1.SelectionFont; //SelectionFont la 1 thuoc tinh cua doi tuong RichTextBox
            if (font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = font.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorBK = new ColorDialog();
            if(colorBK.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorBK.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0 by V.H.T", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            //Xoa phan text duoc chon
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Strikeout);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAs = new SaveFileDialog();

            saveAs.Filter = "text files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveAs.FilterIndex = 2;
            saveAs.RestoreDirectory = true;

            if (saveAs.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter write = new System.IO.StreamWriter(saveAs.FileName.ToString());
                write.WriteLine(richTextBox1.Text);
                write.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                boldToolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                normalToolStripMenuItem.Enabled = true;
                strikeThroughToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                toolStripButton5.Enabled = true;
                toolStripButton6.Enabled = true;
                toolStripButton7.Enabled = true;
                toolStripButton8.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                boldToolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
                strikeThroughToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
                toolStripButton7.Enabled = false;
                toolStripButton8.Enabled = false;

                //Viet lai doan text khoi dau cho LineNumberTextBox
                AddLineNumbers();
            }
        }

        private int getWidth()
        {
            //Lay do rong cua LineNumberTextBox cho phu hop
            int width = 25;
            int lineLength = richTextBox1.Lines.Length;
            int size = (int)richTextBox1.Font.Size;

            if (lineLength < 100)
            {
                width += 20 + size;
            }
            else if(lineLength < 1000)
            {
                width += 30 + size;
            }
            else
            {
                width += 50 + size;
            }

            return width;
        }

        private void AddLineNumbers()
        {
            // tao doi tuong pt cua cau truc Point va khoi tao gia tri (0;0)
            Point pt = new Point(0, 0);
            // lay cac gia tri firstIndex va firstLine tu richTextBox1
            int firstIndex = richTextBox1.GetCharIndexFromPosition(pt);
            int firstLine = richTextBox1.GetLineFromCharIndex(firstIndex);

            // Chuyen toa do cua pt ve vi tri cuoi control
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // lay cac gia tri lastIndex va lastLine tu richTextBox1
            int lastIndex = richTextBox1.GetCharIndexFromPosition(pt);
            int lastLine = richTextBox1.GetLineFromCharIndex(lastIndex);

            // Thiet lap thuoc tinh de doan text hien thi se nam o giua
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // xoa het cac doan text truoc do va thiet lap do rong cua LineNumberTextBox
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();

            // Dien so thu tu tuong ung voi moi dong, co de them 1 dong cuoi cung
            for (int i = firstLine; i < lastLine + 2; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            AddLineNumbers();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            //Su kien SelectionChanged duoc kich hoat khi co 1 o duoc chon hay su lua chon bi huy
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            //Vertical Scroll - cuon thanh theo chieu doc
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            //Su kien FontChanged duoc kich hoat khi font chu trong richTextBox1 thay doi
            //Doi font chu cua LineNumberTextBox cho giong font cua richTextBox1 roi viet lai cac chi so
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Su kien MouseDown duoc kich hoat khi con tro chuot nhan nham vao 1 dong bat ki trong LineNumberTextBox
            //Khi do, con tro chuot se tro ve trong richTextBox1 va khong dong nao cua LineNumberTextBox duoc chon
            richTextBox1.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Su kien richTextBox1 KeyPress voi CheckBox duoc chon
            //Khi co cac dau mo {, [, (, <, duoc nhap vao thi tu dong them dau dong tuong ung
            //vao vi tri (SelectionStart+1). Sau khi them thi bo sung 1 dong va thiet lap e.Handled = true
            //cuoi cung thiet lap SelectionStart toi vi tri dinh truoc
            if (checkBox1.Checked == true)
            {
                char character = e.KeyChar;
                int startPoint = richTextBox1.SelectionStart;

                switch(character)
                {
                    case '(':
                        richTextBox1.Text = richTextBox1.Text.Insert(startPoint, "()");
                        e.Handled = true;
                        richTextBox1.SelectionStart = startPoint + 1;
                        break;

                    case '{':
                        richTextBox1.Text = richTextBox1.Text.Insert(startPoint, "{}");
                        e.Handled = true;
                        richTextBox1.SelectionStart = startPoint + +1;
                        break;

                    case '[':
                        richTextBox1.Text = richTextBox1.Text.Insert(startPoint, "[]");
                        e.Handled = true;
                        richTextBox1.SelectionStart = startPoint + 1;
                        break;

                    case '<':
                        richTextBox1.Text = richTextBox1.Text.Insert(startPoint, "<>");
                        e.Handled = true;
                        richTextBox1.SelectionStart = startPoint + 1;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}