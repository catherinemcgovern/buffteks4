using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace Buffteks4
{
    public class Project
    {
        //PK 
        //name 
        //leader FK team lead*
        //required hours
        //client - FK client 
        //deadline
        public int ProjectID { get; set; }
        
        public string ProjectName { get; set; }
        public int RequiredHours { get; set; }
        public DateTime Deadline  { get; set; }

          public int OrganizationId { get; set; }  //this is the first part of setting up the client foreign key
          public Organization Organization { get; set; }  //this is the second part of setting up the client foreign key




    }
}