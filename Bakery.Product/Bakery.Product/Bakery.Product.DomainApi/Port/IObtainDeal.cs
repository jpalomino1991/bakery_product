using Bakery.Product.DomainApi.Model;
using System.Collections.Generic;

namespace Bakery.Product.DomainApi.Port
{
    public interface IObtainDeal<T>
    {
        List<Deal> GetDeals();
        Deal GetDeal(T id);
    }
}
