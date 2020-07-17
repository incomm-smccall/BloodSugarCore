using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodSugarCore.Model
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<BloodReading> BloodReadings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=bloodsugar.db");
    }
}
