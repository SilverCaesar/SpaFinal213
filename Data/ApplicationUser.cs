using Microsoft.AspNetCore.Identity;
using SpaFinal213.Models;

namespace SpaFinal213.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // Optional one-to-one navigation properties so EF can navigate from Identity user
        public Customer? CustomerProfile { get; set; }
        public Employee? EmployeeProfile { get; set; }
    }
}
