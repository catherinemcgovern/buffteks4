using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Buffteks4
{
     class Program
    {
        public static void Main(string[] args)
        {
            SeedDataBase();

  Console.WriteLine("Welcome to the Bufteks Datatbase");
 bool validChoice;
 
 do // inner do...while loop is to keep looping until the user picks a valid menu selection
            {            //Menu Stuff
             validChoice = true;

              

                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Please select a menu option below:");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine( "Commands:");
                Console.WriteLine("l) Full List list"); 
                //Console.WriteLine("t) Students and Teams list"); 
                Console.WriteLine("a) Who are the 18-20 year olds"); 
                Console.WriteLine("m) List of all the students in alpha order by"); //group by method in ascending order
                Console.WriteLine("g) lets group the students according to age"); 
                Console.WriteLine("e) exit)");
                Console.WriteLine("--------------------------------------------");

              try
                {
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {

                    
                    case "l":
                        Commands.ListAll();
                        validChoice = false;
                        break;

                    
                    case "a":
                        Commands.YoungKids();
                    validChoice = false;
                        break;

                    //case "t":
                      //  Commands.StudentsPlusTeams();
                        //break;

                    case "g":
                    Commands.GroupStudents();
                    validChoice = false;
                    break;
                    
                    case "o":
                    Commands.GroupInOrder();
                    validChoice = false;
                    break;

                    case "m":
                    Commands.OrderStudentsByMethod();
                    validChoice = false;
                    break;
                         
                    case "e":
                        return;
                    default: 
                        validChoice = false;
                        Console.WriteLine("Unknown command.");
                        break;
                }

                }
                catch (FormatException)
                {
                    // This try...catch block catches the FormatException that Convert.ToInt32 will throw 
                    // if the user inputs text or something that cannot be converted to an integer.
                    validChoice = false;
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            } while (validChoice == false); // Inner loop ends when validChoice is true


            //end menu stuff
            

        }


        public static void SeedDataBase()
        {   
            using(var db = new AppDbContext())
            {
                try
                {

                    //no matter what, delete and then create
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Students.Any())
                    {
                        List<Student> students = new List<Student>()
                        {
                            new Student()
                            {
                                Id = 1,
                                FirstName = "Marvin",
                                LastName = "Moore",
                                PhoneNumber = "123-555-1234",
                                Email = "MarvinMoore@test.com",
                                Role = "Senior",
                                TeamId = 1,
                                Age = 23,
                            },
                            new Student()
                            {
                                Id = 2,
                                FirstName = "Joe",
                                LastName = "Smith",
                                PhoneNumber = "456-684-4684",
                                Email = "fun@aol.com",
                                Role = "Sophomore",
                                TeamId = 1,
                                Age = 19,
                            },
                            new Student()
                            {
                                Id = 3,
                                FirstName = "Mary Jane",
                                LastName = "McMoe",
                                PhoneNumber = "123-555-1234",
                                Email = "janesMcMoe@buffs.wtamu.edu",
                                Role = "Freshman",
                                TeamId = 2,
                                Age = 19,

                            },  

                            new Student()
                            {
                                Id = 4,
                                FirstName = "Marion",
                                LastName = "McGovern",
                                PhoneNumber = "888-595-9324",
                                Email = "MarionMcGee@buffs.wtamu.edu",
                                Role = "Sophomore",
                                TeamId = 2,
                                Age = 20,

                            }, 

                           new Student()
                            {
                                Id = 5,
                                FirstName = "Vernon",
                                LastName = "Yarbrough",
                                PhoneNumber = "400-995-1010",
                                Email = "VernonYarbrough@buffs.wtamu.edu",
                                Role = "Senior",
                                TeamId = 3,
                                Age = 22,

                            }, 

                            new Student()
                            {
                            
                                Id = 6,
                                FirstName = "Marshal",
                                LastName = "Noonan",
                                PhoneNumber = "121-256-0006",
                                Email = "MarsalNoonan@buffs.wtamu.edu",
                                Role = "Junior",
                                TeamId = 3,
                                Age = 21,
                            },   

                            new Student()
                            {
                                Id = 7,
                                FirstName = "Jan",
                                LastName = "Spikes",
                                PhoneNumber = "806-000-0006",
                                Email = "JaniceSpikes@buffs.wtamu.edu",
                                Role = "Senior",
                                TeamId = 3,
                                Age = 21,
                            },   
                            
                                                 
                        };


                        //Project db

 List<Project> projects = new List<Project>()
                        {
                            new Project()
                            {
                                ProjectName = "Pink Poodle Boutique Website",
                                RequiredHours = 10,
                                Deadline = new DateTime(2019, 10, 2),
                                OrganizationId = 1,
                            },
 

                          new Project()
                            {
                                ProjectName = "The Insidious Martian Library Web App",
                                RequiredHours = 95,
                                Deadline = new DateTime(2019, 10, 22),
                                OrganizationId = 2,

                            },

                            
                          new Project()
                            {
                                ProjectName = "Frank's Bakery Online Ordering System",
                                RequiredHours = 65,
                                Deadline = new DateTime(2019, 5, 11),
                                OrganizationId = 3,

                            },
 
                            
                                                 
                        };

                       List<Organization> organizations = new List<Organization>()
                        {
                            new Organization()
                            {
                                 OrganizationId = 1,
                                 Name = "Poodles of America",

                            },
 

                            new Organization()
                            {
                                OrganizationId = 2,
                                Name = "Martian Librarians of Tevolia",


                            },

                            
                            new Organization()
                            {
                                 OrganizationId = 3,
                                 Name = "Je Veux International",

                            },

                        };

                        //Team will start here
                         List<Team> teams = new List<Team>()
                        {
                            new Team()
                            {
                                 TeamId = 1,
                                 TeamName = "Team of Awesomeness",
                                 TeamDescription = "We are the Champions my friends"
                                 //AdvisorID = 1,

                            },
 

                             new Team()
                            {
                                 TeamId = 2,
                                 TeamName = "Team-Two Titans",
                                TeamDescription = "Team Titans Go!"

                                 //AdvisorID = 2,
            
                            },

                            new Team()
                            {
                                 TeamId = 3,
                                 TeamName = "Three Cheeses",
                                TeamDescription = "We three cheeses of orient are"

                                 //AdvisorID = 2,
                            },
 
                            
                                                 
                        };
                        //Team ends here


                        //Advisor Starts here

                        List<Advisor> advisors = new List<Advisor>()
                        {
                            new Advisor()
                            {
                                FirstName = "Gandalf",
                                LastName = "McGray",
                                PhoneNumber = "206-515-0056",
                                Email = "McGray@test.com",
                                AdvisorId = 1,
                            },
                            new Advisor()
                            {
                                FirstName = "Morgan",
                                LastName = "LeFay",
                                PhoneNumber = "202-669-0010",
                                Email = "Mo@aol.com",
                                AdvisorId = 2,
                            },


                   
                        };

                        //Advisor ends here

                        //Project end db

                        db.Students.AddRange(students);  
                        db.Project.AddRange(projects);
                        db.Organizations.AddRange(organizations);
                         db.Team.AddRange(teams);
                          db.Advisor.AddRange(advisors);

                     

                        db.SaveChanges();                                              

                    }
                    else
                    {
                        var students = db.Students.ToList();
                        foreach(Student s in students)
                        {
                            Console.WriteLine(s);
                        }

                        var projects = db.Project.ToList();
                        foreach(Project p in projects)
                        {
                            Console.WriteLine(p);
                        }
                    
                     var organizations = db.Organizations.ToList();
                        foreach(Organization o in organizations)
                        {
                            Console.WriteLine(o);
                        }


                        var teams = db.Team.ToList();
                        foreach(Team t in teams)
                        {
                            Console.WriteLine(t);
                        }
                        
                        var Advisor = db.Advisor.ToList();
                        foreach(Advisor a in Advisor)
                        {
                            Console.WriteLine(a);
                        }
                    }


                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

                

                // putting menue stuff here
      



                //end of menu stuff
            }


           
      

            }

            
        }


    
}

