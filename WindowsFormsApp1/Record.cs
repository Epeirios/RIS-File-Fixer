using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Record
    {
        List<String[]> elements;
        
        public List<String[]> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public Record()
        {
            elements = new List<String[]>();
        }
    }
}
