using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MUMScrum.DataAccess
{
   public class MUMScrumInitializer : DropCreateDatabaseIfModelChanges<MUMScrumDbContext>
    {
        protected override void Seed(MUMScrumDbContext context)
        {
            context.ProductBacklogs.Add(new Model.ProductBacklog()
            {
                Name = "MUMScrum Product Backlog",
                Description = "Our First Backlog!",

            });
        }
    }
}
