using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    public class StockItem
    {
        public StockItem(int _date, string _instrument, int _value)
        {
            date = _date;
            instrument = _instrument;
            value = _value;
        }
        public int date { get; set; }
        public string instrument { get; set; }
        public int value { get; set; }
    }
}
