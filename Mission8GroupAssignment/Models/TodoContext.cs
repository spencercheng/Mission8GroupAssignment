using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8GroupAssignment.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
            {


            }
        public DbSet<TaskApplication> Responses { get; set; }
        
        public DbSet<Category>Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
            {

            mb.Entity<Category>().HasData(

                new Category { CategoryId =1, CategoryName = "Home"},
                new Category { CategoryId = 2, CategoryName = "School"},
                new Category { CategoryId = 3, CategoryName = "Work"},
                new Category { CategoryId = 4, CategoryName = "Church"}
                );
            mb.Entity<TaskApplication>().HasData(

                    new TaskApplication
                    {
                        ApplicationId = 1,
                        Task = "YO",
                        Duedate = "10/20/30",
                        Quadrant = 4,
                        CategoryId = 1,
                        Completed = false
                    }

                );
            }
    }

}
