using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace Buffteks4
{
    public class Team
    {
       
        //PK - DONE
        //FK - Student
        //Student List - FK - DONE
        //Name - DONE
        //projects = FK - DONE
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

         // public int AdvisorID { get; set; }  //this is the first part of setting up the advisor foreign key
          //public Advisor Advisor { get; set; }  //this is the second part of setting up the advisor foreign key

    //  public ICollection<Student> Student { get; set; }
       //public ICollection<Projects> Project{ get; set; }
}

    }