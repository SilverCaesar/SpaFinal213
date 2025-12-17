using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SpaFinal213.Models;

namespace SpaFinal213.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Create a scope so we can resolve scoped services (UserManager, DbContext)
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            // Ensure DB created / migrations applied (no-op if already applied)
            context.Database.Migrate();

            // Create identity users to satisfy non-nullable foreign keys for Customer/Employee
            // Use GetAwaiter().GetResult() because this seeding method is synchronous
            ApplicationUser? aliceUser = userManager.FindByNameAsync("alice").GetAwaiter().GetResult();
            if (aliceUser is null)
            {
                aliceUser = new ApplicationUser { UserName = "alice", Email = "alice@local" };
                var r = userManager.CreateAsync(aliceUser, "P@ssw0rd!").GetAwaiter().GetResult();
                if (!r.Succeeded) throw new InvalidOperationException($"Failed to create seed user alice: {string.Join(", ", r.Errors.Select(e => e.Description))}");
            }

            ApplicationUser? bobUser = userManager.FindByNameAsync("bob").GetAwaiter().GetResult();
            if (bobUser is null)
            {
                bobUser = new ApplicationUser { UserName = "bob", Email = "bob@local" };
                var r = userManager.CreateAsync(bobUser, "P@ssw0rd!").GetAwaiter().GetResult();
                if (!r.Succeeded) throw new InvalidOperationException($"Failed to create seed user bob: {string.Join(", ", r.Errors.Select(e => e.Description))}");
            }

            // Seed customers (linked to identity users)
            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new Customer
                    {
                        ApplicationUserId = aliceUser.Id,
                        Fname = "John",
                        Lname = "Doe",
                        Notes = "",
                        DateAccount = DateTime.UtcNow
                    },
                    new Customer
                    {
                        ApplicationUserId = bobUser.Id,
                        Fname = "Jane",
                        Lname = "Smith",
                        Notes = "",
                        DateAccount = DateTime.UtcNow
                    }
                );
            }

            // Seed employees (linked to identity users)
            if (!context.Employee.Any())
            {
                context.Employee.AddRange(
                    new Employee
                    {
                        ApplicationUserId = aliceUser.Id,
                        FName = "Alice",
                        LName = "Johnson",
                        EmployeeType = "Therapist",
                    },
                    new Employee
                    {
                        ApplicationUserId = bobUser.Id,
                        FName = "Bob",
                        LName = "Brown",
                        EmployeeType = "Masseuse"
                    }
                );
            }

            // Seed services
            if (!context.Service.Any())
            {
                context.Service.AddRange(
                    new Service
                    {
                        Name = "Swedish Massage",
                        Description = "A relaxing full-body massage.",
                        Duration = 60,
                        Price = 80.00M
                    },
                    new Service
                    {
                        Name = "Deep Tissue Massage",
                        Description = "A therapeutic massage targeting deeper layers of muscle.",
                        Duration = 60,
                        Price = 90.00M
                    }
                );
            }

            context.SaveChanges();
        }
    }
}