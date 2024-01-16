using gnyang.samples.domain.Dtos;
using gnyang.samples.domain.Entities;
using gnyang.samples.domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gnyang.samples.infrastructure.Interfaces
{
    public interface IProductRepository
    {
        public Task<string> GetNameAsync(string name, CancellationToken cancellationToken);
        public Task<PaginatedList<ProductSummaryDto>> GetPagedAsync(string name, int pageSize, int pageNumber, CancellationToken cancellationToken);
        //public Task CreateAsync(ProductCreatedEvent productCreatedEvent, CancellationToken cancellationToken);
        //public Task UpdateAsync(ProductUpdatedEvent productUpdatedEvent, CancellationToken cancellationToken);
    }
}
