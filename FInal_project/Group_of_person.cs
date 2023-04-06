using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FInal_project
{
    public class Group_of_person
    {
        private string grouped_name;
        private List<Person> Group_persons;
        public void addpersont(Person person)
        {
            Group_persons = new List<Person>();
            Group_persons.Add(person);
        }
        public void removepersont(Person person)
        {
            
        }
    }
}
