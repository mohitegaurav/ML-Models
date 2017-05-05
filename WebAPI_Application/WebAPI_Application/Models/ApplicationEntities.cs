namespace WebAPI_Application.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationEntities : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public ApplicationEntities()
            : base("name=ApplicationDBConnection")
        {
            Database.SetInitializer<ApplicationEntities>(null);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
