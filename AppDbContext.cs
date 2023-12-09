using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramWorkWithoutMigrations
{
    public class AppDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }




        public AppDbContext()
        {
            
        }


        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {
            //Database.Migrate();
            Database.EnsureCreated();
        }
       
    }


   
    
    



    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public required string Name { get; set; }
        public required string Email { get; set; }
    }


}
