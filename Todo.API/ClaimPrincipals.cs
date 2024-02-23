namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Email(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
