using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    [DataContract(Namespace ="subhasishbiswas.com/2018/Employee")]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;  
        private DateTime _dateOfBirth;
        [DataMember(Order =1,Name ="Indetification Number")]
        public int Id { get => _id; set => _id = value; }
        [DataMember]
        public string Name { get => _name; set => _name = value; }
        [DataMember]
        public string Gender { get => _gender; set => _gender = value; }
        [DataMember]
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
    }
}
