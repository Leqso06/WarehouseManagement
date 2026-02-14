using WarehouseManagement.Core.Interfaces.Repositories;
using WarehouseManagement.Infrastructure.Data;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Infrastructure.Repositories;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context) { }
}
