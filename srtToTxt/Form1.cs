using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srtToTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableExport();
            txtNameFile.TextChanged += TxtNameFile_TextChanged;
            btnExport.Click += BtnExport_Click;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            EsportaFile();
        }

        private void EsportaFile()
        {
            StringBuilder fileContent = new StringBuilder();
            var srtContent = File.ReadAllLines(txtNameFile.Text);

            var i = 0;
            foreach (var item in srtContent)
            {
                i++;
                if (i == 3)
                {
                    fileContent.Append(item.Trim() + " ");
                }
                else if (i == 4)
                {
                    i = 0;
                }
            }
            var openFileDialog1 = new SaveFileDialog();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "Output_" + DateTime.Now.ToString("yyyy_MM_dd hh_mm_ss") + ".txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(openFileDialog1.FileName, fileContent.ToString());

                try
                {
                    Process.Start(openFileDialog1.FileName);
                }
                catch (Exception)
                {
                }
            }

        }

        private void TxtNameFile_TextChanged(object sender, EventArgs e)
        {
            EnableExport();
        }

        private void EnableExport()
        {
            btnExport.Enabled = (txtNameFile.Text.Length > 0);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "srt files (*.srt)|*.srt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtNameFile.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNameFile.ReadOnly = true;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string filename;
            var validData = GetFilename(out filename, e);
            txtNameFile.Text = filename;
        }

        private void OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string filename;
            var validData = GetFilename(out filename, e);
            if (validData)
            {

                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected bool GetFilename(out string filename, DragEventArgs e)
        {
            filename = String.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".srt"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
