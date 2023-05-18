 using Entities;
using System.Collections.Generic;

namespace Logic
{
    internal interface ICRUD<T, IDType>
    {
        List<T> GetAll();
        Products GetOne(IDType id);
        bool Finded(IDType id);
        void Add(T crud);
        void Update(T crud);
        void Delete(IDType id);
    }
}
