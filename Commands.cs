using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Buffteks4
{
    public static class Commands
    {


        public static void YoungKids()
         {
            using(var db = new AppDbContext())
             {
                 var filteredResult = from s in db.Students
                 where s.Age >= 18 && s.Age <= 20
                 select "Student Name: " + s.FirstName + ", Age:" + s.Age;

                 PrintList(filteredResult);
             }
         }
         


 

        public static void ListAll()
        {
            using (var db = new AppDbContext())              //#A
            {
                Console.WriteLine();

                Console.WriteLine($"BUFFTEKS DATABASE CONTENT:");

                Console.WriteLine();

                Console.WriteLine("Students");
                
                Console.WriteLine("--------------------------------------------------------------------");

                var students = db.Students.ToList();
                foreach(Student s in students)
                    {
                        Console.WriteLine($"Buffteks Members: {s.FirstName} {s.LastName}, {s.PhoneNumber}, {s.Email}");
                    }
            Console.WriteLine();                        
            Console.WriteLine();

                Console.WriteLine("Organizations");
            
                Console.WriteLine("--------------------------------------------------------------------");
                var organizations = db.Organizations.ToList();
            foreach(Organization o in organizations)
            {
                Console.WriteLine($"Organization: {o.OrganizationId}, {o.Name}");
            }

            
            
            Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine("Team");
            
                Console.WriteLine("--------------------------------------------------------------------");

            var teams = db.Team.ToList();
            foreach(Team t in teams)
            {
                Console.WriteLine($"Team: Team number {t.TeamId}, {t.TeamName}");
            }
            
            
            Console.WriteLine();
            Console.WriteLine();
            


                Console.WriteLine("Advisor");
            
                Console.WriteLine("--------------------------------------------------------------------");

            var Advisor = db.Advisor.ToList();
            foreach(Advisor a in Advisor)
            {
                Console.WriteLine($"Buffteks Advisor: {a.AdvisorId}: {a.FirstName} {a.LastName}, {a.PhoneNumber}, {a.Email}");
            }


            Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine("Projects");
            
                Console.WriteLine("--------------------------------------------------------------------");


            var projects = db.Project.ToList();
            foreach(Project p in projects)
            {
                Console.WriteLine($"Project Number {p.ProjectID}; {p.ProjectName}; Required Hours: {p.RequiredHours}; Deadline: {p.Deadline: d/M/yyyy}");
            }
        }


  
                
    }


            
         public static void BasicFiltersWithWhereMethodSyntax()
         {





         }


                 public static void StudentsPlusTeams()
         {
            using(var db = new AppDbContext())
             {
                 var filteredResult = from s in db.Students
                 where s.Age >= 18 && s.Age <= 20
                 select "Student Name: " + s.FirstName + ", Age:" + s.Age;

                 PrintList(filteredResult);
             }
         }


         public static void Group()
         {
             using(var db = new AppDbContext())
             {
                var groupedResult = from s in db.Students
                group s by s.Age;
                foreach(var ageGroup in groupedResult)
                {
                    Console.WriteLine($"Age Group: {ageGroup.Key}");
                    foreach(Student s in ageGroup)
                    {
                    Console.WriteLine("--" + s.FirstName + s.LastName);

                    }
                }

                //PrintList(groupedResult);
                }
         }

//join method syntax

public static void JoinSyntax()

{
    using(var db = new AppDbContext())

    {
        var innerJoin = db.Students.Join(   //outer sequence
                                        db.Team,          //inner sequence
                                         s => s.TeamId,  //outer key
                                         t => t.TeamId,  //inner key
                                         (s, t) => new   //projection
                                            {
                                                LastName = s.LastName,
                                                TeamName = t.TeamName,
                                                TeamDescription = t.TeamDescription,   
                                            }   
                                        );

        var innerJoinOrdered = innerJoin.OrderBy(p => p.LastName).ThenBy(p => p.TeamName);                                

        foreach(var s in innerJoin)
            {
                Console.WriteLine($"{s.LastName} is on {s.TeamName} Team");
            }
    }

}



//end join method syntax

//Comprehensive Find starts


public static List<Student> CompFindInStudents(string term)
        
  //setting up join-------------------------------------------
/*
 
        
  */      
        
        {

            List<Student> students = new List<Student>();
            
             using (var db = new AppDbContext())
            {

                var innerJoin = db.Students.Join(   //outer sequence
                                        db.Team,          //inner sequence
                                         s => s.TeamId,  //outer key
                                         t => t.TeamId,  //inner key
                                         (s, t) => new   //projection
                                            {
                                                FirstName = s.FirstName,
                                                LastName = s.LastName,
                                                TeamName = t.TeamName,
                                                TeamDescription = t.TeamDescription,   
                                            }   
                                        );

        var innerJoinOrdered = innerJoin.OrderBy(s => s.LastName).ThenBy(s => s.TeamName).Select(s => new{
                        s.FirstName,
                        s.LastName,
                        s.TeamName,
                        s.TeamDescription,
                        
                    }).Where(s => s.FirstName.Contains(term) || s.LastName.Contains(term))
                    .ToList();

  foreach(var s in innerJoin)
                {
                    students.Add(new Student{
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        //TeamName = item.TeamName
            
                    });
                      
            }

                    
                     } return students.Count > 0 ? students : null;
            }
            //{
              //  Console.WriteLine($"{s.FirstName} {s.LastName} is on this team: {s.TeamName}; with this description: ");
            

      /*          foreach(var item in s.students)
                {
                    students.Add(new Student{
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                       Age = item.Age,
                       Email = item.Email,
                       Role = item.Role,
                       TeamName = item.TeamName,
            
                    });*/
        

            //if there are results, return the list
            








//Comprehensive find ends

//FIND BEGINS

 public static List<Student> FindInStudents(string term)
        {

            List<Student> students = new List<Student>();

            using (var db = new AppDbContext())
            {
                //this will require a JOIN to bring the two tables together
                var findStudents = db.Students
                
                    .Select(s => new{
                        s.FirstName,
                        //TeamName = s.students.Select(t => t.Team.TeamName).First(),
                        //AuthorUrl = b.AuthorsLink.Select(q => q.Author.WebUrl).First(),
                        s.LastName,
                        s.Age, 
                        s.Email, 
                        s.Role
                        
                        
                    })
                    .Where(s => s.FirstName.Contains(term) || s.LastName.Contains(term))
                    .ToList();

                foreach(var item in findStudents)
                {
                    students.Add(new Student{
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                       Age = item.Age,
                       Email = item.Email,
                    Role = item.Role
            
                    });
                }                
            }

            //if there are results, return the list
            return students.Count > 0 ? students : null;
}









//FIND ENDS

//Start Method - Group in Order


         public static void GroupInOrder()
         {
             using(var db = new AppDbContext())
             {
                var groupedInOrderResult = db.Students.GroupBy(s => s.Age);
                
                foreach(var ageGroupOrder in groupedInOrderResult)
                {
                    Console.WriteLine($"Age Group: {ageGroupOrder.Key}");
                    foreach(Student s in ageGroupOrder)
                    {
                    Console.WriteLine("--" + s.FirstName + s.LastName);

                    }
                }

                //PrintList(groupedResult);
                }
         }


//End Method

         public static void GroupStudents()
         {
             using(var db = new AppDbContext())
             {
                var groupedResult = from s in db.Students
                group s by s.Age;
                foreach(var ageGroup in groupedResult)
                {
                    Console.WriteLine($"Age Group: {ageGroup.Key}");
                    foreach(Student s in ageGroup)
                    {
                    Console.WriteLine("--" + s.FirstName + " " + s.LastName);

                    }
                }

                //PrintList(groupedResult);
                }
         }

//Start Method - Group by Method Ascending

         public static void NameDescending()
         {
            using(var db = new AppDbContext())
             {
                 var descendingStudent = from s in db.Students
                 orderby s.LastName descending
                 select s;

                foreach(Student s in descendingStudent)
                    {
                    Console.WriteLine(s.FirstName + " " + s.LastName);

                    }



             }
         }
         

         public static void OrderStudentsByMethod()
         {
             using(var db = new AppDbContext())
             {
                var orderedStudents = db.Students.OrderBy(s => s.LastName);
                    foreach(Student s in orderedStudents)
                    {
                    Console.WriteLine(s.FirstName + " " + s.LastName);

                    }
                


                //PrintList(groupedResult);
                }
         }


//End Method



        public static void PrintList(IEnumerable<string> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
        }


        //Setting up a where query




                      //Setting up Find

        // public static List<StudentListDTO> `FindInStudents(string term)
        // {

        //     List<BookListDTO> books = new List<BookListDTO>();

        //     using (var db = GetDbContext())
        //     {
        //         //this will require a JOIN to bring the two tables together
        //         var booksandauthors = db.Books
        //             .Select(b => new{
        //                 b.BookId,
        //                 AuthorName = b.AuthorsLink.Select(q => q.Author.Name).First(),
        //                 AuthorUrl = b.AuthorsLink.Select(q => q.Author.WebUrl).First(),
        //                 b.Title,
        //                 b.Publisher,
        //                 b.PublishedOn
        //             })
        //             .Where(s => s.AuthorName.Contains(term) || s.Title.Contains(term))
        //             .ToList();

        //         foreach(var item in booksandauthors)
        //         {
        //             books.Add(new BookListDTO{

        //                 BookId = item.BookId,
        //                 Title = item.Title,
        //                 AuthorsOrdered = item.AuthorName,
        //                 Publisher = item.Publisher,
        //                 PublishedOn = item.PublishedOn,
        //                 AuthorUrl = item.AuthorUrl
        //             });
        //         }                
        //     }



                        //ending set up of Find
 

    }
}