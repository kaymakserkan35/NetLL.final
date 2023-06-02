using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Models
{
    internal class MoiveModel
    {
        public int id { get; set; }
        public string moive { get; set; }
        public string url { get; set; }
        public int copyright { get; set; }
        public int season { get; set; }
        public int epidose { get; set; }
        public string word { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string line { get; set; }
    }
}
