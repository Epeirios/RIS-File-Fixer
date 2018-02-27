using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveDuplicates
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    RemoveDuplis(File.ReadAllLines(fbd.FileName).ToList());
                }
            }
        }

        private void RemoveDuplis(List<string> list)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\output";

            Directory.CreateDirectory(path);

            var stream = new StreamWriter(path + @"\output.ris", true);

            bool inRecord = false;
            bool hasAB = false;

            List<string[]> record = new List<string[]>();

            foreach (var line in list)
            {
                if (line.Length >= 6)
                {
                    // line has data
                    string key = line.Substring(0, 2);
                    string value = line.Substring(6);

                    if (!inRecord)
                    {
                        // not recording, but got new begin
                        if (key == "TY")
                        {
                            inRecord = true;
                            hasAB = false;
                            record.Add(new string[]{ key, value});
                        }
                    }
                    else
                    {
                        // end of record
                        if (key == "ER")
                        {
                            inRecord = false;
                            record.Add(new string[] { key, value });

                            foreach (var pair in record)
                            {
                                stream.WriteLine(pair[0] + "  - " + pair[1]);
                            }

                            record.Clear();
                        }
                        // no end, so continue
                        else
                        {
                            if (key == "AB")
                            {
                                if (!hasAB)
                                {
                                    hasAB = true;
                                    record.Add(new string[] { key, value });
                                }
                            }
                            else
                            {
                                record.Add(new string[] { key, value });
                            }
                        }
                    }
                }
            }

            stream.Close();

            treeView1.Controls.Add(new Control("DONE"));
            treeView1.Update();
        }
    }
}
