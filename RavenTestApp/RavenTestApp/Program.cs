using Microsoft.VisualStudio.TestTools.UnitTesting;
using RavenTestApp.Db;
using RavenTestApp.Entities;

namespace RavenTestApp
{
    class Program       
    {
        static void Main()
        {
            var employee = new Employee { FirstName = "John", LastName = "Doe" };

            var employeeId = DbSession.Store(employee);
            var loadedEmployee = DbSession.Load<Employee>(employeeId);

            Assert.AreEqual(employee, loadedEmployee);
        }
    }
}
