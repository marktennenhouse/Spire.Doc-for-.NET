using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace SetParagraphShading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create Word document.
            Document document = new Document();

            //Load the file from disk.
            document.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Docx_1.docx");

            //Get a paragraph.
            Paragraph paragaph = document.Sections[0].Paragraphs[0];

            //Set background color for the paragraph.
            paragaph.Format.BackColor = Color.Yellow;

            //Set background color for the selected text of paragraph.
            paragaph = document.Sections[0].Paragraphs[2];
            TextSelection selection = paragaph.Find("Christmas", true, false);
            TextRange range = selection.GetAsOneRange();
            range.CharacterFormat.TextBackgroundColor = Color.Yellow;

            String result = "Result-SetParagraphShading.docx";

            //Save to file.
            document.SaveToFile(result, FileFormat.Docx2013);

            //Launch the MS Word file.
            WordDocViewer(result);
        }

        private void WordDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
