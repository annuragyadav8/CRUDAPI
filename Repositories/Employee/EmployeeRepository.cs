using DtosLayer;

namespace RepositoriesLayer.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<EmployeeClass> GetEmployees()
        {
            return GetEmployeeObject();
        }

        public EmployeeClass GetEmployee(int id)
        {
            List<EmployeeClass> employees = GetEmployeeObject();
            foreach (EmployeeClass employee in employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }

            return new EmployeeClass();
        }
        public List<EmployeeClass> GetEmployeeObject()
        {
            List<EmployeeClass> employees = new List<EmployeeClass>()
            {
                new EmployeeClass() { Id = 1, Name = "Tom", Address = "Thane", Department = "HR"},
                new EmployeeClass() { Id = 2, Name = "Sumit", Address = "Mulund", Department = "Engeering"},
                new EmployeeClass() { Id = 3, Name = "Amit", Address = "Nasik", Department = "Marketing"},
                new EmployeeClass() { Id = 4, Name = "Aman", Address = "Pune", Department = "Marketing"}
            };

            return employees;
        }

        public List<EmployeeClass> AddEmployee(EmployeeClass employee)
        {
            List<EmployeeClass> employees = GetEmployeeObject();
            employees.Add(employee);
            return employees;
        }

        public List<EmployeeClass> UpdateEmployee(EmployeeClass employee)
        {
            List<EmployeeClass> employees = GetEmployeeObject();
            foreach (EmployeeClass emp in employees)
            {
                if (emp.Id == employee.Id)
                {
                    emp.Name = employee.Name;
                    emp.Address = employee.Address;
                    emp.Department = employee.Department;
                }
            }

            return employees;
        }

        public List<EmployeeClass> DeleteEmployee(int id)
        {
            List<EmployeeClass> employees = GetEmployeeObject();
            EmployeeClass employeeToRemove = null;
            foreach (EmployeeClass emp in employees)
            {
                if (emp.Id == id)
                {
                    employeeToRemove = emp;
                    break;
                }
            }
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }

            return employees;
        }
    }
}
