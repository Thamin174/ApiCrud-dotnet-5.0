using EmpRegd.common;
using EmpRegd.Interfaces;
using EmpRegd.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmpRegd.Service
{
    public class EmployeeServices: IEmployeeService
    {

        private readonly DbContext _context;
        public EmployeeServices(DbContext context)
        {
            _context = context;
            //_context.GetConnection();
        }
        public string insert(Employee emp)
        {
            string inserted;
            inserted = Conn_String.ExecuteQuery("insert into  Employee(Username, Uemail, pwd, Gender) VALUES('" + emp.Username + "','" + emp.Uemail+"','" + emp.pwd + "','" + emp.Gender + "')");
            return inserted;
        }

        public string UpdateUser(Employee emp)
        {
            string updated;
            updated = Conn_String.ExecuteQuery("update Employee set Username='"+emp.Username+"', Uemail='"+emp.Uemail+"', pwd = '"+emp.pwd+"', Gender='"+emp.Gender+"' where Userid= '"+emp.Userid+"'");
            return updated;
        }

        public List<Employee> User()
        {
            SqlConnection connection = _context.GetConnection();
            List<Employee> admins = new List<Employee>();
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText="SELECT * FROM Employee";
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admins.Add(new Employee()
                        {
                            Userid = reader["Userid"].ToString(),
                            Username = reader["Username"].ToString(),
                            Uemail = reader["Uemail"].ToString(),
                            pwd = reader["pwd"].ToString(),
                            Gender = reader["Gender"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return admins;
        }

        public void DeleteUser(int id)
        {
            SqlConnection connection = _context.GetConnection();
            Employee admins = new Employee();
            try
            {
                //connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from Employee where Userid = '" + id + "'";
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            //return admins;
        }

        List<Employee> IEmployeeService.User()
        {
            throw new System.NotImplementedException();
        }
    }
}
    

