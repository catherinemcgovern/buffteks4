using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace Buffteks4
{
    public class Organization : Person
    {
        //project list
        //PK 
        //first name  - originates in the abstract class called "Person"
        //last name - originates in the abstract class called "Person"
        //phone - originates in the abstract class called "Person"
        //email - originates in the abstract class called "Person"
        //organization
        public int OrganizationId { get; set; }
        public ICollection<Project> Project{ get; set; }
            public string Name { get; set; }


        

    }
}