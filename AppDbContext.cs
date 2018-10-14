using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Buffteks4
{
    //here, we extend the DbContext class with our own class 'AppDbContext'
    public class AppDbContext : DbContext
    {
        //The connection string is used by the SQL Server database provider to find the database
        private const string ConnectionString = @"Data Source=MyFirstEfCoreDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //Using the SQLite database provider’s UseSqlServer command sets up the options ready for creating the applications’s DBContext
            optionsBuilder.UseSqlite(ConnectionString); //#B
        }        

        public DbSet<Student> Students { get; set; }     
        public DbSet<Team> Team { get; set; }        
        public DbSet<Organization> Organizations { get; set; }   

        public DbSet<Advisor> Advisor { get; set; }   
        public DbSet<Project> Project { get; set; }        



    }    
}