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
            // Lấy connection config bằng cách tạo 1 ConfigurationBiuder, set BasePath là thư mục hiện tại, add jsonFile
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // lẤy được Connection String với tên eShopSolutionDb
            var connectionString = configuration.GetConnectionString("SellingBookSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<SellingBookDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SellingBookDbContext(optionsBuilder.Options);

            // để tạo Migration, trong Package Manager Console, gõ " Add-Migration + [tên Migration] "
            // tiếp tục update database bằng lệnh update-database
        }
    }
}
