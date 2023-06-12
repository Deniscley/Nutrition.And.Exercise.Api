using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Context
{
    public class ApplyConfigurationContext
    {
        public static void OnApplyConfiguration(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
