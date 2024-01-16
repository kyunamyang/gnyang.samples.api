using gnyang.samples.domain.Entities;
using gnyang.samples.domain.Events;
using gnyang.samples.domain.Vo;
using gnyang.samples.infrastructure;
using gnyang.samples.infrastructure.Interfaces;
using MediatR;

namespace gnyang.samples.application.Commands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required Contact Creator { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _productRepository = unitOfWork.ProductRepository;
        }

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                //Creator = request.Creator,
            };

            await _productRepository.UpdateAsync(new ProductUpdatedEvent(entity), cancellationToken);

            entity.AddDomainEvent(new ProductUpdatedEvent(entity));

            return entity.Id;
        }
    }
}
