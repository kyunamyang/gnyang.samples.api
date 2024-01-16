using gnyang.samples.domain.Common;
using gnyang.samples.domain.Entities;

namespace gnyang.samples.domain.Events
{
    public class ProductUpdatedEvent : BaseEvent
    {
        public Product _product { get; }
        public ProductUpdatedEvent(Product product)
        {
            _product = product;
        }

    }
}
