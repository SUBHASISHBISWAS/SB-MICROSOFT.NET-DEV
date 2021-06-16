using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    [MessageContract(IsWrapped =true,WrapperName ="EmployeeRequestObject",WrapperNamespace ="http://mycompany.com/Employee")]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://mycompany.com/Employee")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee")]
        public int EmployeeId { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName = "EmployeeInfoObject", WrapperNamespace = "http://mycompany.com/Employee")]
    public class EmployeeInfo
    {

        public EmployeeInfo()
        {


        }

        public EmployeeInfo(Employee emp)
        {
            this.Id = emp.Id;
            this.Name = emp.Name;
            this.Gender = emp.Gender;
            this.DOB = emp.DateOfBirth;
            this.Type = emp.Type;
            if (Type==EmployeeType.FullTimeEmployee)
            {
                this.AnnuaSalary = ((FullTimeEmployee)emp).AnnualSalary;
            }
            else
            {
                this.HourlyPay = ((PartTimeEmployee)emp).HourlyPay;
                this.HoursWorked = ((PartTimeEmployee)emp).HoursWorked;
            }
        }


        [MessageBodyMember(Namespace = "http://mycompany.com/Employee",Order =1)]
        public int Id { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 2)]
        public string Name { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 3)]
        public string Gender { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 4)]
        public DateTime DOB { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 5)]
        public EmployeeType Type { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 6)]
        public int AnnuaSalary { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 7)]
        public int HourlyPay { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee", Order = 8)]
        public int HoursWorked { get; set; }
    }

    public enum EmployeeType
    {
        FullTimeEmployee=1,
        PartTimeEmployee=2
    }

    //[KnownType(typeof(FullTimeEmployee))]
    //[KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace = "http://subhasish.biswas.com/2015/10/10/Employee")]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;

        [DataMember(Order =5)]
        public EmployeeType Type { get; set; }

        [DataMember(Name="ID",Order =1,IsRequired =true)]
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        [DataMember(Order =2)]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        [DataMember(Order =3)]
        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        [DataMember]
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _dateOfBirth = value;
            }
        }
    }
}
