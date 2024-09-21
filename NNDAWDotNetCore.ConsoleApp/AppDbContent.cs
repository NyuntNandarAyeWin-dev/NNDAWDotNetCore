using Microsoft.EntityFrameworkCore;
using NNDAWDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNDAWDotNetCore.ConsoleApp
{
    internal class AppDbContent : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);


            }
        }

        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
