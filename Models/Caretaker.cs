using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    public class Caretaker
    {
        private Memento _memento;
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
