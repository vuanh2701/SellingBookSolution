using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Data.EF
{
    public class SellingBookDbContextFactory : IDesignTimeDbContextFactory<SellingBookDbContext>
    {
        public SellingBookDbContext CreateDbContext(string[] args)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            
            var connectionString = configuration.GetConnectionString("SellingBookSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<SellingBookDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SellingBookDbContext(optionsBuilder.Options);

            
        }
    }
}
