using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.DataGrid {
    public class Employee {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Title")]
        public string Prefix { get; set; }
        public string Position { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ICollection<EmployeeTask> Tasks { get; set; }

        [Display(Name = "State")]
        public int StateID { get; set; }
        public string State { get; set; }
        public string HomePhone { get; set; }
        public string Skype { get; set; }
        public string Picture { get; set; }
    }
}