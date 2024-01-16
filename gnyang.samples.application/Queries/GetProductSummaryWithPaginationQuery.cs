//using gnyang.samples.application.Commands;
using gnyang.samples.domain.Dtos;
using gnyang.samples.domain.Entities;
using gnyang.samples.domain.Events;
using gnyang.samples.infrastructure;
using gnyang.samples.infrastructure.Interfaces;
using MediatR;

namespace gnyang.samples.application.Queries
{
    public record GetProductSummaryWithPaginationQuery : IRequest<string>
    {
        public string Name { get; set; }

        public GetProductSummaryWithPaginationQuery(string name)
        {
            Name = name;
        }
    }

    public class GetProductSummaryWithPaginationQueryHandler : IRequestHandler<GetProductSummaryWithPaginationQuery, string>
    {
        //private readonly IProductRepository _productRepository;

        public GetProductSummaryWithPaginationQueryHandler(IUnitOfWork unitOfWork)
        {
            //_productRepository = unitOfWork.ProductRepository;
        }

        public async Task<string> Handle(GetProductSummaryWithPaginationQuery query, CancellationToken cancellationToken)
        {
            //return await _productRepository.GetNameAsync(query.Name, cancellationToken);
            var result = query.Name;

            return await Task.FromResult(result);
        }
    }

    ////public record GetProductSummaryWithPaginationQuery : IRequest<PaginatedList<ProductSummaryDto>>
    ////{
    ////    public required string Name { get; init; }
    ////    public int PageNumber { get; init; } = 1;
    ////    public int PageSize { get; init; } = 10;
    ////}

    ////public class GetProductSummaryWithPaginationQueryHandler : IRequestHandler<GetProductSummaryWithPaginationQuery, PaginatedList<ProductSummaryDto>>
    ////{
    ////    private readonly IProductRepository _productRepository;

    ////    public GetProductSummaryWithPaginationQueryHandler(IUnitOfWork unitOfWork)
    ////    {
    ////        _productRepository = unitOfWork.ProductRepository;
    ////    }

    ////    public async Task<PaginatedList<ProductSummaryDto>> Handle(GetProductSummaryWithPaginationQuery request, CancellationToken cancellationToken)
    ////    {
    ////        return await _productRepository.GetPagedAsync(request.Name, request.PageSize, request.PageNumber, cancellationToken);
    ////    }
    ////}
}
