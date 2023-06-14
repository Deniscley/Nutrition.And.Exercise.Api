using Microsoft.EntityFrameworkCore;

namespace Nutrition.And.Exercise.Data.Context
{
    public class ApplyConfigurationContext
    {
        public static void OnApplyConfiguration(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClientConfigurationMap());
        }
    }
}
