using gnyang.samples.domain.Dtos;
using gnyang.samples.domain.Entities;
using gnyang.samples.domain.Events;
using gnyang.samples.infrastructure.Interfaces;
using System.Data;
using System.Transactions;

namespace gnyang.samples.infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IDbTransaction _transaction;

        public ProductRepository(IDbTransaction transaction)
        {
            this._transaction = transaction;
        }

        public async Task<string> GetNameAsync(string name, CancellationToken cancellationToken)
        {
            return await Task.FromResult(name);
        }

        public async Task<PaginatedList<ProductSummaryDto>> GetPagedAsync(string name, int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var temp = new ProductSummaryDto {
                Id = Guid.NewGuid(),
                Name = name,
                Description = string.Empty,
            };

            var list = new List<ProductSummaryDto>();
            var result = new PaginatedList<ProductSummaryDto>(list, 101, pageNumber, pageSize);

            return await Task.FromResult(result);
        }

    }
}
