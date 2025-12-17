using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace SpaFinal213
{
    public class UserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public Session UserSession { get; private set; } = new Session();

        public UserService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task InitializeUserAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            // Reset when no authenticated user
            if (user?.Identity?.IsAuthenticated != true)
            {
                UserSession = new Session();
                return;
            }

            // Populate basic session values from claims
            UserSession.IsAuthenticated = true;
            UserSession.UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            UserSession.UserName = user.Identity?.Name ?? user.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;

            var roles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role || string.Equals(c.Type, "role", System.StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Value)
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Distinct()
                .ToList();

            UserSession.Roles = roles;

            // If Session defines boolean flags like IsCustomer / IsEmployee, set them if present
            var sessionType = UserSession.GetType();

            var isCustomerProp = sessionType.GetProperty("IsCustomer", BindingFlags.Public | BindingFlags.Instance);
            if (isCustomerProp is not null && isCustomerProp.CanWrite && isCustomerProp.PropertyType == typeof(bool))
            {
                isCustomerProp.SetValue(UserSession, roles.Contains("Customer"));
            }

            var isEmployeeProp = sessionType.GetProperty("IsEmployee", BindingFlags.Public | BindingFlags.Instance);
            if (isEmployeeProp is not null && isEmployeeProp.CanWrite && isEmployeeProp.PropertyType == typeof(bool))
            {
                isEmployeeProp.SetValue(UserSession, roles.Contains("Employee"));
            }

            // Leave extension points: if you need DB-backed profile data, inject the required service/DbContext
            // and set fields here (don't access DbContext statically).
        }
    }
}
