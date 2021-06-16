using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        public void SaveEmployee(EmployeeInfo employeeInfo)
        {
            string cs = ConfigurationManager.ConnectionStrings["subhasishConnectionString"].ConnectionString;

            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = employeeInfo.Id
                };
                cmd.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = employeeInfo.Name
                };
                cmd.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = employeeInfo.Gender
                };
                cmd.Parameters.Add(parameterGender);

                SqlParameter parameterDateOfBirth = new SqlParameter()
                {
                    ParameterName = "@DateOfBirth",
                    Value = employeeInfo.DOB
                };
                cmd.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterEmployeeType = new SqlParameter()
                {
                    ParameterName = "@EmployeeType",
                    Value = employeeInfo.Type
                };
                cmd.Parameters.Add(parameterEmployeeType);

                if (employeeInfo.Type==EmployeeType.FullTimeEmployee)
                {
                    SqlParameter parameterAnnualSalary = new SqlParameter()
                    {
                        ParameterName = "@AnnualSalary",
                        Value = employeeInfo.AnnualSalary
                    };
                    cmd.Parameters.Add(parameterAnnualSalary);
                }
                else
                {
                    SqlParameter parameterHourlyPay = new SqlParameter()
                    {
                        ParameterName = "@HourlyPay",
                        Value = employeeInfo.HourlyPay
                    };
                    cmd.Parameters.Add(parameterHourlyPay);

                    SqlParameter parameterHoursWorked = new SqlParameter()
                    {
                        ParameterName = "@HoursWorked",
                        Value = employeeInfo.HoursWorked
                    };
                    cmd.Parameters.Add(parameterHoursWorked);
                }
                con.Open();
                cmd.ExecuteNonQuery();




            }
        }

        public EmployeeInfo GetEmployee(EmployeeRequest request)
        {
            Console.WriteLine("License Key:"+request.LicenseKey);
            Employee emp = default(Employee);
            string cs = ConfigurationManager.ConnectionStrings["subhasishConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = request.EmployeeId;

                cmd.Parameters.Add(parameterId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if ((EmployeeType)reader["EmployeeType"]==EmployeeType.FullTimeEmployee)
                    {
                        emp = new FullTimeEmployee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Type = EmployeeType.FullTimeEmployee,
                            AnnualSalary = Convert.ToInt32(reader["AnnualSalary"])
                        };
                    }
                    else
                    {
                        emp = new PartTimeEmployee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Type = EmployeeType.PartTimeEmployee,
                            HourlyPay = Convert.ToInt32(reader["HourlyPay"]),
                            HoursWorked = Convert.ToInt32(reader["HoursWorked"])
                        };
                    }
                    
                }
            }



            return new EmployeeInfo(emp);
        }
    }
}
