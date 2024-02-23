using Microsoft.EntityFrameworkCore;
using Todo.Storage;

namespace Todo.SqlServer;

public class UserSqlServer : IUserRepository
{
    private TodoContext _context = new TodoContext();

    public async Task Add(UserAo user)
    {
        this._context.Users
            .Add(UserAoToEntity.Map(user));

        await this._context.SaveChangesAsync();
    }
    public async Task<UserAo?> Get(string Id)
    {
        var User = await this._context.Users
            .Where(cols => cols.Id == Id)
            .FirstOrDefaultAsync();

        if (User == null)
        {
            return null;
        }

        return UserEntityToAo.Map(User);
    }
}
