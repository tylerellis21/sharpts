using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class Employee : User {

        [Required()]
        public EmployeeType EmployeeType { get; set; }
        
    } // class Employee
    
} // namespace WP.Common.Models