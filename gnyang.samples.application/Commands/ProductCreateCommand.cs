using gnyang.samples.domain.Entities;
using gnyang.samples.domain.Events;
using gnyang.samples.domain.Vo;
using gnyang.samples.infrastructure;
using gnyang.samples.infrastructure.Interfaces;
using MediatR;

namespace gnyang.samples.application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required Contact Creator { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _productRepository = unitOfWork.ProductRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Id = new Guid(),
                Name = request.Name, 
                Description = request.Description,
                //Creator = request.Creator,
            };

            await _productRepository.CreateAsync(new ProductCreatedEvent(entity), cancellationToken);

            entity.AddDomainEvent(new ProductCreatedEvent(entity));

            return entity.Id;
        }
    }
}
