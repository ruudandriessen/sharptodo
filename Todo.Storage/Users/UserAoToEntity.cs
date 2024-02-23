public class UserAoToEntity
{
    public static UserEntity Map(UserAo User)
    {
        return new UserEntity()
        {
            Id = User.Id,
            Name = User.Name,
            Email = User.Email
        };
    }
}
