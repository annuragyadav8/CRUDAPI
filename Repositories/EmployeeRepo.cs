using DtosLayer;

namespace Repositories
{
    public class EmployeeRepo
    {
        List<EmployeeClass> employees = new List<EmployeeClass>()
        {
            new EmployeeClass() { Id = 1, Name = "Tom", Address = "Thane", Department = "HR"},
            new EmployeeClass() { Id = 2, Name = "Sumit", Address = "Mulund", Department = "Engeering"},
            new EmployeeClass() { Id = 3, Name = "Amit", Address = "Nasik", Department = "Marketing"},
            new EmployeeClass() { Id = 4, Name = "Aman", Address = "Pune", Department = "Marketing"},
        };
    }
}
