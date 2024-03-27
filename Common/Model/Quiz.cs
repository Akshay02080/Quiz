using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Quiz
    {
        public String id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int Answer { get; set; }
    }
}
