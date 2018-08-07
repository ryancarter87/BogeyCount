using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogeyCount
{
    class PeopleAndScores
    {
        public string name;
        public Dictionary<string, int> dateScores;
        public PeopleAndScores(string name, Dictionary<string, int> dateScores)
        {
            this.name = name;
            this.dateScores = dateScores;
        }
    }
}
