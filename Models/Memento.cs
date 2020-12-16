using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    public class Memento
    {
        private string _source;

        public Memento(string source)
        {
            this._source = source;      
        }
   
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

    }
}
