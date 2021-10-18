using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    public class Instruments
    {
        private List<string> listOfInstroments = new List<string>();

        public void CreateListOfInstruments(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    listOfInstroments.Add(s);
                }
            }
        }

        public void SchowInstruments()
        {
            foreach(string instrument in listOfInstroments)
            {
                Console.WriteLine(instrument);
            }
        }

        public bool IfInstrumentExist(string instrument)
        {
            if(listOfInstroments.Contains(instrument))
            {
                return true;
            }
            return false;
        }
    }
}
