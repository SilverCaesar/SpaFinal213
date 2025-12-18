using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpaFinal213.Models;

namespace SpaFinal213.Models
{
    public class Appointment
    {
        [Key]
        public int Appointment_Id { get; set; }

    
        public int? Customer_Id { get; set; }

        public Customer ?Customer { get; set; }

        public int? Employee_Id { get; set; }
        public Employee ?Employee { get; set; }


        public int? Service_Id { get; set; }
        public Service ?Service { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Duration { get; set; }
    }
}
