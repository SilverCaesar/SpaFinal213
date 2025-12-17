namespace SpaFinal213
{
    public class Session
    {
        public string? UserId { get; set; }
        public string ? UserName { get; set; }
        public List<string>? Roles { get; set; }

        public bool IsAuthenticated { get; set; } = false;
    }
}
