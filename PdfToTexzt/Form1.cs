using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfToTexzt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            String filePath;
            dlg.Filter = "PDF Files(*.PDF)|*.PDF|ALL Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName.ToString();

                String src = String.Empty;
                try
                {

                    PdfReader reder = new PdfReader(filePath);
                    for (int page = 1; page <= reder.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        string s = PdfTextExtractor.GetTextFromPage(reder, page, its);
                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                        src += s;
                        richTextBox1.Text = src;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }
    }
}
