﻿using Ecommerce.Common.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{

    public interface IEmployeeService
    {
        Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate);
        Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate);

        Task<List<EmployeeList>> GetEmployeesAsync(EmployeeFilter employeeFilter);
        Task<EmployeeDetails> GetEmployeeAsync(int id);

        Task DeleteEmployeeAsync(EmployeeDelete employeeDelete);
    }
}
