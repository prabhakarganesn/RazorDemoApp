using DempApp.Models.DB;

namespace DempApp.Service
{
    public static class DbInitializer
    {
        public static void Initialize(DemoClientContext context)
        {
            if (context.EmployeeTypes.Any())
            {
                return;  
            }

            var empTypes = new EmployeeType[]
            {
                new EmployeeType{Type="Full Time"},
                new EmployeeType{Type="Part Time"},
            };

            context.EmployeeTypes.AddRange(empTypes);
            context.SaveChanges();
        }
    }
}
