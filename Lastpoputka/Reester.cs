using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lastpoputka
{
    class Reester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Work { get; set; }
        public string NameR { get; set; }
        public int HardEasy { get; set; }
        public Reester() { }
        public Reester(string Name, string Work, string NameR, int HardEasy)
        {
            this.Name = Name;
            this.Work = Work;
            this.NameR = NameR;
            this.HardEasy = HardEasy;
        }
    }
    
}
