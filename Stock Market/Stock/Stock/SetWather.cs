using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stock
{
    public class SetWather
    {
        private string _instrument;
        private int _value;
        private List<StockItem> queryList = new List<StockItem>();
        private XmlDocument doc = new XmlDocument();
        public SetWather(string instrument, int value)
        {
            _instrument = instrument;
            _value = value;
        }

        public void BuyOffert(List<StockItem> offertsStock, string path)
        {
            queryList = offertsStock.Where(x => x.value < _value && x.instrument == _instrument).ToList();

            if(!File.Exists(path))
                doc.LoadXml($"<Transaction></Transaction>");
            else
                doc.Load(path);

            foreach (var query in queryList)
            {
                // Add a value elements.
                XmlElement newElem = doc.CreateElement("Date");
                newElem.InnerText = $"{query.date}";
                doc.DocumentElement.AppendChild(newElem);

                newElem = doc.CreateElement("Instrument");
                newElem.InnerText = $"{query.instrument}";
                doc.DocumentElement.AppendChild(newElem);

                newElem = doc.CreateElement("Value");
                newElem.InnerText = $"{query.value}";
                doc.DocumentElement.AppendChild(newElem);

                
            }

            doc.PreserveWhitespace = true;
            
            doc.Save(path);
        }
    }
}
