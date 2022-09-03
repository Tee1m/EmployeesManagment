﻿using Domain.Employee;
using Infrastructure.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataBase
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Domain.Task.Task> Tasks { get; set; }
    }
}