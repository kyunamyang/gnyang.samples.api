using gnyang.samples.domain.Entities;
using gnyang.samples.domain.Vo;
using MediatR;

namespace gnyang.samples.application.Commands
{

    public class RemoveProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
