using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stock
{
    public class StockOffer
    {
        private List<string> instrument = new List<string>();
        private int offerts = 1000;
        private string losInstrument;
        private Random rand = new Random();
        private int valueOffert = 0;
        private int minValueOffert = 10;
        private int maxValueOffert = 100;
        private string pathSave;
        private XmlDocument doc = new XmlDocument();

        public void StockOfferGenerate(List<StockItem> offertsStock, string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    instrument.Add(s);
                }
            }

            //pathSave = $"offerts{DateTime.Now}";
            pathSave = $"offerts.xml";

            doc.LoadXml($"<Offer></Offer>");

            for (int i = 1; i <= offerts; i++)
            {

                losInstrument = instrument[rand.Next(instrument.Count)];
                valueOffert = rand.Next(minValueOffert, maxValueOffert);


                offertsStock.Add(new StockItem(i, losInstrument, valueOffert));

                // Add a value elements.
                XmlElement newElem = doc.CreateElement("int");
                newElem.InnerText = $"{i}";
                doc.DocumentElement.AppendChild(newElem);

                newElem = doc.CreateElement("Instrument");
                newElem.InnerText = $"{losInstrument}";
                doc.DocumentElement.AppendChild(newElem);

                newElem = doc.CreateElement("Value");
                newElem.InnerText = $"{valueOffert}";
                doc.DocumentElement.AppendChild(newElem);

            }

            // Save the document to a file. White space is
            // preserved (no white space).
            //pathSave = pathSave.Replace('.', '-');
            //pathSave = pathSave.Replace(':', '-');
            //pathSave = pathSave + ".xml";

            doc.PreserveWhitespace = true;
            doc.Save(pathSave);

            //}
        }
    }
}
