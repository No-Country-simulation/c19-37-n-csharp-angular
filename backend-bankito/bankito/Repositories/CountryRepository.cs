using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly List<Country> _s = new List<Country>();

        public IEnumerable<Country> GetAll() => _s;

        public Country GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(Country country) => _s.Add(country);

        public void Update(Country country)
        {
            var index = _s.FindIndex(p => p.Id == country.Id);
            if (index >= 0) _s[index] = country;
        }

        public void Delete(int id)
        {
            var country = _s.FirstOrDefault(p => p.Id == id);
            if (country != null) _s.Remove(country);
        }
    }
}
