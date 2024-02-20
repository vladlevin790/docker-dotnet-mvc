using app.DataAccess.Contracts;
using app.DataAccess.DBContexts;
using app.DataAccess.Implementations.Entities;

namespace app.DataAccess.Repositories
{
    public class ToDoElementRepository(ApplicationContext context, IConfiguration configuration) : GenericRepository<ToDoElement>(context, configuration), IToDoElementRepository
    {
    }
}