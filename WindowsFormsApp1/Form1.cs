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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> filesteam;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    filesteam = File.ReadAllLines(fbd.FileName).ToList();

                    Process(ProcessMethods.FirstAnalaysis);
                }
            }
        }

        public List<Record> StructuriseData(List<string> filestream)
        {
            List<Record> output = new List<Record>();

            bool inRecord = false;
            Record record = null;

            foreach (var line in filestream)
            {
                if (line.Length >= 6)
                {
                    // line has data
                    string key = line.Substring(0, 2);
                    string value = line.Substring(7);

                    if (!inRecord)
                    {
                        if (key == "TY")
                        {
                            inRecord = true;
                            if (record != null)
                            {
                                record = new Record();
                            }

                        }
                    }
                    else
                    {
                        if(key == "ER")
                        {
                            inRecord = false;
                            record.Elements.Add(key, value);
                        }
                    }
                }




            }

            return output;
        }

        public void Process(ProcessMethods method)
        {
            switch (method)
            {
                case ProcessMethods.FirstAnalaysis:

                    break;
                case ProcessMethods.DeleteDuplicateFields:
                    break;
                default:
                    break;
            }
        }

        public void AnalyseData()
        {


            if (filesteam != null)
            {
                foreach (var item in filesteam)
                {

                }
            }
        }
    }
}
