using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class  MoiveWord
    {
        public int id { get; set; }
        public int wordId { get; set; }
        public int moiveId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string line { get; set; }

        public virtual Word word { get; set; }
        public virtual Moive moive { get; set; }

        public UserMoiveWord? usermoiveword { get; set; }
        public int? usermoivewordId { get; set; }

    }
}
