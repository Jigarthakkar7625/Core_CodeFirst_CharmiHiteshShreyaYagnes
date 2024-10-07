using Core_CodeFirst.Data.Models;
using Core_CodeFirst.Services.IServices;

namespace Core_CodeFirst.Services
{
    //public class Employees : ITransient, IScoped, ISingleton
    public class Employees : IEmployees
    {
        //private readonly TestDbmajwtContext testDbmajwtContext;

        Guid id;
        //public Employees(TestDbmajwtContext db)
        public Employees()
        {
            id = Guid.NewGuid();
            //this.testDbmajwtContext = db;
        }

        public List<Employee> GetAllEmployee()
        {
            return new List<Employee> { new Employee { Id = 1, Address = "Ahmedabad", Name = "Jigar" } }; // DB
        }

        //public List<Employee> GetAllEmployee()
        //{

        //    return testDbmajwtContext.Employees.ToList();
        //}

        public Guid GetOperationID()
        {
            return id;
        }
    }

    public class Employees123 : IEmployees
    {
        //private readonly TestDbmajwtContext testDbmajwtContext;

        Guid id;
        //public Employees(TestDbmajwtContext db)

        public List<Employee> GetAllEmployee()
        {
            return new List<Employee> { new Employee { Id = 1, Address = "Surat", Name = "Tushar" } }; // DB
        }

    }
}