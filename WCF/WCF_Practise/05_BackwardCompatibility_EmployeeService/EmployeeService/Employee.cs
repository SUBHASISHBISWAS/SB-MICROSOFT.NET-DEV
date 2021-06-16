﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    

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

        [DataMember(Order = 6, IsRequired = true)]
        public string City { get; set; }

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
