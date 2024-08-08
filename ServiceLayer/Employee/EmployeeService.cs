using DtosLayer;
using RepositoriesLayer.Employee;

namespace ServiceLayer.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeClass> AddEmployee(EmployeeClass employee)
        {
           return _employeeRepository.AddEmployee(employee);
        }

        public List<EmployeeClass> DeleteEmployee(int id)
        {
           return (_employeeRepository.DeleteEmployee(id));   
        }

        public EmployeeClass GetEmployee(int id)
        {
          return  _employeeRepository.GetEmployee(id);
        }

        public List<EmployeeClass> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public List<EmployeeClass> UpdateEmployee(EmployeeClass employee)
        {
          return  _employeeRepository.UpdateEmployee(employee);
        }
    }
}
