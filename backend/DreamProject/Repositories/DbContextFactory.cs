using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DreamProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DreamProject.Repositories
{
    public class DbContextFactory
    {
        public ApplicationDbContext GetDbContext()
        {
            var dbOptions = GetOptions();

            return new ApplicationDbContext(dbOptions);
        }

        private DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), GetConnectionString()).Options;
        }

        private string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__default");

            return connectionString ?? GetConnectionStringFromAppSetting();
        }

        private string GetConnectionStringFromAppSetting()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            return root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
    }
}
