using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models
{
    public class TwoRows
    {
        public long id { get; set; }
        public string title { get; set; }
        public bool isSave { get; set; }

        public TwoRows(bool isSave = true)
        {
            this.isSave = isSave;
        }
    }
}
