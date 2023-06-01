﻿using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Customers { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
