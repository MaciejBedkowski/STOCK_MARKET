using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stock
{
    public class GetTransactions
    {
        private List<StockItem> queryList = new List<StockItem>();
        private List<StockItem> queryListShow = new List<StockItem>();
        private XmlDocument doc = new XmlDocument();
        public int iterator = 1;
        public int value;
        public string instrument;
        public int data;

        public void LoadTransactions(string path)
        {
            XmlTextReader reader = new XmlTextReader(path);
            

            while (reader.Read())
            {

                //Console.Write(reader.Value + "  " );
                
                switch(iterator)
                {
                    case 3:
                        data = Int32.Parse(reader.Value);
                        break;
                    case 6:
                        instrument = reader.Value;
                        break;
                    case 9:
                        value = Int32.Parse(reader.Value);
                        queryList.Add(new StockItem(data, instrument, value));
                        break;
                }
                if(iterator >= 9)
                {
                    iterator = 0;
                }
                iterator++;
                
            }
            Console.ReadLine();

            doc.Save(Console.Out);
        }

        public void ShowSpecyficTransaction(string transaction)
        {
            queryListShow = queryList.Where(x =>  x.instrument == transaction).ToList();

            foreach(var item in queryListShow)
            {
                Console.WriteLine(item.date + "  " + item.instrument + "  " + item.value);
            }
        }

        public void ShowAllTransaction()
        {
            foreach (var item in queryList)
            {
                Console.WriteLine(item.date + "  " + item.instrument + "  " + item.value);
            }
        }

    }
}
