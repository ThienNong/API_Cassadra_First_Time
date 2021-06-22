using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Models
{
    public class Test
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int birthYear { get; set; }

        public Test()
        {
        }

        public Test(int ID, string name, int birthYear)
        {
            this.ID = ID;
            this.name = name;
            this.birthYear = birthYear;
        }
    }
}
