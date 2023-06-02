using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class Moive
    {

        public Moive()
        {
            moivewords = new HashSet<MoiveWord>();
        }

        public int id { get; set; }
        public string moive { get; set; }
        public string url { get; set; }
        public string subtitleUrl { get; set; }
        public int copyright { get; set; }
        public int season { get; set; }
        public int epidose { get; set; }

        public virtual ICollection<MoiveWord> moivewords { get; set; }

    }
}
