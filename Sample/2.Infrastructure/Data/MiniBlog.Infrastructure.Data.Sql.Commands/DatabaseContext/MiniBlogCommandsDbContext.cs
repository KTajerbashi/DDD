﻿using DDD.Infra.Data.Sql.Commands.Library;
using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Domain.Advertisements.Entities;
using MiniBlog.Core.Domain.People.Entities;
using MiniBlog.Core.Domain.People.ValueObjects;
using MiniBlog.Infrastructure.Data.Sql.ValueConversions;

namespace MiniBlog.Infrastructure.Data.Sql.Commands.DatabaseContext;

/// <summary>
/// بدون رویداد ها
/// </summary>
public class MiniBlogCommandsDbContext : BaseCommandDbContext

/// <summary>
/// 
/// </summary>
//public class MiniBlogCommandsDbContext : BaseOutboxCommandDbContext
{
    public MiniBlogCommandsDbContext(DbContextOptions<MiniBlogCommandsDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
    }
    public DbSet<Person> People { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Admin> Admins { get; set; }
}

//public class MiniBlogCommandsDbContextFactory : IDesignTimeDbContextFactory<MiniBlogCommandsDbContext>
//{
//    public MiniBlogCommandsDbContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<MiniBlogCommandsDbContext>();
//        optionsBuilder.UseSqlServer("Server =TAJERBASHI; Database=MiniBlogDb;User Id = sa;Password=123123; MultipleActiveResultSets=true; Encrypt = false");
//        //optionsBuilder.UseSqlServer("Server =172.20.1.20\\DEV; Database=MiniBlogDb;User Id = sa;Password=soft157703ware; MultipleActiveResultSets=true; Encrypt = false");

//        return new MiniBlogCommandsDbContext(optionsBuilder.Options);
//    }
//}