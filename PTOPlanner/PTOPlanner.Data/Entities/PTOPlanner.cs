using System.Data.Entity.Migrations;

namespace PTOPlanner.Data.Entities
{
    using System.Data.Entity;

    public partial class PTOPlanner : DbContext
    {
        /// <summary>
        /// Disable Auto-Migrations
        /// </summary>
        internal sealed class Configuration : DbMigrationsConfiguration<PTOPlanner>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
            }
        }

        public PTOPlanner() : base("name=PTOPlannerEntities")
        {
        }

        public virtual DbSet<Employee_Info> Employee_Info { get; set; }
        public virtual DbSet<PayrollSchedule> PayrollSchedule { get; set; }
        public virtual DbSet<EmployeePTOBalance> EmployeePTOBalance { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
