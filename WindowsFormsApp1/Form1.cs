using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Record> recordList;

        public Form1()
        {
            InitializeComponent();

            cbxProcessMethod.DataSource = Enum.GetValues(typeof(ProcessMethods));
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessMethods method;

            Enum.TryParse<ProcessMethods>(cbxProcessMethod.SelectedValue.ToString(), out method);

            Process(method);
        }

        private void ExportFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\output";

            try
            {
                Directory.Delete(path, true);
            }
            catch (Exception e)
            {
                //Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            Thread.Sleep(500);

            Directory.CreateDirectory(path);

            var stream = new StreamWriter(path + @"\output.ris", true);

            foreach (var item in recordList)
            {
                foreach (var pair in item.Elements)
                {
                    stream.WriteLine(pair[0] + "  - " + pair[1]);
                }

                stream.WriteLine("");
            }

            stream.Close();

            TreeViewAddItem("Exported File");
        }

        private void TreeViewAddItem(string item)
        {
            treeView.Nodes.Add(item);
            treeView.Update();
        }

        private void ImportFile(List<string> stream)
        {
            List<Record> records = new List<Record>();
            Record record = null;

            bool inRecord = false;

            foreach (var line in stream)
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
                            record = new Record();
                            record.Elements.Add(new string[] { key, value });
                        }
                    }
                    else
                    {
                        // end of record
                        if (key == "ER")
                        {
                            inRecord = false;
                            record.Elements.Add(new string[] { key, value });
                            records.Add(record);
                            record = null;
                        }
                        else
                        {
                            record.Elements.Add(new string[] { key, value });
                        }
                    }
                }
            }

            recordList = records;

            TreeViewAddItem("Imported File");
        }

        public void Process(ProcessMethods method)
        {
            switch (method)
            {
                case ProcessMethods.DeleteDuplicateAbstracts:
                    DeleteDuplicateAbstracts();

                    break;
                case ProcessMethods.NormalizeKeywords:
                    NormalizeKeywords();

                    break;
                case ProcessMethods.AllMethods:
                    DeleteDuplicateAbstracts();
                    GoogleApiAnalyses();

                    break;
                case ProcessMethods.GoogleApiAnalyses:
                    GoogleApiAnalyses();
                    break;
                default:
                    break;
            }
        }

        private void GoogleApiAnalyses()
        {
            int requestcounter = 0;

            for (int i = 0; i < recordList.Count; i++)
            {
                string sumtext = string.Empty;

                Record newRecord = new Record();

                foreach (var pair in recordList[i].Elements)
                {
                    if (pair[0] != "KW" && pair[0] != "ER")
                    {
                        newRecord.Elements.Add(pair);
                    }

                    if (pair[0] == "AB" || pair[0] == "KW" || pair[0] == "T1")
                    {
                        sumtext += " " + pair[1];
                    }
                }

                GoogleApi api = new GoogleApi();
                var result = api.DoAnalysis(sumtext);

                requestcounter++;

                foreach (var item in result)
                {
                    newRecord.Elements.Add(item);
                }

                newRecord.Elements.Add(new string[] { "ER", string.Empty });

                recordList[i] = newRecord;
            }

            TreeViewAddItem($"GoogleApiAnalyses - {requestcounter}");
        }

        private void NormalizeKeywords()
        {
            IStemmer stemmer = new EnglishStemmer();

            foreach (var record in recordList)
            {

                foreach (var pair in record.Elements)
                {
                    if (pair[0] == "KW")
                    {
                        pair[1] = stemmer.Stem(pair[1]);
                    }
                }
            }

            TreeViewAddItem("NormalizedKeywords");
        }

        private void DeleteDuplicateAbstracts()
        {
            foreach (var record in recordList)
            {
                bool filterd = false;

                for (int i = 0; i < record.Elements.Count; i++)
                {
                    if (record.Elements[i][0] == "AB")
                    {
                        if (!filterd)
                        {
                            filterd = true;
                        }
                        else
                        {
                            record.Elements.RemoveAt(i);
                            i -= 1;
                        }
                    }
                }
            }

            TreeViewAddItem("DeletedDuplicateAbstracts");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    List<string> filesteam = File.ReadAllLines(fbd.FileName).ToList();

                    ImportFile(filesteam);
                }
            }

            btnExport.Enabled = true;
            btnProcess.Enabled = true;
            cbxProcessMethod.Enabled = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportFile();
        }
    }
}
