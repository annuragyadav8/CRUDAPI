using DtosLayer;

namespace ServiceLayer.Employee
{
    public interface IEmployeeService
    {
        List<EmployeeClass> GetEmployees();
        EmployeeClass GetEmployee(int id);
        List<EmployeeClass> AddEmployee(EmployeeClass employee);
        List<EmployeeClass> UpdateEmployee(EmployeeClass employee);
        List<EmployeeClass> DeleteEmployee(int id);
    }
}
