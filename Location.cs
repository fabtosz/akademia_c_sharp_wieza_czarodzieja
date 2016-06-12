using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication6
{
    abstract class Location
    {
        public Location(string name)
        {
            this.name = name;
        }

        public Location[] Exits;

        private string name;
        public string Name
        {
            get { return name; }
        }
        public virtual string Description
        {
            get
            {
                string description = "Miejsce, w którym się znajdujesz, to " + name
                    + ". Widzisz przejścia do następujących miejsc: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1)
                        description += ",";
                }
                description += ".";
                return description;
            }
        }
    }
}
