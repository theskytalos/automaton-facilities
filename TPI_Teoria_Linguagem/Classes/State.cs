using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Teoria_Linguagem.Classes
{
    public class State
    {
        public string Name { get; set; }
        public bool Initial { get; set; }
        public bool Final { get; set; }

        public State (string Name, bool Initial, bool Final)
        {
            this.Name = Name;
            this.Initial = Initial;
            this.Final = Final;
        }
    }
}
