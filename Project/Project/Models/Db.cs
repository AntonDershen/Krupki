using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Project.Models
{
    public class Db : IdentityDbContext<ApplicationUser>
    {
        public Db()
            : base("MainDb")
        {
        }
        public DbSet<News> News { get; set; }
        public DbSet<Receptions> Receptions { get; set; } 
        public DbSet<Document> Documents { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Statics> Statics { get; set; }
        public DbSet<Leader> Leaders { get; set; }
    }

    public enum Positions
    {
        Director = 0,
        DeputyDirector =1,
        Other = 2
    } 
    public class Leader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Description { get; set; }
        public Positions Position { get; set; }
        public string PhotoUrl { get; set; }
    }
    public class Jobs
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
    public class News
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
    public class Receptions
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string EMail {get; set; }
        public string Body { get; set; }
        public string Index { get; set; }
        public string Adress { get; set; }
        public string Information { get; set; }
        public string Reception { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateReception { get; set; }
        public Boolean Viewed { get; set; }
        public Boolean Answered { get; set; }
    }
    public enum DocsTypes{ File, Blank }
    public class Document
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DocumentUrl { get; set; }
        public DocsTypes Type { get; set; }
        public DateTime Date { get; set; }
    }
    public class Statics
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}