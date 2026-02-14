using WarehouseManagement.Core.Interfaces.Repositories;
using WarehouseManagement.Infrastructure.Data;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Infrastructure.Repositories;

public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext context) : base(context) { }
}
