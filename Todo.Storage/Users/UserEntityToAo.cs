public class UserEntityToAo
{
    public static UserAo Map(UserEntity User)
    {
        return new UserAo()
        {
            Id = User.Id,
            Name = User.Name,
            Email = User.Email
        };
    }
}
