using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpaFinal213.Data;

namespace SpaFinal213.Models
{
    // Employee is a separate table that references ApplicationUser (Identity)
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        // FK to Identity user (AspNetUsers.Id is string
        public string? ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string? EmployeeType { get; set; }
        public Service? Specialization { get; set; }
    }
}
