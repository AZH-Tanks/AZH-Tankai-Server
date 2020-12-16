using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    class ImageOriginator
    {
        private string _source;

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public Memento SaveMemento()
        {
            return new Memento(_source);
        }
        public void RestoreMemento(Memento memento)
        {
            this.Source = memento.Source;
        }

    }
}
