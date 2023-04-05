using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FInal_project
{
    public class Person
    {
        private string id;
        private string firsname;
        private string lastname;
        private int leadership;
        private int ontime;
        private int dutiful;
        private int giveusefulinfomation;


        public Person(string id, string fname, string lname, int leardership, int ontime, int dutiful, int giveusefulinfomation)
        {
            this.id = id;
            this.firsname = fname;
            this.lastname = lname;
            this.leadership = leardership;
            this.ontime = ontime;
            this.dutiful = dutiful;
            this.giveusefulinfomation = giveusefulinfomation;
        }
        public string Id{ get { return id; } }
        public string Firsname { get { return firsname; } }
        public string Lastname { get { return lastname; } }
        public int Leadership { get { return leadership; } }
        public int Ontime { get { return ontime; } }
        public int Dutiful { get { return dutiful; } }
        public int Giveusefulinfomation { get { return giveusefulinfomation; } }
    }
}
