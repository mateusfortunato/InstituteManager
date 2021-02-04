using InstituteManager.Models;
using System.Linq;

namespace InstituteManager.Data
{
    public class IMDbInitializer
    {
        public static void Initialize(IMContext context)
        {
            context.Database.EnsureCreated();

            if(context.Departments.Any())
            {
                return;
            }

            var departments = new Department[]
            {
                new Department { Name = "Computer Science" },
                new Department { Name = "DevOps Engineer" }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }

            context.SaveChanges();
        }
    }
}