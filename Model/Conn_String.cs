using EmpRegd.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmpRegd.Model
{


    public class Conn_String
    {
        private readonly DbContext _context;
        public Conn_String(DbContext context)
        {
            _context = context;
            //_context.GetConnection();
        }

        public static string GetDefaultConnectionString()
        {
            return Startup.connectionString;
        }
        public static object DataAccess { get; private set; }

        public static  SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection cn = new DbContext(GetDefaultConnectionString()).GetConnection();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                return cn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This is used for disconnect the database connectivity.
        /// </summary>
        /// <returns></returns>
        public static SqlConnection CloseConnection()
        {
            SqlConnection cn = new DbContext(GetDefaultConnectionString()).GetConnection();
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return cn;
        }

        public  static string ExecuteQuery(string strQuery)
        {
            SqlConnection cn;
            SqlCommand cmd;
            cn = OpenConnection();

            try
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = strQuery;
                cmd.Prepare();
                cmd.ExecuteNonQuery();   
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (cn != null)
                    cn=CloseConnection();
            }
            return "created";
        }

        public static int ExecuteQuery(string strQuery, SqlConnection cn)
        {
            SqlCommand cmd;
            int intRows = 0;
            try
            {
                cmd = new SqlCommand(strQuery, cn);
                intRows = cmd.ExecuteNonQuery();
                return intRows;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return intRows;
        }
    }


}

