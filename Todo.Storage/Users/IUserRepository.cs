namespace Todo.Storage;

public interface IUserRepository
{
    Task Add(UserAo user);

    Task<UserAo?> Get(string id);
}
