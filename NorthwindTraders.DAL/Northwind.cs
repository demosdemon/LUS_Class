namespace NorthwindTraders.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using POCOS;
    using System.Data.SqlClient;

    public partial class Northwind : DbContext
    {
        public Northwind()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);
        }

        internal List<Employee_POCO> GetEmployeesByTitle(string title)
        {
            var employees = Execute(Database.SqlQuery<Employee_POCO>, "GetEmployeesByTitle", title).ToList();

            return employees;
        }

        internal List<string> GetEmployeeTitles()
        {
            var titles = Execute(Database.SqlQuery<string>, "GetEmployeeTitles").ToList();

            return titles;
        }

        internal int CreateEmployee(string lastName, string firstName, string title, string homePhone, DateTime? hireDate)
        {
            var rowsAffected = Execute(Database.ExecuteSqlCommand, "CreateEmployee",
                lastName, firstName, title, homePhone, hireDate);

            return rowsAffected;
        }

        /// <summary>
        /// Execute the stored procedure on the remote server
        /// </summary>
        /// <typeparam name="TReturn">The return type from <paramref name="method"/> </typeparam>
        /// <param name="method">Either <see cref="Database.ExecuteSqlCommand(string, object[])"/> 
        /// or <see cref="Database.SqlQuery{TElement}(string, object[])"/> </param>
        /// <param name="proc">The name of the stored procedure to execute</param>
        /// <param name="parameters">The parameters to pass to the stored procedure</param>
        /// <returns></returns>
        private static TReturn Execute<TReturn>(Func<string, object[], TReturn> method, string proc, params object[] parameters)
        {
            var sqlParameters = parameters
                .Select((param, idx) => new SqlParameter($"@p{idx}", param))
                .ToArray();

            var paramList = string.Join(", ", parameters.Select((p, idx) => $"@p{idx}"));
            var query = $"{proc} {paramList}";

            return method(query, sqlParameters);
        }
    }
}
