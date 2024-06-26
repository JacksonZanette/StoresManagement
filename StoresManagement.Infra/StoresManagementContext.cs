﻿using Microsoft.EntityFrameworkCore;
using StoresManagement.Domain.Models.Entities;
using System.Reflection;

namespace StoresManagement.Infra;

internal sealed class StoresManagementContext(DbContextOptions<StoresManagementContext> options) : DbContext(options)
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Store> Stores => Set<Store>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}