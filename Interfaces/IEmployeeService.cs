using EmpRegd.Model;
using System;
using System.Collections.Generic;

namespace EmpRegd.Interfaces
{
    public interface IEmployeeService
    {

        string insert(Employee emp);
        //void login(LoginPage login);
        List<Employee> User();
        //  string log(LoginModel loginPage);

    }
}
