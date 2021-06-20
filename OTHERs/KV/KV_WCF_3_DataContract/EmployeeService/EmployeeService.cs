using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee(int Id)
        {
            Employee employee = new Employee();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlConnection=new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = Id;
                sqlCommand.Parameters.Add(parameter);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = reader["Name"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                }
            }

            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spSaveEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = employee.Id
                };
                sqlCommand.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                sqlCommand.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                sqlCommand.Parameters.Add(parameterGender);

                SqlParameter parameterDateOfBirth = new SqlParameter()
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                sqlCommand.Parameters.Add(parameterDateOfBirth);

                sqlConnection.Open();
                sqlCommand.ExecuteScalar();
               
            }

           
        }
    }
}
