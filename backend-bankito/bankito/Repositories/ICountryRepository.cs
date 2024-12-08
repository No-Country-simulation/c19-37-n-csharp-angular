using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country GetById(int id);
        void Add(Country country);
        void Update(Country country);
        void Delete(int id);
    }
}
