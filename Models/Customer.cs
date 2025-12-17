using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpaFinal213.Data;

namespace SpaFinal213.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        // FK to Identity user (AspNetUsers.Id is string)
        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public string? Notes { get; set; }

        public DateTime DateAccount { get; set; }
    }
}

