using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DtosLayer;

namespace RepositoriesLayer.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<EmployeeClass> GetEmployees()
        {
            List<EmployeeClass> employees = new List<EmployeeClass>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmployees", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeClass emp = new EmployeeClass()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        Department = reader["Department"].ToString()
                    };
                    employees.Add(emp);
                }
            }

            return employees;
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
            List<EmployeeClass> employees = new List<EmployeeClass>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Department", employee.Department);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return employees;
        }

        public List<EmployeeClass> UpdateEmployee(EmployeeClass employee)
        {
            List<EmployeeClass> employees = new List<EmployeeClass>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Department", employee.Department);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return employees;
        }

        public List<EmployeeClass> DeleteEmployee(int id)
        {
            List<EmployeeClass> employees = new List<EmployeeClass>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return employees;
        }
    }
}
