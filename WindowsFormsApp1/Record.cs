using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Record
    {
        Dictionary<String, String> elements;
        
        public Dictionary<String, String> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public Record()
        {
            elements = new Dictionary<string, string>();
        }
    }
}
