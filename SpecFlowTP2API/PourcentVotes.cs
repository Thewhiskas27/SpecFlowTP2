using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTP2API
{
    public class PourcentVotes
    {
        public Candidat c { get; set; }
        public decimal percent { get; set; }
        public PourcentVotes(Candidat c, int p)
        {
            this.c = c;
            this.percent = p;
        }
    }
}
