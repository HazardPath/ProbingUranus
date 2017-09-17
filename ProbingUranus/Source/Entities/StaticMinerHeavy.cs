using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbingUranus.Source
{
    class StaticMinerHeavy : StaticMiner
    {
        public StaticMinerHeavy(Location location) : base(location, ArtFetcher.Minerart)
        {

        }
    }
}
