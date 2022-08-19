using System.Collections.Generic;

namespace Bakery.Product.DomainApi.Port
{
    public interface IRequestProduct<T>
    {
        List<T> GetValues();
        T GetValue(int id);
        T AddValue(T value);
    }
}
