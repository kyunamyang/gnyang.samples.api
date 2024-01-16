using gnyang.samples.domain.Common;
using gnyang.samples.domain.Entities;

namespace gnyang.samples.domain.Events
{
    public class ProductCreatedEvent : BaseEvent
    {
        public Product _product { get; }
        public ProductCreatedEvent(Product product)
        {
            _product = product;
        }

    }
}
