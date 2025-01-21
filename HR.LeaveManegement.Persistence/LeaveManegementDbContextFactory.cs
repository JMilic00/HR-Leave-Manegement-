﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Persistence
{
    public class LeaveManegementDbContextFactory : IDesignTimeDbContextFactory<LeaveManegementDbContext>
    {
        public LeaveManegementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManegementDbContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new LeaveManegementDbContext(builder.Options);
        }

    }
}
